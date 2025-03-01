import {
  AuthService,
  BehaviorSubject,
  HttpClient,
  HttpHeaders,
  Subject,
  WindowService,
  catchError,
  map,
  of,
  switchMap,
  takeUntil,
  ɵɵdefineInjectable,
  ɵɵinject
} from "./chunk-SUR7UARE.js";

// src/app/shared/services/open-settings.service.ts
var _OpenSettingsService = class _OpenSettingsService {
  constructor(httpClient, authService, windowService) {
    this.httpClient = httpClient;
    this.authService = authService;
    this.headers = new HttpHeaders();
    this.destroy$ = new Subject();
    this.linksLoadingSubject$ = new BehaviorSubject(false);
    this.isLinksLoading = false;
    this.linksData = null;
    this.route = windowService.controllerOptions.route;
    this.authService.isAuthenticated$.pipe(takeUntil(this.destroy$)).subscribe((isAuthenticated) => {
      this.headers = isAuthenticated ? new HttpHeaders({ "Authorization": `${this.authService.token}` }) : new HttpHeaders();
    });
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
  getSponsors() {
    const url = this.route + "/v1/open-settings/configs-data/sponsors";
    return this.httpClient.get(url, { headers: this.headers }).pipe(map((response) => {
      return { data: response, fromFallback: false };
    }), catchError(() => this.getSponsorsFromFallback()));
  }
  getSponsorsFromFallback() {
    return this.httpClient.get(`assets/sponsors.json?v=${(/* @__PURE__ */ new Date()).getTime()}`).pipe(map((fallbackResponse) => {
      return { data: fallbackResponse, fromFallback: true };
    }));
  }
  getLinks() {
    if (this.linksData) {
      return of(this.linksData);
    }
    if (this.isLinksLoading) {
      return this.linksLoadingSubject$.pipe(switchMap(() => of(this.linksData ?? {})));
    }
    this.isLinksLoading = true;
    this.linksLoadingSubject$.next(true);
    const url = this.route + "/v1/open-settings/configs-data/links";
    return this.httpClient.get(url, { headers: this.headers }).pipe(map((response) => {
      this.linksData = response;
      this.isLinksLoading = false;
      this.linksLoadingSubject$.next(false);
      return response;
    }), catchError(() => of({})));
  }
  getNotifications() {
    const url = this.route + "/v1/open-settings/configs-data/notifications";
    return this.httpClient.get(url, { headers: this.headers }).pipe(map((response) => {
      return response;
    }), catchError(() => of([])));
  }
};
_OpenSettingsService.\u0275fac = function OpenSettingsService_Factory(t) {
  return new (t || _OpenSettingsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_OpenSettingsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _OpenSettingsService, factory: _OpenSettingsService.\u0275fac, providedIn: "root" });
var OpenSettingsService = _OpenSettingsService;

export {
  OpenSettingsService
};
//# sourceMappingURL=chunk-I6EEGYC4.js.map
