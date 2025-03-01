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

// src/app/features/group/services/app-groups.service.ts
var _GroupsService = class _GroupsService {
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
  getPaginatedGroups(request) {
    let url = this.route + "/v1/app-groups/paginated";
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
    if (request.sortBy) {
      params = params.append("sortBy", request.sortBy);
      if (request.sortDirection) {
        params = params.append("sortDirection", request.sortDirection);
      }
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  deleteUnmappedGroups() {
    const url = this.route + "/v1/app-groups/unmapped";
    return this.httpClient.delete(url, { headers: this.headers });
  }
  getGroups(request) {
    let url = this.route + "/v1/app-groups";
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
  createGroup(request) {
    const url = this.route + "/v1/app-groups";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  getGroupById(request) {
    const url = this.route + "/v1/app-groups/" + request.groupIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getGroupBySlug(request) {
    const url = this.route + "/v1/app-groups/slug/" + request.groupIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  deleteGroup(request) {
    const url = this.route + "/v1/app-groups/" + request.id + "?rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.delete(url, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  updateGroupSortOrder(request) {
    const url = this.route + "/v1/app-groups/" + request.id + "/sort-order?ascent=" + request.ascent + "&rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  dragGroup(request) {
    const url = this.route + "/v1/app-groups/" + request.sourceId + "/drag/" + request.targetId + "?ascent=" + request.ascent + "&sourceRowVersion=" + encodeURIComponent(request.sourceRowVersion);
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  updateGroup(request) {
    const url = this.route + "/v1/app-groups/" + request.groupId;
    return this.httpClient.put(url, request.body, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  reorder() {
    const url = this.route + "/v1/app-groups/reorder";
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
};
_GroupsService.\u0275fac = function GroupsService_Factory(t) {
  return new (t || _GroupsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_GroupsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _GroupsService, factory: _GroupsService.\u0275fac, providedIn: "root" });
var GroupsService = _GroupsService;

export {
  GroupsService
};
//# sourceMappingURL=chunk-ZOLOB6KZ.js.map
