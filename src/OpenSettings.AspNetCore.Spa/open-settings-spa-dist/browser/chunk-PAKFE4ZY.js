import {
  authGuard
} from "./chunk-AX4AMJNE.js";
import {
  DefaultLayoutService,
  MatBadge,
  MatBadgeModule,
  MatListItem,
  MatListItemIcon,
  MatListModule,
  MatNavList,
  SharedModule,
  ThemeService,
  TruncatePipe,
  getDateTimeUtcNow
} from "./chunk-A3NZPCV4.js";
import {
  MatDivider,
  MatDividerModule
} from "./chunk-TDUSDNS5.js";
import {
  LicenseUpgradeComponent,
  LicensesService
} from "./chunk-Z7TV74EY.js";
import "./chunk-EB7MRBEE.js";
import "./chunk-4H4XXYOP.js";
import {
  MatSnackBar
} from "./chunk-JQUQ3G7S.js";
import {
  OpenSettingsService
} from "./chunk-I6EEGYC4.js";
import {
  MatMenu,
  MatMenuItem,
  MatMenuModule,
  MatMenuTrigger
} from "./chunk-SDNNC3I4.js";
import {
  ConfirmationDialogComponent,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogModule,
  MatDialogTitle
} from "./chunk-HQT7NEGY.js";
import {
  FormsModule,
  MatCard,
  MatCardContent,
  MatCardHeader,
  MatCardModule,
  MatCardTitle,
  MatFormFieldModule,
  MatIcon,
  MatIconModule,
  MatInputModule,
  MatTooltip,
  MatTooltipModule
} from "./chunk-AXECPBMH.js";
import {
  ANIMATION_MODULE_TYPE,
  AuthService,
  CdkScrollable,
  CdkScrollableModule,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  CommonModule,
  Component,
  ContentChild,
  ContentChildren,
  DOCUMENT,
  DatePipe,
  Directionality,
  Directive,
  ESCAPE,
  ElementRef,
  EventEmitter,
  FocusMonitor,
  FocusTrapFactory,
  HttpClient,
  HttpHeaders,
  HttpParams,
  Inject,
  InjectionToken,
  Input,
  InteractivityChecker,
  LicenseEdition,
  MatButton,
  MatButtonModule,
  MatCommonModule,
  MatIconButton,
  NgClass,
  NgForOf,
  NgIf,
  NgModule,
  NgSwitch,
  NgSwitchCase,
  NgSwitchDefault,
  NgZone,
  Optional,
  Output,
  Platform,
  QueryList,
  Router,
  RouterLink,
  RouterLinkActive,
  RouterModule,
  RouterOutlet,
  ScrollDispatcher,
  Subject,
  Subscription,
  ViewChild,
  ViewEncapsulation$1,
  ViewportRuler,
  WindowService,
  __spreadProps,
  __spreadValues,
  animate,
  coerceBooleanProperty,
  coerceNumberProperty,
  debounceTime,
  distinctUntilChanged,
  filter,
  forwardRef,
  fromEvent,
  hasModifierKey,
  map,
  mapTo,
  merge,
  setClassMetadata,
  startWith,
  state,
  style,
  switchMap,
  take,
  takeUntil,
  timer,
  transition,
  trigger,
  ɵsetClassDebugInfo,
  ɵɵInheritDefinitionFeature,
  ɵɵProvidersFeature,
  ɵɵStandaloneFeature,
  ɵɵadvance,
  ɵɵattribute,
  ɵɵclassMap,
  ɵɵclassProp,
  ɵɵconditional,
  ɵɵcontentQuery,
  ɵɵdefineComponent,
  ɵɵdefineDirective,
  ɵɵdefineInjectable,
  ɵɵdefineInjector,
  ɵɵdefineNgModule,
  ɵɵdirectiveInject,
  ɵɵelement,
  ɵɵelementContainerEnd,
  ɵɵelementContainerStart,
  ɵɵelementEnd,
  ɵɵelementStart,
  ɵɵgetCurrentView,
  ɵɵgetInheritedFactory,
  ɵɵinject,
  ɵɵlistener,
  ɵɵloadQuery,
  ɵɵnextContext,
  ɵɵpipe,
  ɵɵpipeBind2,
  ɵɵprojection,
  ɵɵprojectionDef,
  ɵɵproperty,
  ɵɵpropertyInterpolate,
  ɵɵpureFunction0,
  ɵɵpureFunction1,
  ɵɵpureFunction7,
  ɵɵqueryRefresh,
  ɵɵreference,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵsanitizeHtml,
  ɵɵsanitizeUrl,
  ɵɵstyleProp,
  ɵɵsyntheticHostListener,
  ɵɵsyntheticHostProperty,
  ɵɵtemplate,
  ɵɵtemplateRefExtractor,
  ɵɵtext,
  ɵɵtextInterpolate,
  ɵɵtextInterpolate1,
  ɵɵviewQuery
} from "./chunk-SUR7UARE.js";

// src/app/shared/layouts/default-layout/default-layout-routes.ts
var DEFAULT_ROUTES = {
  base: "apps",
  about: "about",
  groups: "groups",
  identifiers: "identifiers",
  tags: "tags",
  sponsors: "sponsors",
  redirectTo: "apps"
};

// src/app/features/licenses/license-view/license-view.component.ts
function LicenseViewComponent_div_0_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 8)(1, "div", 9);
    \u0275\u0275element(2, "img", 10);
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "div", 11);
    \u0275\u0275elementEnd();
  }
}
function LicenseViewComponent_mat_dialog_content_8_table_1_tr_2_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "tr")(1, "td", 14);
    \u0275\u0275text(2, "Holder:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "td", 15);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate(ctx_r0.license.holder);
  }
}
function LicenseViewComponent_mat_dialog_content_8_table_1_tr_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "tr")(1, "td", 14);
    \u0275\u0275text(2, "Reference Id:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "td", 15);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate(ctx_r0.license.referenceId);
  }
}
function LicenseViewComponent_mat_dialog_content_8_table_1_tr_4_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "tr")(1, "td", 14);
    \u0275\u0275text(2, "Edition:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "td", 15);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate(ctx_r0.license.editionStringRepresentation);
  }
}
function LicenseViewComponent_mat_dialog_content_8_table_1_tr_5_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "tr")(1, "td", 14);
    \u0275\u0275text(2, "Activated On:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "td", 15);
    \u0275\u0275text(4);
    \u0275\u0275pipe(5, "date");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate(\u0275\u0275pipeBind2(5, 1, ctx_r0.license.issuedAt, "dd-MM-yyyy HH:mm"));
  }
}
function LicenseViewComponent_mat_dialog_content_8_table_1_tr_6_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "tr")(1, "td", 14);
    \u0275\u0275text(2, "Expiry Date:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "td", 15);
    \u0275\u0275text(4);
    \u0275\u0275pipe(5, "date");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate(\u0275\u0275pipeBind2(5, 1, ctx_r0.license.expiryDate, "dd-MM-yyyy HH:mm"));
  }
}
function LicenseViewComponent_mat_dialog_content_8_table_1_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "table", 13)(1, "tbody");
    \u0275\u0275template(2, LicenseViewComponent_mat_dialog_content_8_table_1_tr_2_Template, 5, 1, "tr", 4)(3, LicenseViewComponent_mat_dialog_content_8_table_1_tr_3_Template, 5, 1, "tr", 4)(4, LicenseViewComponent_mat_dialog_content_8_table_1_tr_4_Template, 5, 1, "tr", 4)(5, LicenseViewComponent_mat_dialog_content_8_table_1_tr_5_Template, 6, 4, "tr", 4)(6, LicenseViewComponent_mat_dialog_content_8_table_1_tr_6_Template, 6, 4, "tr", 4);
    \u0275\u0275elementStart(7, "tr")(8, "td", 14);
    \u0275\u0275text(9, "Status:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(10, "td", 15);
    \u0275\u0275text(11);
    \u0275\u0275elementEnd()()()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(2);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx_r0.license.holder);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.license.referenceId);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.license.edition);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.license.issuedAt);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.license.expiryDate);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(ctx_r0.license.isExpired ? "Inactive" : "Active");
  }
}
function LicenseViewComponent_mat_dialog_content_8_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-dialog-content");
    \u0275\u0275template(1, LicenseViewComponent_mat_dialog_content_8_table_1_Template, 12, 6, "table", 12);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.license);
  }
}
function LicenseViewComponent_button_12_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 16);
    \u0275\u0275listener("click", function LicenseViewComponent_button_12_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r0 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r0.deleteLicense());
    });
    \u0275\u0275text(1, "Delete");
    \u0275\u0275elementEnd();
  }
}
var _LicenseViewComponent = class _LicenseViewComponent {
  constructor(dialog, licensesService, windowService, snackBar) {
    this.dialog = dialog;
    this.licensesService = licensesService;
    this.windowService = windowService;
    this.snackBar = snackBar;
    this.subscriptions = new Subscription();
    this.isLoading = false;
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  ngOnInit() {
    const licenseSubscription = this.windowService.license$.subscribe({
      next: (license) => {
        this.license = license;
      }
    });
    this.subscriptions.add(licenseSubscription);
  }
  upgradeLicense() {
    this.dialog.open(LicenseUpgradeComponent, {
      width: "500px",
      height: "265px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    });
  }
  deleteLicense() {
    const referenceId = this.license?.referenceId;
    if (!referenceId) {
      return;
    }
    const title = "Confirm delete";
    const message = `Are you sure you want to delete the '${referenceId}' license? This action cannot be undone.`;
    const confirmationDialogComponentModel = {
      title,
      message,
      requireConfirmation: true
    };
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: confirmationDialogComponentModel
    }).afterClosed().pipe(filter((result) => !!result), switchMap(() => {
      this.isLoading = true;
      return this.licensesService.deleteLicense(referenceId);
    }), switchMap(() => this.licensesService.getCurrentLicense())).subscribe({
      next: (response) => {
        const currentLicense = response.data;
        if (!currentLicense) {
          this.isLoading = false;
          return;
        }
        const initialLicense = this.windowService.license;
        const licenseUpdateMessage = this.licensesService.getLicenseUpdateMessage(initialLicense, currentLicense);
        this.windowService.updateLicense(currentLicense);
        this.isLoading = false;
        this.snackBar.open(licenseUpdateMessage.message, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: licenseUpdateMessage.duration
        });
      },
      error: (err) => {
        this.isLoading = false;
      }
    });
    this.subscriptions.add(subscription);
  }
};
_LicenseViewComponent.\u0275fac = function LicenseViewComponent_Factory(t) {
  return new (t || _LicenseViewComponent)(\u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(LicensesService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatSnackBar));
};
_LicenseViewComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _LicenseViewComponent, selectors: [["ng-component"]], decls: 13, vars: 4, consts: [["class", "loading-container", 4, "ngIf"], ["mat-dialog-title", ""], ["matTooltip", "Only active license will be shown here. If multiple licenses added, the highest edition with the longest expiry date takes precedence.", 1, "position-absolute", "t-4", "ml-2"], ["mat-icon-button", "", "mat-dialog-close", "", "matTooltip", "Close", "matTooltipPosition", "above", 1, "position-absolute", "r-0", "t-0"], [4, "ngIf"], ["align", "end"], ["mat-button", "", "color", "primary", 3, "click"], ["mat-button", "", "color", "warn", 3, "click", 4, "ngIf"], [1, "loading-container"], [1, "mat-bg-primary", "position-absolute", "rounded-circle", "app-icon-animation"], [1, "app-icon", "bg-white"], [1, "loading-spinner"], ["class", "custom-mat-table", 4, "ngIf"], [1, "custom-mat-table"], [1, "custom-mat-cell", "key-cell"], [1, "custom-mat-cell"], ["mat-button", "", "color", "warn", 3, "click"]], template: function LicenseViewComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275template(0, LicenseViewComponent_div_0_Template, 4, 0, "div", 0);
    \u0275\u0275elementStart(1, "h2", 1);
    \u0275\u0275text(2, " License Information ");
    \u0275\u0275elementStart(3, "mat-icon", 2);
    \u0275\u0275text(4, "info");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(5, "button", 3)(6, "mat-icon");
    \u0275\u0275text(7, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275template(8, LicenseViewComponent_mat_dialog_content_8_Template, 2, 1, "mat-dialog-content", 4);
    \u0275\u0275elementStart(9, "mat-dialog-actions", 5)(10, "button", 6);
    \u0275\u0275listener("click", function LicenseViewComponent_Template_button_click_10_listener() {
      return ctx.upgradeLicense();
    });
    \u0275\u0275text(11);
    \u0275\u0275elementEnd();
    \u0275\u0275template(12, LicenseViewComponent_button_12_Template, 2, 0, "button", 7);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    \u0275\u0275property("ngIf", ctx.isLoading);
    \u0275\u0275advance(8);
    \u0275\u0275property("ngIf", ctx.license);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate((ctx.license == null ? null : ctx.license.edition) === 500 ? "Re-new" : "Upgrade");
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.license == null ? null : ctx.license.referenceId);
  }
}, dependencies: [NgIf, MatDialogClose, MatDialogTitle, MatDialogActions, MatDialogContent, MatButton, MatIconButton, MatIcon, MatTooltip, DatePipe], encapsulation: 2 });
var LicenseViewComponent = _LicenseViewComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(LicenseViewComponent, { className: "LicenseViewComponent", filePath: "src\\app\\features\\licenses\\license-view\\license-view.component.ts", lineNumber: 14 });
})();

// src/app/shared/services/notifications.service.ts
var _NotificationsService = class _NotificationsService {
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
  createNotification(request) {
    const url = this.route + "/v1/notifications";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  markNotificationsAsOpened(request) {
    const url = this.route + `/v1/notifications/users/${request.userId}/open`;
    return this.httpClient.post(url, null, { headers: this.headers });
  }
  markNotificationAsViewed(request) {
    const url = this.route + `/v1/notifications/${request.notificationId}/users/${request.userId}/view`;
    return this.httpClient.post(url, null, { headers: this.headers });
  }
  markNotificationAsDismissed(request) {
    const url = this.route + `/v1/notifications/${request.notificationId}/users/${request.userId}/dismiss`;
    return this.httpClient.post(url, null, { headers: this.headers });
  }
  getNotifications(request) {
    let url = this.route + "/v1/notifications";
    let params = new HttpParams();
    if (request.isExpired !== void 0) {
      params = params.append("isExpired", request.isExpired);
    }
    if (request.type !== void 0) {
      params = params.append("type", request.type);
    }
    if (request.source !== void 0) {
      params = params.append("source", request.source);
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getUserNotifications(request) {
    let url = this.route + "/v1/notifications/users/" + request.userId;
    let params = new HttpParams();
    if (request.isOpened !== void 0) {
      params = params.append("isOpened", request.isOpened);
    }
    if (request.isViewed !== void 0) {
      params = params.append("isViewed", request.isViewed);
    }
    if (request.isDismissed !== void 0) {
      params = params.append("isDismissed", request.isDismissed);
    }
    if (request.isExpired !== void 0) {
      params = params.append("isExpired", request.isExpired);
    }
    if (request.type !== void 0) {
      params = params.append("type", request.type);
    }
    if (request.source !== void 0) {
      params = params.append("source", request.source);
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  dispatchNotificationsToUsers(request) {
    const url = this.route + `/v1/notifications/${request.notificationId}/users/dispatch`;
    return this.httpClient.post(url, null, { headers: this.headers });
  }
};
_NotificationsService.\u0275fac = function NotificationsService_Factory(t) {
  return new (t || _NotificationsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_NotificationsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _NotificationsService, factory: _NotificationsService.\u0275fac, providedIn: "root" });
var NotificationsService = _NotificationsService;
var NotificationType;
(function(NotificationType2) {
  NotificationType2[NotificationType2["Neutral"] = 1] = "Neutral";
  NotificationType2[NotificationType2["Info"] = 2] = "Info";
  NotificationType2[NotificationType2["Accent"] = 3] = "Accent";
  NotificationType2[NotificationType2["Success"] = 4] = "Success";
  NotificationType2[NotificationType2["Warn"] = 5] = "Warn";
  NotificationType2[NotificationType2["Error"] = 6] = "Error";
  NotificationType2[NotificationType2["NewVersionAvailable"] = 7] = "NewVersionAvailable";
  NotificationType2[NotificationType2["VersionMismatch"] = 8] = "VersionMismatch";
  NotificationType2[NotificationType2["LicenseExpiring"] = 9] = "LicenseExpiring";
})(NotificationType || (NotificationType = {}));
var NotificationSource;
(function(NotificationSource2) {
  NotificationSource2[NotificationSource2["User"] = 1] = "User";
  NotificationSource2[NotificationSource2["System"] = 2] = "System";
  NotificationSource2[NotificationSource2["OpenSettings"] = 3] = "OpenSettings";
})(NotificationSource || (NotificationSource = {}));

// src/app/shared/components/account-menu/account-menu.component.ts
var _c0 = (a0, a1, a2, a3, a4, a5, a6) => ({ "neutral": a0, "info": a1, "accent": a2, "success": a3, "warn": a4, "error": a5, "not-viewed": a6 });
var _c1 = (a0) => ({ "show": a0 });
function AccountMenuComponent_img_1_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "img", 7);
  }
}
function AccountMenuComponent_ng_template_2_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 8);
    \u0275\u0275text(1);
    \u0275\u0275pipe(2, "truncate");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", \u0275\u0275pipeBind2(2, 1, ctx_r0.initials || "U", 2), "");
  }
}
function AccountMenuComponent_ng_container_6_img_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "img", 21);
  }
}
function AccountMenuComponent_ng_container_6_span_15_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span");
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(2);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1("(", ctx_r0.notificationCounts.notOpened, ")");
  }
}
function AccountMenuComponent_ng_container_6_button_18_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 16);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_6_button_18_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r0 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r0.logout());
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "remove_moderator");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "span");
    \u0275\u0275text(4, "Logout");
    \u0275\u0275elementEnd()();
  }
}
function AccountMenuComponent_ng_container_6_button_20_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 16);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_6_button_20_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r0 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r0.changeMenu("theme"));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "contrast");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "span");
    \u0275\u0275text(4);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(5, "mat-icon", 18);
    \u0275\u0275text(6, "chevron_right");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(2);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate1("Theme: ", ctx_r0.themeInfo.name, "");
  }
}
function AccountMenuComponent_ng_container_6_div_21_a_1_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "a", 24)(1, "mat-icon");
    \u0275\u0275text(2, "description");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "span");
    \u0275\u0275text(4, "Docs");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275property("href", ctx_r0.docs.url, \u0275\u0275sanitizeUrl);
  }
}
function AccountMenuComponent_ng_container_6_div_21_a_2_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "a", 24)(1, "mat-icon");
    \u0275\u0275text(2, "help");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "span");
    \u0275\u0275text(4, "Help");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275property("href", ctx_r0.help.url, \u0275\u0275sanitizeUrl);
  }
}
function AccountMenuComponent_ng_container_6_div_21_a_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "a", 24)(1, "mat-icon");
    \u0275\u0275text(2, "feedback");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "span");
    \u0275\u0275text(4, "Feedback");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(3);
    \u0275\u0275property("href", ctx_r0.feedback.url, \u0275\u0275sanitizeUrl);
  }
}
function AccountMenuComponent_ng_container_6_div_21_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 22);
    \u0275\u0275template(1, AccountMenuComponent_ng_container_6_div_21_a_1_Template, 5, 1, "a", 23)(2, AccountMenuComponent_ng_container_6_div_21_a_2_Template, 5, 1, "a", 23)(3, AccountMenuComponent_ng_container_6_div_21_a_3_Template, 5, 1, "a", 23);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext(2);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.docs.isActive && ctx_r0.docs.url);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.help.isActive && ctx_r0.help.url);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.feedback.isActive && ctx_r0.feedback.url);
  }
}
function AccountMenuComponent_ng_container_6_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementContainerStart(0);
    \u0275\u0275elementStart(1, "span", 9);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_6_Template_span_click_1_listener($event) {
      \u0275\u0275restoreView(_r2);
      return \u0275\u0275resetView($event.stopPropagation());
    });
    \u0275\u0275elementStart(2, "div", 10);
    \u0275\u0275template(3, AccountMenuComponent_ng_container_6_img_3_Template, 1, 0, "img", 11);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(4, "div", 12)(5, "span", 13);
    \u0275\u0275text(6);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(7, "span", 14);
    \u0275\u0275text(8);
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(9, "div", 15)(10, "button", 16);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_6_Template_button_click_10_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r0 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r0.changeMenu("notifications"));
    });
    \u0275\u0275elementStart(11, "mat-icon");
    \u0275\u0275text(12, "notifications");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(13, "span");
    \u0275\u0275text(14, "Notifications ");
    \u0275\u0275template(15, AccountMenuComponent_ng_container_6_span_15_Template, 2, 1, "span", 17);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(16, "mat-icon", 18);
    \u0275\u0275text(17, "chevron_right");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(18, AccountMenuComponent_ng_container_6_button_18_Template, 5, 0, "button", 19);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(19, "div");
    \u0275\u0275template(20, AccountMenuComponent_ng_container_6_button_20_Template, 7, 1, "button", 19);
    \u0275\u0275elementEnd();
    \u0275\u0275template(21, AccountMenuComponent_ng_container_6_div_21_Template, 4, 3, "div", 20);
    \u0275\u0275elementContainerEnd();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext();
    const showInitials_r5 = \u0275\u0275reference(3);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", false)("ngIfElse", showInitials_r5);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx_r0.displayName || "Unknown");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx_r0.email || ctx_r0.userId);
    \u0275\u0275advance(7);
    \u0275\u0275property("ngIf", ctx_r0.notificationCounts.notOpened > 0);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", ctx_r0.isAuthenticated);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx_r0.themeInfo);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r0.docs.isActive && ctx_r0.docs.url || ctx_r0.help.isActive && ctx_r0.help.url || ctx_r0.feedback.isActive && ctx_r0.feedback.url);
  }
}
function AccountMenuComponent_ng_container_7_button_7_Template(rf, ctx) {
  if (rf & 1) {
    const _r7 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 29);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_7_button_7_Template_button_click_0_listener($event) {
      const theme_r8 = \u0275\u0275restoreView(_r7).$implicit;
      const ctx_r0 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r0.selectTheme($event, theme_r8.preference));
    });
    \u0275\u0275elementStart(1, "mat-icon", 30);
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "span");
    \u0275\u0275text(4);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const theme_r8 = ctx.$implicit;
    const ctx_r0 = \u0275\u0275nextContext(2);
    \u0275\u0275property("matTooltip", theme_r8.tooltip);
    \u0275\u0275advance();
    \u0275\u0275property("color", ctx_r0.themeInfo.preference === theme_r8.preference ? "primary" : "");
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(ctx_r0.themeInfo.preference === theme_r8.preference ? "check" : theme_r8.icon);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(theme_r8.name);
  }
}
function AccountMenuComponent_ng_container_7_Template(rf, ctx) {
  if (rf & 1) {
    const _r6 = \u0275\u0275getCurrentView();
    \u0275\u0275elementContainerStart(0);
    \u0275\u0275elementStart(1, "div", 25);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_7_Template_div_click_1_listener($event) {
      \u0275\u0275restoreView(_r6);
      return \u0275\u0275resetView($event.stopPropagation());
    });
    \u0275\u0275elementStart(2, "button", 26);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_7_Template_button_click_2_listener() {
      \u0275\u0275restoreView(_r6);
      const ctx_r0 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r0.returnMenu("menu"));
    });
    \u0275\u0275elementStart(3, "mat-icon");
    \u0275\u0275text(4, "arrow_back");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(5, "span", 27);
    \u0275\u0275text(6, "Select your theme prefence");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(7, AccountMenuComponent_ng_container_7_button_7_Template, 5, 4, "button", 28);
    \u0275\u0275elementContainerEnd();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext();
    \u0275\u0275advance(7);
    \u0275\u0275property("ngForOf", ctx_r0.themes);
  }
}
function AccountMenuComponent_ng_container_8_div_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 33)(1, "mat-card", 34)(2, "mat-card-content")(3, "div", 35);
    \u0275\u0275text(4, "No notifications found.");
    \u0275\u0275elementEnd()()()();
  }
}
function AccountMenuComponent_ng_container_8_ng_container_8_div_1_Template(rf, ctx) {
  if (rf & 1) {
    const _r10 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 37);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_8_ng_container_8_div_1_Template_div_click_0_listener($event) {
      \u0275\u0275restoreView(_r10);
      return \u0275\u0275resetView($event.stopPropagation());
    });
    \u0275\u0275elementStart(1, "mat-card", 38);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_8_ng_container_8_div_1_Template_mat_card_click_1_listener($event) {
      \u0275\u0275restoreView(_r10);
      const notification_r11 = \u0275\u0275nextContext().$implicit;
      const ctx_r0 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r0.markNotificationAsViewed(notification_r11, $event));
    });
    \u0275\u0275elementStart(2, "mat-card-header", 39)(3, "mat-card-title", 40);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(5, "button", 41);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_8_ng_container_8_div_1_Template_button_click_5_listener($event) {
      \u0275\u0275restoreView(_r10);
      const notification_r11 = \u0275\u0275nextContext().$implicit;
      const ctx_r0 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r0.markNotificationAsDismissed(notification_r11, $event));
    });
    \u0275\u0275elementStart(6, "mat-icon");
    \u0275\u0275text(7, "close");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(8, "div", 42);
    \u0275\u0275text(9, "new");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(10, "mat-card-content");
    \u0275\u0275element(11, "div", 43);
    \u0275\u0275elementStart(12, "div", 44)(13, "span");
    \u0275\u0275text(14);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(15, "span", 45);
    \u0275\u0275text(16);
    \u0275\u0275elementEnd()()()()();
  }
  if (rf & 2) {
    const notification_r11 = \u0275\u0275nextContext().$implicit;
    const ctx_r0 = \u0275\u0275nextContext(2);
    \u0275\u0275property("ngClass", \u0275\u0275pureFunction7(8, _c0, notification_r11.type === 1, notification_r11.type === 2, notification_r11.type === 3, notification_r11.type === 4 || notification_r11.type === 7, notification_r11.type === 5 || notification_r11.type === 8 || notification_r11.type === 9, notification_r11.type === 6, !notification_r11.isViewed));
    \u0275\u0275advance();
    \u0275\u0275styleProp("cursor", notification_r11.isViewed ? "unset" : "pointer");
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1(" ", notification_r11.title, " ");
    \u0275\u0275advance(4);
    \u0275\u0275property("ngClass", \u0275\u0275pureFunction1(16, _c1, !notification_r11.isOpened));
    \u0275\u0275advance(3);
    \u0275\u0275property("innerHTML", notification_r11.message, \u0275\u0275sanitizeHtml);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx_r0.formatTimestamp(notification_r11.createdOn));
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(notification_r11.creatorName ? "- " + notification_r11.creatorName : "");
  }
}
function AccountMenuComponent_ng_container_8_ng_container_8_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementContainerStart(0, 33);
    \u0275\u0275template(1, AccountMenuComponent_ng_container_8_ng_container_8_div_1_Template, 17, 18, "div", 36);
    \u0275\u0275elementContainerEnd();
  }
  if (rf & 2) {
    const notification_r11 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", !notification_r11.isDismissed);
  }
}
function AccountMenuComponent_ng_container_8_Template(rf, ctx) {
  if (rf & 1) {
    const _r9 = \u0275\u0275getCurrentView();
    \u0275\u0275elementContainerStart(0);
    \u0275\u0275elementStart(1, "div", 25);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_8_Template_div_click_1_listener($event) {
      \u0275\u0275restoreView(_r9);
      return \u0275\u0275resetView($event.stopPropagation());
    });
    \u0275\u0275elementStart(2, "button", 26);
    \u0275\u0275listener("click", function AccountMenuComponent_ng_container_8_Template_button_click_2_listener() {
      \u0275\u0275restoreView(_r9);
      const ctx_r0 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r0.returnMenu("menu"));
    });
    \u0275\u0275elementStart(3, "mat-icon");
    \u0275\u0275text(4, "arrow_back");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(5, "span", 27);
    \u0275\u0275text(6, "Notifications");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(7, AccountMenuComponent_ng_container_8_div_7_Template, 5, 0, "div", 31)(8, AccountMenuComponent_ng_container_8_ng_container_8_Template, 2, 1, "ng-container", 32);
    \u0275\u0275elementContainerEnd();
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext();
    \u0275\u0275advance(7);
    \u0275\u0275property("ngIf", ctx_r0.notifications.length === 0);
    \u0275\u0275advance();
    \u0275\u0275property("ngForOf", ctx_r0.notifications);
  }
}
var _AccountMenuComponent = class _AccountMenuComponent {
  constructor(router, authService, themeService, notificationsService, openSettingsService) {
    this.router = router;
    this.authService = authService;
    this.themeService = themeService;
    this.notificationsService = notificationsService;
    this.openSettingsService = openSettingsService;
    this.themes = [];
    this.notificationCounts = {
      opened: 0,
      notOpened: 0,
      viewed: 0,
      notViewed: 0,
      dismissed: 0,
      notDismissed: 0
    };
    this.notifications = [];
    this.docs = { url: "", isActive: false };
    this.help = { url: "", isActive: false };
    this.feedback = { url: "", isActive: false };
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    this.themes = this.themeService.themes;
    this.themeInfo = this.themeService.getThemeInfo(this.themeService.themePreference ?? "light");
    this.isAuthenticated = this.authService.isAuthenticated;
    const claims = this.authService.claims;
    this.displayName = claims["db_user_displayName"] ?? "";
    this.initials = claims["db_user_initials"] ?? "";
    this.userId = claims["db_user_id"] ?? "";
    this.email = claims["db_user_email"] ?? "";
    if (this.userId) {
      const subscription = this.notificationsService.getUserNotifications({
        userId: this.userId,
        isDismissed: false
      }).subscribe({
        next: (response) => {
          const responseData = response.data;
          if (!responseData) {
            return;
          }
          this.notificationCounts.opened += responseData.notificationCounts.opened;
          this.notificationCounts.notOpened += responseData.notificationCounts.notOpened;
          this.notificationCounts.viewed += responseData.notificationCounts.viewed;
          this.notificationCounts.notViewed += responseData.notificationCounts.notViewed;
          this.notificationCounts.dismissed += responseData.notificationCounts.dismissed;
          this.notificationCounts.notDismissed += responseData.notificationCounts.notDismissed;
          responseData.notifications.forEach((notification) => {
            this.notifications.push(notification);
          });
        }
      });
      this.subscriptions.add(subscription);
    } else {
      this.getNotifications();
    }
    const linkSubscription = this.openSettingsService.getLinks().subscribe((response) => {
      const docs = response["docs"];
      const help = response["help"];
      const feedback = response["feedback"];
      if (docs) {
        this.docs.url = docs.url;
        this.docs.isActive = docs.isActive;
      }
      if (help) {
        this.help.url = help.url;
        this.help.isActive = help.isActive;
      }
      if (feedback) {
        this.feedback.url = feedback.url;
        this.feedback.isActive = feedback.isActive;
      }
    });
    this.subscriptions.add(linkSubscription);
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  ngAfterViewInit() {
    const subscription = this.menuTrigger.menuClosed.subscribe(() => {
      const timerSubscription = timer(130).subscribe(() => {
        this.selectedMenu = this.nextMenu;
        if (this.nextMenu) {
          this.menuTrigger.openMenu();
          this.nextMenu = void 0;
        }
      });
      this.subscriptions.add(timerSubscription);
    });
    this.subscriptions.add(subscription);
  }
  getNotifications() {
    const subscription = this.notificationsService.getNotifications({}).subscribe((response) => {
      const responseData = response.data;
      if (!responseData) {
        return;
      }
      responseData.notifications.forEach((notification) => {
        const key = this.getNotificationKey(notification.id);
        const localNotificationItem = localStorage.getItem(key);
        let localNotification;
        if (localNotificationItem) {
          localNotification = JSON.parse(localNotificationItem);
          if (localNotification.isDismissed) {
            return;
          }
        } else {
          localNotification = {
            id: notification.id,
            title: notification.title,
            message: notification.message,
            type: notification.type,
            source: notification.source,
            metadata: notification.metadata,
            isOpened: false,
            isViewed: false,
            isDismissed: false,
            isExpired: notification.isExpired,
            createdOn: notification.createdOn,
            creatorName: notification.creatorName
          };
        }
        if (localNotification.isOpened) {
          this.notificationCounts.opened++;
        } else {
          this.notificationCounts.notOpened++;
        }
        if (localNotification.isViewed) {
          this.notificationCounts.viewed++;
        } else {
          this.notificationCounts.notViewed++;
        }
        this.notificationCounts.notDismissed++;
        this.notifications.push(localNotification);
        localStorage.setItem(key, JSON.stringify(localNotification));
      });
    });
    this.subscriptions.add(subscription);
  }
  logout() {
    this.authService.logout();
    if (!this.authService.isAuthenticated && this.authService.isAuthorizationRequired) {
      this.router.navigate(["login"]);
    }
  }
  changeMenu(menu) {
    this.nextMenu = menu;
    if (this.nextMenu === "notifications") {
      this.markNotificationsAsOpened();
    }
  }
  changeMenuWithoutClosing($event, menu) {
    $event.stopPropagation();
    this.selectedMenu = menu;
  }
  returnMenuWithoutClosing($event) {
    $event.stopPropagation();
    this.selectedMenu = void 0;
  }
  returnMenu(menu) {
    this.changeMenu(menu);
    this.menuTrigger.closeMenu();
  }
  selectTheme($event, preference) {
    $event.stopPropagation();
    this.themeService.setThemePreference(preference);
    this.themeInfo = this.themeService.getThemeInfo(preference);
  }
  markNotificationsAsOpened() {
    if (!(this.notificationCounts.notOpened > 0)) {
      return;
    }
    const unopenedNotifications = this.notifications.filter((n) => !n.isOpened);
    if (!(unopenedNotifications.length > 0)) {
      return;
    }
    if (this.userId) {
      const subscription = this.notificationsService.markNotificationsAsOpened({
        userId: this.userId
      }).subscribe();
      this.subscriptions.add(subscription);
    }
    this.notificationsOpened(unopenedNotifications);
  }
  notificationsOpened(unOpenedNotifications) {
    unOpenedNotifications.forEach((notification) => {
      this.notificationCounts.opened++;
      this.notificationCounts.notOpened--;
      setTimeout(() => notification.isOpened = true, 1250);
      if (!this.userId) {
        const key = this.getNotificationKey(notification.id);
        const notificationCopy = __spreadProps(__spreadValues({}, notification), { isOpened: true });
        localStorage.setItem(key, JSON.stringify(notificationCopy));
      }
    });
  }
  getNotificationKey(notificationId) {
    return `system:notification:${notificationId}:user:${this.userId}`;
  }
  markNotificationAsViewed(notification, event) {
    event.stopPropagation();
    if (notification.isViewed) {
      return;
    }
    if (this.userId) {
      const subscription = this.notificationsService.markNotificationAsViewed({
        userId: this.userId,
        notificationId: notification.id
      }).subscribe();
      this.subscriptions.add(subscription);
    }
    this.notificationViewed(notification);
  }
  notificationViewed(notification) {
    if (!notification.isOpened) {
      notification.isOpened = true;
      this.notificationCounts.opened++;
      this.notificationCounts.notOpened--;
    }
    notification.isViewed = true;
    this.notificationCounts.viewed++;
    this.notificationCounts.notViewed--;
    if (!this.userId) {
      const key = this.getNotificationKey(notification.id);
      localStorage.setItem(key, JSON.stringify(notification));
    }
  }
  markNotificationAsDismissed(notification, event) {
    event.stopPropagation();
    if (notification.isDismissed) {
      return;
    }
    if (this.userId) {
      const subscription = this.notificationsService.markNotificationAsDismissed({
        userId: this.userId,
        notificationId: notification.id
      }).subscribe();
      this.subscriptions.add(subscription);
    }
    this.notificationDismissed(notification);
  }
  notificationDismissed(notification) {
    if (!notification.isOpened) {
      notification.isOpened = true;
      this.notificationCounts.opened++;
      this.notificationCounts.notOpened--;
    }
    if (!notification.isViewed) {
      notification.isViewed = true;
      this.notificationCounts.viewed++;
      this.notificationCounts.notViewed--;
    }
    notification.isDismissed = true;
    this.notificationCounts.dismissed++;
    this.notificationCounts.notDismissed--;
    if (!this.userId) {
      const key = this.getNotificationKey(notification.id);
      localStorage.setItem(key, JSON.stringify(notification));
    }
    const index = this.notifications.findIndex((n) => n.id === notification.id);
    if (index === -1) {
      return;
    }
    this.notifications.splice(index, 1);
  }
  formatTimestamp(date) {
    const now = getDateTimeUtcNow();
    const localDate = new Date(date);
    const diff = now.getTime() - localDate.getTime();
    const seconds = Math.floor(diff / 1e3);
    const minutes = Math.floor(seconds / 60);
    const hours = Math.floor(minutes / 60);
    const days = Math.floor(hours / 24);
    if (days > 0) {
      return `${days}d ago`;
    } else if (hours > 0) {
      return `${hours}h ago`;
    } else if (minutes > 0) {
      return `${minutes}m ago`;
    } else {
      return `${seconds}s ago`;
    }
  }
};
_AccountMenuComponent.\u0275fac = function AccountMenuComponent_Factory(t) {
  return new (t || _AccountMenuComponent)(\u0275\u0275directiveInject(Router), \u0275\u0275directiveInject(AuthService), \u0275\u0275directiveInject(ThemeService), \u0275\u0275directiveInject(NotificationsService), \u0275\u0275directiveInject(OpenSettingsService));
};
_AccountMenuComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AccountMenuComponent, selectors: [["app-account-menu"]], viewQuery: function AccountMenuComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(MatMenuTrigger, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.menuTrigger = _t.first);
  }
}, decls: 9, vars: 8, consts: [["showInitials", ""], ["menu", "matMenu"], ["mat-icon-button", "", "matBadgePosition", "before", "matBadgeColor", "primary", 3, "matMenuTriggerFor", "matBadge", "matBadgeHidden"], ["class", "rounded-circle account-menu-mini-image", "src", "favicon.ico", 4, "ngIf", "ngIfElse"], [1, "mat-menu", 3, "ngSwitch"], [4, "ngSwitchDefault"], [4, "ngSwitchCase"], ["src", "favicon.ico", 1, "rounded-circle", "account-menu-mini-image"], [1, "account-menu-mini-image", "initials-circle", "d-flex", "rounded-circle", "align-items-center", "justify-content-center", "text-bold", "text-uppercase"], [1, "px-2", "pb-2", "border-bottom", "d-flex", "menu", 3, "click"], [1, "d-grid"], ["class", "rounded-circle border", "src", "favicon.ico", "height", "40", "width", "40", 4, "ngIf", "ngIfElse"], [1, "d-flex", "flex-direction-column", "pl-2", "break-word"], [1, "user-title"], [1, "user-subtitle"], [1, "border-bottom"], ["mat-menu-item", "", 3, "click"], [4, "ngIf"], [1, "mat-icon-right"], ["mat-menu-item", "", 3, "click", 4, "ngIf"], ["class", "border-top", 4, "ngIf"], ["src", "favicon.ico", "height", "40", "width", "40", 1, "rounded-circle", "border"], [1, "border-top"], ["mat-menu-item", "", "target", "_blank", 3, "href", 4, "ngIf"], ["mat-menu-item", "", "target", "_blank", 3, "href"], [1, "px-2", "pb-1", "border-bottom", "d-flex", "align-items-center", 3, "click"], ["mat-icon-button", "", 3, "click"], [1, "ml-1", "me-3"], ["mat-menu-item", "", "matTooltipPosition", "left", 3, "matTooltip", "click", 4, "ngFor", "ngForOf"], ["mat-menu-item", "", "matTooltipPosition", "left", 3, "click", "matTooltip"], [1, "ml-1", 3, "color"], ["class", "notification-item", 4, "ngIf"], ["class", "notification-item", 4, "ngFor", "ngForOf"], [1, "notification-item"], [1, "notification-card", 2, "box-shadow", "none"], [1, "notification-message"], ["class", "notification-item", 3, "ngClass", "click", 4, "ngIf"], [1, "notification-item", 3, "click", "ngClass"], [1, "notification-card", 3, "click"], [1, "notification-header"], [1, "notification-title"], ["mat-icon-button", "", 1, "icon-mini", "notification-dismiss", 3, "click"], [1, "new-indicator", 3, "ngClass"], [1, "notification-message", 3, "innerHTML"], [1, "notification-bottom", "text-neutral"], [1, "font-style-italic"]], template: function AccountMenuComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "button", 2);
    \u0275\u0275template(1, AccountMenuComponent_img_1_Template, 1, 0, "img", 3)(2, AccountMenuComponent_ng_template_2_Template, 3, 4, "ng-template", null, 0, \u0275\u0275templateRefExtractor);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(4, "mat-menu", 4, 1);
    \u0275\u0275template(6, AccountMenuComponent_ng_container_6_Template, 22, 8, "ng-container", 5)(7, AccountMenuComponent_ng_container_7_Template, 8, 1, "ng-container", 6)(8, AccountMenuComponent_ng_container_8_Template, 9, 2, "ng-container", 6);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const showInitials_r5 = \u0275\u0275reference(3);
    const menu_r12 = \u0275\u0275reference(5);
    \u0275\u0275property("matMenuTriggerFor", menu_r12)("matBadge", ctx.notificationCounts.notOpened > 9 ? "9+" : ctx.notificationCounts.notOpened)("matBadgeHidden", ctx.notificationCounts.notOpened == 0);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", false)("ngIfElse", showInitials_r5);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngSwitch", ctx.selectedMenu);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngSwitchCase", "theme");
    \u0275\u0275advance();
    \u0275\u0275property("ngSwitchCase", "notifications");
  }
}, dependencies: [NgClass, NgForOf, NgIf, NgSwitch, NgSwitchCase, NgSwitchDefault, MatIconButton, MatMenu, MatMenuItem, MatMenuTrigger, MatIcon, MatBadge, MatTooltip, MatCard, MatCardContent, MatCardHeader, MatCardTitle, TruncatePipe], styles: ["\n\n[_nghost-%COMP%]     .mat-badge-medium.mat-badge-overlap.mat-badge-before .mat-badge-content {\n  font-size: 10px;\n  left: 40px;\n}\n[_nghost-%COMP%]     .mat-badge-medium.mat-badge-above .mat-badge-content {\n  top: 15px;\n}\n[_nghost-%COMP%]     .mat-badge-medium .mat-badge-content {\n  width: 15px;\n  height: 15px;\n  line-height: 14px;\n}\n[_nghost-%COMP%]     .mat-badge-content {\n  border: 1px solid;\n}\n  .mat-menu {\n  max-width: 500px !important;\n}\n.account-menu-mini-image[_ngcontent-%COMP%] {\n  text-overflow: clip;\n  overflow: hidden;\n  position: relative;\n  padding: 0;\n  border: 1px solid;\n  top: -1px;\n  left: -1px;\n}\n.initials-circle[_ngcontent-%COMP%] {\n  width: 24px;\n  height: 24px;\n  background-color: var(--mat-full-pseudo-checkbox-disabled-selected-icon-color);\n  font-size: 12px;\n}\n.menu[_ngcontent-%COMP%]   .initials-circle[_ngcontent-%COMP%] {\n  width: 40px;\n  height: 40px;\n  border: none;\n}\n.user-subtitle[_ngcontent-%COMP%] {\n  font-size: 12px;\n}\n.user-title[_ngcontent-%COMP%] {\n  text-overflow: ellipsis;\n  overflow: hidden;\n}\n.notification-item[_ngcontent-%COMP%] {\n  padding: 10px;\n}\n.notification-header[_ngcontent-%COMP%] {\n  padding-top: 0px;\n}\n.notification-card[_ngcontent-%COMP%] {\n  width: 460px;\n}\n.notification-title[_ngcontent-%COMP%] {\n  font-size: 14px;\n}\n.notification-message[_ngcontent-%COMP%] {\n  font-size: 13px;\n}\n.notification-card[_ngcontent-%COMP%]   mat-card-header[_ngcontent-%COMP%] {\n  display: flex;\n  justify-content: space-between;\n  align-items: center;\n}\n.notification-item.neutral[_ngcontent-%COMP%]   .notification-card[_ngcontent-%COMP%] {\n  border-left: 5px solid var(--neutral);\n}\n.notification-item.info[_ngcontent-%COMP%]   .notification-card[_ngcontent-%COMP%] {\n  border-left: 5px solid var(--info);\n}\n.notification-item.accent[_ngcontent-%COMP%]   .notification-card[_ngcontent-%COMP%] {\n  border-left: 5px solid var(--accent);\n}\n.notification-item.success[_ngcontent-%COMP%]   .notification-card[_ngcontent-%COMP%] {\n  border-left: 5px solid var(--success);\n}\n.notification-item.warn[_ngcontent-%COMP%]   .notification-card[_ngcontent-%COMP%] {\n  border-left: 5px solid var(--warn);\n}\n.notification-item.error[_ngcontent-%COMP%]   .notification-card[_ngcontent-%COMP%] {\n  border-left: 5px solid var(--error);\n}\n.notification-item.not-viewed[_ngcontent-%COMP%]   .notification-card[_ngcontent-%COMP%] {\n  background-color: rgba(0, 0, 0, 0.05);\n}\n.notification-card[_ngcontent-%COMP%]   button[_ngcontent-%COMP%] {\n  background: transparent;\n  border: none;\n  opacity: 0;\n}\n.notification-card[_ngcontent-%COMP%]:hover   button[_ngcontent-%COMP%] {\n  opacity: 1;\n}\n.notification-bottom[_ngcontent-%COMP%] {\n  font-size: 12px;\n  justify-content: space-between;\n  display: flex;\n}\n.new-indicator[_ngcontent-%COMP%] {\n  color: white;\n  font-weight: bold;\n  transition: opacity 1s ease-in-out;\n  border-radius: 7px;\n  animation: fadeInOut 3s ease-in-out forwards;\n  background-color: var(--accent);\n  font-size: 9px;\n  text-align: center;\n  position: fixed;\n  right: 35px;\n  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);\n  padding: 0 7px;\n  opacity: 0;\n  z-index: -1;\n}\n.new-indicator.show[_ngcontent-%COMP%] {\n  opacity: 1;\n  z-index: 1;\n}\n/*# sourceMappingURL=account-menu.component.css.map */"] });
var AccountMenuComponent = _AccountMenuComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AccountMenuComponent, { className: "AccountMenuComponent", filePath: "src\\app\\shared\\components\\account-menu\\account-menu.component.ts", lineNumber: 17 });
})();

// node_modules/@angular/material/fesm2022/sidenav.mjs
var _c02 = ["*"];
var _c12 = ["content"];
var _c2 = [[["mat-drawer"]], [["mat-drawer-content"]], "*"];
var _c3 = ["mat-drawer", "mat-drawer-content", "*"];
function MatDrawerContainer_Conditional_0_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 1);
    \u0275\u0275listener("click", function MatDrawerContainer_Conditional_0_Template_div_click_0_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1._onBackdropClicked());
    });
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275classProp("mat-drawer-shown", ctx_r1._isShowingBackdrop());
  }
}
function MatDrawerContainer_Conditional_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-drawer-content");
    \u0275\u0275projection(1, 2);
    \u0275\u0275elementEnd();
  }
}
var _c4 = [[["mat-sidenav"]], [["mat-sidenav-content"]], "*"];
var _c5 = ["mat-sidenav", "mat-sidenav-content", "*"];
function MatSidenavContainer_Conditional_0_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 1);
    \u0275\u0275listener("click", function MatSidenavContainer_Conditional_0_Template_div_click_0_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1._onBackdropClicked());
    });
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275classProp("mat-drawer-shown", ctx_r1._isShowingBackdrop());
  }
}
function MatSidenavContainer_Conditional_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-sidenav-content");
    \u0275\u0275projection(1, 2);
    \u0275\u0275elementEnd();
  }
}
var _c6 = '.mat-drawer-container{position:relative;z-index:1;color:var(--mat-sidenav-content-text-color);background-color:var(--mat-sidenav-content-background-color);box-sizing:border-box;-webkit-overflow-scrolling:touch;display:block;overflow:hidden}.mat-drawer-container[fullscreen]{top:0;left:0;right:0;bottom:0;position:absolute}.mat-drawer-container[fullscreen].mat-drawer-container-has-open{overflow:hidden}.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side{z-index:3}.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,.mat-drawer-container.ng-animate-disabled .mat-drawer-content,.ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,.ng-animate-disabled .mat-drawer-container .mat-drawer-content{transition:none}.mat-drawer-backdrop{top:0;left:0;right:0;bottom:0;position:absolute;display:block;z-index:3;visibility:hidden}.mat-drawer-backdrop.mat-drawer-shown{visibility:visible;background-color:var(--mat-sidenav-scrim-color)}.mat-drawer-transition .mat-drawer-backdrop{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:background-color,visibility}.cdk-high-contrast-active .mat-drawer-backdrop{opacity:.5}.mat-drawer-content{position:relative;z-index:1;display:block;height:100%;overflow:auto}.mat-drawer-transition .mat-drawer-content{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:transform,margin-left,margin-right}.mat-drawer{position:relative;z-index:4;color:var(--mat-sidenav-container-text-color);box-shadow:var(--mat-sidenav-container-elevation-shadow);background-color:var(--mat-sidenav-container-background-color);border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);width:var(--mat-sidenav-container-width);display:block;position:absolute;top:0;bottom:0;z-index:3;outline:0;box-sizing:border-box;overflow-y:auto;transform:translate3d(-100%, 0, 0)}.cdk-high-contrast-active .mat-drawer,.cdk-high-contrast-active [dir=rtl] .mat-drawer.mat-drawer-end{border-right:solid 1px currentColor}.cdk-high-contrast-active [dir=rtl] .mat-drawer,.cdk-high-contrast-active .mat-drawer.mat-drawer-end{border-left:solid 1px currentColor;border-right:none}.mat-drawer.mat-drawer-side{z-index:2}.mat-drawer.mat-drawer-end{right:0;transform:translate3d(100%, 0, 0);border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0}[dir=rtl] .mat-drawer{border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0;transform:translate3d(100%, 0, 0)}[dir=rtl] .mat-drawer.mat-drawer-end{border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);border-top-left-radius:0;border-bottom-left-radius:0;left:0;right:auto;transform:translate3d(-100%, 0, 0)}.mat-drawer[style*="visibility: hidden"]{display:none}.mat-drawer-side{box-shadow:none;border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid}.mat-drawer-side.mat-drawer-end{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side.mat-drawer-end{border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid;border-left:none}.mat-drawer-inner-container{width:100%;height:100%;overflow:auto;-webkit-overflow-scrolling:touch}.mat-sidenav-fixed{position:fixed}';
var matDrawerAnimations = {
  /** Animation that slides a drawer in and out. */
  transformDrawer: trigger("transform", [
    // We remove the `transform` here completely, rather than setting it to zero, because:
    // 1. Having a transform can cause elements with ripples or an animated
    //    transform to shift around in Chrome with an RTL layout (see #10023).
    // 2. 3d transforms causes text to appear blurry on IE and Edge.
    state("open, open-instant", style({
      "transform": "none",
      "visibility": "visible"
    })),
    state("void", style({
      // Avoids the shadow showing up when closed in SSR.
      "box-shadow": "none",
      "visibility": "hidden"
    })),
    transition("void => open-instant", animate("0ms")),
    transition("void <=> open, open-instant => void", animate("400ms cubic-bezier(0.25, 0.8, 0.25, 1)"))
  ])
};
function throwMatDuplicatedDrawerError(position) {
  throw Error(`A drawer was already declared for 'position="${position}"'`);
}
var MAT_DRAWER_DEFAULT_AUTOSIZE = new InjectionToken("MAT_DRAWER_DEFAULT_AUTOSIZE", {
  providedIn: "root",
  factory: MAT_DRAWER_DEFAULT_AUTOSIZE_FACTORY
});
var MAT_DRAWER_CONTAINER = new InjectionToken("MAT_DRAWER_CONTAINER");
function MAT_DRAWER_DEFAULT_AUTOSIZE_FACTORY() {
  return false;
}
var _MatDrawerContent = class _MatDrawerContent extends CdkScrollable {
  constructor(_changeDetectorRef, _container, elementRef, scrollDispatcher, ngZone) {
    super(elementRef, scrollDispatcher, ngZone);
    this._changeDetectorRef = _changeDetectorRef;
    this._container = _container;
  }
  ngAfterContentInit() {
    this._container._contentMarginChanges.subscribe(() => {
      this._changeDetectorRef.markForCheck();
    });
  }
};
_MatDrawerContent.\u0275fac = function MatDrawerContent_Factory(t) {
  return new (t || _MatDrawerContent)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(forwardRef(() => MatDrawerContainer)), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ScrollDispatcher), \u0275\u0275directiveInject(NgZone));
};
_MatDrawerContent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatDrawerContent,
  selectors: [["mat-drawer-content"]],
  hostAttrs: [1, "mat-drawer-content"],
  hostVars: 4,
  hostBindings: function MatDrawerContent_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275styleProp("margin-left", ctx._container._contentMargins.left, "px")("margin-right", ctx._container._contentMargins.right, "px");
    }
  },
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: CdkScrollable,
    useExisting: _MatDrawerContent
  }]), \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c02,
  decls: 1,
  vars: 0,
  template: function MatDrawerContent_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275projection(0);
    }
  },
  encapsulation: 2,
  changeDetection: 0
});
var MatDrawerContent = _MatDrawerContent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatDrawerContent, [{
    type: Component,
    args: [{
      selector: "mat-drawer-content",
      template: "<ng-content></ng-content>",
      host: {
        "class": "mat-drawer-content",
        "[style.margin-left.px]": "_container._contentMargins.left",
        "[style.margin-right.px]": "_container._contentMargins.right"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      providers: [{
        provide: CdkScrollable,
        useExisting: MatDrawerContent
      }],
      standalone: true
    }]
  }], () => [{
    type: ChangeDetectorRef
  }, {
    type: MatDrawerContainer,
    decorators: [{
      type: Inject,
      args: [forwardRef(() => MatDrawerContainer)]
    }]
  }, {
    type: ElementRef
  }, {
    type: ScrollDispatcher
  }, {
    type: NgZone
  }], null);
})();
var _MatDrawer = class _MatDrawer {
  /** The side that the drawer is attached to. */
  get position() {
    return this._position;
  }
  set position(value) {
    value = value === "end" ? "end" : "start";
    if (value !== this._position) {
      if (this._isAttached) {
        this._updatePositionInParent(value);
      }
      this._position = value;
      this.onPositionChanged.emit();
    }
  }
  /** Mode of the drawer; one of 'over', 'push' or 'side'. */
  get mode() {
    return this._mode;
  }
  set mode(value) {
    this._mode = value;
    this._updateFocusTrapState();
    this._modeChanged.next();
  }
  /** Whether the drawer can be closed with the escape key or by clicking on the backdrop. */
  get disableClose() {
    return this._disableClose;
  }
  set disableClose(value) {
    this._disableClose = coerceBooleanProperty(value);
  }
  /**
   * Whether the drawer should focus the first focusable element automatically when opened.
   * Defaults to false in when `mode` is set to `side`, otherwise defaults to `true`. If explicitly
   * enabled, focus will be moved into the sidenav in `side` mode as well.
   * @breaking-change 14.0.0 Remove boolean option from autoFocus. Use string or AutoFocusTarget
   * instead.
   */
  get autoFocus() {
    const value = this._autoFocus;
    if (value == null) {
      if (this.mode === "side") {
        return "dialog";
      } else {
        return "first-tabbable";
      }
    }
    return value;
  }
  set autoFocus(value) {
    if (value === "true" || value === "false" || value == null) {
      value = coerceBooleanProperty(value);
    }
    this._autoFocus = value;
  }
  /**
   * Whether the drawer is opened. We overload this because we trigger an event when it
   * starts or end.
   */
  get opened() {
    return this._opened;
  }
  set opened(value) {
    this.toggle(coerceBooleanProperty(value));
  }
  constructor(_elementRef, _focusTrapFactory, _focusMonitor, _platform, _ngZone, _interactivityChecker, _doc, _container) {
    this._elementRef = _elementRef;
    this._focusTrapFactory = _focusTrapFactory;
    this._focusMonitor = _focusMonitor;
    this._platform = _platform;
    this._ngZone = _ngZone;
    this._interactivityChecker = _interactivityChecker;
    this._doc = _doc;
    this._container = _container;
    this._focusTrap = null;
    this._elementFocusedBeforeDrawerWasOpened = null;
    this._enableAnimations = false;
    this._position = "start";
    this._mode = "over";
    this._disableClose = false;
    this._opened = false;
    this._animationStarted = new Subject();
    this._animationEnd = new Subject();
    this._animationState = "void";
    this.openedChange = // Note this has to be async in order to avoid some issues with two-bindings (see #8872).
    new EventEmitter(
      /* isAsync */
      true
    );
    this._openedStream = this.openedChange.pipe(filter((o) => o), map(() => {
    }));
    this.openedStart = this._animationStarted.pipe(filter((e) => e.fromState !== e.toState && e.toState.indexOf("open") === 0), mapTo(void 0));
    this._closedStream = this.openedChange.pipe(filter((o) => !o), map(() => {
    }));
    this.closedStart = this._animationStarted.pipe(filter((e) => e.fromState !== e.toState && e.toState === "void"), mapTo(void 0));
    this._destroyed = new Subject();
    this.onPositionChanged = new EventEmitter();
    this._modeChanged = new Subject();
    this.openedChange.subscribe((opened) => {
      if (opened) {
        if (this._doc) {
          this._elementFocusedBeforeDrawerWasOpened = this._doc.activeElement;
        }
        this._takeFocus();
      } else if (this._isFocusWithinDrawer()) {
        this._restoreFocus(this._openedVia || "program");
      }
    });
    this._ngZone.runOutsideAngular(() => {
      fromEvent(this._elementRef.nativeElement, "keydown").pipe(filter((event) => {
        return event.keyCode === ESCAPE && !this.disableClose && !hasModifierKey(event);
      }), takeUntil(this._destroyed)).subscribe((event) => this._ngZone.run(() => {
        this.close();
        event.stopPropagation();
        event.preventDefault();
      }));
    });
    this._animationEnd.pipe(distinctUntilChanged((x, y) => {
      return x.fromState === y.fromState && x.toState === y.toState;
    })).subscribe((event) => {
      const {
        fromState,
        toState
      } = event;
      if (toState.indexOf("open") === 0 && fromState === "void" || toState === "void" && fromState.indexOf("open") === 0) {
        this.openedChange.emit(this._opened);
      }
    });
  }
  /**
   * Focuses the provided element. If the element is not focusable, it will add a tabIndex
   * attribute to forcefully focus it. The attribute is removed after focus is moved.
   * @param element The element to focus.
   */
  _forceFocus(element, options) {
    if (!this._interactivityChecker.isFocusable(element)) {
      element.tabIndex = -1;
      this._ngZone.runOutsideAngular(() => {
        const callback = () => {
          element.removeEventListener("blur", callback);
          element.removeEventListener("mousedown", callback);
          element.removeAttribute("tabindex");
        };
        element.addEventListener("blur", callback);
        element.addEventListener("mousedown", callback);
      });
    }
    element.focus(options);
  }
  /**
   * Focuses the first element that matches the given selector within the focus trap.
   * @param selector The CSS selector for the element to set focus to.
   */
  _focusByCssSelector(selector, options) {
    let elementToFocus = this._elementRef.nativeElement.querySelector(selector);
    if (elementToFocus) {
      this._forceFocus(elementToFocus, options);
    }
  }
  /**
   * Moves focus into the drawer. Note that this works even if
   * the focus trap is disabled in `side` mode.
   */
  _takeFocus() {
    if (!this._focusTrap) {
      return;
    }
    const element = this._elementRef.nativeElement;
    switch (this.autoFocus) {
      case false:
      case "dialog":
        return;
      case true:
      case "first-tabbable":
        this._focusTrap.focusInitialElementWhenReady().then((hasMovedFocus) => {
          if (!hasMovedFocus && typeof this._elementRef.nativeElement.focus === "function") {
            element.focus();
          }
        });
        break;
      case "first-heading":
        this._focusByCssSelector('h1, h2, h3, h4, h5, h6, [role="heading"]');
        break;
      default:
        this._focusByCssSelector(this.autoFocus);
        break;
    }
  }
  /**
   * Restores focus to the element that was originally focused when the drawer opened.
   * If no element was focused at that time, the focus will be restored to the drawer.
   */
  _restoreFocus(focusOrigin) {
    if (this.autoFocus === "dialog") {
      return;
    }
    if (this._elementFocusedBeforeDrawerWasOpened) {
      this._focusMonitor.focusVia(this._elementFocusedBeforeDrawerWasOpened, focusOrigin);
    } else {
      this._elementRef.nativeElement.blur();
    }
    this._elementFocusedBeforeDrawerWasOpened = null;
  }
  /** Whether focus is currently within the drawer. */
  _isFocusWithinDrawer() {
    const activeEl = this._doc.activeElement;
    return !!activeEl && this._elementRef.nativeElement.contains(activeEl);
  }
  ngAfterViewInit() {
    this._isAttached = true;
    if (this._position === "end") {
      this._updatePositionInParent("end");
    }
    if (this._platform.isBrowser) {
      this._focusTrap = this._focusTrapFactory.create(this._elementRef.nativeElement);
      this._updateFocusTrapState();
    }
  }
  ngAfterContentChecked() {
    if (this._platform.isBrowser) {
      this._enableAnimations = true;
    }
  }
  ngOnDestroy() {
    this._focusTrap?.destroy();
    this._anchor?.remove();
    this._anchor = null;
    this._animationStarted.complete();
    this._animationEnd.complete();
    this._modeChanged.complete();
    this._destroyed.next();
    this._destroyed.complete();
  }
  /**
   * Open the drawer.
   * @param openedVia Whether the drawer was opened by a key press, mouse click or programmatically.
   * Used for focus management after the sidenav is closed.
   */
  open(openedVia) {
    return this.toggle(true, openedVia);
  }
  /** Close the drawer. */
  close() {
    return this.toggle(false);
  }
  /** Closes the drawer with context that the backdrop was clicked. */
  _closeViaBackdropClick() {
    return this._setOpen(
      /* isOpen */
      false,
      /* restoreFocus */
      true,
      "mouse"
    );
  }
  /**
   * Toggle this drawer.
   * @param isOpen Whether the drawer should be open.
   * @param openedVia Whether the drawer was opened by a key press, mouse click or programmatically.
   * Used for focus management after the sidenav is closed.
   */
  toggle(isOpen = !this.opened, openedVia) {
    if (isOpen && openedVia) {
      this._openedVia = openedVia;
    }
    const result = this._setOpen(
      isOpen,
      /* restoreFocus */
      !isOpen && this._isFocusWithinDrawer(),
      this._openedVia || "program"
    );
    if (!isOpen) {
      this._openedVia = null;
    }
    return result;
  }
  /**
   * Toggles the opened state of the drawer.
   * @param isOpen Whether the drawer should open or close.
   * @param restoreFocus Whether focus should be restored on close.
   * @param focusOrigin Origin to use when restoring focus.
   */
  _setOpen(isOpen, restoreFocus, focusOrigin) {
    this._opened = isOpen;
    if (isOpen) {
      this._animationState = this._enableAnimations ? "open" : "open-instant";
    } else {
      this._animationState = "void";
      if (restoreFocus) {
        this._restoreFocus(focusOrigin);
      }
    }
    this._updateFocusTrapState();
    return new Promise((resolve) => {
      this.openedChange.pipe(take(1)).subscribe((open) => resolve(open ? "open" : "close"));
    });
  }
  _getWidth() {
    return this._elementRef.nativeElement ? this._elementRef.nativeElement.offsetWidth || 0 : 0;
  }
  /** Updates the enabled state of the focus trap. */
  _updateFocusTrapState() {
    if (this._focusTrap) {
      this._focusTrap.enabled = !!this._container?.hasBackdrop;
    }
  }
  /**
   * Updates the position of the drawer in the DOM. We need to move the element around ourselves
   * when it's in the `end` position so that it comes after the content and the visual order
   * matches the tab order. We also need to be able to move it back to `start` if the sidenav
   * started off as `end` and was changed to `start`.
   */
  _updatePositionInParent(newPosition) {
    if (!this._platform.isBrowser) {
      return;
    }
    const element = this._elementRef.nativeElement;
    const parent = element.parentNode;
    if (newPosition === "end") {
      if (!this._anchor) {
        this._anchor = this._doc.createComment("mat-drawer-anchor");
        parent.insertBefore(this._anchor, element);
      }
      parent.appendChild(element);
    } else if (this._anchor) {
      this._anchor.parentNode.insertBefore(element, this._anchor);
    }
  }
};
_MatDrawer.\u0275fac = function MatDrawer_Factory(t) {
  return new (t || _MatDrawer)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(FocusTrapFactory), \u0275\u0275directiveInject(FocusMonitor), \u0275\u0275directiveInject(Platform), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(InteractivityChecker), \u0275\u0275directiveInject(DOCUMENT, 8), \u0275\u0275directiveInject(MAT_DRAWER_CONTAINER, 8));
};
_MatDrawer.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatDrawer,
  selectors: [["mat-drawer"]],
  viewQuery: function MatDrawer_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(_c12, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._content = _t.first);
    }
  },
  hostAttrs: ["tabIndex", "-1", 1, "mat-drawer"],
  hostVars: 12,
  hostBindings: function MatDrawer_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275syntheticHostListener("@transform.start", function MatDrawer_animation_transform_start_HostBindingHandler($event) {
        return ctx._animationStarted.next($event);
      })("@transform.done", function MatDrawer_animation_transform_done_HostBindingHandler($event) {
        return ctx._animationEnd.next($event);
      });
    }
    if (rf & 2) {
      \u0275\u0275syntheticHostProperty("@transform", ctx._animationState);
      \u0275\u0275attribute("align", null);
      \u0275\u0275classProp("mat-drawer-end", ctx.position === "end")("mat-drawer-over", ctx.mode === "over")("mat-drawer-push", ctx.mode === "push")("mat-drawer-side", ctx.mode === "side")("mat-drawer-opened", ctx.opened);
    }
  },
  inputs: {
    position: "position",
    mode: "mode",
    disableClose: "disableClose",
    autoFocus: "autoFocus",
    opened: "opened"
  },
  outputs: {
    openedChange: "openedChange",
    _openedStream: "opened",
    openedStart: "openedStart",
    _closedStream: "closed",
    closedStart: "closedStart",
    onPositionChanged: "positionChanged"
  },
  exportAs: ["matDrawer"],
  standalone: true,
  features: [\u0275\u0275StandaloneFeature],
  ngContentSelectors: _c02,
  decls: 3,
  vars: 0,
  consts: [["content", ""], ["cdkScrollable", "", 1, "mat-drawer-inner-container"]],
  template: function MatDrawer_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "div", 1, 0);
      \u0275\u0275projection(2);
      \u0275\u0275elementEnd();
    }
  },
  dependencies: [CdkScrollable],
  encapsulation: 2,
  data: {
    animation: [matDrawerAnimations.transformDrawer]
  },
  changeDetection: 0
});
var MatDrawer = _MatDrawer;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatDrawer, [{
    type: Component,
    args: [{
      selector: "mat-drawer",
      exportAs: "matDrawer",
      animations: [matDrawerAnimations.transformDrawer],
      host: {
        "class": "mat-drawer",
        // must prevent the browser from aligning text based on value
        "[attr.align]": "null",
        "[class.mat-drawer-end]": 'position === "end"',
        "[class.mat-drawer-over]": 'mode === "over"',
        "[class.mat-drawer-push]": 'mode === "push"',
        "[class.mat-drawer-side]": 'mode === "side"',
        "[class.mat-drawer-opened]": "opened",
        "tabIndex": "-1",
        "[@transform]": "_animationState",
        "(@transform.start)": "_animationStarted.next($event)",
        "(@transform.done)": "_animationEnd.next($event)"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      standalone: true,
      imports: [CdkScrollable],
      template: '<div class="mat-drawer-inner-container" cdkScrollable #content>\r\n  <ng-content></ng-content>\r\n</div>\r\n'
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: FocusTrapFactory
  }, {
    type: FocusMonitor
  }, {
    type: Platform
  }, {
    type: NgZone
  }, {
    type: InteractivityChecker
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [DOCUMENT]
    }]
  }, {
    type: MatDrawerContainer,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_DRAWER_CONTAINER]
    }]
  }], {
    position: [{
      type: Input
    }],
    mode: [{
      type: Input
    }],
    disableClose: [{
      type: Input
    }],
    autoFocus: [{
      type: Input
    }],
    opened: [{
      type: Input
    }],
    openedChange: [{
      type: Output
    }],
    _openedStream: [{
      type: Output,
      args: ["opened"]
    }],
    openedStart: [{
      type: Output
    }],
    _closedStream: [{
      type: Output,
      args: ["closed"]
    }],
    closedStart: [{
      type: Output
    }],
    onPositionChanged: [{
      type: Output,
      args: ["positionChanged"]
    }],
    _content: [{
      type: ViewChild,
      args: ["content"]
    }]
  });
})();
var _MatDrawerContainer = class _MatDrawerContainer {
  /** The drawer child with the `start` position. */
  get start() {
    return this._start;
  }
  /** The drawer child with the `end` position. */
  get end() {
    return this._end;
  }
  /**
   * Whether to automatically resize the container whenever
   * the size of any of its drawers changes.
   *
   * **Use at your own risk!** Enabling this option can cause layout thrashing by measuring
   * the drawers on every change detection cycle. Can be configured globally via the
   * `MAT_DRAWER_DEFAULT_AUTOSIZE` token.
   */
  get autosize() {
    return this._autosize;
  }
  set autosize(value) {
    this._autosize = coerceBooleanProperty(value);
  }
  /**
   * Whether the drawer container should have a backdrop while one of the sidenavs is open.
   * If explicitly set to `true`, the backdrop will be enabled for drawers in the `side`
   * mode as well.
   */
  get hasBackdrop() {
    return this._drawerHasBackdrop(this._start) || this._drawerHasBackdrop(this._end);
  }
  set hasBackdrop(value) {
    this._backdropOverride = value == null ? null : coerceBooleanProperty(value);
  }
  /** Reference to the CdkScrollable instance that wraps the scrollable content. */
  get scrollable() {
    return this._userContent || this._content;
  }
  constructor(_dir, _element, _ngZone, _changeDetectorRef, viewportRuler, defaultAutosize = false, _animationMode) {
    this._dir = _dir;
    this._element = _element;
    this._ngZone = _ngZone;
    this._changeDetectorRef = _changeDetectorRef;
    this._animationMode = _animationMode;
    this._drawers = new QueryList();
    this.backdropClick = new EventEmitter();
    this._destroyed = new Subject();
    this._doCheckSubject = new Subject();
    this._contentMargins = {
      left: null,
      right: null
    };
    this._contentMarginChanges = new Subject();
    if (_dir) {
      _dir.change.pipe(takeUntil(this._destroyed)).subscribe(() => {
        this._validateDrawers();
        this.updateContentMargins();
      });
    }
    viewportRuler.change().pipe(takeUntil(this._destroyed)).subscribe(() => this.updateContentMargins());
    this._autosize = defaultAutosize;
  }
  ngAfterContentInit() {
    this._allDrawers.changes.pipe(startWith(this._allDrawers), takeUntil(this._destroyed)).subscribe((drawer) => {
      this._drawers.reset(drawer.filter((item) => !item._container || item._container === this));
      this._drawers.notifyOnChanges();
    });
    this._drawers.changes.pipe(startWith(null)).subscribe(() => {
      this._validateDrawers();
      this._drawers.forEach((drawer) => {
        this._watchDrawerToggle(drawer);
        this._watchDrawerPosition(drawer);
        this._watchDrawerMode(drawer);
      });
      if (!this._drawers.length || this._isDrawerOpen(this._start) || this._isDrawerOpen(this._end)) {
        this.updateContentMargins();
      }
      this._changeDetectorRef.markForCheck();
    });
    this._ngZone.runOutsideAngular(() => {
      this._doCheckSubject.pipe(
        debounceTime(10),
        // Arbitrary debounce time, less than a frame at 60fps
        takeUntil(this._destroyed)
      ).subscribe(() => this.updateContentMargins());
    });
  }
  ngOnDestroy() {
    this._contentMarginChanges.complete();
    this._doCheckSubject.complete();
    this._drawers.destroy();
    this._destroyed.next();
    this._destroyed.complete();
  }
  /** Calls `open` of both start and end drawers */
  open() {
    this._drawers.forEach((drawer) => drawer.open());
  }
  /** Calls `close` of both start and end drawers */
  close() {
    this._drawers.forEach((drawer) => drawer.close());
  }
  /**
   * Recalculates and updates the inline styles for the content. Note that this should be used
   * sparingly, because it causes a reflow.
   */
  updateContentMargins() {
    let left = 0;
    let right = 0;
    if (this._left && this._left.opened) {
      if (this._left.mode == "side") {
        left += this._left._getWidth();
      } else if (this._left.mode == "push") {
        const width = this._left._getWidth();
        left += width;
        right -= width;
      }
    }
    if (this._right && this._right.opened) {
      if (this._right.mode == "side") {
        right += this._right._getWidth();
      } else if (this._right.mode == "push") {
        const width = this._right._getWidth();
        right += width;
        left -= width;
      }
    }
    left = left || null;
    right = right || null;
    if (left !== this._contentMargins.left || right !== this._contentMargins.right) {
      this._contentMargins = {
        left,
        right
      };
      this._ngZone.run(() => this._contentMarginChanges.next(this._contentMargins));
    }
  }
  ngDoCheck() {
    if (this._autosize && this._isPushed()) {
      this._ngZone.runOutsideAngular(() => this._doCheckSubject.next());
    }
  }
  /**
   * Subscribes to drawer events in order to set a class on the main container element when the
   * drawer is open and the backdrop is visible. This ensures any overflow on the container element
   * is properly hidden.
   */
  _watchDrawerToggle(drawer) {
    drawer._animationStarted.pipe(filter((event) => event.fromState !== event.toState), takeUntil(this._drawers.changes)).subscribe((event) => {
      if (event.toState !== "open-instant" && this._animationMode !== "NoopAnimations") {
        this._element.nativeElement.classList.add("mat-drawer-transition");
      }
      this.updateContentMargins();
      this._changeDetectorRef.markForCheck();
    });
    if (drawer.mode !== "side") {
      drawer.openedChange.pipe(takeUntil(this._drawers.changes)).subscribe(() => this._setContainerClass(drawer.opened));
    }
  }
  /**
   * Subscribes to drawer onPositionChanged event in order to
   * re-validate drawers when the position changes.
   */
  _watchDrawerPosition(drawer) {
    if (!drawer) {
      return;
    }
    drawer.onPositionChanged.pipe(takeUntil(this._drawers.changes)).subscribe(() => {
      this._ngZone.onMicrotaskEmpty.pipe(take(1)).subscribe(() => {
        this._validateDrawers();
      });
    });
  }
  /** Subscribes to changes in drawer mode so we can run change detection. */
  _watchDrawerMode(drawer) {
    if (drawer) {
      drawer._modeChanged.pipe(takeUntil(merge(this._drawers.changes, this._destroyed))).subscribe(() => {
        this.updateContentMargins();
        this._changeDetectorRef.markForCheck();
      });
    }
  }
  /** Toggles the 'mat-drawer-opened' class on the main 'mat-drawer-container' element. */
  _setContainerClass(isAdd) {
    const classList = this._element.nativeElement.classList;
    const className = "mat-drawer-container-has-open";
    if (isAdd) {
      classList.add(className);
    } else {
      classList.remove(className);
    }
  }
  /** Validate the state of the drawer children components. */
  _validateDrawers() {
    this._start = this._end = null;
    this._drawers.forEach((drawer) => {
      if (drawer.position == "end") {
        if (this._end != null && (typeof ngDevMode === "undefined" || ngDevMode)) {
          throwMatDuplicatedDrawerError("end");
        }
        this._end = drawer;
      } else {
        if (this._start != null && (typeof ngDevMode === "undefined" || ngDevMode)) {
          throwMatDuplicatedDrawerError("start");
        }
        this._start = drawer;
      }
    });
    this._right = this._left = null;
    if (this._dir && this._dir.value === "rtl") {
      this._left = this._end;
      this._right = this._start;
    } else {
      this._left = this._start;
      this._right = this._end;
    }
  }
  /** Whether the container is being pushed to the side by one of the drawers. */
  _isPushed() {
    return this._isDrawerOpen(this._start) && this._start.mode != "over" || this._isDrawerOpen(this._end) && this._end.mode != "over";
  }
  _onBackdropClicked() {
    this.backdropClick.emit();
    this._closeModalDrawersViaBackdrop();
  }
  _closeModalDrawersViaBackdrop() {
    [this._start, this._end].filter((drawer) => drawer && !drawer.disableClose && this._drawerHasBackdrop(drawer)).forEach((drawer) => drawer._closeViaBackdropClick());
  }
  _isShowingBackdrop() {
    return this._isDrawerOpen(this._start) && this._drawerHasBackdrop(this._start) || this._isDrawerOpen(this._end) && this._drawerHasBackdrop(this._end);
  }
  _isDrawerOpen(drawer) {
    return drawer != null && drawer.opened;
  }
  // Whether argument drawer should have a backdrop when it opens
  _drawerHasBackdrop(drawer) {
    if (this._backdropOverride == null) {
      return !!drawer && drawer.mode !== "side";
    }
    return this._backdropOverride;
  }
};
_MatDrawerContainer.\u0275fac = function MatDrawerContainer_Factory(t) {
  return new (t || _MatDrawerContainer)(\u0275\u0275directiveInject(Directionality, 8), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ViewportRuler), \u0275\u0275directiveInject(MAT_DRAWER_DEFAULT_AUTOSIZE), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8));
};
_MatDrawerContainer.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatDrawerContainer,
  selectors: [["mat-drawer-container"]],
  contentQueries: function MatDrawerContainer_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatDrawerContent, 5);
      \u0275\u0275contentQuery(dirIndex, MatDrawer, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._content = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._allDrawers = _t);
    }
  },
  viewQuery: function MatDrawerContainer_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(MatDrawerContent, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._userContent = _t.first);
    }
  },
  hostAttrs: [1, "mat-drawer-container"],
  hostVars: 2,
  hostBindings: function MatDrawerContainer_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275classProp("mat-drawer-container-explicit-backdrop", ctx._backdropOverride);
    }
  },
  inputs: {
    autosize: "autosize",
    hasBackdrop: "hasBackdrop"
  },
  outputs: {
    backdropClick: "backdropClick"
  },
  exportAs: ["matDrawerContainer"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_DRAWER_CONTAINER,
    useExisting: _MatDrawerContainer
  }]), \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c3,
  decls: 4,
  vars: 2,
  consts: [[1, "mat-drawer-backdrop", 3, "mat-drawer-shown"], [1, "mat-drawer-backdrop", 3, "click"]],
  template: function MatDrawerContainer_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef(_c2);
      \u0275\u0275template(0, MatDrawerContainer_Conditional_0_Template, 1, 2, "div", 0);
      \u0275\u0275projection(1);
      \u0275\u0275projection(2, 1);
      \u0275\u0275template(3, MatDrawerContainer_Conditional_3_Template, 2, 0, "mat-drawer-content");
    }
    if (rf & 2) {
      \u0275\u0275conditional(0, ctx.hasBackdrop ? 0 : -1);
      \u0275\u0275advance(3);
      \u0275\u0275conditional(3, !ctx._content ? 3 : -1);
    }
  },
  dependencies: [MatDrawerContent],
  styles: ['.mat-drawer-container{position:relative;z-index:1;color:var(--mat-sidenav-content-text-color);background-color:var(--mat-sidenav-content-background-color);box-sizing:border-box;-webkit-overflow-scrolling:touch;display:block;overflow:hidden}.mat-drawer-container[fullscreen]{top:0;left:0;right:0;bottom:0;position:absolute}.mat-drawer-container[fullscreen].mat-drawer-container-has-open{overflow:hidden}.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side{z-index:3}.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,.mat-drawer-container.ng-animate-disabled .mat-drawer-content,.ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,.ng-animate-disabled .mat-drawer-container .mat-drawer-content{transition:none}.mat-drawer-backdrop{top:0;left:0;right:0;bottom:0;position:absolute;display:block;z-index:3;visibility:hidden}.mat-drawer-backdrop.mat-drawer-shown{visibility:visible;background-color:var(--mat-sidenav-scrim-color)}.mat-drawer-transition .mat-drawer-backdrop{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:background-color,visibility}.cdk-high-contrast-active .mat-drawer-backdrop{opacity:.5}.mat-drawer-content{position:relative;z-index:1;display:block;height:100%;overflow:auto}.mat-drawer-transition .mat-drawer-content{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:transform,margin-left,margin-right}.mat-drawer{position:relative;z-index:4;color:var(--mat-sidenav-container-text-color);box-shadow:var(--mat-sidenav-container-elevation-shadow);background-color:var(--mat-sidenav-container-background-color);border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);width:var(--mat-sidenav-container-width);display:block;position:absolute;top:0;bottom:0;z-index:3;outline:0;box-sizing:border-box;overflow-y:auto;transform:translate3d(-100%, 0, 0)}.cdk-high-contrast-active .mat-drawer,.cdk-high-contrast-active [dir=rtl] .mat-drawer.mat-drawer-end{border-right:solid 1px currentColor}.cdk-high-contrast-active [dir=rtl] .mat-drawer,.cdk-high-contrast-active .mat-drawer.mat-drawer-end{border-left:solid 1px currentColor;border-right:none}.mat-drawer.mat-drawer-side{z-index:2}.mat-drawer.mat-drawer-end{right:0;transform:translate3d(100%, 0, 0);border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0}[dir=rtl] .mat-drawer{border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0;transform:translate3d(100%, 0, 0)}[dir=rtl] .mat-drawer.mat-drawer-end{border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);border-top-left-radius:0;border-bottom-left-radius:0;left:0;right:auto;transform:translate3d(-100%, 0, 0)}.mat-drawer[style*="visibility: hidden"]{display:none}.mat-drawer-side{box-shadow:none;border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid}.mat-drawer-side.mat-drawer-end{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side.mat-drawer-end{border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid;border-left:none}.mat-drawer-inner-container{width:100%;height:100%;overflow:auto;-webkit-overflow-scrolling:touch}.mat-sidenav-fixed{position:fixed}'],
  encapsulation: 2,
  changeDetection: 0
});
var MatDrawerContainer = _MatDrawerContainer;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatDrawerContainer, [{
    type: Component,
    args: [{
      selector: "mat-drawer-container",
      exportAs: "matDrawerContainer",
      host: {
        "class": "mat-drawer-container",
        "[class.mat-drawer-container-explicit-backdrop]": "_backdropOverride"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      providers: [{
        provide: MAT_DRAWER_CONTAINER,
        useExisting: MatDrawerContainer
      }],
      standalone: true,
      imports: [MatDrawerContent],
      template: '@if (hasBackdrop) {\n  <div class="mat-drawer-backdrop" (click)="_onBackdropClicked()"\n       [class.mat-drawer-shown]="_isShowingBackdrop()"></div>\n}\n\n<ng-content select="mat-drawer"></ng-content>\n\n<ng-content select="mat-drawer-content">\n</ng-content>\n\n@if (!_content) {\n  <mat-drawer-content>\n    <ng-content></ng-content>\n  </mat-drawer-content>\n}\n',
      styles: ['.mat-drawer-container{position:relative;z-index:1;color:var(--mat-sidenav-content-text-color);background-color:var(--mat-sidenav-content-background-color);box-sizing:border-box;-webkit-overflow-scrolling:touch;display:block;overflow:hidden}.mat-drawer-container[fullscreen]{top:0;left:0;right:0;bottom:0;position:absolute}.mat-drawer-container[fullscreen].mat-drawer-container-has-open{overflow:hidden}.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side{z-index:3}.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,.mat-drawer-container.ng-animate-disabled .mat-drawer-content,.ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,.ng-animate-disabled .mat-drawer-container .mat-drawer-content{transition:none}.mat-drawer-backdrop{top:0;left:0;right:0;bottom:0;position:absolute;display:block;z-index:3;visibility:hidden}.mat-drawer-backdrop.mat-drawer-shown{visibility:visible;background-color:var(--mat-sidenav-scrim-color)}.mat-drawer-transition .mat-drawer-backdrop{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:background-color,visibility}.cdk-high-contrast-active .mat-drawer-backdrop{opacity:.5}.mat-drawer-content{position:relative;z-index:1;display:block;height:100%;overflow:auto}.mat-drawer-transition .mat-drawer-content{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:transform,margin-left,margin-right}.mat-drawer{position:relative;z-index:4;color:var(--mat-sidenav-container-text-color);box-shadow:var(--mat-sidenav-container-elevation-shadow);background-color:var(--mat-sidenav-container-background-color);border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);width:var(--mat-sidenav-container-width);display:block;position:absolute;top:0;bottom:0;z-index:3;outline:0;box-sizing:border-box;overflow-y:auto;transform:translate3d(-100%, 0, 0)}.cdk-high-contrast-active .mat-drawer,.cdk-high-contrast-active [dir=rtl] .mat-drawer.mat-drawer-end{border-right:solid 1px currentColor}.cdk-high-contrast-active [dir=rtl] .mat-drawer,.cdk-high-contrast-active .mat-drawer.mat-drawer-end{border-left:solid 1px currentColor;border-right:none}.mat-drawer.mat-drawer-side{z-index:2}.mat-drawer.mat-drawer-end{right:0;transform:translate3d(100%, 0, 0);border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0}[dir=rtl] .mat-drawer{border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0;transform:translate3d(100%, 0, 0)}[dir=rtl] .mat-drawer.mat-drawer-end{border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);border-top-left-radius:0;border-bottom-left-radius:0;left:0;right:auto;transform:translate3d(-100%, 0, 0)}.mat-drawer[style*="visibility: hidden"]{display:none}.mat-drawer-side{box-shadow:none;border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid}.mat-drawer-side.mat-drawer-end{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side.mat-drawer-end{border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid;border-left:none}.mat-drawer-inner-container{width:100%;height:100%;overflow:auto;-webkit-overflow-scrolling:touch}.mat-sidenav-fixed{position:fixed}']
    }]
  }], () => [{
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }, {
    type: ElementRef
  }, {
    type: NgZone
  }, {
    type: ChangeDetectorRef
  }, {
    type: ViewportRuler
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_DRAWER_DEFAULT_AUTOSIZE]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }], {
    _allDrawers: [{
      type: ContentChildren,
      args: [MatDrawer, {
        // We need to use `descendants: true`, because Ivy will no longer match
        // indirect descendants if it's left as false.
        descendants: true
      }]
    }],
    _content: [{
      type: ContentChild,
      args: [MatDrawerContent]
    }],
    _userContent: [{
      type: ViewChild,
      args: [MatDrawerContent]
    }],
    autosize: [{
      type: Input
    }],
    hasBackdrop: [{
      type: Input
    }],
    backdropClick: [{
      type: Output
    }]
  });
})();
var _MatSidenavContent = class _MatSidenavContent extends MatDrawerContent {
  constructor(changeDetectorRef, container, elementRef, scrollDispatcher, ngZone) {
    super(changeDetectorRef, container, elementRef, scrollDispatcher, ngZone);
  }
};
_MatSidenavContent.\u0275fac = function MatSidenavContent_Factory(t) {
  return new (t || _MatSidenavContent)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(forwardRef(() => MatSidenavContainer)), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ScrollDispatcher), \u0275\u0275directiveInject(NgZone));
};
_MatSidenavContent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatSidenavContent,
  selectors: [["mat-sidenav-content"]],
  hostAttrs: [1, "mat-drawer-content", "mat-sidenav-content"],
  hostVars: 4,
  hostBindings: function MatSidenavContent_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275styleProp("margin-left", ctx._container._contentMargins.left, "px")("margin-right", ctx._container._contentMargins.right, "px");
    }
  },
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: CdkScrollable,
    useExisting: _MatSidenavContent
  }]), \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c02,
  decls: 1,
  vars: 0,
  template: function MatSidenavContent_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275projection(0);
    }
  },
  encapsulation: 2,
  changeDetection: 0
});
var MatSidenavContent = _MatSidenavContent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatSidenavContent, [{
    type: Component,
    args: [{
      selector: "mat-sidenav-content",
      template: "<ng-content></ng-content>",
      host: {
        "class": "mat-drawer-content mat-sidenav-content",
        "[style.margin-left.px]": "_container._contentMargins.left",
        "[style.margin-right.px]": "_container._contentMargins.right"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      providers: [{
        provide: CdkScrollable,
        useExisting: MatSidenavContent
      }],
      standalone: true
    }]
  }], () => [{
    type: ChangeDetectorRef
  }, {
    type: MatSidenavContainer,
    decorators: [{
      type: Inject,
      args: [forwardRef(() => MatSidenavContainer)]
    }]
  }, {
    type: ElementRef
  }, {
    type: ScrollDispatcher
  }, {
    type: NgZone
  }], null);
})();
var _MatSidenav = class _MatSidenav extends MatDrawer {
  constructor() {
    super(...arguments);
    this._fixedInViewport = false;
    this._fixedTopGap = 0;
    this._fixedBottomGap = 0;
  }
  /** Whether the sidenav is fixed in the viewport. */
  get fixedInViewport() {
    return this._fixedInViewport;
  }
  set fixedInViewport(value) {
    this._fixedInViewport = coerceBooleanProperty(value);
  }
  /**
   * The gap between the top of the sidenav and the top of the viewport when the sidenav is in fixed
   * mode.
   */
  get fixedTopGap() {
    return this._fixedTopGap;
  }
  set fixedTopGap(value) {
    this._fixedTopGap = coerceNumberProperty(value);
  }
  /**
   * The gap between the bottom of the sidenav and the bottom of the viewport when the sidenav is in
   * fixed mode.
   */
  get fixedBottomGap() {
    return this._fixedBottomGap;
  }
  set fixedBottomGap(value) {
    this._fixedBottomGap = coerceNumberProperty(value);
  }
};
_MatSidenav.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatSidenav_BaseFactory;
  return function MatSidenav_Factory(t) {
    return (\u0275MatSidenav_BaseFactory || (\u0275MatSidenav_BaseFactory = \u0275\u0275getInheritedFactory(_MatSidenav)))(t || _MatSidenav);
  };
})();
_MatSidenav.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatSidenav,
  selectors: [["mat-sidenav"]],
  hostAttrs: ["tabIndex", "-1", 1, "mat-drawer", "mat-sidenav"],
  hostVars: 17,
  hostBindings: function MatSidenav_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275attribute("align", null);
      \u0275\u0275styleProp("top", ctx.fixedInViewport ? ctx.fixedTopGap : null, "px")("bottom", ctx.fixedInViewport ? ctx.fixedBottomGap : null, "px");
      \u0275\u0275classProp("mat-drawer-end", ctx.position === "end")("mat-drawer-over", ctx.mode === "over")("mat-drawer-push", ctx.mode === "push")("mat-drawer-side", ctx.mode === "side")("mat-drawer-opened", ctx.opened)("mat-sidenav-fixed", ctx.fixedInViewport);
    }
  },
  inputs: {
    fixedInViewport: "fixedInViewport",
    fixedTopGap: "fixedTopGap",
    fixedBottomGap: "fixedBottomGap"
  },
  exportAs: ["matSidenav"],
  standalone: true,
  features: [\u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c02,
  decls: 3,
  vars: 0,
  consts: [["content", ""], ["cdkScrollable", "", 1, "mat-drawer-inner-container"]],
  template: function MatSidenav_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "div", 1, 0);
      \u0275\u0275projection(2);
      \u0275\u0275elementEnd();
    }
  },
  dependencies: [CdkScrollable],
  encapsulation: 2,
  data: {
    animation: [matDrawerAnimations.transformDrawer]
  },
  changeDetection: 0
});
var MatSidenav = _MatSidenav;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatSidenav, [{
    type: Component,
    args: [{
      selector: "mat-sidenav",
      exportAs: "matSidenav",
      animations: [matDrawerAnimations.transformDrawer],
      host: {
        "class": "mat-drawer mat-sidenav",
        "tabIndex": "-1",
        // must prevent the browser from aligning text based on value
        "[attr.align]": "null",
        "[class.mat-drawer-end]": 'position === "end"',
        "[class.mat-drawer-over]": 'mode === "over"',
        "[class.mat-drawer-push]": 'mode === "push"',
        "[class.mat-drawer-side]": 'mode === "side"',
        "[class.mat-drawer-opened]": "opened",
        "[class.mat-sidenav-fixed]": "fixedInViewport",
        "[style.top.px]": "fixedInViewport ? fixedTopGap : null",
        "[style.bottom.px]": "fixedInViewport ? fixedBottomGap : null"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      standalone: true,
      imports: [CdkScrollable],
      template: '<div class="mat-drawer-inner-container" cdkScrollable #content>\r\n  <ng-content></ng-content>\r\n</div>\r\n'
    }]
  }], null, {
    fixedInViewport: [{
      type: Input
    }],
    fixedTopGap: [{
      type: Input
    }],
    fixedBottomGap: [{
      type: Input
    }]
  });
})();
var _MatSidenavContainer = class _MatSidenavContainer extends MatDrawerContainer {
  constructor() {
    super(...arguments);
    this._allDrawers = void 0;
    this._content = void 0;
  }
};
_MatSidenavContainer.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatSidenavContainer_BaseFactory;
  return function MatSidenavContainer_Factory(t) {
    return (\u0275MatSidenavContainer_BaseFactory || (\u0275MatSidenavContainer_BaseFactory = \u0275\u0275getInheritedFactory(_MatSidenavContainer)))(t || _MatSidenavContainer);
  };
})();
_MatSidenavContainer.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatSidenavContainer,
  selectors: [["mat-sidenav-container"]],
  contentQueries: function MatSidenavContainer_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatSidenavContent, 5);
      \u0275\u0275contentQuery(dirIndex, MatSidenav, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._content = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._allDrawers = _t);
    }
  },
  hostAttrs: [1, "mat-drawer-container", "mat-sidenav-container"],
  hostVars: 2,
  hostBindings: function MatSidenavContainer_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275classProp("mat-drawer-container-explicit-backdrop", ctx._backdropOverride);
    }
  },
  exportAs: ["matSidenavContainer"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_DRAWER_CONTAINER,
    useExisting: _MatSidenavContainer
  }]), \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c5,
  decls: 4,
  vars: 2,
  consts: [[1, "mat-drawer-backdrop", 3, "mat-drawer-shown"], [1, "mat-drawer-backdrop", 3, "click"]],
  template: function MatSidenavContainer_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef(_c4);
      \u0275\u0275template(0, MatSidenavContainer_Conditional_0_Template, 1, 2, "div", 0);
      \u0275\u0275projection(1);
      \u0275\u0275projection(2, 1);
      \u0275\u0275template(3, MatSidenavContainer_Conditional_3_Template, 2, 0, "mat-sidenav-content");
    }
    if (rf & 2) {
      \u0275\u0275conditional(0, ctx.hasBackdrop ? 0 : -1);
      \u0275\u0275advance(3);
      \u0275\u0275conditional(3, !ctx._content ? 3 : -1);
    }
  },
  dependencies: [MatSidenavContent],
  styles: [_c6],
  encapsulation: 2,
  changeDetection: 0
});
var MatSidenavContainer = _MatSidenavContainer;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatSidenavContainer, [{
    type: Component,
    args: [{
      selector: "mat-sidenav-container",
      exportAs: "matSidenavContainer",
      host: {
        "class": "mat-drawer-container mat-sidenav-container",
        "[class.mat-drawer-container-explicit-backdrop]": "_backdropOverride"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      providers: [{
        provide: MAT_DRAWER_CONTAINER,
        useExisting: MatSidenavContainer
      }],
      standalone: true,
      imports: [MatSidenavContent],
      template: '@if (hasBackdrop) {\n  <div class="mat-drawer-backdrop" (click)="_onBackdropClicked()"\n       [class.mat-drawer-shown]="_isShowingBackdrop()"></div>\n}\n\n<ng-content select="mat-sidenav"></ng-content>\n\n<ng-content select="mat-sidenav-content">\n</ng-content>\n\n@if (!_content) {\n  <mat-sidenav-content>\n    <ng-content></ng-content>\n  </mat-sidenav-content>\n}\n',
      styles: ['.mat-drawer-container{position:relative;z-index:1;color:var(--mat-sidenav-content-text-color);background-color:var(--mat-sidenav-content-background-color);box-sizing:border-box;-webkit-overflow-scrolling:touch;display:block;overflow:hidden}.mat-drawer-container[fullscreen]{top:0;left:0;right:0;bottom:0;position:absolute}.mat-drawer-container[fullscreen].mat-drawer-container-has-open{overflow:hidden}.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side{z-index:3}.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,.mat-drawer-container.ng-animate-disabled .mat-drawer-content,.ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,.ng-animate-disabled .mat-drawer-container .mat-drawer-content{transition:none}.mat-drawer-backdrop{top:0;left:0;right:0;bottom:0;position:absolute;display:block;z-index:3;visibility:hidden}.mat-drawer-backdrop.mat-drawer-shown{visibility:visible;background-color:var(--mat-sidenav-scrim-color)}.mat-drawer-transition .mat-drawer-backdrop{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:background-color,visibility}.cdk-high-contrast-active .mat-drawer-backdrop{opacity:.5}.mat-drawer-content{position:relative;z-index:1;display:block;height:100%;overflow:auto}.mat-drawer-transition .mat-drawer-content{transition-duration:400ms;transition-timing-function:cubic-bezier(0.25, 0.8, 0.25, 1);transition-property:transform,margin-left,margin-right}.mat-drawer{position:relative;z-index:4;color:var(--mat-sidenav-container-text-color);box-shadow:var(--mat-sidenav-container-elevation-shadow);background-color:var(--mat-sidenav-container-background-color);border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);width:var(--mat-sidenav-container-width);display:block;position:absolute;top:0;bottom:0;z-index:3;outline:0;box-sizing:border-box;overflow-y:auto;transform:translate3d(-100%, 0, 0)}.cdk-high-contrast-active .mat-drawer,.cdk-high-contrast-active [dir=rtl] .mat-drawer.mat-drawer-end{border-right:solid 1px currentColor}.cdk-high-contrast-active [dir=rtl] .mat-drawer,.cdk-high-contrast-active .mat-drawer.mat-drawer-end{border-left:solid 1px currentColor;border-right:none}.mat-drawer.mat-drawer-side{z-index:2}.mat-drawer.mat-drawer-end{right:0;transform:translate3d(100%, 0, 0);border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0}[dir=rtl] .mat-drawer{border-top-left-radius:var(--mat-sidenav-container-shape);border-bottom-left-radius:var(--mat-sidenav-container-shape);border-top-right-radius:0;border-bottom-right-radius:0;transform:translate3d(100%, 0, 0)}[dir=rtl] .mat-drawer.mat-drawer-end{border-top-right-radius:var(--mat-sidenav-container-shape);border-bottom-right-radius:var(--mat-sidenav-container-shape);border-top-left-radius:0;border-bottom-left-radius:0;left:0;right:auto;transform:translate3d(-100%, 0, 0)}.mat-drawer[style*="visibility: hidden"]{display:none}.mat-drawer-side{box-shadow:none;border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid}.mat-drawer-side.mat-drawer-end{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side{border-left-color:var(--mat-sidenav-container-divider-color);border-left-width:1px;border-left-style:solid;border-right:none}[dir=rtl] .mat-drawer-side.mat-drawer-end{border-right-color:var(--mat-sidenav-container-divider-color);border-right-width:1px;border-right-style:solid;border-left:none}.mat-drawer-inner-container{width:100%;height:100%;overflow:auto;-webkit-overflow-scrolling:touch}.mat-sidenav-fixed{position:fixed}']
    }]
  }], null, {
    _allDrawers: [{
      type: ContentChildren,
      args: [MatSidenav, {
        // We need to use `descendants: true`, because Ivy will no longer match
        // indirect descendants if it's left as false.
        descendants: true
      }]
    }],
    _content: [{
      type: ContentChild,
      args: [MatSidenavContent]
    }]
  });
})();
var _MatSidenavModule = class _MatSidenavModule {
};
_MatSidenavModule.\u0275fac = function MatSidenavModule_Factory(t) {
  return new (t || _MatSidenavModule)();
};
_MatSidenavModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatSidenavModule
});
_MatSidenavModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatCommonModule, CdkScrollableModule, CdkScrollableModule, MatCommonModule]
});
var MatSidenavModule = _MatSidenavModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatSidenavModule, [{
    type: NgModule,
    args: [{
      imports: [MatCommonModule, CdkScrollableModule, MatDrawer, MatDrawerContainer, MatDrawerContent, MatSidenav, MatSidenavContainer, MatSidenavContent],
      exports: [CdkScrollableModule, MatCommonModule, MatDrawer, MatDrawerContainer, MatDrawerContent, MatSidenav, MatSidenavContainer, MatSidenavContent]
    }]
  }], null, null);
})();

// node_modules/@angular/material/fesm2022/toolbar.mjs
var _c03 = ["*", [["mat-toolbar-row"]]];
var _c13 = ["*", "mat-toolbar-row"];
var _MatToolbarRow = class _MatToolbarRow {
};
_MatToolbarRow.\u0275fac = function MatToolbarRow_Factory(t) {
  return new (t || _MatToolbarRow)();
};
_MatToolbarRow.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatToolbarRow,
  selectors: [["mat-toolbar-row"]],
  hostAttrs: [1, "mat-toolbar-row"],
  exportAs: ["matToolbarRow"],
  standalone: true
});
var MatToolbarRow = _MatToolbarRow;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatToolbarRow, [{
    type: Directive,
    args: [{
      selector: "mat-toolbar-row",
      exportAs: "matToolbarRow",
      host: {
        "class": "mat-toolbar-row"
      },
      standalone: true
    }]
  }], null, null);
})();
var _MatToolbar = class _MatToolbar {
  constructor(_elementRef, _platform, document) {
    this._elementRef = _elementRef;
    this._platform = _platform;
    this._document = document;
  }
  ngAfterViewInit() {
    if (this._platform.isBrowser) {
      this._checkToolbarMixedModes();
      this._toolbarRows.changes.subscribe(() => this._checkToolbarMixedModes());
    }
  }
  /**
   * Throws an exception when developers are attempting to combine the different toolbar row modes.
   */
  _checkToolbarMixedModes() {
    if (this._toolbarRows.length && (typeof ngDevMode === "undefined" || ngDevMode)) {
      const isCombinedUsage = Array.from(this._elementRef.nativeElement.childNodes).filter((node) => !(node.classList && node.classList.contains("mat-toolbar-row"))).filter((node) => node.nodeType !== (this._document ? this._document.COMMENT_NODE : 8)).some((node) => !!(node.textContent && node.textContent.trim()));
      if (isCombinedUsage) {
        throwToolbarMixedModesError();
      }
    }
  }
};
_MatToolbar.\u0275fac = function MatToolbar_Factory(t) {
  return new (t || _MatToolbar)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(Platform), \u0275\u0275directiveInject(DOCUMENT));
};
_MatToolbar.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatToolbar,
  selectors: [["mat-toolbar"]],
  contentQueries: function MatToolbar_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatToolbarRow, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._toolbarRows = _t);
    }
  },
  hostAttrs: [1, "mat-toolbar"],
  hostVars: 6,
  hostBindings: function MatToolbar_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275classMap(ctx.color ? "mat-" + ctx.color : "");
      \u0275\u0275classProp("mat-toolbar-multiple-rows", ctx._toolbarRows.length > 0)("mat-toolbar-single-row", ctx._toolbarRows.length === 0);
    }
  },
  inputs: {
    color: "color"
  },
  exportAs: ["matToolbar"],
  standalone: true,
  features: [\u0275\u0275StandaloneFeature],
  ngContentSelectors: _c13,
  decls: 2,
  vars: 0,
  template: function MatToolbar_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef(_c03);
      \u0275\u0275projection(0);
      \u0275\u0275projection(1, 1);
    }
  },
  styles: [".mat-toolbar{background:var(--mat-toolbar-container-background-color);color:var(--mat-toolbar-container-text-color)}.mat-toolbar,.mat-toolbar h1,.mat-toolbar h2,.mat-toolbar h3,.mat-toolbar h4,.mat-toolbar h5,.mat-toolbar h6{font-family:var(--mat-toolbar-title-text-font);font-size:var(--mat-toolbar-title-text-size);line-height:var(--mat-toolbar-title-text-line-height);font-weight:var(--mat-toolbar-title-text-weight);letter-spacing:var(--mat-toolbar-title-text-tracking);margin:0}.cdk-high-contrast-active .mat-toolbar{outline:solid 1px}.mat-toolbar .mat-form-field-underline,.mat-toolbar .mat-form-field-ripple,.mat-toolbar .mat-focused .mat-form-field-ripple{background-color:currentColor}.mat-toolbar .mat-form-field-label,.mat-toolbar .mat-focused .mat-form-field-label,.mat-toolbar .mat-select-value,.mat-toolbar .mat-select-arrow,.mat-toolbar .mat-form-field.mat-focused .mat-select-arrow{color:inherit}.mat-toolbar .mat-input-element{caret-color:currentColor}.mat-toolbar .mat-mdc-button-base.mat-mdc-button-base.mat-unthemed{--mdc-text-button-label-text-color:var(--mat-toolbar-container-text-color);--mdc-outlined-button-label-text-color:var(--mat-toolbar-container-text-color)}.mat-toolbar-row,.mat-toolbar-single-row{display:flex;box-sizing:border-box;padding:0 16px;width:100%;flex-direction:row;align-items:center;white-space:nowrap;height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-row,.mat-toolbar-single-row{height:var(--mat-toolbar-mobile-height)}}.mat-toolbar-multiple-rows{display:flex;box-sizing:border-box;flex-direction:column;width:100%;min-height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-multiple-rows{min-height:var(--mat-toolbar-mobile-height)}}"],
  encapsulation: 2,
  changeDetection: 0
});
var MatToolbar = _MatToolbar;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatToolbar, [{
    type: Component,
    args: [{
      selector: "mat-toolbar",
      exportAs: "matToolbar",
      host: {
        "class": "mat-toolbar",
        "[class]": 'color ? "mat-" + color : ""',
        "[class.mat-toolbar-multiple-rows]": "_toolbarRows.length > 0",
        "[class.mat-toolbar-single-row]": "_toolbarRows.length === 0"
      },
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      standalone: true,
      template: '<ng-content></ng-content>\n<ng-content select="mat-toolbar-row"></ng-content>\n',
      styles: [".mat-toolbar{background:var(--mat-toolbar-container-background-color);color:var(--mat-toolbar-container-text-color)}.mat-toolbar,.mat-toolbar h1,.mat-toolbar h2,.mat-toolbar h3,.mat-toolbar h4,.mat-toolbar h5,.mat-toolbar h6{font-family:var(--mat-toolbar-title-text-font);font-size:var(--mat-toolbar-title-text-size);line-height:var(--mat-toolbar-title-text-line-height);font-weight:var(--mat-toolbar-title-text-weight);letter-spacing:var(--mat-toolbar-title-text-tracking);margin:0}.cdk-high-contrast-active .mat-toolbar{outline:solid 1px}.mat-toolbar .mat-form-field-underline,.mat-toolbar .mat-form-field-ripple,.mat-toolbar .mat-focused .mat-form-field-ripple{background-color:currentColor}.mat-toolbar .mat-form-field-label,.mat-toolbar .mat-focused .mat-form-field-label,.mat-toolbar .mat-select-value,.mat-toolbar .mat-select-arrow,.mat-toolbar .mat-form-field.mat-focused .mat-select-arrow{color:inherit}.mat-toolbar .mat-input-element{caret-color:currentColor}.mat-toolbar .mat-mdc-button-base.mat-mdc-button-base.mat-unthemed{--mdc-text-button-label-text-color:var(--mat-toolbar-container-text-color);--mdc-outlined-button-label-text-color:var(--mat-toolbar-container-text-color)}.mat-toolbar-row,.mat-toolbar-single-row{display:flex;box-sizing:border-box;padding:0 16px;width:100%;flex-direction:row;align-items:center;white-space:nowrap;height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-row,.mat-toolbar-single-row{height:var(--mat-toolbar-mobile-height)}}.mat-toolbar-multiple-rows{display:flex;box-sizing:border-box;flex-direction:column;width:100%;min-height:var(--mat-toolbar-standard-height)}@media(max-width: 599px){.mat-toolbar-multiple-rows{min-height:var(--mat-toolbar-mobile-height)}}"]
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: Platform
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [DOCUMENT]
    }]
  }], {
    color: [{
      type: Input
    }],
    _toolbarRows: [{
      type: ContentChildren,
      args: [MatToolbarRow, {
        descendants: true
      }]
    }]
  });
})();
function throwToolbarMixedModesError() {
  throw Error("MatToolbar: Attempting to combine different toolbar modes. Either specify multiple `<mat-toolbar-row>` elements explicitly or just place content inside of a `<mat-toolbar>` for a single row.");
}
var _MatToolbarModule = class _MatToolbarModule {
};
_MatToolbarModule.\u0275fac = function MatToolbarModule_Factory(t) {
  return new (t || _MatToolbarModule)();
};
_MatToolbarModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatToolbarModule
});
_MatToolbarModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatCommonModule, MatCommonModule]
});
var MatToolbarModule = _MatToolbarModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatToolbarModule, [{
    type: NgModule,
    args: [{
      imports: [MatCommonModule, MatToolbar, MatToolbarRow],
      exports: [MatToolbar, MatToolbarRow, MatCommonModule]
    }]
  }], null, null);
})();

// src/app/shared/layouts/default-layout/default-layout.component.ts
var _c04 = () => ({ exact: true });
function DefaultLayoutComponent_mat_list_item_14_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-list-item", 25);
    \u0275\u0275text(1, " Groups ");
    \u0275\u0275elementStart(2, "mat-icon", 10);
    \u0275\u0275text(3, "workspaces");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275propertyInterpolate("matTooltipDisabled", ctx_r1.menuOpened);
    \u0275\u0275property("routerLink", ctx_r1.ROUTES.groups);
  }
}
function DefaultLayoutComponent_mat_list_item_15_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-list-item", 26);
    \u0275\u0275text(1, " Identifiers ");
    \u0275\u0275elementStart(2, "mat-icon", 10);
    \u0275\u0275text(3, "local_library");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275propertyInterpolate("matTooltipDisabled", ctx_r1.menuOpened);
    \u0275\u0275property("routerLink", ctx_r1.ROUTES.identifiers);
  }
}
function DefaultLayoutComponent_mat_list_item_16_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-list-item", 27);
    \u0275\u0275text(1, " Tags ");
    \u0275\u0275elementStart(2, "mat-icon", 10);
    \u0275\u0275text(3, "tag");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275propertyInterpolate("matTooltipDisabled", ctx_r1.menuOpened);
    \u0275\u0275property("routerLink", ctx_r1.ROUTES.tags);
  }
}
function DefaultLayoutComponent_mat_list_item_20_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-list-item", 28);
    \u0275\u0275text(1, " Sponsors ");
    \u0275\u0275element(2, "mat-icon", 29);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275propertyInterpolate("matTooltipDisabled", ctx_r1.menuOpened);
    \u0275\u0275property("routerLink", ctx_r1.ROUTES.sponsors);
  }
}
function DefaultLayoutComponent_a_21_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "a", 30)(1, "mat-list-item", 31);
    \u0275\u0275text(2, " Bug report ");
    \u0275\u0275element(3, "mat-icon", 32);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("href", ctx_r1.bugReport.url, \u0275\u0275sanitizeUrl);
    \u0275\u0275advance();
    \u0275\u0275propertyInterpolate("matTooltipDisabled", ctx_r1.menuOpened);
  }
}
function DefaultLayoutComponent_ng_container_35_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementContainerStart(0);
    \u0275\u0275elementStart(1, "button", 33);
    \u0275\u0275listener("click", function DefaultLayoutComponent_ng_container_35_Template_button_click_1_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.viewLicense());
    });
    \u0275\u0275elementStart(2, "mat-icon");
    \u0275\u0275text(3, "info");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementContainerEnd();
  }
}
function DefaultLayoutComponent_ng_template_36_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 34);
    \u0275\u0275listener("click", function DefaultLayoutComponent_ng_template_36_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.upgradeLicense());
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "arrow_circle_up");
    \u0275\u0275elementEnd()();
  }
}
function DefaultLayoutComponent_p_42_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "p", 35);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(ctx_r1.license == null ? null : ctx_r1.license.holder);
  }
}
var _DefaultLayoutComponent = class _DefaultLayoutComponent {
  constructor(windowService, defaultLayoutService, openSettingsService, matDialog, router) {
    this.windowService = windowService;
    this.defaultLayoutService = defaultLayoutService;
    this.openSettingsService = openSettingsService;
    this.matDialog = matDialog;
    this.router = router;
    this.ROUTES = DEFAULT_ROUTES;
    this.menuOpened = false;
    this.bugReport = { url: "", isActive: false };
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    this.subscriptions.add(this.defaultLayoutService.menuOpened$.subscribe((menuOpened) => this.menuOpened = menuOpened));
    this.route = this.windowService.controllerOptions.route;
    this.providerInfo = this.windowService.providerInfo;
    this.documentTitle = this.windowService.documentTitle;
    this.isProvider = this.windowService.isProvider;
    this.subtitle = this.windowService.serviceType;
    if (this.windowService.dataAccessType) {
      this.subtitle += ` (${this.windowService.dataAccessType}:${this.windowService.dbProviderName})`;
    }
    this.subtitle += ` v${this.windowService.packVersion}`;
    const licenseSubscription = this.windowService.license$.subscribe((license) => {
      if (license.edition !== LicenseEdition.Community && this.router.url === `/${this.ROUTES.sponsors}`) {
        this.router.navigate(["/"]);
      }
      this.license = license;
    });
    this.subscriptions.add(licenseSubscription);
    const linksSubscription = this.openSettingsService.getLinks().subscribe((response) => {
      const bugReport = response["bugReport"];
      if (bugReport) {
        this.bugReport.url = bugReport.url;
        this.bugReport.isActive = bugReport.isActive;
      }
    });
    this.subscriptions.add(linksSubscription);
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  toggleMenu() {
    this.defaultLayoutService.toggleMenu();
  }
  upgradeLicense() {
    const subscription = this.matDialog.open(LicenseUpgradeComponent, {
      width: "500px",
      height: "265px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    }).afterClosed().subscribe((response) => {
      if (response) {
        this.viewLicense();
      }
    });
    this.subscriptions.add(subscription);
  }
  viewLicense() {
    this.matDialog.open(LicenseViewComponent, {
      width: "580px",
      height: "490px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    });
  }
};
_DefaultLayoutComponent.\u0275fac = function DefaultLayoutComponent_Factory(t) {
  return new (t || _DefaultLayoutComponent)(\u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(DefaultLayoutService), \u0275\u0275directiveInject(OpenSettingsService), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(Router));
};
_DefaultLayoutComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _DefaultLayoutComponent, selectors: [["ng-component"]], decls: 43, vars: 21, consts: [["snav", ""], ["upgrade", ""], [1, "sidenav-container"], ["opened", "true", "mode", "side", "disableClose", "true", 1, "sidebar"], [1, "nav-list", "mat-toolbar", "mat-primary", "menu", "pb-0"], [1, "d-flex", "nav-list-content"], ["mat-icon-button", "", 3, "click"], ["fontIcon", "menu"], [1, "nav-list-menu"], ["routerLinkActive", "nav-item-active", "matTooltip", "Apps", "matTooltipPosition", "right", 3, "routerLink", "routerLinkActiveOptions", "matTooltipDisabled"], ["matListItemIcon", ""], ["routerLinkActive", "nav-item-active", "matTooltip", "Groups", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled", 4, "ngIf"], ["routerLinkActive", "nav-item-active", "matTooltip", "Identifiers", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled", 4, "ngIf"], ["routerLinkActive", "nav-item-active", "matTooltip", "Tags", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled", 4, "ngIf"], [1, "spacer"], ["routerLinkActive", "nav-item-active", "matTooltip", "Sponsors", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled", 4, "ngIf"], ["target", "_blank", "class", "text-decoration-none", 3, "href", 4, "ngIf"], ["routerLinkActive", "nav-item-active", "matTooltip", "About", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled"], ["color", "primary", 1, "toolbar"], [1, "ml-1"], [1, "subtitle"], [1, "edition"], [4, "ngIf", "ngIfElse"], [1, "pt-2"], ["class", "brand-watermark", 4, "ngIf"], ["routerLinkActive", "nav-item-active", "matTooltip", "Groups", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled"], ["routerLinkActive", "nav-item-active", "matTooltip", "Identifiers", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled"], ["routerLinkActive", "nav-item-active", "matTooltip", "Tags", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled"], ["routerLinkActive", "nav-item-active", "matTooltip", "Sponsors", "matTooltipPosition", "right", 3, "routerLink", "matTooltipDisabled"], ["matListItemIcon", "", "fontIcon", "favorite"], ["target", "_blank", 1, "text-decoration-none", 3, "href"], ["matTooltip", "Bug report", "matTooltipPosition", "right", 3, "matTooltipDisabled"], ["matListItemIcon", "", "fontIcon", "bug_report"], ["mat-icon-button", "", "matTooltip", "Info", 3, "click"], ["mat-icon-button", "", "matTooltip", "Upgrade", 3, "click"], [1, "brand-watermark"]], template: function DefaultLayoutComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-sidenav-container", 2)(1, "mat-sidenav", 3, 0)(3, "mat-nav-list", 4)(4, "div", 5)(5, "button", 6);
    \u0275\u0275listener("click", function DefaultLayoutComponent_Template_button_click_5_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.toggleMenu());
    });
    \u0275\u0275element(6, "mat-icon", 7);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(7, "p", 8);
    \u0275\u0275text(8, "Menu");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(9, "mat-nav-list")(10, "mat-list-item", 9);
    \u0275\u0275text(11, " Apps ");
    \u0275\u0275elementStart(12, "mat-icon", 10);
    \u0275\u0275text(13, "dashboard");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(14, DefaultLayoutComponent_mat_list_item_14_Template, 4, 2, "mat-list-item", 11)(15, DefaultLayoutComponent_mat_list_item_15_Template, 4, 2, "mat-list-item", 12)(16, DefaultLayoutComponent_mat_list_item_16_Template, 4, 2, "mat-list-item", 13);
    \u0275\u0275elementEnd();
    \u0275\u0275element(17, "div", 14)(18, "mat-divider");
    \u0275\u0275elementStart(19, "mat-nav-list");
    \u0275\u0275template(20, DefaultLayoutComponent_mat_list_item_20_Template, 3, 2, "mat-list-item", 15)(21, DefaultLayoutComponent_a_21_Template, 4, 2, "a", 16);
    \u0275\u0275elementStart(22, "mat-list-item", 17);
    \u0275\u0275text(23, " About ");
    \u0275\u0275elementStart(24, "mat-icon", 10);
    \u0275\u0275text(25, "info");
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(26, "mat-sidenav-content")(27, "mat-toolbar", 18)(28, "span", 19);
    \u0275\u0275text(29);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(30, "span", 20)(31, "span");
    \u0275\u0275text(32);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(33, "span", 21);
    \u0275\u0275text(34);
    \u0275\u0275template(35, DefaultLayoutComponent_ng_container_35_Template, 4, 0, "ng-container", 22)(36, DefaultLayoutComponent_ng_template_36_Template, 3, 0, "ng-template", null, 1, \u0275\u0275templateRefExtractor);
    \u0275\u0275elementEnd()();
    \u0275\u0275element(38, "span", 14)(39, "app-account-menu");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(40, "div", 23);
    \u0275\u0275element(41, "router-outlet");
    \u0275\u0275template(42, DefaultLayoutComponent_p_42_Template, 2, 1, "p", 24);
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const upgrade_r5 = \u0275\u0275reference(37);
    \u0275\u0275advance();
    \u0275\u0275styleProp("width", ctx.menuOpened ? "175px" : "58px");
    \u0275\u0275advance(9);
    \u0275\u0275propertyInterpolate("matTooltipDisabled", ctx.menuOpened);
    \u0275\u0275property("routerLink", ctx.ROUTES.base)("routerLinkActiveOptions", \u0275\u0275pureFunction0(20, _c04));
    \u0275\u0275advance(4);
    \u0275\u0275property("ngIf", ctx.isProvider);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isProvider);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isProvider);
    \u0275\u0275advance(4);
    \u0275\u0275property("ngIf", (ctx.license == null ? null : ctx.license.edition) === 100);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.bugReport.isActive && ctx.bugReport.url);
    \u0275\u0275advance();
    \u0275\u0275propertyInterpolate("matTooltipDisabled", ctx.menuOpened);
    \u0275\u0275property("routerLink", ctx.ROUTES.about);
    \u0275\u0275advance(4);
    \u0275\u0275styleProp("margin-left", ctx.menuOpened ? "175px" : "58px");
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx.documentTitle);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx.subtitle);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1("", ctx.license == null ? null : ctx.license.editionStringRepresentation, " Edition ");
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.license == null ? null : ctx.license.referenceId)("ngIfElse", upgrade_r5);
    \u0275\u0275advance(7);
    \u0275\u0275property("ngIf", ctx.license == null ? null : ctx.license.holder);
  }
}, dependencies: [NgIf, RouterOutlet, RouterLink, RouterLinkActive, AccountMenuComponent, MatSidenav, MatSidenavContainer, MatSidenavContent, MatNavList, MatListItem, MatListItemIcon, MatDivider, MatIcon, MatTooltip, MatToolbar, MatIconButton], styles: ['\n\n.subtitle[_ngcontent-%COMP%] {\n  font-size: 10px;\n  color: white;\n  padding: 2px 6px;\n  margin-left: 10px;\n  display: flex;\n  align-items: center;\n  justify-content: center;\n  height: 15px;\n  box-shadow: 2px 2px 6px 1px rgba(0, 0, 0, 0.2);\n}\n.mat-toolbar-row[_ngcontent-%COMP%] {\n  padding-left: 4px;\n}\n.mat-sidenav-container[_ngcontent-%COMP%] {\n  height: 100%;\n  min-height: 100%;\n  width: 100%;\n  min-width: 100%;\n}\n  .mat-drawer-inner-container {\n  display: flex;\n  flex-direction: column;\n  overflow-x: hidden !important;\n}\nmat-nav-list[_ngcontent-%COMP%]   mat-list-item[_ngcontent-%COMP%] {\n  border-radius: 0 !important;\n}\n.menu[_ngcontent-%COMP%] {\n  padding: 0 4px;\n  padding-top: 3px;\n  padding-bottom: 3.3px;\n  font-size: 17px;\n  height: 52px;\n}\n.nav-list-menu[_ngcontent-%COMP%] {\n  bottom: 7px;\n  position: relative;\n  left: 19px;\n}\n.nav-item-active[_ngcontent-%COMP%] {\n  background-color: rgba(0, 0, 0, 0.15);\n  border-left: 3px solid var(--mat-option-selected-state-label-text-color);\n}\n.nav-item-active[_ngcontent-%COMP%]   mat-icon[_ngcontent-%COMP%] {\n  margin-left: 13.5px;\n}\n.edition[_ngcontent-%COMP%] {\n  position: absolute;\n  font-size: 8px;\n  top: 23px;\n}\n.edition[_ngcontent-%COMP%]    > button[_ngcontent-%COMP%] {\n  position: absolute;\n  top: -8px;\n  margin-left: -15px;\n  transform: scale(0.6);\n}\n.brand-watermark[_ngcontent-%COMP%] {\n  letter-spacing: 2.5px;\n  position: fixed;\n  bottom: 10px;\n  font-size: 14px;\n  color: var(--mat-ripple-color);\n  padding: 5px 10px;\n  font-family: "Verdana", sans-serif;\n  text-transform: uppercase;\n  z-index: -1;\n  -webkit-user-select: none;\n  user-select: none;\n}\n/*# sourceMappingURL=default-layout.component.css.map */'] });
var DefaultLayoutComponent = _DefaultLayoutComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(DefaultLayoutComponent, { className: "DefaultLayoutComponent", filePath: "src\\app\\shared\\layouts\\default-layout\\default-layout.component.ts", lineNumber: 18 });
})();

// src/app/shared/layouts/default-layout/default-layout-routing.module.ts
var routes = [
  {
    path: "",
    component: DefaultLayoutComponent,
    canActivateChild: [authGuard],
    children: [
      { path: DEFAULT_ROUTES.base, loadChildren: () => import("./chunk-3JJMQLFD.js").then((m) => m.AppModule) },
      { path: DEFAULT_ROUTES.about, loadChildren: () => import("./chunk-EZ3VPIGX.js").then((m) => m.AboutModule) },
      { path: DEFAULT_ROUTES.groups, loadChildren: () => import("./chunk-U6WLI2RV.js").then((m) => m.GroupModule) },
      { path: DEFAULT_ROUTES.identifiers, loadChildren: () => import("./chunk-AINCA7M4.js").then((m) => m.IdentifierModule) },
      { path: DEFAULT_ROUTES.tags, loadChildren: () => import("./chunk-ETRWFHWU.js").then((m) => m.TagModule) },
      { path: DEFAULT_ROUTES.sponsors, loadChildren: () => import("./chunk-RFFSR5IV.js").then((m) => m.SponsorModule) },
      { path: "**", redirectTo: DEFAULT_ROUTES.redirectTo }
    ]
  }
];
var _DefaultLayoutRoutingModule = class _DefaultLayoutRoutingModule {
};
_DefaultLayoutRoutingModule.\u0275fac = function DefaultLayoutRoutingModule_Factory(t) {
  return new (t || _DefaultLayoutRoutingModule)();
};
_DefaultLayoutRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _DefaultLayoutRoutingModule });
_DefaultLayoutRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes), RouterModule] });
var DefaultLayoutRoutingModule = _DefaultLayoutRoutingModule;

// src/app/shared/components/confirmation-dialog/confirmation-dialog.module.ts
var _ConfirmationDialogModule = class _ConfirmationDialogModule {
};
_ConfirmationDialogModule.\u0275fac = function ConfirmationDialogModule_Factory(t) {
  return new (t || _ConfirmationDialogModule)();
};
_ConfirmationDialogModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _ConfirmationDialogModule });
_ConfirmationDialogModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  FormsModule,
  MatDialogModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule
] });
var ConfirmationDialogModule = _ConfirmationDialogModule;

// src/app/shared/components/account-menu/account-menu.module.ts
var _AccountMenuModule = class _AccountMenuModule {
};
_AccountMenuModule.\u0275fac = function AccountMenuModule_Factory(t) {
  return new (t || _AccountMenuModule)();
};
_AccountMenuModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _AccountMenuModule });
_AccountMenuModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  SharedModule,
  MatButtonModule,
  MatMenuModule,
  MatIconModule,
  MatBadgeModule,
  MatTooltipModule,
  MatCardModule
] });
var AccountMenuModule = _AccountMenuModule;

// src/app/features/licenses/license-upgrade/license-upgrade.module.ts
var _LicenseUpgradeModule = class _LicenseUpgradeModule {
};
_LicenseUpgradeModule.\u0275fac = function LicenseUpgradeModule_Factory(t) {
  return new (t || _LicenseUpgradeModule)();
};
_LicenseUpgradeModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _LicenseUpgradeModule });
_LicenseUpgradeModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  FormsModule,
  MatDialogModule,
  MatButtonModule,
  MatIconModule,
  MatTooltipModule,
  MatFormFieldModule,
  MatInputModule
] });
var LicenseUpgradeModule = _LicenseUpgradeModule;

// src/app/features/licenses/license-view/license-view.module.ts
var _LicenseViewModule = class _LicenseViewModule {
};
_LicenseViewModule.\u0275fac = function LicenseViewModule_Factory(t) {
  return new (t || _LicenseViewModule)();
};
_LicenseViewModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _LicenseViewModule });
_LicenseViewModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  FormsModule,
  MatDialogModule,
  MatButtonModule,
  MatIconModule,
  MatTooltipModule,
  MatFormFieldModule,
  MatInputModule,
  LicenseUpgradeModule
] });
var LicenseViewModule = _LicenseViewModule;

// src/app/shared/layouts/default-layout/default-layout.module.ts
var _DefaultLayoutModule = class _DefaultLayoutModule {
};
_DefaultLayoutModule.\u0275fac = function DefaultLayoutModule_Factory(t) {
  return new (t || _DefaultLayoutModule)();
};
_DefaultLayoutModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _DefaultLayoutModule });
_DefaultLayoutModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  DefaultLayoutRoutingModule,
  AccountMenuModule,
  ConfirmationDialogModule,
  MatSidenavModule,
  MatListModule,
  MatIconModule,
  MatDividerModule,
  MatTooltipModule,
  MatToolbarModule,
  MatButtonModule,
  LicenseViewModule
] });
var DefaultLayoutModule = _DefaultLayoutModule;
export {
  DefaultLayoutModule
};
//# sourceMappingURL=chunk-PAKFE4ZY.js.map
