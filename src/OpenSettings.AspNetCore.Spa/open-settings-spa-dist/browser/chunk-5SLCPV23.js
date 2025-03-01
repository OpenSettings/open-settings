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

// src/app/features/identifier/services/identifiers.service.ts
var _IdentifiersService = class _IdentifiersService {
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
  getPaginatedIdentifiers(request) {
    let url = this.route + "/v1/identifiers/paginated";
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
      if (request.sortDirection) {
        params = params.append("sortDirection", request.sortDirection);
      }
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  deleteUnmappedIdentifiers() {
    const url = this.route + "/v1/identifiers/unmapped";
    return this.httpClient.delete(url, { headers: this.headers });
  }
  getIdentifiers(request) {
    let url = this.route + "/v1/identifiers";
    let params = new HttpParams();
    if (request.searchTerm) {
      params = params.append("searchTerm", request.searchTerm);
    }
    if (request.appId) {
      params = params.append("appId", request.appId);
      if (request.isAppMapped) {
        params = params.append("isAppMapped", request.isAppMapped);
      }
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  createIdentifier(request) {
    const url = this.route + "/v1/identifiers";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  getIdentifierById(request) {
    const url = this.route + "/v1/identifiers/" + request.identifierIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getIdentifierBySlug(request) {
    const url = this.route + "/v1/identifiers/slug/" + request.identifierIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  updateIdentifier(request) {
    const url = this.route + "/v1/identifiers/" + request.identifierId;
    return this.httpClient.put(url, request.body, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  deleteIdentifier(request) {
    const url = this.route + "/v1/identifiers/" + request.identifierId + "?rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.delete(url, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  updateIdentifierSortOrder(request) {
    const url = this.route + "/v1/identifiers/" + request.identifierId + "/sort-order?ascent=" + request.ascent + "&rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  dragIdentifier(request) {
    const url = this.route + "/v1/identifiers/" + request.sourceId + "/drag/" + request.targetId + "?ascent=" + request.ascent + "&sourceRowVersion=" + encodeURIComponent(request.sourceRowVersion);
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
  reorder() {
    const url = this.route + "/v1/identifiers/reorder";
    return this.httpClient.post(url, null, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
};
_IdentifiersService.\u0275fac = function IdentifiersService_Factory(t) {
  return new (t || _IdentifiersService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_IdentifiersService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _IdentifiersService, factory: _IdentifiersService.\u0275fac, providedIn: "root" });
var IdentifiersService = _IdentifiersService;

export {
  IdentifiersService
};
//# sourceMappingURL=chunk-5SLCPV23.js.map
