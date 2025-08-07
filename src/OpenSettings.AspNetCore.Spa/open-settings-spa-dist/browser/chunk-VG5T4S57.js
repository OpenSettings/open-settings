import {
  AuthService,
  Router,
  inject,
  of,
  switchMap
} from "./chunk-LZGOMIDX.js";

// src/app/core/guards/auth.guard.ts
var authGuard = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  if (authService.isAuthenticated || !authService.isAuthorizationRequired) {
    return true;
  }
  return authService.checkAuthorization().pipe(switchMap((isAuthenticated) => {
    if (!isAuthenticated) {
      router.navigate(["/login"], { queryParams: { returnUrl: state.url } });
    }
    return of(isAuthenticated);
  }));
};

export {
  authGuard
};
//# sourceMappingURL=chunk-VG5T4S57.js.map
