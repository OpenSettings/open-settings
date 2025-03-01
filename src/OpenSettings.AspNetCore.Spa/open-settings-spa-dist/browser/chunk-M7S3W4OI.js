import {
  SortDirection
} from "./chunk-EB7MRBEE.js";
import {
  AuthService,
  HttpClient,
  HttpHeaders,
  HttpParams,
  Subject,
  WindowService,
  catchError,
  of,
  takeUntil,
  ɵɵdefineInjectable,
  ɵɵinject
} from "./chunk-SUR7UARE.js";

// src/app/features/tag/services/tags.service.ts
var _TagsService = class _TagsService {
  constructor(httpClient, authService, windowService) {
    this.httpClient = httpClient;
    this.authService = authService;
    this.headers = new HttpHeaders();
    this.destroy$ = new Subject();
    this.route = windowService.controllerOptions.route;
    this.authService.isAuthenticated$.pipe(takeUntil(this.destroy$)).subscribe((isAuthenticated) => {
      this.headers = isAuthenticated ? new HttpHeaders({ "Authorization": `${this.authService.token}` }) : new HttpHeaders();
    });
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
  getTags(request) {
    let url = this.route + "/v1/tags";
    let params = new HttpParams();
    if (request.searchTerm) {
      params = params.append("searchTerm", request.searchTerm);
    }
    if (request.hasMappings) {
      params = params.append("hasMappings", request.hasMappings);
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  createTag(request) {
    const url = this.route + "/v1/tags";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  getPaginatedTags(request) {
    let url = this.route + "/v1/tags/paginated";
    let params = new HttpParams();
    if (request.pageIndex) {
      params = params.append("page", request.pageIndex);
    }
    if (request.pageSize) {
      params = params.append("size", request.pageSize);
    }
    if (request.searchTerm) {
      params = params.append("searchTerm", request.searchTerm);
    }
    if (request.searchBy) {
      params = params.append("searchBy", request.searchBy);
    }
    if (request.sortBy) {
      params = params.append("sortBy", request.sortBy);
      if (request.sortDirection === SortDirection.Desc) {
        params = params.append("sortDirection", request.sortDirection);
      }
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  deleteUnmappedTags() {
    const url = this.route + "/v1/tags/unmapped";
    return this.httpClient.delete(url, { headers: this.headers });
  }
  getTagById(request) {
    const url = this.route + "/v1/tags/" + request.tagIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getTagBySlug(request) {
    const url = this.route + "/v1/tags/slug/" + request.tagIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  updateTag(request) {
    const url = this.route + "/v1/tags/" + request.tagId;
    return this.httpClient.put(url, request.body, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  deleteTag(request) {
    const url = this.route + "/v1/tags/" + request.tagId + "?rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.delete(url, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  updateTagSortOrder(request) {
    const url = this.route + "/v1/tags/" + request.id + "/sort-order?ascent=" + request.ascent + "&rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  dragTag(request) {
    const url = this.route + "/v1/tags/" + request.sourceId + "/drag/" + request.targetId + "?ascent=" + request.ascent + "&sourceRowVersion=" + encodeURIComponent(request.sourceRowVersion);
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  reorder() {
    const url = this.route + "/v1/tags/reorder";
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
};
_TagsService.\u0275fac = function TagsService_Factory(t) {
  return new (t || _TagsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_TagsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _TagsService, factory: _TagsService.\u0275fac, providedIn: "root" });
var TagsService = _TagsService;

export {
  TagsService
};
//# sourceMappingURL=chunk-M7S3W4OI.js.map
