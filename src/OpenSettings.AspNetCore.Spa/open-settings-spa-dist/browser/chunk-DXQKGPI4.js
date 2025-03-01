import {
  DefaultLayoutService,
  MatBadgeModule,
  MatList,
  MatListItem,
  MatListModule,
  SharedModule,
  ThemeService,
  TruncatePipe,
  isNullOrWhiteSpace
} from "./chunk-A3NZPCV4.js";
import {
  CustomValidators,
  computeIdentifier,
  isValidGuid
} from "./chunk-QG7R5YN6.js";
import "./chunk-TDUSDNS5.js";
import {
  GroupsService
} from "./chunk-ZOLOB6KZ.js";
import {
  IdentifiersService
} from "./chunk-5SLCPV23.js";
import {
  TagsService
} from "./chunk-M7S3W4OI.js";
import {
  ConflictResolverDialogComponent,
  DummyComponent,
  DummyComponentService,
  SetSortOrderPosition
} from "./chunk-J5EK4X6F.js";
import "./chunk-EB7MRBEE.js";
import {
  UtilityService
} from "./chunk-4H4XXYOP.js";
import {
  MatSnackBar
} from "./chunk-JQUQ3G7S.js";
import {
  MatAccordion,
  MatExpansionModule,
  MatExpansionPanel,
  MatExpansionPanelDescription,
  MatExpansionPanelHeader,
  MatExpansionPanelTitle
} from "./chunk-A4RMTSFK.js";
import {
  MatProgressBar,
  MatProgressBarModule,
  MatSelect,
  MatSelectModule
} from "./chunk-S64WAFEK.js";
import {
  MatMenu,
  MatMenuItem,
  MatMenuModule,
  MatMenuTrigger
} from "./chunk-SDNNC3I4.js";
import {
  ConfirmationDialogComponent,
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogModule,
  MatDialogRef,
  MatDialogTitle
} from "./chunk-HQT7NEGY.js";
import {
  CheckboxRequiredValidator,
  DefaultValueAccessor,
  FormBuilder,
  FormControlName,
  FormGroupDirective,
  FormGroupName,
  FormsModule,
  MAT_FORM_FIELD,
  MatCard,
  MatCardActions,
  MatCardAvatar,
  MatCardContent,
  MatCardHeader,
  MatCardModule,
  MatCardSubtitle,
  MatCardTitle,
  MatError,
  MatFormField,
  MatFormFieldControl,
  MatFormFieldModule,
  MatHint,
  MatIcon,
  MatIconModule,
  MatInput,
  MatInputModule,
  MatLabel,
  MatSuffix,
  MatTooltip,
  MatTooltipModule,
  NG_VALIDATORS,
  NG_VALUE_ACCESSOR,
  NgControl,
  NgControlStatus,
  NgControlStatusGroup,
  NgForm,
  NgModel,
  ReactiveFormsModule,
  Validators,
  ɵNgNoValidate
} from "./chunk-AXECPBMH.js";
import {
  ANIMATION_MODULE_TYPE,
  ActivatedRoute,
  ActiveDescendantKeyManager,
  AsyncPipe,
  Attribute,
  AuthService,
  BACKSPACE,
  BehaviorSubject,
  CdkMonitorFocus,
  CdkObserveContent,
  CdkPortal,
  CdkPortalOutlet,
  CdkScrollable,
  CdkScrollableModule,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  CommonModule,
  Component,
  ComponentFactoryResolver$1,
  ContentChild,
  ContentChildren,
  DELETE,
  DOCUMENT,
  DOWN_ARROW,
  Directionality,
  Directive,
  EMPTY,
  ENTER,
  ESCAPE,
  ElementRef,
  ErrorStateMatcher,
  EventEmitter,
  FocusKeyManager,
  FocusMonitor,
  Host,
  HttpClient,
  HttpHeaders,
  HttpParams,
  Inject,
  InjectionToken,
  Input,
  InputFlags,
  MAT_OPTGROUP,
  MAT_OPTION_PARENT_COMPONENT,
  MAT_RIPPLE_GLOBAL_OPTIONS,
  MatButton,
  MatButtonModule,
  MatCommonModule,
  MatFabButton,
  MatIconButton,
  MatOption,
  MatOptionModule,
  MatOptionSelectionChange,
  MatPseudoCheckbox,
  MatRipple,
  MatRippleLoader,
  MatRippleModule,
  NgClass,
  NgForOf,
  NgIf,
  NgModule,
  NgStyle,
  NgZone,
  Observable,
  Optional,
  Output,
  Overlay,
  OverlayConfig,
  OverlayModule,
  Platform,
  QueryList,
  Router,
  RouterLink,
  RouterModule,
  RouterOutlet,
  SPACE,
  SelectionModel,
  Self,
  Subject,
  Subscription,
  TAB,
  TemplatePortal,
  TemplateRef,
  UP_ARROW,
  UserPreferencesService,
  ViewChild,
  ViewContainerRef,
  ViewEncapsulation$1,
  ViewportRuler,
  WindowService,
  _ErrorStateTracker,
  _MatInternalFormField,
  __spreadValues,
  _countGroupLabelsBeforeOption,
  _getEventTarget,
  _getOptionScrollPosition,
  addAriaReferencedId,
  animate,
  booleanAttribute,
  catchError,
  debounceTime,
  defer,
  delay,
  distinctUntilChanged,
  filter,
  forwardRef,
  fromEvent,
  group,
  hasModifierKey,
  inject,
  map,
  merge,
  normalizePassiveListenerOptions,
  numberAttribute,
  of,
  removeAriaReferencedId,
  setClassMetadata,
  skip,
  startWith,
  state,
  style,
  switchMap,
  take,
  takeUntil,
  tap,
  timer,
  transition,
  trigger,
  v4_default,
  ɵsetClassDebugInfo,
  ɵɵInheritDefinitionFeature,
  ɵɵInputTransformsFeature,
  ɵɵNgOnChangesFeature,
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
  ɵɵhostProperty,
  ɵɵinject,
  ɵɵinjectAttribute,
  ɵɵlistener,
  ɵɵloadQuery,
  ɵɵnamespaceHTML,
  ɵɵnamespaceSVG,
  ɵɵnextContext,
  ɵɵpipe,
  ɵɵpipeBind1,
  ɵɵpipeBind2,
  ɵɵprojection,
  ɵɵprojectionDef,
  ɵɵproperty,
  ɵɵpropertyInterpolate,
  ɵɵpureFunction0,
  ɵɵpureFunction1,
  ɵɵpureFunction2,
  ɵɵpureFunction3,
  ɵɵqueryRefresh,
  ɵɵreference,
  ɵɵrepeater,
  ɵɵrepeaterCreate,
  ɵɵrepeaterTrackByIdentity,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵsanitizeUrl,
  ɵɵstyleProp,
  ɵɵtemplate,
  ɵɵtemplateRefExtractor,
  ɵɵtext,
  ɵɵtextInterpolate,
  ɵɵtextInterpolate1,
  ɵɵtextInterpolate2,
  ɵɵtwoWayBindingSet,
  ɵɵtwoWayListener,
  ɵɵtwoWayProperty,
  ɵɵviewQuery
} from "./chunk-SUR7UARE.js";

// src/app/features/app/services/apps.service.ts
var _AppsService = class _AppsService {
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
  getGroupedApps(request) {
    let url = this.route + "/v1/apps/grouped";
    let params = new HttpParams();
    if (request.groupId) {
      params = params.append("groupId", request.groupId);
    }
    if (request.searchTerm) {
      params = params.append("searchTerm", request.searchTerm);
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getAppById(request) {
    const url = this.route + "/v1/apps/" + request.appIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getAppBySlug(request) {
    const url = this.route + "/v1/apps/slug/" + request.appIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getApps(request) {
    let url = this.route + "/v1/apps";
    let params = new HttpParams();
    if (request.searchTerm) {
      params = params.append("searchTerm", request.searchTerm);
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  updateApp(request) {
    const url = this.route + "/v1/apps/" + request.appId;
    return this.httpClient.put(url, request.body, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      return of();
    }));
  }
  createApp(request) {
    let url = this.route + "/v1/apps";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  getGroupedAppDataByAppId(request) {
    const url = this.route + "/v1/apps/" + request.appIdOrSlug + "/grouped";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getGroupedAppDataByAppSlug(request) {
    const url = this.route + "/v1/apps/slug/" + request.appIdOrSlug + "/grouped";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getGroupedAppDataByAppIdAndIdentifierId(request) {
    const url = this.route + "/v1/apps/" + request.appIdOrSlug + "/identifiers/" + request.identifierIdOrSlug + "/grouped";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getGroupedAppDataByAppSlugAndIdentifierSlug(request) {
    const url = this.route + "/v1/apps/slug/" + request.appIdOrSlug + "/identifiers/" + request.identifierIdOrSlug + "/grouped";
    return this.httpClient.get(url, { headers: this.headers });
  }
  deleteApp(request) {
    const url = this.route + "/v1/apps/" + request.appId + "?rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.delete(url, { headers: this.headers });
  }
};
_AppsService.\u0275fac = function AppsService_Factory(t) {
  return new (t || _AppsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_AppsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _AppsService, factory: _AppsService.\u0275fac, providedIn: "root" });
var AppsService = _AppsService;

// node_modules/@angular/material/fesm2022/chips.mjs
var _c0 = ["*", [["mat-chip-avatar"], ["", "matChipAvatar", ""]], [["mat-chip-trailing-icon"], ["", "matChipRemove", ""], ["", "matChipTrailingIcon", ""]]];
var _c1 = ["*", "mat-chip-avatar, [matChipAvatar]", "mat-chip-trailing-icon,[matChipRemove],[matChipTrailingIcon]"];
function MatChip_Conditional_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span", 3);
    \u0275\u0275projection(1, 1);
    \u0275\u0275elementEnd();
  }
}
function MatChip_Conditional_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span", 6);
    \u0275\u0275projection(1, 2);
    \u0275\u0275elementEnd();
  }
}
function MatChipOption_Conditional_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span", 3);
    \u0275\u0275projection(1, 1);
    \u0275\u0275elementStart(2, "span", 8);
    \u0275\u0275namespaceSVG();
    \u0275\u0275elementStart(3, "svg", 9);
    \u0275\u0275element(4, "path", 10);
    \u0275\u0275elementEnd()()();
  }
}
function MatChipOption_Conditional_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span", 6);
    \u0275\u0275projection(1, 2);
    \u0275\u0275elementEnd();
  }
}
var _c2 = '.mdc-evolution-chip,.mdc-evolution-chip__cell,.mdc-evolution-chip__action{display:inline-flex;align-items:center}.mdc-evolution-chip{position:relative;max-width:100%}.mdc-evolution-chip .mdc-elevation-overlay{width:100%;height:100%;top:0;left:0}.mdc-evolution-chip__cell,.mdc-evolution-chip__action{height:100%}.mdc-evolution-chip__cell--primary{overflow-x:hidden}.mdc-evolution-chip__cell--trailing{flex:1 0 auto}.mdc-evolution-chip__action{align-items:center;background:none;border:none;box-sizing:content-box;cursor:pointer;display:inline-flex;justify-content:center;outline:none;padding:0;text-decoration:none;color:inherit}.mdc-evolution-chip__action--presentational{cursor:auto}.mdc-evolution-chip--disabled,.mdc-evolution-chip__action:disabled{pointer-events:none}.mdc-evolution-chip__action--primary{overflow-x:hidden}.mdc-evolution-chip__action--trailing{position:relative;overflow:visible}.mdc-evolution-chip__action--primary:before{box-sizing:border-box;content:"";height:100%;left:0;position:absolute;pointer-events:none;top:0;width:100%;z-index:1}.mdc-evolution-chip--touch{margin-top:8px;margin-bottom:8px}.mdc-evolution-chip__action-touch{position:absolute;top:50%;height:48px;left:0;right:0;transform:translateY(-50%)}.mdc-evolution-chip__text-label{white-space:nowrap;user-select:none;text-overflow:ellipsis;overflow:hidden}.mdc-evolution-chip__graphic{align-items:center;display:inline-flex;justify-content:center;overflow:hidden;pointer-events:none;position:relative;flex:1 0 auto}.mdc-evolution-chip__checkmark{position:absolute;opacity:0;top:50%;left:50%}.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--selected):not(.mdc-evolution-chip--with-primary-icon) .mdc-evolution-chip__graphic{width:0}.mdc-evolution-chip__checkmark-background{opacity:0}.mdc-evolution-chip__checkmark-svg{display:block}.mdc-evolution-chip__checkmark-path{stroke-width:2px;stroke-dasharray:29.7833385;stroke-dashoffset:29.7833385;stroke:currentColor}.mdc-evolution-chip--selecting .mdc-evolution-chip__graphic{transition:width 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark{transition:transform 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__graphic{transition:width 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark{transition:opacity 50ms 0ms linear,transform 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-50%, -50%)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selected .mdc-evolution-chip__icon--primary{opacity:0}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{transform:translate(-50%, -50%);opacity:1}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}@keyframes mdc-evolution-chip-enter{from{transform:scale(0.8);opacity:.4}to{transform:scale(1);opacity:1}}.mdc-evolution-chip--enter{animation:mdc-evolution-chip-enter 100ms 0ms cubic-bezier(0, 0, 0.2, 1)}@keyframes mdc-evolution-chip-exit{from{opacity:1}to{opacity:0}}.mdc-evolution-chip--exit{animation:mdc-evolution-chip-exit 75ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mdc-evolution-chip--hidden{opacity:0;pointer-events:none;transition:width 150ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mat-mdc-standard-chip{border-radius:var(--mdc-chip-container-shape-radius);height:var(--mdc-chip-container-height)}.mat-mdc-standard-chip .mdc-evolution-chip__ripple{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{border-radius:var(--mdc-chip-with-avatar-avatar-shape-radius)}.mat-mdc-standard-chip.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--with-primary-icon){--mdc-chip-graphic-selected-width:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip .mdc-evolution-chip__graphic{height:var(--mdc-chip-with-avatar-avatar-size);width:var(--mdc-chip-with-avatar-avatar-size);font-size:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational).mdc-ripple-upgraded--background-focused:before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational):not(.mdc-ripple-upgraded):focus:before{border-color:var(--mdc-chip-focus-outline-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-disabled-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-outline-width)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-flat-selected-outline-width)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-selected-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-flat-disabled-selected-container-color)}.mat-mdc-standard-chip .mdc-evolution-chip__text-label{font-family:var(--mdc-chip-label-text-font);line-height:var(--mdc-chip-label-text-line-height);font-size:var(--mdc-chip-label-text-size);font-weight:var(--mdc-chip-label-text-weight);letter-spacing:var(--mdc-chip-label-text-tracking)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-selected-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{height:var(--mdc-chip-with-icon-icon-size);width:var(--mdc-chip-with-icon-icon-size);font-size:var(--mdc-chip-with-icon-icon-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-selected-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-hover-state-layer-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-selected-hover-state-layer-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color)}.mat-mdc-chip-selected .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color)}.mat-mdc-chip:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-hover-state-layer-color);opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-chip-selected:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-hover-state-layer-color);opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-chip.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color);opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-chip-selected.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color);opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mdc-evolution-chip--disabled:not(.mdc-evolution-chip--selected) .mat-mdc-chip-avatar{opacity:var(--mdc-chip-with-avatar-disabled-avatar-opacity)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{opacity:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity)}.mdc-evolution-chip--disabled.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{opacity:var(--mdc-chip-with-icon-disabled-icon-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{opacity:var(--mat-chip-disabled-container-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-disabled-trailing-icon-color)}.mat-mdc-chip-remove{opacity:var(--mat-chip-trailing-action-opacity)}.mat-mdc-chip-remove:focus{opacity:var(--mat-chip-trailing-action-focus-opacity)}.mat-mdc-chip-remove::after{background:var(--mat-chip-trailing-action-state-layer-color)}.mat-mdc-chip-remove:hover::after{opacity:var(--mat-chip-trailing-action-hover-state-layer-opacity)}.mat-mdc-chip-remove:focus::after{opacity:var(--mat-chip-trailing-action-focus-state-layer-opacity)}.mat-mdc-chip-selected .mat-mdc-chip-remove::after{background:var(--mat-chip-selected-trailing-action-state-layer-color)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove{opacity:calc(var(--mat-chip-trailing-action-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove:focus{opacity:calc(var(--mat-chip-trailing-action-focus-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-style:solid}.mat-mdc-standard-chip .mdc-evolution-chip__checkmark{height:20px;width:20px}.mat-mdc-standard-chip .mdc-evolution-chip__icon--trailing{height:18px;width:18px;font-size:18px}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mat-mdc-standard-chip{-webkit-tap-highlight-color:rgba(0,0,0,0)}.cdk-high-contrast-active .mat-mdc-standard-chip{outline:solid 1px}.cdk-high-contrast-active .mat-mdc-standard-chip .mdc-evolution-chip__checkmark-path{stroke:CanvasText !important}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mat-mdc-chip-action-label{overflow:visible}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary{flex-basis:100%}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{font:inherit;letter-spacing:inherit;white-space:inherit}.mat-mdc-standard-chip .mat-mdc-chip-graphic,.mat-mdc-standard-chip .mat-mdc-chip-trailing-icon{box-sizing:content-box}.mat-mdc-standard-chip._mat-animation-noopable,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__graphic,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark-path{transition-duration:1ms;animation-duration:1ms}.mat-mdc-basic-chip .mdc-evolution-chip__action--primary{font:inherit}.mat-mdc-chip-focus-overlay{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;opacity:0;border-radius:inherit;transition:opacity 150ms linear}._mat-animation-noopable .mat-mdc-chip-focus-overlay{transition:none}.mat-mdc-basic-chip .mat-mdc-chip-focus-overlay{display:none}.mat-mdc-chip .mat-ripple.mat-mdc-chip-ripple{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;border-radius:inherit}.mat-mdc-chip-avatar{text-align:center;line-height:1;color:var(--mdc-chip-with-icon-icon-color, currentColor)}.mat-mdc-chip{position:relative;z-index:0}.mat-mdc-chip-action-label{text-align:left;z-index:1}[dir=rtl] .mat-mdc-chip-action-label{text-align:right}.mat-mdc-chip.mdc-evolution-chip--with-trailing-action .mat-mdc-chip-action-label{position:relative}.mat-mdc-chip-action-label .mat-mdc-chip-primary-focus-indicator{position:absolute;top:0;right:0;bottom:0;left:0;pointer-events:none}.mat-mdc-chip-action-label .mat-mdc-focus-indicator::before{margin:calc(calc(var(--mat-mdc-focus-indicator-border-width, 3px) + 2px)*-1)}.mat-mdc-chip-remove::before{margin:calc(var(--mat-mdc-focus-indicator-border-width, 3px)*-1);left:8px;right:8px}.mat-mdc-chip-remove::after{content:"";display:block;opacity:0;position:absolute;top:-2px;bottom:-2px;left:6px;right:6px;border-radius:50%}.mat-mdc-chip-remove .mat-icon{width:18px;height:18px;font-size:18px;box-sizing:content-box}.mat-chip-edit-input{cursor:text;display:inline-block;color:inherit;outline:0}.cdk-high-contrast-active .mat-mdc-chip-selected:not(.mat-mdc-chip-multiple){outline-width:3px}.mat-mdc-chip-action:focus .mat-mdc-focus-indicator::before{content:""}';
var _c3 = [[["mat-chip-avatar"], ["", "matChipAvatar", ""]], [["", "matChipEditInput", ""]], "*", [["mat-chip-trailing-icon"], ["", "matChipRemove", ""], ["", "matChipTrailingIcon", ""]]];
var _c4 = ["mat-chip-avatar, [matChipAvatar]", "[matChipEditInput]", "*", "mat-chip-trailing-icon,[matChipRemove],[matChipTrailingIcon]"];
function MatChipRow_Conditional_0_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "span", 0);
  }
}
function MatChipRow_Conditional_2_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span", 2);
    \u0275\u0275projection(1);
    \u0275\u0275elementEnd();
  }
}
function MatChipRow_Conditional_4_Conditional_0_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275projection(0, 1);
  }
}
function MatChipRow_Conditional_4_Conditional_1_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "span", 7);
  }
}
function MatChipRow_Conditional_4_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275template(0, MatChipRow_Conditional_4_Conditional_0_Template, 1, 0)(1, MatChipRow_Conditional_4_Conditional_1_Template, 1, 0);
  }
  if (rf & 2) {
    const ctx_r0 = \u0275\u0275nextContext();
    \u0275\u0275conditional(0, ctx_r0.contentEditInput ? 0 : 1);
  }
}
function MatChipRow_Conditional_5_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275projection(0, 2);
  }
}
function MatChipRow_Conditional_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "span", 5);
    \u0275\u0275projection(1, 3);
    \u0275\u0275elementEnd();
  }
}
var _c5 = ["*"];
var _c6 = ".mdc-evolution-chip-set{display:flex}.mdc-evolution-chip-set:focus{outline:none}.mdc-evolution-chip-set__chips{display:flex;flex-flow:wrap;min-width:0}.mdc-evolution-chip-set--overflow .mdc-evolution-chip-set__chips{flex-flow:nowrap}.mdc-evolution-chip-set .mdc-evolution-chip-set__chips{margin-left:-8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip-set__chips,.mdc-evolution-chip-set .mdc-evolution-chip-set__chips[dir=rtl]{margin-left:0;margin-right:-8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-left:8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip,.mdc-evolution-chip-set .mdc-evolution-chip[dir=rtl]{margin-left:0;margin-right:8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-top:4px;margin-bottom:4px}.mat-mdc-chip-set .mdc-evolution-chip-set__chips{min-width:100%}.mat-mdc-chip-set-stacked{flex-direction:column;align-items:flex-start}.mat-mdc-chip-set-stacked .mat-mdc-chip{width:100%}.mat-mdc-chip-set-stacked .mdc-evolution-chip__graphic{flex-grow:0}.mat-mdc-chip-set-stacked .mdc-evolution-chip__action--primary{flex-basis:100%;justify-content:start}input.mat-mdc-chip-input{flex:1 0 150px;margin-left:8px}[dir=rtl] input.mat-mdc-chip-input{margin-left:0;margin-right:8px}";
var MAT_CHIPS_DEFAULT_OPTIONS = new InjectionToken("mat-chips-default-options", {
  providedIn: "root",
  factory: () => ({
    separatorKeyCodes: [ENTER]
  })
});
var MAT_CHIP_AVATAR = new InjectionToken("MatChipAvatar");
var MAT_CHIP_TRAILING_ICON = new InjectionToken("MatChipTrailingIcon");
var MAT_CHIP_REMOVE = new InjectionToken("MatChipRemove");
var MAT_CHIP = new InjectionToken("MatChip");
var _MatChipAction = class _MatChipAction {
  /** Whether the action is disabled. */
  get disabled() {
    return this._disabled || this._parentChip.disabled;
  }
  set disabled(value) {
    this._disabled = value;
  }
  /**
   * Determine the value of the disabled attribute for this chip action.
   */
  _getDisabledAttribute() {
    return this.disabled && !this._allowFocusWhenDisabled ? "" : null;
  }
  /**
   * Determine the value of the tabindex attribute for this chip action.
   */
  _getTabindex() {
    return this.disabled && !this._allowFocusWhenDisabled || !this.isInteractive ? null : this.tabIndex.toString();
  }
  constructor(_elementRef, _parentChip) {
    this._elementRef = _elementRef;
    this._parentChip = _parentChip;
    this.isInteractive = true;
    this._isPrimary = true;
    this._disabled = false;
    this.tabIndex = -1;
    this._allowFocusWhenDisabled = false;
    if (_elementRef.nativeElement.nodeName === "BUTTON") {
      _elementRef.nativeElement.setAttribute("type", "button");
    }
  }
  focus() {
    this._elementRef.nativeElement.focus();
  }
  _handleClick(event) {
    if (!this.disabled && this.isInteractive && this._isPrimary) {
      event.preventDefault();
      this._parentChip._handlePrimaryActionInteraction();
    }
  }
  _handleKeydown(event) {
    if ((event.keyCode === ENTER || event.keyCode === SPACE) && !this.disabled && this.isInteractive && this._isPrimary && !this._parentChip._isEditing) {
      event.preventDefault();
      this._parentChip._handlePrimaryActionInteraction();
    }
  }
};
_MatChipAction.\u0275fac = function MatChipAction_Factory(t) {
  return new (t || _MatChipAction)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(MAT_CHIP));
};
_MatChipAction.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatChipAction,
  selectors: [["", "matChipAction", ""]],
  hostAttrs: [1, "mdc-evolution-chip__action", "mat-mdc-chip-action"],
  hostVars: 9,
  hostBindings: function MatChipAction_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("click", function MatChipAction_click_HostBindingHandler($event) {
        return ctx._handleClick($event);
      })("keydown", function MatChipAction_keydown_HostBindingHandler($event) {
        return ctx._handleKeydown($event);
      });
    }
    if (rf & 2) {
      \u0275\u0275attribute("tabindex", ctx._getTabindex())("disabled", ctx._getDisabledAttribute())("aria-disabled", ctx.disabled);
      \u0275\u0275classProp("mdc-evolution-chip__action--primary", ctx._isPrimary)("mdc-evolution-chip__action--presentational", !ctx.isInteractive)("mdc-evolution-chip__action--trailing", !ctx._isPrimary);
    }
  },
  inputs: {
    isInteractive: "isInteractive",
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    tabIndex: [InputFlags.HasDecoratorInputTransform, "tabIndex", "tabIndex", (value) => value == null ? -1 : numberAttribute(value)],
    _allowFocusWhenDisabled: "_allowFocusWhenDisabled"
  },
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature]
});
var MatChipAction = _MatChipAction;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipAction, [{
    type: Directive,
    args: [{
      selector: "[matChipAction]",
      host: {
        "class": "mdc-evolution-chip__action mat-mdc-chip-action",
        "[class.mdc-evolution-chip__action--primary]": "_isPrimary",
        "[class.mdc-evolution-chip__action--presentational]": "!isInteractive",
        "[class.mdc-evolution-chip__action--trailing]": "!_isPrimary",
        "[attr.tabindex]": "_getTabindex()",
        "[attr.disabled]": "_getDisabledAttribute()",
        "[attr.aria-disabled]": "disabled",
        "(click)": "_handleClick($event)",
        "(keydown)": "_handleKeydown($event)"
      },
      standalone: true
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_CHIP]
    }]
  }], {
    isInteractive: [{
      type: Input
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    tabIndex: [{
      type: Input,
      args: [{
        transform: (value) => value == null ? -1 : numberAttribute(value)
      }]
    }],
    _allowFocusWhenDisabled: [{
      type: Input
    }]
  });
})();
var _MatChipAvatar = class _MatChipAvatar {
};
_MatChipAvatar.\u0275fac = function MatChipAvatar_Factory(t) {
  return new (t || _MatChipAvatar)();
};
_MatChipAvatar.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatChipAvatar,
  selectors: [["mat-chip-avatar"], ["", "matChipAvatar", ""]],
  hostAttrs: ["role", "img", 1, "mat-mdc-chip-avatar", "mdc-evolution-chip__icon", "mdc-evolution-chip__icon--primary"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_CHIP_AVATAR,
    useExisting: _MatChipAvatar
  }])]
});
var MatChipAvatar = _MatChipAvatar;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipAvatar, [{
    type: Directive,
    args: [{
      selector: "mat-chip-avatar, [matChipAvatar]",
      host: {
        "class": "mat-mdc-chip-avatar mdc-evolution-chip__icon mdc-evolution-chip__icon--primary",
        "role": "img"
      },
      providers: [{
        provide: MAT_CHIP_AVATAR,
        useExisting: MatChipAvatar
      }],
      standalone: true
    }]
  }], null, null);
})();
var _MatChipTrailingIcon = class _MatChipTrailingIcon extends MatChipAction {
  constructor() {
    super(...arguments);
    this.isInteractive = false;
    this._isPrimary = false;
  }
};
_MatChipTrailingIcon.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatChipTrailingIcon_BaseFactory;
  return function MatChipTrailingIcon_Factory(t) {
    return (\u0275MatChipTrailingIcon_BaseFactory || (\u0275MatChipTrailingIcon_BaseFactory = \u0275\u0275getInheritedFactory(_MatChipTrailingIcon)))(t || _MatChipTrailingIcon);
  };
})();
_MatChipTrailingIcon.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatChipTrailingIcon,
  selectors: [["mat-chip-trailing-icon"], ["", "matChipTrailingIcon", ""]],
  hostAttrs: ["aria-hidden", "true", 1, "mat-mdc-chip-trailing-icon", "mdc-evolution-chip__icon", "mdc-evolution-chip__icon--trailing"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_CHIP_TRAILING_ICON,
    useExisting: _MatChipTrailingIcon
  }]), \u0275\u0275InheritDefinitionFeature]
});
var MatChipTrailingIcon = _MatChipTrailingIcon;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipTrailingIcon, [{
    type: Directive,
    args: [{
      selector: "mat-chip-trailing-icon, [matChipTrailingIcon]",
      host: {
        "class": "mat-mdc-chip-trailing-icon mdc-evolution-chip__icon mdc-evolution-chip__icon--trailing",
        "aria-hidden": "true"
      },
      providers: [{
        provide: MAT_CHIP_TRAILING_ICON,
        useExisting: MatChipTrailingIcon
      }],
      standalone: true
    }]
  }], null, null);
})();
var _MatChipRemove = class _MatChipRemove extends MatChipAction {
  constructor() {
    super(...arguments);
    this._isPrimary = false;
  }
  _handleClick(event) {
    if (!this.disabled) {
      event.stopPropagation();
      event.preventDefault();
      this._parentChip.remove();
    }
  }
  _handleKeydown(event) {
    if ((event.keyCode === ENTER || event.keyCode === SPACE) && !this.disabled) {
      event.stopPropagation();
      event.preventDefault();
      this._parentChip.remove();
    }
  }
};
_MatChipRemove.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatChipRemove_BaseFactory;
  return function MatChipRemove_Factory(t) {
    return (\u0275MatChipRemove_BaseFactory || (\u0275MatChipRemove_BaseFactory = \u0275\u0275getInheritedFactory(_MatChipRemove)))(t || _MatChipRemove);
  };
})();
_MatChipRemove.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatChipRemove,
  selectors: [["", "matChipRemove", ""]],
  hostAttrs: ["role", "button", 1, "mat-mdc-chip-remove", "mat-mdc-chip-trailing-icon", "mat-mdc-focus-indicator", "mdc-evolution-chip__icon", "mdc-evolution-chip__icon--trailing"],
  hostVars: 1,
  hostBindings: function MatChipRemove_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275attribute("aria-hidden", null);
    }
  },
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_CHIP_REMOVE,
    useExisting: _MatChipRemove
  }]), \u0275\u0275InheritDefinitionFeature]
});
var MatChipRemove = _MatChipRemove;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipRemove, [{
    type: Directive,
    args: [{
      selector: "[matChipRemove]",
      host: {
        "class": "mat-mdc-chip-remove mat-mdc-chip-trailing-icon mat-mdc-focus-indicator mdc-evolution-chip__icon mdc-evolution-chip__icon--trailing",
        "role": "button",
        "[attr.aria-hidden]": "null"
      },
      providers: [{
        provide: MAT_CHIP_REMOVE,
        useExisting: MatChipRemove
      }],
      standalone: true
    }]
  }], null, null);
})();
var uid = 0;
var _MatChip = class _MatChip {
  _hasFocus() {
    return this._hasFocusInternal;
  }
  /**
   * The value of the chip. Defaults to the content inside
   * the `mat-mdc-chip-action-label` element.
   */
  get value() {
    return this._value !== void 0 ? this._value : this._textElement.textContent.trim();
  }
  set value(value) {
    this._value = value;
  }
  /**
   * Reference to the MatRipple instance of the chip.
   * @deprecated Considered an implementation detail. To be removed.
   * @breaking-change 17.0.0
   */
  get ripple() {
    return this._rippleLoader?.getRipple(this._elementRef.nativeElement);
  }
  set ripple(v) {
    this._rippleLoader?.attachRipple(this._elementRef.nativeElement, v);
  }
  constructor(_changeDetectorRef, _elementRef, _ngZone, _focusMonitor, _document, animationMode, _globalRippleOptions, tabIndex) {
    this._changeDetectorRef = _changeDetectorRef;
    this._elementRef = _elementRef;
    this._ngZone = _ngZone;
    this._focusMonitor = _focusMonitor;
    this._globalRippleOptions = _globalRippleOptions;
    this._onFocus = new Subject();
    this._onBlur = new Subject();
    this.role = null;
    this._hasFocusInternal = false;
    this.id = `mat-mdc-chip-${uid++}`;
    this.ariaLabel = null;
    this.ariaDescription = null;
    this._ariaDescriptionId = `${this.id}-aria-description`;
    this.removable = true;
    this.highlighted = false;
    this.disableRipple = false;
    this.disabled = false;
    this.tabIndex = -1;
    this.removed = new EventEmitter();
    this.destroyed = new EventEmitter();
    this.basicChipAttrName = "mat-basic-chip";
    this._rippleLoader = inject(MatRippleLoader);
    this._document = _document;
    this._animationsDisabled = animationMode === "NoopAnimations";
    if (tabIndex != null) {
      this.tabIndex = parseInt(tabIndex) ?? -1;
    }
    this._monitorFocus();
    this._rippleLoader?.configureRipple(this._elementRef.nativeElement, {
      className: "mat-mdc-chip-ripple",
      disabled: this._isRippleDisabled()
    });
  }
  ngOnInit() {
    const element = this._elementRef.nativeElement;
    this._isBasicChip = element.hasAttribute(this.basicChipAttrName) || element.tagName.toLowerCase() === this.basicChipAttrName;
  }
  ngAfterViewInit() {
    this._textElement = this._elementRef.nativeElement.querySelector(".mat-mdc-chip-action-label");
    if (this._pendingFocus) {
      this._pendingFocus = false;
      this.focus();
    }
  }
  ngAfterContentInit() {
    this._actionChanges = merge(this._allLeadingIcons.changes, this._allTrailingIcons.changes, this._allRemoveIcons.changes).subscribe(() => this._changeDetectorRef.markForCheck());
  }
  ngDoCheck() {
    this._rippleLoader.setDisabled(this._elementRef.nativeElement, this._isRippleDisabled());
  }
  ngOnDestroy() {
    this._focusMonitor.stopMonitoring(this._elementRef);
    this._rippleLoader?.destroyRipple(this._elementRef.nativeElement);
    this._actionChanges?.unsubscribe();
    this.destroyed.emit({
      chip: this
    });
    this.destroyed.complete();
  }
  /**
   * Allows for programmatic removal of the chip.
   *
   * Informs any listeners of the removal request. Does not remove the chip from the DOM.
   */
  remove() {
    if (this.removable) {
      this.removed.emit({
        chip: this
      });
    }
  }
  /** Whether or not the ripple should be disabled. */
  _isRippleDisabled() {
    return this.disabled || this.disableRipple || this._animationsDisabled || this._isBasicChip || !!this._globalRippleOptions?.disabled;
  }
  /** Returns whether the chip has a trailing icon. */
  _hasTrailingIcon() {
    return !!(this.trailingIcon || this.removeIcon);
  }
  /** Handles keyboard events on the chip. */
  _handleKeydown(event) {
    if (event.keyCode === BACKSPACE || event.keyCode === DELETE) {
      event.preventDefault();
      this.remove();
    }
  }
  /** Allows for programmatic focusing of the chip. */
  focus() {
    if (!this.disabled) {
      if (this.primaryAction) {
        this.primaryAction.focus();
      } else {
        this._pendingFocus = true;
      }
    }
  }
  /** Gets the action that contains a specific target node. */
  _getSourceAction(target) {
    return this._getActions().find((action) => {
      const element = action._elementRef.nativeElement;
      return element === target || element.contains(target);
    });
  }
  /** Gets all of the actions within the chip. */
  _getActions() {
    const result = [];
    if (this.primaryAction) {
      result.push(this.primaryAction);
    }
    if (this.removeIcon) {
      result.push(this.removeIcon);
    }
    if (this.trailingIcon) {
      result.push(this.trailingIcon);
    }
    return result;
  }
  /** Handles interactions with the primary action of the chip. */
  _handlePrimaryActionInteraction() {
  }
  /** Gets the tabindex of the chip. */
  _getTabIndex() {
    if (!this.role) {
      return null;
    }
    return this.disabled ? -1 : this.tabIndex;
  }
  /** Starts the focus monitoring process on the chip. */
  _monitorFocus() {
    this._focusMonitor.monitor(this._elementRef, true).subscribe((origin) => {
      const hasFocus = origin !== null;
      if (hasFocus !== this._hasFocusInternal) {
        this._hasFocusInternal = hasFocus;
        if (hasFocus) {
          this._onFocus.next({
            chip: this
          });
        } else {
          this._ngZone.onStable.pipe(take(1)).subscribe(() => this._ngZone.run(() => this._onBlur.next({
            chip: this
          })));
        }
      }
    });
  }
};
_MatChip.\u0275fac = function MatChip_Factory(t) {
  return new (t || _MatChip)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(FocusMonitor), \u0275\u0275directiveInject(DOCUMENT), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8), \u0275\u0275directiveInject(MAT_RIPPLE_GLOBAL_OPTIONS, 8), \u0275\u0275injectAttribute("tabindex"));
};
_MatChip.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatChip,
  selectors: [["mat-basic-chip"], ["", "mat-basic-chip", ""], ["mat-chip"], ["", "mat-chip", ""]],
  contentQueries: function MatChip_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MAT_CHIP_AVATAR, 5);
      \u0275\u0275contentQuery(dirIndex, MAT_CHIP_TRAILING_ICON, 5);
      \u0275\u0275contentQuery(dirIndex, MAT_CHIP_REMOVE, 5);
      \u0275\u0275contentQuery(dirIndex, MAT_CHIP_AVATAR, 5);
      \u0275\u0275contentQuery(dirIndex, MAT_CHIP_TRAILING_ICON, 5);
      \u0275\u0275contentQuery(dirIndex, MAT_CHIP_REMOVE, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.leadingIcon = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.trailingIcon = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.removeIcon = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._allLeadingIcons = _t);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._allTrailingIcons = _t);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._allRemoveIcons = _t);
    }
  },
  viewQuery: function MatChip_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(MatChipAction, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.primaryAction = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-chip"],
  hostVars: 32,
  hostBindings: function MatChip_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("keydown", function MatChip_keydown_HostBindingHandler($event) {
        return ctx._handleKeydown($event);
      });
    }
    if (rf & 2) {
      \u0275\u0275hostProperty("id", ctx.id);
      \u0275\u0275attribute("role", ctx.role)("tabindex", ctx._getTabIndex())("aria-label", ctx.ariaLabel);
      \u0275\u0275classMap("mat-" + (ctx.color || "primary"));
      \u0275\u0275classProp("mdc-evolution-chip", !ctx._isBasicChip)("mdc-evolution-chip--disabled", ctx.disabled)("mdc-evolution-chip--with-trailing-action", ctx._hasTrailingIcon())("mdc-evolution-chip--with-primary-graphic", ctx.leadingIcon)("mdc-evolution-chip--with-primary-icon", ctx.leadingIcon)("mdc-evolution-chip--with-avatar", ctx.leadingIcon)("mat-mdc-chip-with-avatar", ctx.leadingIcon)("mat-mdc-chip-highlighted", ctx.highlighted)("mat-mdc-chip-disabled", ctx.disabled)("mat-mdc-basic-chip", ctx._isBasicChip)("mat-mdc-standard-chip", !ctx._isBasicChip)("mat-mdc-chip-with-trailing-icon", ctx._hasTrailingIcon())("_mat-animation-noopable", ctx._animationsDisabled);
    }
  },
  inputs: {
    role: "role",
    id: "id",
    ariaLabel: [InputFlags.None, "aria-label", "ariaLabel"],
    ariaDescription: [InputFlags.None, "aria-description", "ariaDescription"],
    value: "value",
    color: "color",
    removable: [InputFlags.HasDecoratorInputTransform, "removable", "removable", booleanAttribute],
    highlighted: [InputFlags.HasDecoratorInputTransform, "highlighted", "highlighted", booleanAttribute],
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    tabIndex: [InputFlags.HasDecoratorInputTransform, "tabIndex", "tabIndex", (value) => value == null ? void 0 : numberAttribute(value)]
  },
  outputs: {
    removed: "removed",
    destroyed: "destroyed"
  },
  exportAs: ["matChip"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_CHIP,
    useExisting: _MatChip
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c1,
  decls: 8,
  vars: 3,
  consts: [[1, "mat-mdc-chip-focus-overlay"], [1, "mdc-evolution-chip__cell", "mdc-evolution-chip__cell--primary"], ["matChipAction", "", 3, "isInteractive"], [1, "mdc-evolution-chip__graphic", "mat-mdc-chip-graphic"], [1, "mdc-evolution-chip__text-label", "mat-mdc-chip-action-label"], [1, "mat-mdc-chip-primary-focus-indicator", "mat-mdc-focus-indicator"], [1, "mdc-evolution-chip__cell", "mdc-evolution-chip__cell--trailing"]],
  template: function MatChip_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef(_c0);
      \u0275\u0275element(0, "span", 0);
      \u0275\u0275elementStart(1, "span", 1)(2, "span", 2);
      \u0275\u0275template(3, MatChip_Conditional_3_Template, 2, 0, "span", 3);
      \u0275\u0275elementStart(4, "span", 4);
      \u0275\u0275projection(5);
      \u0275\u0275element(6, "span", 5);
      \u0275\u0275elementEnd()()();
      \u0275\u0275template(7, MatChip_Conditional_7_Template, 2, 0, "span", 6);
    }
    if (rf & 2) {
      \u0275\u0275advance(2);
      \u0275\u0275property("isInteractive", false);
      \u0275\u0275advance();
      \u0275\u0275conditional(3, ctx.leadingIcon ? 3 : -1);
      \u0275\u0275advance(4);
      \u0275\u0275conditional(7, ctx._hasTrailingIcon() ? 7 : -1);
    }
  },
  dependencies: [MatChipAction],
  styles: ['.mdc-evolution-chip,.mdc-evolution-chip__cell,.mdc-evolution-chip__action{display:inline-flex;align-items:center}.mdc-evolution-chip{position:relative;max-width:100%}.mdc-evolution-chip .mdc-elevation-overlay{width:100%;height:100%;top:0;left:0}.mdc-evolution-chip__cell,.mdc-evolution-chip__action{height:100%}.mdc-evolution-chip__cell--primary{overflow-x:hidden}.mdc-evolution-chip__cell--trailing{flex:1 0 auto}.mdc-evolution-chip__action{align-items:center;background:none;border:none;box-sizing:content-box;cursor:pointer;display:inline-flex;justify-content:center;outline:none;padding:0;text-decoration:none;color:inherit}.mdc-evolution-chip__action--presentational{cursor:auto}.mdc-evolution-chip--disabled,.mdc-evolution-chip__action:disabled{pointer-events:none}.mdc-evolution-chip__action--primary{overflow-x:hidden}.mdc-evolution-chip__action--trailing{position:relative;overflow:visible}.mdc-evolution-chip__action--primary:before{box-sizing:border-box;content:"";height:100%;left:0;position:absolute;pointer-events:none;top:0;width:100%;z-index:1}.mdc-evolution-chip--touch{margin-top:8px;margin-bottom:8px}.mdc-evolution-chip__action-touch{position:absolute;top:50%;height:48px;left:0;right:0;transform:translateY(-50%)}.mdc-evolution-chip__text-label{white-space:nowrap;user-select:none;text-overflow:ellipsis;overflow:hidden}.mdc-evolution-chip__graphic{align-items:center;display:inline-flex;justify-content:center;overflow:hidden;pointer-events:none;position:relative;flex:1 0 auto}.mdc-evolution-chip__checkmark{position:absolute;opacity:0;top:50%;left:50%}.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--selected):not(.mdc-evolution-chip--with-primary-icon) .mdc-evolution-chip__graphic{width:0}.mdc-evolution-chip__checkmark-background{opacity:0}.mdc-evolution-chip__checkmark-svg{display:block}.mdc-evolution-chip__checkmark-path{stroke-width:2px;stroke-dasharray:29.7833385;stroke-dashoffset:29.7833385;stroke:currentColor}.mdc-evolution-chip--selecting .mdc-evolution-chip__graphic{transition:width 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark{transition:transform 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__graphic{transition:width 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark{transition:opacity 50ms 0ms linear,transform 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-50%, -50%)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selected .mdc-evolution-chip__icon--primary{opacity:0}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{transform:translate(-50%, -50%);opacity:1}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}@keyframes mdc-evolution-chip-enter{from{transform:scale(0.8);opacity:.4}to{transform:scale(1);opacity:1}}.mdc-evolution-chip--enter{animation:mdc-evolution-chip-enter 100ms 0ms cubic-bezier(0, 0, 0.2, 1)}@keyframes mdc-evolution-chip-exit{from{opacity:1}to{opacity:0}}.mdc-evolution-chip--exit{animation:mdc-evolution-chip-exit 75ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mdc-evolution-chip--hidden{opacity:0;pointer-events:none;transition:width 150ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mat-mdc-standard-chip{border-radius:var(--mdc-chip-container-shape-radius);height:var(--mdc-chip-container-height)}.mat-mdc-standard-chip .mdc-evolution-chip__ripple{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{border-radius:var(--mdc-chip-with-avatar-avatar-shape-radius)}.mat-mdc-standard-chip.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--with-primary-icon){--mdc-chip-graphic-selected-width:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip .mdc-evolution-chip__graphic{height:var(--mdc-chip-with-avatar-avatar-size);width:var(--mdc-chip-with-avatar-avatar-size);font-size:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational).mdc-ripple-upgraded--background-focused:before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational):not(.mdc-ripple-upgraded):focus:before{border-color:var(--mdc-chip-focus-outline-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-disabled-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-outline-width)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-flat-selected-outline-width)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-selected-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-flat-disabled-selected-container-color)}.mat-mdc-standard-chip .mdc-evolution-chip__text-label{font-family:var(--mdc-chip-label-text-font);line-height:var(--mdc-chip-label-text-line-height);font-size:var(--mdc-chip-label-text-size);font-weight:var(--mdc-chip-label-text-weight);letter-spacing:var(--mdc-chip-label-text-tracking)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-selected-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{height:var(--mdc-chip-with-icon-icon-size);width:var(--mdc-chip-with-icon-icon-size);font-size:var(--mdc-chip-with-icon-icon-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-selected-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-hover-state-layer-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-selected-hover-state-layer-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color)}.mat-mdc-chip-selected .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color)}.mat-mdc-chip:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-hover-state-layer-color);opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-chip-selected:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-hover-state-layer-color);opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-chip.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color);opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-chip-selected.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color);opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mdc-evolution-chip--disabled:not(.mdc-evolution-chip--selected) .mat-mdc-chip-avatar{opacity:var(--mdc-chip-with-avatar-disabled-avatar-opacity)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{opacity:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity)}.mdc-evolution-chip--disabled.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{opacity:var(--mdc-chip-with-icon-disabled-icon-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{opacity:var(--mat-chip-disabled-container-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-disabled-trailing-icon-color)}.mat-mdc-chip-remove{opacity:var(--mat-chip-trailing-action-opacity)}.mat-mdc-chip-remove:focus{opacity:var(--mat-chip-trailing-action-focus-opacity)}.mat-mdc-chip-remove::after{background:var(--mat-chip-trailing-action-state-layer-color)}.mat-mdc-chip-remove:hover::after{opacity:var(--mat-chip-trailing-action-hover-state-layer-opacity)}.mat-mdc-chip-remove:focus::after{opacity:var(--mat-chip-trailing-action-focus-state-layer-opacity)}.mat-mdc-chip-selected .mat-mdc-chip-remove::after{background:var(--mat-chip-selected-trailing-action-state-layer-color)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove{opacity:calc(var(--mat-chip-trailing-action-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove:focus{opacity:calc(var(--mat-chip-trailing-action-focus-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-style:solid}.mat-mdc-standard-chip .mdc-evolution-chip__checkmark{height:20px;width:20px}.mat-mdc-standard-chip .mdc-evolution-chip__icon--trailing{height:18px;width:18px;font-size:18px}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mat-mdc-standard-chip{-webkit-tap-highlight-color:rgba(0,0,0,0)}.cdk-high-contrast-active .mat-mdc-standard-chip{outline:solid 1px}.cdk-high-contrast-active .mat-mdc-standard-chip .mdc-evolution-chip__checkmark-path{stroke:CanvasText !important}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mat-mdc-chip-action-label{overflow:visible}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary{flex-basis:100%}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{font:inherit;letter-spacing:inherit;white-space:inherit}.mat-mdc-standard-chip .mat-mdc-chip-graphic,.mat-mdc-standard-chip .mat-mdc-chip-trailing-icon{box-sizing:content-box}.mat-mdc-standard-chip._mat-animation-noopable,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__graphic,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark-path{transition-duration:1ms;animation-duration:1ms}.mat-mdc-basic-chip .mdc-evolution-chip__action--primary{font:inherit}.mat-mdc-chip-focus-overlay{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;opacity:0;border-radius:inherit;transition:opacity 150ms linear}._mat-animation-noopable .mat-mdc-chip-focus-overlay{transition:none}.mat-mdc-basic-chip .mat-mdc-chip-focus-overlay{display:none}.mat-mdc-chip .mat-ripple.mat-mdc-chip-ripple{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;border-radius:inherit}.mat-mdc-chip-avatar{text-align:center;line-height:1;color:var(--mdc-chip-with-icon-icon-color, currentColor)}.mat-mdc-chip{position:relative;z-index:0}.mat-mdc-chip-action-label{text-align:left;z-index:1}[dir=rtl] .mat-mdc-chip-action-label{text-align:right}.mat-mdc-chip.mdc-evolution-chip--with-trailing-action .mat-mdc-chip-action-label{position:relative}.mat-mdc-chip-action-label .mat-mdc-chip-primary-focus-indicator{position:absolute;top:0;right:0;bottom:0;left:0;pointer-events:none}.mat-mdc-chip-action-label .mat-mdc-focus-indicator::before{margin:calc(calc(var(--mat-mdc-focus-indicator-border-width, 3px) + 2px)*-1)}.mat-mdc-chip-remove::before{margin:calc(var(--mat-mdc-focus-indicator-border-width, 3px)*-1);left:8px;right:8px}.mat-mdc-chip-remove::after{content:"";display:block;opacity:0;position:absolute;top:-2px;bottom:-2px;left:6px;right:6px;border-radius:50%}.mat-mdc-chip-remove .mat-icon{width:18px;height:18px;font-size:18px;box-sizing:content-box}.mat-chip-edit-input{cursor:text;display:inline-block;color:inherit;outline:0}.cdk-high-contrast-active .mat-mdc-chip-selected:not(.mat-mdc-chip-multiple){outline-width:3px}.mat-mdc-chip-action:focus .mat-mdc-focus-indicator::before{content:""}'],
  encapsulation: 2,
  changeDetection: 0
});
var MatChip = _MatChip;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChip, [{
    type: Component,
    args: [{
      selector: "mat-basic-chip, [mat-basic-chip], mat-chip, [mat-chip]",
      exportAs: "matChip",
      host: {
        "class": "mat-mdc-chip",
        "[class]": '"mat-" + (color || "primary")',
        "[class.mdc-evolution-chip]": "!_isBasicChip",
        "[class.mdc-evolution-chip--disabled]": "disabled",
        "[class.mdc-evolution-chip--with-trailing-action]": "_hasTrailingIcon()",
        "[class.mdc-evolution-chip--with-primary-graphic]": "leadingIcon",
        "[class.mdc-evolution-chip--with-primary-icon]": "leadingIcon",
        "[class.mdc-evolution-chip--with-avatar]": "leadingIcon",
        "[class.mat-mdc-chip-with-avatar]": "leadingIcon",
        "[class.mat-mdc-chip-highlighted]": "highlighted",
        "[class.mat-mdc-chip-disabled]": "disabled",
        "[class.mat-mdc-basic-chip]": "_isBasicChip",
        "[class.mat-mdc-standard-chip]": "!_isBasicChip",
        "[class.mat-mdc-chip-with-trailing-icon]": "_hasTrailingIcon()",
        "[class._mat-animation-noopable]": "_animationsDisabled",
        "[id]": "id",
        "[attr.role]": "role",
        "[attr.tabindex]": "_getTabIndex()",
        "[attr.aria-label]": "ariaLabel",
        "(keydown)": "_handleKeydown($event)"
      },
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      providers: [{
        provide: MAT_CHIP,
        useExisting: MatChip
      }],
      standalone: true,
      imports: [MatChipAction],
      template: '<span class="mat-mdc-chip-focus-overlay"></span>\n\n<span class="mdc-evolution-chip__cell mdc-evolution-chip__cell--primary">\n  <span matChipAction [isInteractive]="false">\n    @if (leadingIcon) {\n      <span class="mdc-evolution-chip__graphic mat-mdc-chip-graphic">\n        <ng-content select="mat-chip-avatar, [matChipAvatar]"></ng-content>\n      </span>\n    }\n    <span class="mdc-evolution-chip__text-label mat-mdc-chip-action-label">\n      <ng-content></ng-content>\n      <span class="mat-mdc-chip-primary-focus-indicator mat-mdc-focus-indicator"></span>\n    </span>\n  </span>\n</span>\n\n@if (_hasTrailingIcon()) {\n  <span class="mdc-evolution-chip__cell mdc-evolution-chip__cell--trailing">\n    <ng-content select="mat-chip-trailing-icon,[matChipRemove],[matChipTrailingIcon]"></ng-content>\n  </span>\n}\n',
      styles: ['.mdc-evolution-chip,.mdc-evolution-chip__cell,.mdc-evolution-chip__action{display:inline-flex;align-items:center}.mdc-evolution-chip{position:relative;max-width:100%}.mdc-evolution-chip .mdc-elevation-overlay{width:100%;height:100%;top:0;left:0}.mdc-evolution-chip__cell,.mdc-evolution-chip__action{height:100%}.mdc-evolution-chip__cell--primary{overflow-x:hidden}.mdc-evolution-chip__cell--trailing{flex:1 0 auto}.mdc-evolution-chip__action{align-items:center;background:none;border:none;box-sizing:content-box;cursor:pointer;display:inline-flex;justify-content:center;outline:none;padding:0;text-decoration:none;color:inherit}.mdc-evolution-chip__action--presentational{cursor:auto}.mdc-evolution-chip--disabled,.mdc-evolution-chip__action:disabled{pointer-events:none}.mdc-evolution-chip__action--primary{overflow-x:hidden}.mdc-evolution-chip__action--trailing{position:relative;overflow:visible}.mdc-evolution-chip__action--primary:before{box-sizing:border-box;content:"";height:100%;left:0;position:absolute;pointer-events:none;top:0;width:100%;z-index:1}.mdc-evolution-chip--touch{margin-top:8px;margin-bottom:8px}.mdc-evolution-chip__action-touch{position:absolute;top:50%;height:48px;left:0;right:0;transform:translateY(-50%)}.mdc-evolution-chip__text-label{white-space:nowrap;user-select:none;text-overflow:ellipsis;overflow:hidden}.mdc-evolution-chip__graphic{align-items:center;display:inline-flex;justify-content:center;overflow:hidden;pointer-events:none;position:relative;flex:1 0 auto}.mdc-evolution-chip__checkmark{position:absolute;opacity:0;top:50%;left:50%}.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--selected):not(.mdc-evolution-chip--with-primary-icon) .mdc-evolution-chip__graphic{width:0}.mdc-evolution-chip__checkmark-background{opacity:0}.mdc-evolution-chip__checkmark-svg{display:block}.mdc-evolution-chip__checkmark-path{stroke-width:2px;stroke-dasharray:29.7833385;stroke-dashoffset:29.7833385;stroke:currentColor}.mdc-evolution-chip--selecting .mdc-evolution-chip__graphic{transition:width 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark{transition:transform 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__graphic{transition:width 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark{transition:opacity 50ms 0ms linear,transform 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-50%, -50%)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selected .mdc-evolution-chip__icon--primary{opacity:0}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{transform:translate(-50%, -50%);opacity:1}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}@keyframes mdc-evolution-chip-enter{from{transform:scale(0.8);opacity:.4}to{transform:scale(1);opacity:1}}.mdc-evolution-chip--enter{animation:mdc-evolution-chip-enter 100ms 0ms cubic-bezier(0, 0, 0.2, 1)}@keyframes mdc-evolution-chip-exit{from{opacity:1}to{opacity:0}}.mdc-evolution-chip--exit{animation:mdc-evolution-chip-exit 75ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mdc-evolution-chip--hidden{opacity:0;pointer-events:none;transition:width 150ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mat-mdc-standard-chip{border-radius:var(--mdc-chip-container-shape-radius);height:var(--mdc-chip-container-height)}.mat-mdc-standard-chip .mdc-evolution-chip__ripple{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{border-radius:var(--mdc-chip-with-avatar-avatar-shape-radius)}.mat-mdc-standard-chip.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--with-primary-icon){--mdc-chip-graphic-selected-width:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip .mdc-evolution-chip__graphic{height:var(--mdc-chip-with-avatar-avatar-size);width:var(--mdc-chip-with-avatar-avatar-size);font-size:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational).mdc-ripple-upgraded--background-focused:before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational):not(.mdc-ripple-upgraded):focus:before{border-color:var(--mdc-chip-focus-outline-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-disabled-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-outline-width)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-flat-selected-outline-width)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-selected-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-flat-disabled-selected-container-color)}.mat-mdc-standard-chip .mdc-evolution-chip__text-label{font-family:var(--mdc-chip-label-text-font);line-height:var(--mdc-chip-label-text-line-height);font-size:var(--mdc-chip-label-text-size);font-weight:var(--mdc-chip-label-text-weight);letter-spacing:var(--mdc-chip-label-text-tracking)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-selected-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{height:var(--mdc-chip-with-icon-icon-size);width:var(--mdc-chip-with-icon-icon-size);font-size:var(--mdc-chip-with-icon-icon-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-selected-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-hover-state-layer-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-selected-hover-state-layer-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color)}.mat-mdc-chip-selected .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color)}.mat-mdc-chip:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-hover-state-layer-color);opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-chip-selected:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-hover-state-layer-color);opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-chip.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color);opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-chip-selected.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color);opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mdc-evolution-chip--disabled:not(.mdc-evolution-chip--selected) .mat-mdc-chip-avatar{opacity:var(--mdc-chip-with-avatar-disabled-avatar-opacity)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{opacity:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity)}.mdc-evolution-chip--disabled.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{opacity:var(--mdc-chip-with-icon-disabled-icon-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{opacity:var(--mat-chip-disabled-container-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-disabled-trailing-icon-color)}.mat-mdc-chip-remove{opacity:var(--mat-chip-trailing-action-opacity)}.mat-mdc-chip-remove:focus{opacity:var(--mat-chip-trailing-action-focus-opacity)}.mat-mdc-chip-remove::after{background:var(--mat-chip-trailing-action-state-layer-color)}.mat-mdc-chip-remove:hover::after{opacity:var(--mat-chip-trailing-action-hover-state-layer-opacity)}.mat-mdc-chip-remove:focus::after{opacity:var(--mat-chip-trailing-action-focus-state-layer-opacity)}.mat-mdc-chip-selected .mat-mdc-chip-remove::after{background:var(--mat-chip-selected-trailing-action-state-layer-color)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove{opacity:calc(var(--mat-chip-trailing-action-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove:focus{opacity:calc(var(--mat-chip-trailing-action-focus-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-style:solid}.mat-mdc-standard-chip .mdc-evolution-chip__checkmark{height:20px;width:20px}.mat-mdc-standard-chip .mdc-evolution-chip__icon--trailing{height:18px;width:18px;font-size:18px}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mat-mdc-standard-chip{-webkit-tap-highlight-color:rgba(0,0,0,0)}.cdk-high-contrast-active .mat-mdc-standard-chip{outline:solid 1px}.cdk-high-contrast-active .mat-mdc-standard-chip .mdc-evolution-chip__checkmark-path{stroke:CanvasText !important}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mat-mdc-chip-action-label{overflow:visible}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary{flex-basis:100%}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{font:inherit;letter-spacing:inherit;white-space:inherit}.mat-mdc-standard-chip .mat-mdc-chip-graphic,.mat-mdc-standard-chip .mat-mdc-chip-trailing-icon{box-sizing:content-box}.mat-mdc-standard-chip._mat-animation-noopable,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__graphic,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark-path{transition-duration:1ms;animation-duration:1ms}.mat-mdc-basic-chip .mdc-evolution-chip__action--primary{font:inherit}.mat-mdc-chip-focus-overlay{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;opacity:0;border-radius:inherit;transition:opacity 150ms linear}._mat-animation-noopable .mat-mdc-chip-focus-overlay{transition:none}.mat-mdc-basic-chip .mat-mdc-chip-focus-overlay{display:none}.mat-mdc-chip .mat-ripple.mat-mdc-chip-ripple{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;border-radius:inherit}.mat-mdc-chip-avatar{text-align:center;line-height:1;color:var(--mdc-chip-with-icon-icon-color, currentColor)}.mat-mdc-chip{position:relative;z-index:0}.mat-mdc-chip-action-label{text-align:left;z-index:1}[dir=rtl] .mat-mdc-chip-action-label{text-align:right}.mat-mdc-chip.mdc-evolution-chip--with-trailing-action .mat-mdc-chip-action-label{position:relative}.mat-mdc-chip-action-label .mat-mdc-chip-primary-focus-indicator{position:absolute;top:0;right:0;bottom:0;left:0;pointer-events:none}.mat-mdc-chip-action-label .mat-mdc-focus-indicator::before{margin:calc(calc(var(--mat-mdc-focus-indicator-border-width, 3px) + 2px)*-1)}.mat-mdc-chip-remove::before{margin:calc(var(--mat-mdc-focus-indicator-border-width, 3px)*-1);left:8px;right:8px}.mat-mdc-chip-remove::after{content:"";display:block;opacity:0;position:absolute;top:-2px;bottom:-2px;left:6px;right:6px;border-radius:50%}.mat-mdc-chip-remove .mat-icon{width:18px;height:18px;font-size:18px;box-sizing:content-box}.mat-chip-edit-input{cursor:text;display:inline-block;color:inherit;outline:0}.cdk-high-contrast-active .mat-mdc-chip-selected:not(.mat-mdc-chip-multiple){outline-width:3px}.mat-mdc-chip-action:focus .mat-mdc-focus-indicator::before{content:""}']
    }]
  }], () => [{
    type: ChangeDetectorRef
  }, {
    type: ElementRef
  }, {
    type: NgZone
  }, {
    type: FocusMonitor
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [DOCUMENT]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_RIPPLE_GLOBAL_OPTIONS]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Attribute,
      args: ["tabindex"]
    }]
  }], {
    role: [{
      type: Input
    }],
    _allLeadingIcons: [{
      type: ContentChildren,
      args: [MAT_CHIP_AVATAR, {
        descendants: true
      }]
    }],
    _allTrailingIcons: [{
      type: ContentChildren,
      args: [MAT_CHIP_TRAILING_ICON, {
        descendants: true
      }]
    }],
    _allRemoveIcons: [{
      type: ContentChildren,
      args: [MAT_CHIP_REMOVE, {
        descendants: true
      }]
    }],
    id: [{
      type: Input
    }],
    ariaLabel: [{
      type: Input,
      args: ["aria-label"]
    }],
    ariaDescription: [{
      type: Input,
      args: ["aria-description"]
    }],
    value: [{
      type: Input
    }],
    color: [{
      type: Input
    }],
    removable: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    highlighted: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    tabIndex: [{
      type: Input,
      args: [{
        transform: (value) => value == null ? void 0 : numberAttribute(value)
      }]
    }],
    removed: [{
      type: Output
    }],
    destroyed: [{
      type: Output
    }],
    leadingIcon: [{
      type: ContentChild,
      args: [MAT_CHIP_AVATAR]
    }],
    trailingIcon: [{
      type: ContentChild,
      args: [MAT_CHIP_TRAILING_ICON]
    }],
    removeIcon: [{
      type: ContentChild,
      args: [MAT_CHIP_REMOVE]
    }],
    primaryAction: [{
      type: ViewChild,
      args: [MatChipAction]
    }]
  });
})();
var _MatChipOption = class _MatChipOption extends MatChip {
  constructor() {
    super(...arguments);
    this._defaultOptions = inject(MAT_CHIPS_DEFAULT_OPTIONS, {
      optional: true
    });
    this.chipListSelectable = true;
    this._chipListMultiple = false;
    this._chipListHideSingleSelectionIndicator = this._defaultOptions?.hideSingleSelectionIndicator ?? false;
    this._selectable = true;
    this._selected = false;
    this.basicChipAttrName = "mat-basic-chip-option";
    this.selectionChange = new EventEmitter();
  }
  /**
   * Whether or not the chip is selectable.
   *
   * When a chip is not selectable, changes to its selected state are always
   * ignored. By default an option chip is selectable, and it becomes
   * non-selectable if its parent chip list is not selectable.
   */
  get selectable() {
    return this._selectable && this.chipListSelectable;
  }
  set selectable(value) {
    this._selectable = value;
    this._changeDetectorRef.markForCheck();
  }
  /** Whether the chip is selected. */
  get selected() {
    return this._selected;
  }
  set selected(value) {
    this._setSelectedState(value, false, true);
  }
  /**
   * The ARIA selected applied to the chip. Conforms to WAI ARIA best practices for listbox
   * interaction patterns.
   *
   * From [WAI ARIA Listbox authoring practices guide](
   * https://www.w3.org/WAI/ARIA/apg/patterns/listbox/):
   *  "If any options are selected, each selected option has either aria-selected or aria-checked
   *  set to true. All options that are selectable but not selected have either aria-selected or
   *  aria-checked set to false."
   *
   * Set `aria-selected="false"` on not-selected listbox options that are selectable to fix
   * VoiceOver reading every option as "selected" (#25736).
   */
  get ariaSelected() {
    return this.selectable ? this.selected.toString() : null;
  }
  ngOnInit() {
    super.ngOnInit();
    this.role = "presentation";
  }
  /** Selects the chip. */
  select() {
    this._setSelectedState(true, false, true);
  }
  /** Deselects the chip. */
  deselect() {
    this._setSelectedState(false, false, true);
  }
  /** Selects this chip and emits userInputSelection event */
  selectViaInteraction() {
    this._setSelectedState(true, true, true);
  }
  /** Toggles the current selected state of this chip. */
  toggleSelected(isUserInput = false) {
    this._setSelectedState(!this.selected, isUserInput, true);
    return this.selected;
  }
  _handlePrimaryActionInteraction() {
    if (!this.disabled) {
      this.focus();
      if (this.selectable) {
        this.toggleSelected(true);
      }
    }
  }
  _hasLeadingGraphic() {
    if (this.leadingIcon) {
      return true;
    }
    return !this._chipListHideSingleSelectionIndicator || this._chipListMultiple;
  }
  _setSelectedState(isSelected, isUserInput, emitEvent) {
    if (isSelected !== this.selected) {
      this._selected = isSelected;
      if (emitEvent) {
        this.selectionChange.emit({
          source: this,
          isUserInput,
          selected: this.selected
        });
      }
      this._changeDetectorRef.markForCheck();
    }
  }
};
_MatChipOption.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatChipOption_BaseFactory;
  return function MatChipOption_Factory(t) {
    return (\u0275MatChipOption_BaseFactory || (\u0275MatChipOption_BaseFactory = \u0275\u0275getInheritedFactory(_MatChipOption)))(t || _MatChipOption);
  };
})();
_MatChipOption.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatChipOption,
  selectors: [["mat-basic-chip-option"], ["", "mat-basic-chip-option", ""], ["mat-chip-option"], ["", "mat-chip-option", ""]],
  hostAttrs: [1, "mat-mdc-chip", "mat-mdc-chip-option"],
  hostVars: 37,
  hostBindings: function MatChipOption_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275hostProperty("id", ctx.id);
      \u0275\u0275attribute("tabindex", null)("aria-label", null)("aria-description", null)("role", ctx.role);
      \u0275\u0275classProp("mdc-evolution-chip", !ctx._isBasicChip)("mdc-evolution-chip--filter", !ctx._isBasicChip)("mdc-evolution-chip--selectable", !ctx._isBasicChip)("mat-mdc-chip-selected", ctx.selected)("mat-mdc-chip-multiple", ctx._chipListMultiple)("mat-mdc-chip-disabled", ctx.disabled)("mat-mdc-chip-with-avatar", ctx.leadingIcon)("mdc-evolution-chip--disabled", ctx.disabled)("mdc-evolution-chip--selected", ctx.selected)("mdc-evolution-chip--selecting", !ctx._animationsDisabled)("mdc-evolution-chip--with-trailing-action", ctx._hasTrailingIcon())("mdc-evolution-chip--with-primary-icon", ctx.leadingIcon)("mdc-evolution-chip--with-primary-graphic", ctx._hasLeadingGraphic())("mdc-evolution-chip--with-avatar", ctx.leadingIcon)("mat-mdc-chip-highlighted", ctx.highlighted)("mat-mdc-chip-with-trailing-icon", ctx._hasTrailingIcon());
    }
  },
  inputs: {
    selectable: [InputFlags.HasDecoratorInputTransform, "selectable", "selectable", booleanAttribute],
    selected: [InputFlags.HasDecoratorInputTransform, "selected", "selected", booleanAttribute]
  },
  outputs: {
    selectionChange: "selectionChange"
  },
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MatChip,
    useExisting: _MatChipOption
  }, {
    provide: MAT_CHIP,
    useExisting: _MatChipOption
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c1,
  decls: 10,
  vars: 9,
  consts: [[1, "mat-mdc-chip-focus-overlay"], [1, "mdc-evolution-chip__cell", "mdc-evolution-chip__cell--primary"], ["matChipAction", "", "role", "option", 3, "tabIndex", "_allowFocusWhenDisabled"], [1, "mdc-evolution-chip__graphic", "mat-mdc-chip-graphic"], [1, "mdc-evolution-chip__text-label", "mat-mdc-chip-action-label"], [1, "mat-mdc-chip-primary-focus-indicator", "mat-mdc-focus-indicator"], [1, "mdc-evolution-chip__cell", "mdc-evolution-chip__cell--trailing"], [1, "cdk-visually-hidden", 3, "id"], [1, "mdc-evolution-chip__checkmark"], ["viewBox", "-2 -3 30 30", "focusable", "false", "aria-hidden", "true", 1, "mdc-evolution-chip__checkmark-svg"], ["fill", "none", "stroke", "currentColor", "d", "M1.73,12.91 8.1,19.28 22.79,4.59", 1, "mdc-evolution-chip__checkmark-path"]],
  template: function MatChipOption_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef(_c0);
      \u0275\u0275element(0, "span", 0);
      \u0275\u0275elementStart(1, "span", 1)(2, "button", 2);
      \u0275\u0275template(3, MatChipOption_Conditional_3_Template, 5, 0, "span", 3);
      \u0275\u0275elementStart(4, "span", 4);
      \u0275\u0275projection(5);
      \u0275\u0275element(6, "span", 5);
      \u0275\u0275elementEnd()()();
      \u0275\u0275template(7, MatChipOption_Conditional_7_Template, 2, 0, "span", 6);
      \u0275\u0275elementStart(8, "span", 7);
      \u0275\u0275text(9);
      \u0275\u0275elementEnd();
    }
    if (rf & 2) {
      \u0275\u0275advance(2);
      \u0275\u0275property("tabIndex", ctx.tabIndex)("_allowFocusWhenDisabled", true);
      \u0275\u0275attribute("aria-selected", ctx.ariaSelected)("aria-label", ctx.ariaLabel)("aria-describedby", ctx._ariaDescriptionId);
      \u0275\u0275advance();
      \u0275\u0275conditional(3, ctx._hasLeadingGraphic() ? 3 : -1);
      \u0275\u0275advance(4);
      \u0275\u0275conditional(7, ctx._hasTrailingIcon() ? 7 : -1);
      \u0275\u0275advance();
      \u0275\u0275property("id", ctx._ariaDescriptionId);
      \u0275\u0275advance();
      \u0275\u0275textInterpolate(ctx.ariaDescription);
    }
  },
  dependencies: [MatChipAction],
  styles: [_c2],
  encapsulation: 2,
  changeDetection: 0
});
var MatChipOption = _MatChipOption;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipOption, [{
    type: Component,
    args: [{
      selector: "mat-basic-chip-option, [mat-basic-chip-option], mat-chip-option, [mat-chip-option]",
      host: {
        "class": "mat-mdc-chip mat-mdc-chip-option",
        "[class.mdc-evolution-chip]": "!_isBasicChip",
        "[class.mdc-evolution-chip--filter]": "!_isBasicChip",
        "[class.mdc-evolution-chip--selectable]": "!_isBasicChip",
        "[class.mat-mdc-chip-selected]": "selected",
        "[class.mat-mdc-chip-multiple]": "_chipListMultiple",
        "[class.mat-mdc-chip-disabled]": "disabled",
        "[class.mat-mdc-chip-with-avatar]": "leadingIcon",
        "[class.mdc-evolution-chip--disabled]": "disabled",
        "[class.mdc-evolution-chip--selected]": "selected",
        // This class enables the transition on the checkmark. Usually MDC adds it when selection
        // starts and removes it once the animation is finished. We don't need to go through all
        // the trouble, because we only care about the selection animation. MDC needs to do it,
        // because they also have an exit animation that we don't care about.
        "[class.mdc-evolution-chip--selecting]": "!_animationsDisabled",
        "[class.mdc-evolution-chip--with-trailing-action]": "_hasTrailingIcon()",
        "[class.mdc-evolution-chip--with-primary-icon]": "leadingIcon",
        "[class.mdc-evolution-chip--with-primary-graphic]": "_hasLeadingGraphic()",
        "[class.mdc-evolution-chip--with-avatar]": "leadingIcon",
        "[class.mat-mdc-chip-highlighted]": "highlighted",
        "[class.mat-mdc-chip-with-trailing-icon]": "_hasTrailingIcon()",
        "[attr.tabindex]": "null",
        "[attr.aria-label]": "null",
        "[attr.aria-description]": "null",
        "[attr.role]": "role",
        "[id]": "id"
      },
      providers: [{
        provide: MatChip,
        useExisting: MatChipOption
      }, {
        provide: MAT_CHIP,
        useExisting: MatChipOption
      }],
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true,
      imports: [MatChipAction],
      template: '<span class="mat-mdc-chip-focus-overlay"></span>\n\n<span class="mdc-evolution-chip__cell mdc-evolution-chip__cell--primary">\n  <button\n    matChipAction\n    [tabIndex]="tabIndex"\n    [_allowFocusWhenDisabled]="true"\n    [attr.aria-selected]="ariaSelected"\n    [attr.aria-label]="ariaLabel"\n    [attr.aria-describedby]="_ariaDescriptionId"\n    role="option">\n    @if (_hasLeadingGraphic()) {\n      <span class="mdc-evolution-chip__graphic mat-mdc-chip-graphic">\n        <ng-content select="mat-chip-avatar, [matChipAvatar]"></ng-content>\n        <span class="mdc-evolution-chip__checkmark">\n          <svg\n            class="mdc-evolution-chip__checkmark-svg"\n            viewBox="-2 -3 30 30"\n            focusable="false"\n            aria-hidden="true">\n            <path class="mdc-evolution-chip__checkmark-path"\n                  fill="none" stroke="currentColor" d="M1.73,12.91 8.1,19.28 22.79,4.59" />\n          </svg>\n        </span>\n      </span>\n    }\n    <span class="mdc-evolution-chip__text-label mat-mdc-chip-action-label">\n      <ng-content></ng-content>\n      <span class="mat-mdc-chip-primary-focus-indicator mat-mdc-focus-indicator"></span>\n    </span>\n  </button>\n</span>\n\n@if (_hasTrailingIcon()) {\n  <span class="mdc-evolution-chip__cell mdc-evolution-chip__cell--trailing">\n    <ng-content select="mat-chip-trailing-icon,[matChipRemove],[matChipTrailingIcon]"></ng-content>\n  </span>\n}\n\n<span class="cdk-visually-hidden" [id]="_ariaDescriptionId">{{ariaDescription}}</span>\n',
      styles: ['.mdc-evolution-chip,.mdc-evolution-chip__cell,.mdc-evolution-chip__action{display:inline-flex;align-items:center}.mdc-evolution-chip{position:relative;max-width:100%}.mdc-evolution-chip .mdc-elevation-overlay{width:100%;height:100%;top:0;left:0}.mdc-evolution-chip__cell,.mdc-evolution-chip__action{height:100%}.mdc-evolution-chip__cell--primary{overflow-x:hidden}.mdc-evolution-chip__cell--trailing{flex:1 0 auto}.mdc-evolution-chip__action{align-items:center;background:none;border:none;box-sizing:content-box;cursor:pointer;display:inline-flex;justify-content:center;outline:none;padding:0;text-decoration:none;color:inherit}.mdc-evolution-chip__action--presentational{cursor:auto}.mdc-evolution-chip--disabled,.mdc-evolution-chip__action:disabled{pointer-events:none}.mdc-evolution-chip__action--primary{overflow-x:hidden}.mdc-evolution-chip__action--trailing{position:relative;overflow:visible}.mdc-evolution-chip__action--primary:before{box-sizing:border-box;content:"";height:100%;left:0;position:absolute;pointer-events:none;top:0;width:100%;z-index:1}.mdc-evolution-chip--touch{margin-top:8px;margin-bottom:8px}.mdc-evolution-chip__action-touch{position:absolute;top:50%;height:48px;left:0;right:0;transform:translateY(-50%)}.mdc-evolution-chip__text-label{white-space:nowrap;user-select:none;text-overflow:ellipsis;overflow:hidden}.mdc-evolution-chip__graphic{align-items:center;display:inline-flex;justify-content:center;overflow:hidden;pointer-events:none;position:relative;flex:1 0 auto}.mdc-evolution-chip__checkmark{position:absolute;opacity:0;top:50%;left:50%}.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--selected):not(.mdc-evolution-chip--with-primary-icon) .mdc-evolution-chip__graphic{width:0}.mdc-evolution-chip__checkmark-background{opacity:0}.mdc-evolution-chip__checkmark-svg{display:block}.mdc-evolution-chip__checkmark-path{stroke-width:2px;stroke-dasharray:29.7833385;stroke-dashoffset:29.7833385;stroke:currentColor}.mdc-evolution-chip--selecting .mdc-evolution-chip__graphic{transition:width 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark{transition:transform 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__graphic{transition:width 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark{transition:opacity 50ms 0ms linear,transform 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-50%, -50%)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selected .mdc-evolution-chip__icon--primary{opacity:0}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{transform:translate(-50%, -50%);opacity:1}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}@keyframes mdc-evolution-chip-enter{from{transform:scale(0.8);opacity:.4}to{transform:scale(1);opacity:1}}.mdc-evolution-chip--enter{animation:mdc-evolution-chip-enter 100ms 0ms cubic-bezier(0, 0, 0.2, 1)}@keyframes mdc-evolution-chip-exit{from{opacity:1}to{opacity:0}}.mdc-evolution-chip--exit{animation:mdc-evolution-chip-exit 75ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mdc-evolution-chip--hidden{opacity:0;pointer-events:none;transition:width 150ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mat-mdc-standard-chip{border-radius:var(--mdc-chip-container-shape-radius);height:var(--mdc-chip-container-height)}.mat-mdc-standard-chip .mdc-evolution-chip__ripple{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{border-radius:var(--mdc-chip-with-avatar-avatar-shape-radius)}.mat-mdc-standard-chip.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--with-primary-icon){--mdc-chip-graphic-selected-width:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip .mdc-evolution-chip__graphic{height:var(--mdc-chip-with-avatar-avatar-size);width:var(--mdc-chip-with-avatar-avatar-size);font-size:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational).mdc-ripple-upgraded--background-focused:before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational):not(.mdc-ripple-upgraded):focus:before{border-color:var(--mdc-chip-focus-outline-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-disabled-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-outline-width)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-flat-selected-outline-width)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-selected-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-flat-disabled-selected-container-color)}.mat-mdc-standard-chip .mdc-evolution-chip__text-label{font-family:var(--mdc-chip-label-text-font);line-height:var(--mdc-chip-label-text-line-height);font-size:var(--mdc-chip-label-text-size);font-weight:var(--mdc-chip-label-text-weight);letter-spacing:var(--mdc-chip-label-text-tracking)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-selected-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{height:var(--mdc-chip-with-icon-icon-size);width:var(--mdc-chip-with-icon-icon-size);font-size:var(--mdc-chip-with-icon-icon-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-selected-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-hover-state-layer-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-selected-hover-state-layer-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color)}.mat-mdc-chip-selected .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color)}.mat-mdc-chip:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-hover-state-layer-color);opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-chip-selected:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-hover-state-layer-color);opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-chip.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color);opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-chip-selected.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color);opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mdc-evolution-chip--disabled:not(.mdc-evolution-chip--selected) .mat-mdc-chip-avatar{opacity:var(--mdc-chip-with-avatar-disabled-avatar-opacity)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{opacity:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity)}.mdc-evolution-chip--disabled.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{opacity:var(--mdc-chip-with-icon-disabled-icon-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{opacity:var(--mat-chip-disabled-container-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-disabled-trailing-icon-color)}.mat-mdc-chip-remove{opacity:var(--mat-chip-trailing-action-opacity)}.mat-mdc-chip-remove:focus{opacity:var(--mat-chip-trailing-action-focus-opacity)}.mat-mdc-chip-remove::after{background:var(--mat-chip-trailing-action-state-layer-color)}.mat-mdc-chip-remove:hover::after{opacity:var(--mat-chip-trailing-action-hover-state-layer-opacity)}.mat-mdc-chip-remove:focus::after{opacity:var(--mat-chip-trailing-action-focus-state-layer-opacity)}.mat-mdc-chip-selected .mat-mdc-chip-remove::after{background:var(--mat-chip-selected-trailing-action-state-layer-color)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove{opacity:calc(var(--mat-chip-trailing-action-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove:focus{opacity:calc(var(--mat-chip-trailing-action-focus-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-style:solid}.mat-mdc-standard-chip .mdc-evolution-chip__checkmark{height:20px;width:20px}.mat-mdc-standard-chip .mdc-evolution-chip__icon--trailing{height:18px;width:18px;font-size:18px}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mat-mdc-standard-chip{-webkit-tap-highlight-color:rgba(0,0,0,0)}.cdk-high-contrast-active .mat-mdc-standard-chip{outline:solid 1px}.cdk-high-contrast-active .mat-mdc-standard-chip .mdc-evolution-chip__checkmark-path{stroke:CanvasText !important}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mat-mdc-chip-action-label{overflow:visible}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary{flex-basis:100%}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{font:inherit;letter-spacing:inherit;white-space:inherit}.mat-mdc-standard-chip .mat-mdc-chip-graphic,.mat-mdc-standard-chip .mat-mdc-chip-trailing-icon{box-sizing:content-box}.mat-mdc-standard-chip._mat-animation-noopable,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__graphic,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark-path{transition-duration:1ms;animation-duration:1ms}.mat-mdc-basic-chip .mdc-evolution-chip__action--primary{font:inherit}.mat-mdc-chip-focus-overlay{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;opacity:0;border-radius:inherit;transition:opacity 150ms linear}._mat-animation-noopable .mat-mdc-chip-focus-overlay{transition:none}.mat-mdc-basic-chip .mat-mdc-chip-focus-overlay{display:none}.mat-mdc-chip .mat-ripple.mat-mdc-chip-ripple{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;border-radius:inherit}.mat-mdc-chip-avatar{text-align:center;line-height:1;color:var(--mdc-chip-with-icon-icon-color, currentColor)}.mat-mdc-chip{position:relative;z-index:0}.mat-mdc-chip-action-label{text-align:left;z-index:1}[dir=rtl] .mat-mdc-chip-action-label{text-align:right}.mat-mdc-chip.mdc-evolution-chip--with-trailing-action .mat-mdc-chip-action-label{position:relative}.mat-mdc-chip-action-label .mat-mdc-chip-primary-focus-indicator{position:absolute;top:0;right:0;bottom:0;left:0;pointer-events:none}.mat-mdc-chip-action-label .mat-mdc-focus-indicator::before{margin:calc(calc(var(--mat-mdc-focus-indicator-border-width, 3px) + 2px)*-1)}.mat-mdc-chip-remove::before{margin:calc(var(--mat-mdc-focus-indicator-border-width, 3px)*-1);left:8px;right:8px}.mat-mdc-chip-remove::after{content:"";display:block;opacity:0;position:absolute;top:-2px;bottom:-2px;left:6px;right:6px;border-radius:50%}.mat-mdc-chip-remove .mat-icon{width:18px;height:18px;font-size:18px;box-sizing:content-box}.mat-chip-edit-input{cursor:text;display:inline-block;color:inherit;outline:0}.cdk-high-contrast-active .mat-mdc-chip-selected:not(.mat-mdc-chip-multiple){outline-width:3px}.mat-mdc-chip-action:focus .mat-mdc-focus-indicator::before{content:""}']
    }]
  }], null, {
    selectable: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    selected: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    selectionChange: [{
      type: Output
    }]
  });
})();
var _MatChipEditInput = class _MatChipEditInput {
  constructor(_elementRef, _document) {
    this._elementRef = _elementRef;
    this._document = _document;
  }
  initialize(initialValue) {
    this.getNativeElement().focus();
    this.setValue(initialValue);
  }
  getNativeElement() {
    return this._elementRef.nativeElement;
  }
  setValue(value) {
    this.getNativeElement().textContent = value;
    this._moveCursorToEndOfInput();
  }
  getValue() {
    return this.getNativeElement().textContent || "";
  }
  _moveCursorToEndOfInput() {
    const range = this._document.createRange();
    range.selectNodeContents(this.getNativeElement());
    range.collapse(false);
    const sel = window.getSelection();
    sel.removeAllRanges();
    sel.addRange(range);
  }
};
_MatChipEditInput.\u0275fac = function MatChipEditInput_Factory(t) {
  return new (t || _MatChipEditInput)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(DOCUMENT));
};
_MatChipEditInput.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatChipEditInput,
  selectors: [["span", "matChipEditInput", ""]],
  hostAttrs: ["role", "textbox", "tabindex", "-1", "contenteditable", "true", 1, "mat-chip-edit-input"],
  standalone: true
});
var MatChipEditInput = _MatChipEditInput;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipEditInput, [{
    type: Directive,
    args: [{
      selector: "span[matChipEditInput]",
      host: {
        "class": "mat-chip-edit-input",
        "role": "textbox",
        "tabindex": "-1",
        "contenteditable": "true"
      },
      standalone: true
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [DOCUMENT]
    }]
  }], null);
})();
var _MatChipRow = class _MatChipRow extends MatChip {
  constructor(changeDetectorRef, elementRef, ngZone, focusMonitor, _document, animationMode, globalRippleOptions, tabIndex) {
    super(changeDetectorRef, elementRef, ngZone, focusMonitor, _document, animationMode, globalRippleOptions, tabIndex);
    this.basicChipAttrName = "mat-basic-chip-row";
    this._editStartPending = false;
    this.editable = false;
    this.edited = new EventEmitter();
    this._isEditing = false;
    this.role = "row";
    this._onBlur.pipe(takeUntil(this.destroyed)).subscribe(() => {
      if (this._isEditing && !this._editStartPending) {
        this._onEditFinish();
      }
    });
  }
  _hasTrailingIcon() {
    return !this._isEditing && super._hasTrailingIcon();
  }
  /** Sends focus to the first gridcell when the user clicks anywhere inside the chip. */
  _handleFocus() {
    if (!this._isEditing && !this.disabled) {
      this.focus();
    }
  }
  _handleKeydown(event) {
    if (event.keyCode === ENTER && !this.disabled) {
      if (this._isEditing) {
        event.preventDefault();
        this._onEditFinish();
      } else if (this.editable) {
        this._startEditing(event);
      }
    } else if (this._isEditing) {
      event.stopPropagation();
    } else {
      super._handleKeydown(event);
    }
  }
  _handleDoubleclick(event) {
    if (!this.disabled && this.editable) {
      this._startEditing(event);
    }
  }
  _startEditing(event) {
    if (!this.primaryAction || this.removeIcon && this._getSourceAction(event.target) === this.removeIcon) {
      return;
    }
    const value = this.value;
    this._isEditing = this._editStartPending = true;
    this._changeDetectorRef.detectChanges();
    setTimeout(() => {
      this._getEditInput().initialize(value);
      this._editStartPending = false;
    });
  }
  _onEditFinish() {
    this._isEditing = this._editStartPending = false;
    this.edited.emit({
      chip: this,
      value: this._getEditInput().getValue()
    });
    if (this._document.activeElement === this._getEditInput().getNativeElement() || this._document.activeElement === this._document.body) {
      this.primaryAction.focus();
    }
  }
  _isRippleDisabled() {
    return super._isRippleDisabled() || this._isEditing;
  }
  /**
   * Gets the projected chip edit input, or the default input if none is projected in. One of these
   * two values is guaranteed to be defined.
   */
  _getEditInput() {
    return this.contentEditInput || this.defaultEditInput;
  }
};
_MatChipRow.\u0275fac = function MatChipRow_Factory(t) {
  return new (t || _MatChipRow)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(FocusMonitor), \u0275\u0275directiveInject(DOCUMENT), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8), \u0275\u0275directiveInject(MAT_RIPPLE_GLOBAL_OPTIONS, 8), \u0275\u0275injectAttribute("tabindex"));
};
_MatChipRow.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatChipRow,
  selectors: [["mat-chip-row"], ["", "mat-chip-row", ""], ["mat-basic-chip-row"], ["", "mat-basic-chip-row", ""]],
  contentQueries: function MatChipRow_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatChipEditInput, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.contentEditInput = _t.first);
    }
  },
  viewQuery: function MatChipRow_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(MatChipEditInput, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.defaultEditInput = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-chip", "mat-mdc-chip-row", "mdc-evolution-chip"],
  hostVars: 27,
  hostBindings: function MatChipRow_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("focus", function MatChipRow_focus_HostBindingHandler($event) {
        return ctx._handleFocus($event);
      })("dblclick", function MatChipRow_dblclick_HostBindingHandler($event) {
        return ctx._handleDoubleclick($event);
      });
    }
    if (rf & 2) {
      \u0275\u0275hostProperty("id", ctx.id);
      \u0275\u0275attribute("tabindex", ctx.disabled ? null : -1)("aria-label", null)("aria-description", null)("role", ctx.role);
      \u0275\u0275classProp("mat-mdc-chip-with-avatar", ctx.leadingIcon)("mat-mdc-chip-disabled", ctx.disabled)("mat-mdc-chip-editing", ctx._isEditing)("mat-mdc-chip-editable", ctx.editable)("mdc-evolution-chip--disabled", ctx.disabled)("mdc-evolution-chip--with-trailing-action", ctx._hasTrailingIcon())("mdc-evolution-chip--with-primary-graphic", ctx.leadingIcon)("mdc-evolution-chip--with-primary-icon", ctx.leadingIcon)("mdc-evolution-chip--with-avatar", ctx.leadingIcon)("mat-mdc-chip-highlighted", ctx.highlighted)("mat-mdc-chip-with-trailing-icon", ctx._hasTrailingIcon());
    }
  },
  inputs: {
    editable: "editable"
  },
  outputs: {
    edited: "edited"
  },
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MatChip,
    useExisting: _MatChipRow
  }, {
    provide: MAT_CHIP,
    useExisting: _MatChipRow
  }]), \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c4,
  decls: 10,
  vars: 10,
  consts: [[1, "mat-mdc-chip-focus-overlay"], ["role", "gridcell", "matChipAction", "", 1, "mdc-evolution-chip__cell", "mdc-evolution-chip__cell--primary", 3, "tabIndex", "disabled"], [1, "mdc-evolution-chip__graphic", "mat-mdc-chip-graphic"], [1, "mdc-evolution-chip__text-label", "mat-mdc-chip-action-label"], ["aria-hidden", "true", 1, "mat-mdc-chip-primary-focus-indicator", "mat-mdc-focus-indicator"], ["role", "gridcell", 1, "mdc-evolution-chip__cell", "mdc-evolution-chip__cell--trailing"], [1, "cdk-visually-hidden", 3, "id"], ["matChipEditInput", ""]],
  template: function MatChipRow_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef(_c3);
      \u0275\u0275template(0, MatChipRow_Conditional_0_Template, 1, 0, "span", 0);
      \u0275\u0275elementStart(1, "span", 1);
      \u0275\u0275template(2, MatChipRow_Conditional_2_Template, 2, 0, "span", 2);
      \u0275\u0275elementStart(3, "span", 3);
      \u0275\u0275template(4, MatChipRow_Conditional_4_Template, 2, 1)(5, MatChipRow_Conditional_5_Template, 1, 0);
      \u0275\u0275element(6, "span", 4);
      \u0275\u0275elementEnd()();
      \u0275\u0275template(7, MatChipRow_Conditional_7_Template, 2, 0, "span", 5);
      \u0275\u0275elementStart(8, "span", 6);
      \u0275\u0275text(9);
      \u0275\u0275elementEnd();
    }
    if (rf & 2) {
      \u0275\u0275conditional(0, !ctx._isEditing ? 0 : -1);
      \u0275\u0275advance();
      \u0275\u0275property("tabIndex", ctx.tabIndex)("disabled", ctx.disabled);
      \u0275\u0275attribute("aria-label", ctx.ariaLabel)("aria-describedby", ctx._ariaDescriptionId);
      \u0275\u0275advance();
      \u0275\u0275conditional(2, ctx.leadingIcon ? 2 : -1);
      \u0275\u0275advance(2);
      \u0275\u0275conditional(4, ctx._isEditing ? 4 : 5);
      \u0275\u0275advance(3);
      \u0275\u0275conditional(7, ctx._hasTrailingIcon() ? 7 : -1);
      \u0275\u0275advance();
      \u0275\u0275property("id", ctx._ariaDescriptionId);
      \u0275\u0275advance();
      \u0275\u0275textInterpolate(ctx.ariaDescription);
    }
  },
  dependencies: [MatChipAction, MatChipEditInput],
  styles: [_c2],
  encapsulation: 2,
  changeDetection: 0
});
var MatChipRow = _MatChipRow;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipRow, [{
    type: Component,
    args: [{
      selector: "mat-chip-row, [mat-chip-row], mat-basic-chip-row, [mat-basic-chip-row]",
      host: {
        "class": "mat-mdc-chip mat-mdc-chip-row mdc-evolution-chip",
        "[class.mat-mdc-chip-with-avatar]": "leadingIcon",
        "[class.mat-mdc-chip-disabled]": "disabled",
        "[class.mat-mdc-chip-editing]": "_isEditing",
        "[class.mat-mdc-chip-editable]": "editable",
        "[class.mdc-evolution-chip--disabled]": "disabled",
        "[class.mdc-evolution-chip--with-trailing-action]": "_hasTrailingIcon()",
        "[class.mdc-evolution-chip--with-primary-graphic]": "leadingIcon",
        "[class.mdc-evolution-chip--with-primary-icon]": "leadingIcon",
        "[class.mdc-evolution-chip--with-avatar]": "leadingIcon",
        "[class.mat-mdc-chip-highlighted]": "highlighted",
        "[class.mat-mdc-chip-with-trailing-icon]": "_hasTrailingIcon()",
        "[id]": "id",
        // Has to have a negative tabindex in order to capture
        // focus and redirect it to the primary action.
        "[attr.tabindex]": "disabled ? null : -1",
        "[attr.aria-label]": "null",
        "[attr.aria-description]": "null",
        "[attr.role]": "role",
        "(focus)": "_handleFocus($event)",
        "(dblclick)": "_handleDoubleclick($event)"
      },
      providers: [{
        provide: MatChip,
        useExisting: MatChipRow
      }, {
        provide: MAT_CHIP,
        useExisting: MatChipRow
      }],
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true,
      imports: [MatChipAction, MatChipEditInput],
      template: '@if (!_isEditing) {\n  <span class="mat-mdc-chip-focus-overlay"></span>\n}\n\n<span class="mdc-evolution-chip__cell mdc-evolution-chip__cell--primary" role="gridcell"\n    matChipAction\n    [tabIndex]="tabIndex"\n    [disabled]="disabled"\n    [attr.aria-label]="ariaLabel"\n    [attr.aria-describedby]="_ariaDescriptionId">\n  @if (leadingIcon) {\n    <span class="mdc-evolution-chip__graphic mat-mdc-chip-graphic">\n      <ng-content select="mat-chip-avatar, [matChipAvatar]"></ng-content>\n    </span>\n  }\n\n  <span class="mdc-evolution-chip__text-label mat-mdc-chip-action-label">\n    @if (_isEditing) {\n      @if (contentEditInput) {\n        <ng-content select="[matChipEditInput]"></ng-content>\n      } @else {\n        <span matChipEditInput></span>\n      }\n    } @else {\n      <ng-content></ng-content>\n    }\n\n    <span class="mat-mdc-chip-primary-focus-indicator mat-mdc-focus-indicator" aria-hidden="true"></span>\n  </span>\n</span>\n\n@if (_hasTrailingIcon()) {\n  <span\n    class="mdc-evolution-chip__cell mdc-evolution-chip__cell--trailing"\n    role="gridcell">\n    <ng-content select="mat-chip-trailing-icon,[matChipRemove],[matChipTrailingIcon]"></ng-content>\n  </span>\n}\n\n<span class="cdk-visually-hidden" [id]="_ariaDescriptionId">{{ariaDescription}}</span>\n',
      styles: ['.mdc-evolution-chip,.mdc-evolution-chip__cell,.mdc-evolution-chip__action{display:inline-flex;align-items:center}.mdc-evolution-chip{position:relative;max-width:100%}.mdc-evolution-chip .mdc-elevation-overlay{width:100%;height:100%;top:0;left:0}.mdc-evolution-chip__cell,.mdc-evolution-chip__action{height:100%}.mdc-evolution-chip__cell--primary{overflow-x:hidden}.mdc-evolution-chip__cell--trailing{flex:1 0 auto}.mdc-evolution-chip__action{align-items:center;background:none;border:none;box-sizing:content-box;cursor:pointer;display:inline-flex;justify-content:center;outline:none;padding:0;text-decoration:none;color:inherit}.mdc-evolution-chip__action--presentational{cursor:auto}.mdc-evolution-chip--disabled,.mdc-evolution-chip__action:disabled{pointer-events:none}.mdc-evolution-chip__action--primary{overflow-x:hidden}.mdc-evolution-chip__action--trailing{position:relative;overflow:visible}.mdc-evolution-chip__action--primary:before{box-sizing:border-box;content:"";height:100%;left:0;position:absolute;pointer-events:none;top:0;width:100%;z-index:1}.mdc-evolution-chip--touch{margin-top:8px;margin-bottom:8px}.mdc-evolution-chip__action-touch{position:absolute;top:50%;height:48px;left:0;right:0;transform:translateY(-50%)}.mdc-evolution-chip__text-label{white-space:nowrap;user-select:none;text-overflow:ellipsis;overflow:hidden}.mdc-evolution-chip__graphic{align-items:center;display:inline-flex;justify-content:center;overflow:hidden;pointer-events:none;position:relative;flex:1 0 auto}.mdc-evolution-chip__checkmark{position:absolute;opacity:0;top:50%;left:50%}.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--selected):not(.mdc-evolution-chip--with-primary-icon) .mdc-evolution-chip__graphic{width:0}.mdc-evolution-chip__checkmark-background{opacity:0}.mdc-evolution-chip__checkmark-svg{display:block}.mdc-evolution-chip__checkmark-path{stroke-width:2px;stroke-dasharray:29.7833385;stroke-dashoffset:29.7833385;stroke:currentColor}.mdc-evolution-chip--selecting .mdc-evolution-chip__graphic{transition:width 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark{transition:transform 150ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--selecting .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__graphic{transition:width 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark{transition:opacity 50ms 0ms linear,transform 100ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-75%, -50%)}.mdc-evolution-chip--deselecting .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--selecting-with-primary-icon .mdc-evolution-chip__checkmark-path{transition:stroke-dashoffset 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__icon--primary{transition:opacity 150ms 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark{transition:opacity 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);transform:translate(-50%, -50%)}.mdc-evolution-chip--deselecting-with-primary-icon .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}.mdc-evolution-chip--selected .mdc-evolution-chip__icon--primary{opacity:0}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{transform:translate(-50%, -50%);opacity:1}.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark-path{stroke-dashoffset:0}@keyframes mdc-evolution-chip-enter{from{transform:scale(0.8);opacity:.4}to{transform:scale(1);opacity:1}}.mdc-evolution-chip--enter{animation:mdc-evolution-chip-enter 100ms 0ms cubic-bezier(0, 0, 0.2, 1)}@keyframes mdc-evolution-chip-exit{from{opacity:1}to{opacity:0}}.mdc-evolution-chip--exit{animation:mdc-evolution-chip-exit 75ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mdc-evolution-chip--hidden{opacity:0;pointer-events:none;transition:width 150ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mat-mdc-standard-chip{border-radius:var(--mdc-chip-container-shape-radius);height:var(--mdc-chip-container-height)}.mat-mdc-standard-chip .mdc-evolution-chip__ripple{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-radius:var(--mdc-chip-container-shape-radius)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{border-radius:var(--mdc-chip-with-avatar-avatar-shape-radius)}.mat-mdc-standard-chip.mdc-evolution-chip--selectable:not(.mdc-evolution-chip--with-primary-icon){--mdc-chip-graphic-selected-width:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip .mdc-evolution-chip__graphic{height:var(--mdc-chip-with-avatar-avatar-size);width:var(--mdc-chip-with-avatar-avatar-size);font-size:var(--mdc-chip-with-avatar-avatar-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational).mdc-ripple-upgraded--background-focused:before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-evolution-chip__action--presentational):not(.mdc-ripple-upgraded):focus:before{border-color:var(--mdc-chip-focus-outline-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__action--primary:before{border-color:var(--mdc-chip-disabled-outline-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-outline-width)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:before{border-width:var(--mdc-chip-flat-selected-outline-width)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled){background-color:var(--mdc-chip-elevated-selected-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-elevated-disabled-container-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled{background-color:var(--mdc-chip-flat-disabled-selected-container-color)}.mat-mdc-standard-chip .mdc-evolution-chip__text-label{font-family:var(--mdc-chip-label-text-font);line-height:var(--mdc-chip-label-text-line-height);font-size:var(--mdc-chip-label-text-size);font-weight:var(--mdc-chip-label-text-weight);letter-spacing:var(--mdc-chip-label-text-tracking)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__text-label{color:var(--mdc-chip-selected-label-text-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__text-label{color:var(--mdc-chip-disabled-label-text-color)}.mat-mdc-standard-chip .mdc-evolution-chip__icon--primary{height:var(--mdc-chip-with-icon-icon-size);width:var(--mdc-chip-with-icon-icon-size);font-size:var(--mdc-chip-with-icon-icon-size)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--primary{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-selected-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__checkmark{color:var(--mdc-chip-with-icon-disabled-icon-color)}.mat-mdc-standard-chip:not(.mdc-evolution-chip--disabled) .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-hover-state-layer-color)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary .mdc-evolution-chip__ripple::after{background-color:var(--mdc-chip-selected-hover-state-layer-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:hover .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-surface--hover .mdc-evolution-chip__ripple::before{opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary.mdc-ripple-upgraded--background-focused .mdc-evolution-chip__ripple::before,.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__action--primary:not(.mdc-ripple-upgraded):focus .mdc-evolution-chip__ripple::before{transition-duration:75ms;opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color)}.mat-mdc-chip-selected .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color)}.mat-mdc-chip:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-hover-state-layer-color);opacity:var(--mdc-chip-hover-state-layer-opacity)}.mat-mdc-chip-selected:hover .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-hover-state-layer-color);opacity:var(--mdc-chip-selected-hover-state-layer-opacity)}.mat-mdc-chip.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-focus-state-layer-color);opacity:var(--mdc-chip-focus-state-layer-opacity)}.mat-mdc-chip-selected.cdk-focused .mat-mdc-chip-focus-overlay{background:var(--mdc-chip-selected-focus-state-layer-color);opacity:var(--mdc-chip-selected-focus-state-layer-opacity)}.mdc-evolution-chip--disabled:not(.mdc-evolution-chip--selected) .mat-mdc-chip-avatar{opacity:var(--mdc-chip-with-avatar-disabled-avatar-opacity)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{opacity:var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity)}.mdc-evolution-chip--disabled.mdc-evolution-chip--selected .mdc-evolution-chip__checkmark{opacity:var(--mdc-chip-with-icon-disabled-icon-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--disabled{opacity:var(--mat-chip-disabled-container-opacity)}.mat-mdc-standard-chip.mdc-evolution-chip--selected .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-trailing-icon-color)}.mat-mdc-standard-chip.mdc-evolution-chip--selected.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing{color:var(--mat-chip-selected-disabled-trailing-icon-color)}.mat-mdc-chip-remove{opacity:var(--mat-chip-trailing-action-opacity)}.mat-mdc-chip-remove:focus{opacity:var(--mat-chip-trailing-action-focus-opacity)}.mat-mdc-chip-remove::after{background:var(--mat-chip-trailing-action-state-layer-color)}.mat-mdc-chip-remove:hover::after{opacity:var(--mat-chip-trailing-action-hover-state-layer-opacity)}.mat-mdc-chip-remove:focus::after{opacity:var(--mat-chip-trailing-action-focus-state-layer-opacity)}.mat-mdc-chip-selected .mat-mdc-chip-remove::after{background:var(--mat-chip-selected-trailing-action-state-layer-color)}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove{opacity:calc(var(--mat-chip-trailing-action-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mdc-evolution-chip--disabled .mdc-evolution-chip__icon--trailing.mat-mdc-chip-remove:focus{opacity:calc(var(--mat-chip-trailing-action-focus-opacity)*var(--mdc-chip-with-trailing-icon-disabled-trailing-icon-opacity))}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary:before{border-style:solid}.mat-mdc-standard-chip .mdc-evolution-chip__checkmark{height:20px;width:20px}.mat-mdc-standard-chip .mdc-evolution-chip__icon--trailing{height:18px;width:18px;font-size:18px}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:12px;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:12px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:6px;padding-right:6px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:6px;padding-right:6px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary{padding-left:0;padding-right:12px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:12px;padding-right:0}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic{padding-left:4px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__graphic[dir=rtl]{padding-left:8px;padding-right:4px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing{padding-left:8px;padding-right:8px}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--trailing[dir=rtl]{padding-left:8px;padding-right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing{left:8px;right:initial}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__ripple--trailing[dir=rtl]{left:initial;right:8px}.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary{padding-left:0;padding-right:0}[dir=rtl] .mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary,.mdc-evolution-chip--with-avatar.mdc-evolution-chip--with-primary-graphic.mdc-evolution-chip--with-trailing-action .mdc-evolution-chip__action--primary[dir=rtl]{padding-left:0;padding-right:0}.mat-mdc-standard-chip{-webkit-tap-highlight-color:rgba(0,0,0,0)}.cdk-high-contrast-active .mat-mdc-standard-chip{outline:solid 1px}.cdk-high-contrast-active .mat-mdc-standard-chip .mdc-evolution-chip__checkmark-path{stroke:CanvasText !important}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary,.mat-mdc-standard-chip .mdc-evolution-chip__action--primary,.mat-mdc-standard-chip .mat-mdc-chip-action-label{overflow:visible}.mat-mdc-standard-chip .mdc-evolution-chip__cell--primary{flex-basis:100%}.mat-mdc-standard-chip .mdc-evolution-chip__action--primary{font:inherit;letter-spacing:inherit;white-space:inherit}.mat-mdc-standard-chip .mat-mdc-chip-graphic,.mat-mdc-standard-chip .mat-mdc-chip-trailing-icon{box-sizing:content-box}.mat-mdc-standard-chip._mat-animation-noopable,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__graphic,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark,.mat-mdc-standard-chip._mat-animation-noopable .mdc-evolution-chip__checkmark-path{transition-duration:1ms;animation-duration:1ms}.mat-mdc-basic-chip .mdc-evolution-chip__action--primary{font:inherit}.mat-mdc-chip-focus-overlay{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;opacity:0;border-radius:inherit;transition:opacity 150ms linear}._mat-animation-noopable .mat-mdc-chip-focus-overlay{transition:none}.mat-mdc-basic-chip .mat-mdc-chip-focus-overlay{display:none}.mat-mdc-chip .mat-ripple.mat-mdc-chip-ripple{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none;border-radius:inherit}.mat-mdc-chip-avatar{text-align:center;line-height:1;color:var(--mdc-chip-with-icon-icon-color, currentColor)}.mat-mdc-chip{position:relative;z-index:0}.mat-mdc-chip-action-label{text-align:left;z-index:1}[dir=rtl] .mat-mdc-chip-action-label{text-align:right}.mat-mdc-chip.mdc-evolution-chip--with-trailing-action .mat-mdc-chip-action-label{position:relative}.mat-mdc-chip-action-label .mat-mdc-chip-primary-focus-indicator{position:absolute;top:0;right:0;bottom:0;left:0;pointer-events:none}.mat-mdc-chip-action-label .mat-mdc-focus-indicator::before{margin:calc(calc(var(--mat-mdc-focus-indicator-border-width, 3px) + 2px)*-1)}.mat-mdc-chip-remove::before{margin:calc(var(--mat-mdc-focus-indicator-border-width, 3px)*-1);left:8px;right:8px}.mat-mdc-chip-remove::after{content:"";display:block;opacity:0;position:absolute;top:-2px;bottom:-2px;left:6px;right:6px;border-radius:50%}.mat-mdc-chip-remove .mat-icon{width:18px;height:18px;font-size:18px;box-sizing:content-box}.mat-chip-edit-input{cursor:text;display:inline-block;color:inherit;outline:0}.cdk-high-contrast-active .mat-mdc-chip-selected:not(.mat-mdc-chip-multiple){outline-width:3px}.mat-mdc-chip-action:focus .mat-mdc-focus-indicator::before{content:""}']
    }]
  }], () => [{
    type: ChangeDetectorRef
  }, {
    type: ElementRef
  }, {
    type: NgZone
  }, {
    type: FocusMonitor
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [DOCUMENT]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_RIPPLE_GLOBAL_OPTIONS]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Attribute,
      args: ["tabindex"]
    }]
  }], {
    editable: [{
      type: Input
    }],
    edited: [{
      type: Output
    }],
    defaultEditInput: [{
      type: ViewChild,
      args: [MatChipEditInput]
    }],
    contentEditInput: [{
      type: ContentChild,
      args: [MatChipEditInput]
    }]
  });
})();
var _MatChipSet = class _MatChipSet {
  /** Combined stream of all of the child chips' focus events. */
  get chipFocusChanges() {
    return this._getChipStream((chip) => chip._onFocus);
  }
  /** Combined stream of all of the child chips' destroy events. */
  get chipDestroyedChanges() {
    return this._getChipStream((chip) => chip.destroyed);
  }
  /** Combined stream of all of the child chips' remove events. */
  get chipRemovedChanges() {
    return this._getChipStream((chip) => chip.removed);
  }
  /** Whether the chip set is disabled. */
  get disabled() {
    return this._disabled;
  }
  set disabled(value) {
    this._disabled = value;
    this._syncChipsState();
  }
  /** Whether the chip list contains chips or not. */
  get empty() {
    return !this._chips || this._chips.length === 0;
  }
  /** The ARIA role applied to the chip set. */
  get role() {
    if (this._explicitRole) {
      return this._explicitRole;
    }
    return this.empty ? null : this._defaultRole;
  }
  set role(value) {
    this._explicitRole = value;
  }
  /** Whether any of the chips inside of this chip-set has focus. */
  get focused() {
    return this._hasFocusedChip();
  }
  constructor(_elementRef, _changeDetectorRef, _dir) {
    this._elementRef = _elementRef;
    this._changeDetectorRef = _changeDetectorRef;
    this._dir = _dir;
    this._lastDestroyedFocusedChipIndex = null;
    this._destroyed = new Subject();
    this._defaultRole = "presentation";
    this._disabled = false;
    this.tabIndex = 0;
    this._explicitRole = null;
    this._chipActions = new QueryList();
  }
  ngAfterViewInit() {
    this._setUpFocusManagement();
    this._trackChipSetChanges();
    this._trackDestroyedFocusedChip();
  }
  ngOnDestroy() {
    this._keyManager?.destroy();
    this._chipActions.destroy();
    this._destroyed.next();
    this._destroyed.complete();
  }
  /** Checks whether any of the chips is focused. */
  _hasFocusedChip() {
    return this._chips && this._chips.some((chip) => chip._hasFocus());
  }
  /** Syncs the chip-set's state with the individual chips. */
  _syncChipsState() {
    if (this._chips) {
      this._chips.forEach((chip) => {
        chip.disabled = this._disabled;
        chip._changeDetectorRef.markForCheck();
      });
    }
  }
  /** Dummy method for subclasses to override. Base chip set cannot be focused. */
  focus() {
  }
  /** Handles keyboard events on the chip set. */
  _handleKeydown(event) {
    if (this._originatesFromChip(event)) {
      this._keyManager.onKeydown(event);
    }
  }
  /**
   * Utility to ensure all indexes are valid.
   *
   * @param index The index to be checked.
   * @returns True if the index is valid for our list of chips.
   */
  _isValidIndex(index) {
    return index >= 0 && index < this._chips.length;
  }
  /**
   * Removes the `tabindex` from the chip set and resets it back afterwards, allowing the
   * user to tab out of it. This prevents the set from capturing focus and redirecting
   * it back to the first chip, creating a focus trap, if it user tries to tab away.
   */
  _allowFocusEscape() {
    if (this.tabIndex !== -1) {
      const previousTabIndex = this.tabIndex;
      this.tabIndex = -1;
      setTimeout(() => this.tabIndex = previousTabIndex);
    }
  }
  /**
   * Gets a stream of events from all the chips within the set.
   * The stream will automatically incorporate any newly-added chips.
   */
  _getChipStream(mappingFunction) {
    return this._chips.changes.pipe(startWith(null), switchMap(() => merge(...this._chips.map(mappingFunction))));
  }
  /** Checks whether an event comes from inside a chip element. */
  _originatesFromChip(event) {
    let currentElement = event.target;
    while (currentElement && currentElement !== this._elementRef.nativeElement) {
      if (currentElement.classList.contains("mat-mdc-chip")) {
        return true;
      }
      currentElement = currentElement.parentElement;
    }
    return false;
  }
  /** Sets up the chip set's focus management logic. */
  _setUpFocusManagement() {
    this._chips.changes.pipe(startWith(this._chips)).subscribe((chips) => {
      const actions = [];
      chips.forEach((chip) => chip._getActions().forEach((action) => actions.push(action)));
      this._chipActions.reset(actions);
      this._chipActions.notifyOnChanges();
    });
    this._keyManager = new FocusKeyManager(this._chipActions).withVerticalOrientation().withHorizontalOrientation(this._dir ? this._dir.value : "ltr").withHomeAndEnd().skipPredicate((action) => this._skipPredicate(action));
    this.chipFocusChanges.pipe(takeUntil(this._destroyed)).subscribe(({
      chip
    }) => {
      const action = chip._getSourceAction(document.activeElement);
      if (action) {
        this._keyManager.updateActiveItem(action);
      }
    });
    this._dir?.change.pipe(takeUntil(this._destroyed)).subscribe((direction) => this._keyManager.withHorizontalOrientation(direction));
  }
  /**
   * Determines if key manager should avoid putting a given chip action in the tab index. Skip
   * non-interactive and disabled actions since the user can't do anything with them.
   */
  _skipPredicate(action) {
    return !action.isInteractive || action.disabled;
  }
  /** Listens to changes in the chip set and syncs up the state of the individual chips. */
  _trackChipSetChanges() {
    this._chips.changes.pipe(startWith(null), takeUntil(this._destroyed)).subscribe(() => {
      if (this.disabled) {
        Promise.resolve().then(() => this._syncChipsState());
      }
      this._redirectDestroyedChipFocus();
    });
  }
  /** Starts tracking the destroyed chips in order to capture the focused one. */
  _trackDestroyedFocusedChip() {
    this.chipDestroyedChanges.pipe(takeUntil(this._destroyed)).subscribe((event) => {
      const chipArray = this._chips.toArray();
      const chipIndex = chipArray.indexOf(event.chip);
      if (this._isValidIndex(chipIndex) && event.chip._hasFocus()) {
        this._lastDestroyedFocusedChipIndex = chipIndex;
      }
    });
  }
  /**
   * Finds the next appropriate chip to move focus to,
   * if the currently-focused chip is destroyed.
   */
  _redirectDestroyedChipFocus() {
    if (this._lastDestroyedFocusedChipIndex == null) {
      return;
    }
    if (this._chips.length) {
      const newIndex = Math.min(this._lastDestroyedFocusedChipIndex, this._chips.length - 1);
      const chipToFocus = this._chips.toArray()[newIndex];
      if (chipToFocus.disabled) {
        if (this._chips.length === 1) {
          this.focus();
        } else {
          this._keyManager.setPreviousItemActive();
        }
      } else {
        chipToFocus.focus();
      }
    } else {
      this.focus();
    }
    this._lastDestroyedFocusedChipIndex = null;
  }
};
_MatChipSet.\u0275fac = function MatChipSet_Factory(t) {
  return new (t || _MatChipSet)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(Directionality, 8));
};
_MatChipSet.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatChipSet,
  selectors: [["mat-chip-set"]],
  contentQueries: function MatChipSet_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatChip, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._chips = _t);
    }
  },
  hostAttrs: [1, "mat-mdc-chip-set", "mdc-evolution-chip-set"],
  hostVars: 1,
  hostBindings: function MatChipSet_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("keydown", function MatChipSet_keydown_HostBindingHandler($event) {
        return ctx._handleKeydown($event);
      });
    }
    if (rf & 2) {
      \u0275\u0275attribute("role", ctx.role);
    }
  },
  inputs: {
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    role: "role",
    tabIndex: [InputFlags.HasDecoratorInputTransform, "tabIndex", "tabIndex", (value) => value == null ? 0 : numberAttribute(value)]
  },
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c5,
  decls: 2,
  vars: 0,
  consts: [["role", "presentation", 1, "mdc-evolution-chip-set__chips"]],
  template: function MatChipSet_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "div", 0);
      \u0275\u0275projection(1);
      \u0275\u0275elementEnd();
    }
  },
  styles: [".mdc-evolution-chip-set{display:flex}.mdc-evolution-chip-set:focus{outline:none}.mdc-evolution-chip-set__chips{display:flex;flex-flow:wrap;min-width:0}.mdc-evolution-chip-set--overflow .mdc-evolution-chip-set__chips{flex-flow:nowrap}.mdc-evolution-chip-set .mdc-evolution-chip-set__chips{margin-left:-8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip-set__chips,.mdc-evolution-chip-set .mdc-evolution-chip-set__chips[dir=rtl]{margin-left:0;margin-right:-8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-left:8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip,.mdc-evolution-chip-set .mdc-evolution-chip[dir=rtl]{margin-left:0;margin-right:8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-top:4px;margin-bottom:4px}.mat-mdc-chip-set .mdc-evolution-chip-set__chips{min-width:100%}.mat-mdc-chip-set-stacked{flex-direction:column;align-items:flex-start}.mat-mdc-chip-set-stacked .mat-mdc-chip{width:100%}.mat-mdc-chip-set-stacked .mdc-evolution-chip__graphic{flex-grow:0}.mat-mdc-chip-set-stacked .mdc-evolution-chip__action--primary{flex-basis:100%;justify-content:start}input.mat-mdc-chip-input{flex:1 0 150px;margin-left:8px}[dir=rtl] input.mat-mdc-chip-input{margin-left:0;margin-right:8px}"],
  encapsulation: 2,
  changeDetection: 0
});
var MatChipSet = _MatChipSet;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipSet, [{
    type: Component,
    args: [{
      selector: "mat-chip-set",
      template: `
    <div class="mdc-evolution-chip-set__chips" role="presentation">
      <ng-content></ng-content>
    </div>
  `,
      host: {
        "class": "mat-mdc-chip-set mdc-evolution-chip-set",
        "(keydown)": "_handleKeydown($event)",
        "[attr.role]": "role"
      },
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true,
      styles: [".mdc-evolution-chip-set{display:flex}.mdc-evolution-chip-set:focus{outline:none}.mdc-evolution-chip-set__chips{display:flex;flex-flow:wrap;min-width:0}.mdc-evolution-chip-set--overflow .mdc-evolution-chip-set__chips{flex-flow:nowrap}.mdc-evolution-chip-set .mdc-evolution-chip-set__chips{margin-left:-8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip-set__chips,.mdc-evolution-chip-set .mdc-evolution-chip-set__chips[dir=rtl]{margin-left:0;margin-right:-8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-left:8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip,.mdc-evolution-chip-set .mdc-evolution-chip[dir=rtl]{margin-left:0;margin-right:8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-top:4px;margin-bottom:4px}.mat-mdc-chip-set .mdc-evolution-chip-set__chips{min-width:100%}.mat-mdc-chip-set-stacked{flex-direction:column;align-items:flex-start}.mat-mdc-chip-set-stacked .mat-mdc-chip{width:100%}.mat-mdc-chip-set-stacked .mdc-evolution-chip__graphic{flex-grow:0}.mat-mdc-chip-set-stacked .mdc-evolution-chip__action--primary{flex-basis:100%;justify-content:start}input.mat-mdc-chip-input{flex:1 0 150px;margin-left:8px}[dir=rtl] input.mat-mdc-chip-input{margin-left:0;margin-right:8px}"]
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: ChangeDetectorRef
  }, {
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }], {
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    role: [{
      type: Input
    }],
    tabIndex: [{
      type: Input,
      args: [{
        transform: (value) => value == null ? 0 : numberAttribute(value)
      }]
    }],
    _chips: [{
      type: ContentChildren,
      args: [MatChip, {
        // We need to use `descendants: true`, because Ivy will no longer match
        // indirect descendants if it's left as false.
        descendants: true
      }]
    }]
  });
})();
var MatChipListboxChange = class {
  constructor(source, value) {
    this.source = source;
    this.value = value;
  }
};
var MAT_CHIP_LISTBOX_CONTROL_VALUE_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => MatChipListbox),
  multi: true
};
var _MatChipListbox = class _MatChipListbox extends MatChipSet {
  constructor() {
    super(...arguments);
    this._onTouched = () => {
    };
    this._onChange = () => {
    };
    this._defaultRole = "listbox";
    this._defaultOptions = inject(MAT_CHIPS_DEFAULT_OPTIONS, {
      optional: true
    });
    this._multiple = false;
    this.ariaOrientation = "horizontal";
    this._selectable = true;
    this.compareWith = (o1, o2) => o1 === o2;
    this.required = false;
    this._hideSingleSelectionIndicator = this._defaultOptions?.hideSingleSelectionIndicator ?? false;
    this.change = new EventEmitter();
    this._chips = void 0;
  }
  /** Whether the user should be allowed to select multiple chips. */
  get multiple() {
    return this._multiple;
  }
  set multiple(value) {
    this._multiple = value;
    this._syncListboxProperties();
  }
  /** The array of selected chips inside the chip listbox. */
  get selected() {
    const selectedChips = this._chips.toArray().filter((chip) => chip.selected);
    return this.multiple ? selectedChips : selectedChips[0];
  }
  /**
   * Whether or not this chip listbox is selectable.
   *
   * When a chip listbox is not selectable, the selected states for all
   * the chips inside the chip listbox are always ignored.
   */
  get selectable() {
    return this._selectable;
  }
  set selectable(value) {
    this._selectable = value;
    this._syncListboxProperties();
  }
  /** Whether checkmark indicator for single-selection options is hidden. */
  get hideSingleSelectionIndicator() {
    return this._hideSingleSelectionIndicator;
  }
  set hideSingleSelectionIndicator(value) {
    this._hideSingleSelectionIndicator = value;
    this._syncListboxProperties();
  }
  /** Combined stream of all of the child chips' selection change events. */
  get chipSelectionChanges() {
    return this._getChipStream((chip) => chip.selectionChange);
  }
  /** Combined stream of all of the child chips' blur events. */
  get chipBlurChanges() {
    return this._getChipStream((chip) => chip._onBlur);
  }
  /** The value of the listbox, which is the combined value of the selected chips. */
  get value() {
    return this._value;
  }
  set value(value) {
    this.writeValue(value);
    this._value = value;
  }
  ngAfterContentInit() {
    if (this._pendingInitialValue !== void 0) {
      Promise.resolve().then(() => {
        this._setSelectionByValue(this._pendingInitialValue, false);
        this._pendingInitialValue = void 0;
      });
    }
    this._chips.changes.pipe(startWith(null), takeUntil(this._destroyed)).subscribe(() => {
      this._syncListboxProperties();
    });
    this.chipBlurChanges.pipe(takeUntil(this._destroyed)).subscribe(() => this._blur());
    this.chipSelectionChanges.pipe(takeUntil(this._destroyed)).subscribe((event) => {
      if (!this.multiple) {
        this._chips.forEach((chip) => {
          if (chip !== event.source) {
            chip._setSelectedState(false, false, false);
          }
        });
      }
      if (event.isUserInput) {
        this._propagateChanges();
      }
    });
  }
  /**
   * Focuses the first selected chip in this chip listbox, or the first non-disabled chip when there
   * are no selected chips.
   */
  focus() {
    if (this.disabled) {
      return;
    }
    const firstSelectedChip = this._getFirstSelectedChip();
    if (firstSelectedChip && !firstSelectedChip.disabled) {
      firstSelectedChip.focus();
    } else if (this._chips.length > 0) {
      this._keyManager.setFirstItemActive();
    } else {
      this._elementRef.nativeElement.focus();
    }
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  writeValue(value) {
    if (this._chips) {
      this._setSelectionByValue(value, false);
    } else if (value != null) {
      this._pendingInitialValue = value;
    }
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  registerOnChange(fn) {
    this._onChange = fn;
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  registerOnTouched(fn) {
    this._onTouched = fn;
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  setDisabledState(isDisabled) {
    this.disabled = isDisabled;
  }
  /** Selects all chips with value. */
  _setSelectionByValue(value, isUserInput = true) {
    this._clearSelection();
    if (Array.isArray(value)) {
      value.forEach((currentValue) => this._selectValue(currentValue, isUserInput));
    } else {
      this._selectValue(value, isUserInput);
    }
  }
  /** When blurred, marks the field as touched when focus moved outside the chip listbox. */
  _blur() {
    if (!this.disabled) {
      setTimeout(() => {
        if (!this.focused) {
          this._markAsTouched();
        }
      });
    }
  }
  _keydown(event) {
    if (event.keyCode === TAB) {
      super._allowFocusEscape();
    }
  }
  /** Marks the field as touched */
  _markAsTouched() {
    this._onTouched();
    this._changeDetectorRef.markForCheck();
  }
  /** Emits change event to set the model value. */
  _propagateChanges() {
    let valueToEmit = null;
    if (Array.isArray(this.selected)) {
      valueToEmit = this.selected.map((chip) => chip.value);
    } else {
      valueToEmit = this.selected ? this.selected.value : void 0;
    }
    this._value = valueToEmit;
    this.change.emit(new MatChipListboxChange(this, valueToEmit));
    this._onChange(valueToEmit);
    this._changeDetectorRef.markForCheck();
  }
  /**
   * Deselects every chip in the listbox.
   * @param skip Chip that should not be deselected.
   */
  _clearSelection(skip2) {
    this._chips.forEach((chip) => {
      if (chip !== skip2) {
        chip.deselect();
      }
    });
  }
  /**
   * Finds and selects the chip based on its value.
   * @returns Chip that has the corresponding value.
   */
  _selectValue(value, isUserInput) {
    const correspondingChip = this._chips.find((chip) => {
      return chip.value != null && this.compareWith(chip.value, value);
    });
    if (correspondingChip) {
      isUserInput ? correspondingChip.selectViaInteraction() : correspondingChip.select();
    }
    return correspondingChip;
  }
  /** Syncs the chip-listbox selection state with the individual chips. */
  _syncListboxProperties() {
    if (this._chips) {
      Promise.resolve().then(() => {
        this._chips.forEach((chip) => {
          chip._chipListMultiple = this.multiple;
          chip.chipListSelectable = this._selectable;
          chip._chipListHideSingleSelectionIndicator = this.hideSingleSelectionIndicator;
          chip._changeDetectorRef.markForCheck();
        });
      });
    }
  }
  /** Returns the first selected chip in this listbox, or undefined if no chips are selected. */
  _getFirstSelectedChip() {
    if (Array.isArray(this.selected)) {
      return this.selected.length ? this.selected[0] : void 0;
    } else {
      return this.selected;
    }
  }
  /**
   * Determines if key manager should avoid putting a given chip action in the tab index. Skip
   * non-interactive actions since the user can't do anything with them.
   */
  _skipPredicate(action) {
    return !action.isInteractive;
  }
};
_MatChipListbox.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatChipListbox_BaseFactory;
  return function MatChipListbox_Factory(t) {
    return (\u0275MatChipListbox_BaseFactory || (\u0275MatChipListbox_BaseFactory = \u0275\u0275getInheritedFactory(_MatChipListbox)))(t || _MatChipListbox);
  };
})();
_MatChipListbox.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatChipListbox,
  selectors: [["mat-chip-listbox"]],
  contentQueries: function MatChipListbox_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatChipOption, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._chips = _t);
    }
  },
  hostAttrs: [1, "mdc-evolution-chip-set", "mat-mdc-chip-listbox"],
  hostVars: 11,
  hostBindings: function MatChipListbox_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("focus", function MatChipListbox_focus_HostBindingHandler() {
        return ctx.focus();
      })("blur", function MatChipListbox_blur_HostBindingHandler() {
        return ctx._blur();
      })("keydown", function MatChipListbox_keydown_HostBindingHandler($event) {
        return ctx._keydown($event);
      });
    }
    if (rf & 2) {
      \u0275\u0275hostProperty("tabIndex", ctx.disabled || ctx.empty ? -1 : ctx.tabIndex);
      \u0275\u0275attribute("role", ctx.role)("aria-describedby", ctx._ariaDescribedby || null)("aria-required", ctx.role ? ctx.required : null)("aria-disabled", ctx.disabled.toString())("aria-multiselectable", ctx.multiple)("aria-orientation", ctx.ariaOrientation);
      \u0275\u0275classProp("mat-mdc-chip-list-disabled", ctx.disabled)("mat-mdc-chip-list-required", ctx.required);
    }
  },
  inputs: {
    multiple: [InputFlags.HasDecoratorInputTransform, "multiple", "multiple", booleanAttribute],
    ariaOrientation: [InputFlags.None, "aria-orientation", "ariaOrientation"],
    selectable: [InputFlags.HasDecoratorInputTransform, "selectable", "selectable", booleanAttribute],
    compareWith: "compareWith",
    required: [InputFlags.HasDecoratorInputTransform, "required", "required", booleanAttribute],
    hideSingleSelectionIndicator: [InputFlags.HasDecoratorInputTransform, "hideSingleSelectionIndicator", "hideSingleSelectionIndicator", booleanAttribute],
    value: "value"
  },
  outputs: {
    change: "change"
  },
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([MAT_CHIP_LISTBOX_CONTROL_VALUE_ACCESSOR]), \u0275\u0275InputTransformsFeature, \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c5,
  decls: 2,
  vars: 0,
  consts: [["role", "presentation", 1, "mdc-evolution-chip-set__chips"]],
  template: function MatChipListbox_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "div", 0);
      \u0275\u0275projection(1);
      \u0275\u0275elementEnd();
    }
  },
  styles: [_c6],
  encapsulation: 2,
  changeDetection: 0
});
var MatChipListbox = _MatChipListbox;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipListbox, [{
    type: Component,
    args: [{
      selector: "mat-chip-listbox",
      template: `
    <div class="mdc-evolution-chip-set__chips" role="presentation">
      <ng-content></ng-content>
    </div>
  `,
      host: {
        "class": "mdc-evolution-chip-set mat-mdc-chip-listbox",
        "[attr.role]": "role",
        "[tabIndex]": "(disabled || empty) ? -1 : tabIndex",
        // TODO: replace this binding with use of AriaDescriber
        "[attr.aria-describedby]": "_ariaDescribedby || null",
        "[attr.aria-required]": "role ? required : null",
        "[attr.aria-disabled]": "disabled.toString()",
        "[attr.aria-multiselectable]": "multiple",
        "[attr.aria-orientation]": "ariaOrientation",
        "[class.mat-mdc-chip-list-disabled]": "disabled",
        "[class.mat-mdc-chip-list-required]": "required",
        "(focus)": "focus()",
        "(blur)": "_blur()",
        "(keydown)": "_keydown($event)"
      },
      providers: [MAT_CHIP_LISTBOX_CONTROL_VALUE_ACCESSOR],
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true,
      styles: [".mdc-evolution-chip-set{display:flex}.mdc-evolution-chip-set:focus{outline:none}.mdc-evolution-chip-set__chips{display:flex;flex-flow:wrap;min-width:0}.mdc-evolution-chip-set--overflow .mdc-evolution-chip-set__chips{flex-flow:nowrap}.mdc-evolution-chip-set .mdc-evolution-chip-set__chips{margin-left:-8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip-set__chips,.mdc-evolution-chip-set .mdc-evolution-chip-set__chips[dir=rtl]{margin-left:0;margin-right:-8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-left:8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip,.mdc-evolution-chip-set .mdc-evolution-chip[dir=rtl]{margin-left:0;margin-right:8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-top:4px;margin-bottom:4px}.mat-mdc-chip-set .mdc-evolution-chip-set__chips{min-width:100%}.mat-mdc-chip-set-stacked{flex-direction:column;align-items:flex-start}.mat-mdc-chip-set-stacked .mat-mdc-chip{width:100%}.mat-mdc-chip-set-stacked .mdc-evolution-chip__graphic{flex-grow:0}.mat-mdc-chip-set-stacked .mdc-evolution-chip__action--primary{flex-basis:100%;justify-content:start}input.mat-mdc-chip-input{flex:1 0 150px;margin-left:8px}[dir=rtl] input.mat-mdc-chip-input{margin-left:0;margin-right:8px}"]
    }]
  }], null, {
    multiple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    ariaOrientation: [{
      type: Input,
      args: ["aria-orientation"]
    }],
    selectable: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    compareWith: [{
      type: Input
    }],
    required: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    hideSingleSelectionIndicator: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    value: [{
      type: Input
    }],
    change: [{
      type: Output
    }],
    _chips: [{
      type: ContentChildren,
      args: [MatChipOption, {
        // We need to use `descendants: true`, because Ivy will no longer match
        // indirect descendants if it's left as false.
        descendants: true
      }]
    }]
  });
})();
var MatChipGridChange = class {
  constructor(source, value) {
    this.source = source;
    this.value = value;
  }
};
var _MatChipGrid = class _MatChipGrid extends MatChipSet {
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  get disabled() {
    return this.ngControl ? !!this.ngControl.disabled : this._disabled;
  }
  set disabled(value) {
    this._disabled = value;
    this._syncChipsState();
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  get id() {
    return this._chipInput.id;
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  get empty() {
    return (!this._chipInput || this._chipInput.empty) && (!this._chips || this._chips.length === 0);
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  get placeholder() {
    return this._chipInput ? this._chipInput.placeholder : this._placeholder;
  }
  set placeholder(value) {
    this._placeholder = value;
    this.stateChanges.next();
  }
  /** Whether any chips or the matChipInput inside of this chip-grid has focus. */
  get focused() {
    return this._chipInput.focused || this._hasFocusedChip();
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  get required() {
    return this._required ?? this.ngControl?.control?.hasValidator(Validators.required) ?? false;
  }
  set required(value) {
    this._required = value;
    this.stateChanges.next();
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  get shouldLabelFloat() {
    return !this.empty || this.focused;
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  get value() {
    return this._value;
  }
  set value(value) {
    this._value = value;
  }
  /** An object used to control when error messages are shown. */
  get errorStateMatcher() {
    return this._errorStateTracker.matcher;
  }
  set errorStateMatcher(value) {
    this._errorStateTracker.matcher = value;
  }
  /** Combined stream of all of the child chips' blur events. */
  get chipBlurChanges() {
    return this._getChipStream((chip) => chip._onBlur);
  }
  /** Whether the chip grid is in an error state. */
  get errorState() {
    return this._errorStateTracker.errorState;
  }
  set errorState(value) {
    this._errorStateTracker.errorState = value;
  }
  constructor(elementRef, changeDetectorRef, dir, parentForm, parentFormGroup, defaultErrorStateMatcher, ngControl) {
    super(elementRef, changeDetectorRef, dir);
    this.ngControl = ngControl;
    this.controlType = "mat-chip-grid";
    this._defaultRole = "grid";
    this._ariaDescribedbyIds = [];
    this._onTouched = () => {
    };
    this._onChange = () => {
    };
    this._value = [];
    this.change = new EventEmitter();
    this.valueChange = new EventEmitter();
    this._chips = void 0;
    this.stateChanges = new Subject();
    if (this.ngControl) {
      this.ngControl.valueAccessor = this;
    }
    this._errorStateTracker = new _ErrorStateTracker(defaultErrorStateMatcher, ngControl, parentFormGroup, parentForm, this.stateChanges);
  }
  ngAfterContentInit() {
    this.chipBlurChanges.pipe(takeUntil(this._destroyed)).subscribe(() => {
      this._blur();
      this.stateChanges.next();
    });
    merge(this.chipFocusChanges, this._chips.changes).pipe(takeUntil(this._destroyed)).subscribe(() => this.stateChanges.next());
  }
  ngAfterViewInit() {
    super.ngAfterViewInit();
    if (!this._chipInput && (typeof ngDevMode === "undefined" || ngDevMode)) {
      throw Error("mat-chip-grid must be used in combination with matChipInputFor.");
    }
  }
  ngDoCheck() {
    if (this.ngControl) {
      this.updateErrorState();
    }
  }
  ngOnDestroy() {
    super.ngOnDestroy();
    this.stateChanges.complete();
  }
  /** Associates an HTML input element with this chip grid. */
  registerInput(inputElement) {
    this._chipInput = inputElement;
    this._chipInput.setDescribedByIds(this._ariaDescribedbyIds);
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  onContainerClick(event) {
    if (!this.disabled && !this._originatesFromChip(event)) {
      this.focus();
    }
  }
  /**
   * Focuses the first chip in this chip grid, or the associated input when there
   * are no eligible chips.
   */
  focus() {
    if (this.disabled || this._chipInput.focused) {
      return;
    }
    if (!this._chips.length || this._chips.first.disabled) {
      Promise.resolve().then(() => this._chipInput.focus());
    } else if (this._chips.length) {
      this._keyManager.setFirstItemActive();
    }
    this.stateChanges.next();
  }
  /**
   * Implemented as part of MatFormFieldControl.
   * @docs-private
   */
  setDescribedByIds(ids) {
    this._ariaDescribedbyIds = ids;
    this._chipInput?.setDescribedByIds(ids);
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  writeValue(value) {
    this._value = value;
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  registerOnChange(fn) {
    this._onChange = fn;
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  registerOnTouched(fn) {
    this._onTouched = fn;
  }
  /**
   * Implemented as part of ControlValueAccessor.
   * @docs-private
   */
  setDisabledState(isDisabled) {
    this.disabled = isDisabled;
    this.stateChanges.next();
  }
  /** Refreshes the error state of the chip grid. */
  updateErrorState() {
    this._errorStateTracker.updateErrorState();
  }
  /** When blurred, mark the field as touched when focus moved outside the chip grid. */
  _blur() {
    if (!this.disabled) {
      setTimeout(() => {
        if (!this.focused) {
          this._propagateChanges();
          this._markAsTouched();
        }
      });
    }
  }
  /**
   * Removes the `tabindex` from the chip grid and resets it back afterwards, allowing the
   * user to tab out of it. This prevents the grid from capturing focus and redirecting
   * it back to the first chip, creating a focus trap, if it user tries to tab away.
   */
  _allowFocusEscape() {
    if (!this._chipInput.focused) {
      super._allowFocusEscape();
    }
  }
  /** Handles custom keyboard events. */
  _handleKeydown(event) {
    if (event.keyCode === TAB) {
      if (this._chipInput.focused && hasModifierKey(event, "shiftKey") && this._chips.length && !this._chips.last.disabled) {
        event.preventDefault();
        if (this._keyManager.activeItem) {
          this._keyManager.setActiveItem(this._keyManager.activeItem);
        } else {
          this._focusLastChip();
        }
      } else {
        super._allowFocusEscape();
      }
    } else if (!this._chipInput.focused) {
      super._handleKeydown(event);
    }
    this.stateChanges.next();
  }
  _focusLastChip() {
    if (this._chips.length) {
      this._chips.last.focus();
    }
  }
  /** Emits change event to set the model value. */
  _propagateChanges() {
    const valueToEmit = this._chips.length ? this._chips.toArray().map((chip) => chip.value) : [];
    this._value = valueToEmit;
    this.change.emit(new MatChipGridChange(this, valueToEmit));
    this.valueChange.emit(valueToEmit);
    this._onChange(valueToEmit);
    this._changeDetectorRef.markForCheck();
  }
  /** Mark the field as touched */
  _markAsTouched() {
    this._onTouched();
    this._changeDetectorRef.markForCheck();
    this.stateChanges.next();
  }
};
_MatChipGrid.\u0275fac = function MatChipGrid_Factory(t) {
  return new (t || _MatChipGrid)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(Directionality, 8), \u0275\u0275directiveInject(NgForm, 8), \u0275\u0275directiveInject(FormGroupDirective, 8), \u0275\u0275directiveInject(ErrorStateMatcher), \u0275\u0275directiveInject(NgControl, 10));
};
_MatChipGrid.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatChipGrid,
  selectors: [["mat-chip-grid"]],
  contentQueries: function MatChipGrid_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatChipRow, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._chips = _t);
    }
  },
  hostAttrs: [1, "mat-mdc-chip-set", "mat-mdc-chip-grid", "mdc-evolution-chip-set"],
  hostVars: 10,
  hostBindings: function MatChipGrid_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("focus", function MatChipGrid_focus_HostBindingHandler() {
        return ctx.focus();
      })("blur", function MatChipGrid_blur_HostBindingHandler() {
        return ctx._blur();
      });
    }
    if (rf & 2) {
      \u0275\u0275attribute("role", ctx.role)("tabindex", ctx.disabled || ctx._chips && ctx._chips.length === 0 ? -1 : ctx.tabIndex)("aria-disabled", ctx.disabled.toString())("aria-invalid", ctx.errorState);
      \u0275\u0275classProp("mat-mdc-chip-list-disabled", ctx.disabled)("mat-mdc-chip-list-invalid", ctx.errorState)("mat-mdc-chip-list-required", ctx.required);
    }
  },
  inputs: {
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    placeholder: "placeholder",
    required: [InputFlags.HasDecoratorInputTransform, "required", "required", booleanAttribute],
    value: "value",
    errorStateMatcher: "errorStateMatcher"
  },
  outputs: {
    change: "change",
    valueChange: "valueChange"
  },
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MatFormFieldControl,
    useExisting: _MatChipGrid
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c5,
  decls: 2,
  vars: 0,
  consts: [["role", "presentation", 1, "mdc-evolution-chip-set__chips"]],
  template: function MatChipGrid_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "div", 0);
      \u0275\u0275projection(1);
      \u0275\u0275elementEnd();
    }
  },
  styles: [_c6],
  encapsulation: 2,
  changeDetection: 0
});
var MatChipGrid = _MatChipGrid;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipGrid, [{
    type: Component,
    args: [{
      selector: "mat-chip-grid",
      template: `
    <div class="mdc-evolution-chip-set__chips" role="presentation">
      <ng-content></ng-content>
    </div>
  `,
      host: {
        "class": "mat-mdc-chip-set mat-mdc-chip-grid mdc-evolution-chip-set",
        "[attr.role]": "role",
        "[attr.tabindex]": "(disabled || (_chips && _chips.length === 0)) ? -1 : tabIndex",
        "[attr.aria-disabled]": "disabled.toString()",
        "[attr.aria-invalid]": "errorState",
        "[class.mat-mdc-chip-list-disabled]": "disabled",
        "[class.mat-mdc-chip-list-invalid]": "errorState",
        "[class.mat-mdc-chip-list-required]": "required",
        "(focus)": "focus()",
        "(blur)": "_blur()"
      },
      providers: [{
        provide: MatFormFieldControl,
        useExisting: MatChipGrid
      }],
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true,
      styles: [".mdc-evolution-chip-set{display:flex}.mdc-evolution-chip-set:focus{outline:none}.mdc-evolution-chip-set__chips{display:flex;flex-flow:wrap;min-width:0}.mdc-evolution-chip-set--overflow .mdc-evolution-chip-set__chips{flex-flow:nowrap}.mdc-evolution-chip-set .mdc-evolution-chip-set__chips{margin-left:-8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip-set__chips,.mdc-evolution-chip-set .mdc-evolution-chip-set__chips[dir=rtl]{margin-left:0;margin-right:-8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-left:8px;margin-right:0}[dir=rtl] .mdc-evolution-chip-set .mdc-evolution-chip,.mdc-evolution-chip-set .mdc-evolution-chip[dir=rtl]{margin-left:0;margin-right:8px}.mdc-evolution-chip-set .mdc-evolution-chip{margin-top:4px;margin-bottom:4px}.mat-mdc-chip-set .mdc-evolution-chip-set__chips{min-width:100%}.mat-mdc-chip-set-stacked{flex-direction:column;align-items:flex-start}.mat-mdc-chip-set-stacked .mat-mdc-chip{width:100%}.mat-mdc-chip-set-stacked .mdc-evolution-chip__graphic{flex-grow:0}.mat-mdc-chip-set-stacked .mdc-evolution-chip__action--primary{flex-basis:100%;justify-content:start}input.mat-mdc-chip-input{flex:1 0 150px;margin-left:8px}[dir=rtl] input.mat-mdc-chip-input{margin-left:0;margin-right:8px}"]
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: ChangeDetectorRef
  }, {
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }, {
    type: NgForm,
    decorators: [{
      type: Optional
    }]
  }, {
    type: FormGroupDirective,
    decorators: [{
      type: Optional
    }]
  }, {
    type: ErrorStateMatcher
  }, {
    type: NgControl,
    decorators: [{
      type: Optional
    }, {
      type: Self
    }]
  }], {
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    placeholder: [{
      type: Input
    }],
    required: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    value: [{
      type: Input
    }],
    errorStateMatcher: [{
      type: Input
    }],
    change: [{
      type: Output
    }],
    valueChange: [{
      type: Output
    }],
    _chips: [{
      type: ContentChildren,
      args: [MatChipRow, {
        // We need to use `descendants: true`, because Ivy will no longer match
        // indirect descendants if it's left as false.
        descendants: true
      }]
    }]
  });
})();
var nextUniqueId = 0;
var _MatChipInput = class _MatChipInput {
  /** Register input for chip list */
  get chipGrid() {
    return this._chipGrid;
  }
  set chipGrid(value) {
    if (value) {
      this._chipGrid = value;
      this._chipGrid.registerInput(this);
    }
  }
  /** Whether the input is disabled. */
  get disabled() {
    return this._disabled || this._chipGrid && this._chipGrid.disabled;
  }
  set disabled(value) {
    this._disabled = value;
  }
  /** Whether the input is empty. */
  get empty() {
    return !this.inputElement.value;
  }
  constructor(_elementRef, defaultOptions, formField) {
    this._elementRef = _elementRef;
    this.focused = false;
    this.addOnBlur = false;
    this.chipEnd = new EventEmitter();
    this.placeholder = "";
    this.id = `mat-mdc-chip-list-input-${nextUniqueId++}`;
    this._disabled = false;
    this.inputElement = this._elementRef.nativeElement;
    this.separatorKeyCodes = defaultOptions.separatorKeyCodes;
    if (formField) {
      this.inputElement.classList.add("mat-mdc-form-field-input-control");
    }
  }
  ngOnChanges() {
    this._chipGrid.stateChanges.next();
  }
  ngOnDestroy() {
    this.chipEnd.complete();
  }
  ngAfterContentInit() {
    this._focusLastChipOnBackspace = this.empty;
  }
  /** Utility method to make host definition/tests more clear. */
  _keydown(event) {
    if (event) {
      if (event.keyCode === BACKSPACE && this._focusLastChipOnBackspace) {
        this._chipGrid._focusLastChip();
        event.preventDefault();
        return;
      } else {
        this._focusLastChipOnBackspace = false;
      }
    }
    this._emitChipEnd(event);
  }
  /**
   * Pass events to the keyboard manager. Available here for tests.
   */
  _keyup(event) {
    if (!this._focusLastChipOnBackspace && event.keyCode === BACKSPACE && this.empty) {
      this._focusLastChipOnBackspace = true;
      event.preventDefault();
    }
  }
  /** Checks to see if the blur should emit the (chipEnd) event. */
  _blur() {
    if (this.addOnBlur) {
      this._emitChipEnd();
    }
    this.focused = false;
    if (!this._chipGrid.focused) {
      this._chipGrid._blur();
    }
    this._chipGrid.stateChanges.next();
  }
  _focus() {
    this.focused = true;
    this._focusLastChipOnBackspace = this.empty;
    this._chipGrid.stateChanges.next();
  }
  /** Checks to see if the (chipEnd) event needs to be emitted. */
  _emitChipEnd(event) {
    if (!event || this._isSeparatorKey(event)) {
      this.chipEnd.emit({
        input: this.inputElement,
        value: this.inputElement.value,
        chipInput: this
      });
      event?.preventDefault();
    }
  }
  _onInput() {
    this._chipGrid.stateChanges.next();
  }
  /** Focuses the input. */
  focus() {
    this.inputElement.focus();
  }
  /** Clears the input */
  clear() {
    this.inputElement.value = "";
    this._focusLastChipOnBackspace = true;
  }
  setDescribedByIds(ids) {
    const element = this._elementRef.nativeElement;
    if (ids.length) {
      element.setAttribute("aria-describedby", ids.join(" "));
    } else {
      element.removeAttribute("aria-describedby");
    }
  }
  /** Checks whether a keycode is one of the configured separators. */
  _isSeparatorKey(event) {
    return !hasModifierKey(event) && new Set(this.separatorKeyCodes).has(event.keyCode);
  }
};
_MatChipInput.\u0275fac = function MatChipInput_Factory(t) {
  return new (t || _MatChipInput)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(MAT_CHIPS_DEFAULT_OPTIONS), \u0275\u0275directiveInject(MAT_FORM_FIELD, 8));
};
_MatChipInput.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatChipInput,
  selectors: [["input", "matChipInputFor", ""]],
  hostAttrs: [1, "mat-mdc-chip-input", "mat-mdc-input-element", "mdc-text-field__input", "mat-input-element"],
  hostVars: 6,
  hostBindings: function MatChipInput_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("keydown", function MatChipInput_keydown_HostBindingHandler($event) {
        return ctx._keydown($event);
      })("keyup", function MatChipInput_keyup_HostBindingHandler($event) {
        return ctx._keyup($event);
      })("blur", function MatChipInput_blur_HostBindingHandler() {
        return ctx._blur();
      })("focus", function MatChipInput_focus_HostBindingHandler() {
        return ctx._focus();
      })("input", function MatChipInput_input_HostBindingHandler() {
        return ctx._onInput();
      });
    }
    if (rf & 2) {
      \u0275\u0275hostProperty("id", ctx.id);
      \u0275\u0275attribute("disabled", ctx.disabled || null)("placeholder", ctx.placeholder || null)("aria-invalid", ctx._chipGrid && ctx._chipGrid.ngControl ? ctx._chipGrid.ngControl.invalid : null)("aria-required", ctx._chipGrid && ctx._chipGrid.required || null)("required", ctx._chipGrid && ctx._chipGrid.required || null);
    }
  },
  inputs: {
    chipGrid: [InputFlags.None, "matChipInputFor", "chipGrid"],
    addOnBlur: [InputFlags.HasDecoratorInputTransform, "matChipInputAddOnBlur", "addOnBlur", booleanAttribute],
    separatorKeyCodes: [InputFlags.None, "matChipInputSeparatorKeyCodes", "separatorKeyCodes"],
    placeholder: "placeholder",
    id: "id",
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute]
  },
  outputs: {
    chipEnd: "matChipInputTokenEnd"
  },
  exportAs: ["matChipInput", "matChipInputFor"],
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature, \u0275\u0275NgOnChangesFeature]
});
var MatChipInput = _MatChipInput;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipInput, [{
    type: Directive,
    args: [{
      selector: "input[matChipInputFor]",
      exportAs: "matChipInput, matChipInputFor",
      host: {
        // TODO: eventually we should remove `mat-input-element` from here since it comes from the
        // non-MDC version of the input. It's currently being kept for backwards compatibility, because
        // the MDC chips were landed initially with it.
        "class": "mat-mdc-chip-input mat-mdc-input-element mdc-text-field__input mat-input-element",
        "(keydown)": "_keydown($event)",
        "(keyup)": "_keyup($event)",
        "(blur)": "_blur()",
        "(focus)": "_focus()",
        "(input)": "_onInput()",
        "[id]": "id",
        "[attr.disabled]": "disabled || null",
        "[attr.placeholder]": "placeholder || null",
        "[attr.aria-invalid]": "_chipGrid && _chipGrid.ngControl ? _chipGrid.ngControl.invalid : null",
        "[attr.aria-required]": "_chipGrid && _chipGrid.required || null",
        "[attr.required]": "_chipGrid && _chipGrid.required || null"
      },
      standalone: true
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_CHIPS_DEFAULT_OPTIONS]
    }]
  }, {
    type: MatFormField,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_FORM_FIELD]
    }]
  }], {
    chipGrid: [{
      type: Input,
      args: ["matChipInputFor"]
    }],
    addOnBlur: [{
      type: Input,
      args: [{
        alias: "matChipInputAddOnBlur",
        transform: booleanAttribute
      }]
    }],
    separatorKeyCodes: [{
      type: Input,
      args: ["matChipInputSeparatorKeyCodes"]
    }],
    chipEnd: [{
      type: Output,
      args: ["matChipInputTokenEnd"]
    }],
    placeholder: [{
      type: Input
    }],
    id: [{
      type: Input
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }]
  });
})();
var CHIP_DECLARATIONS = [MatChip, MatChipAvatar, MatChipEditInput, MatChipGrid, MatChipInput, MatChipListbox, MatChipOption, MatChipRemove, MatChipRow, MatChipSet, MatChipTrailingIcon];
var _MatChipsModule = class _MatChipsModule {
};
_MatChipsModule.\u0275fac = function MatChipsModule_Factory(t) {
  return new (t || _MatChipsModule)();
};
_MatChipsModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatChipsModule
});
_MatChipsModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  providers: [ErrorStateMatcher, {
    provide: MAT_CHIPS_DEFAULT_OPTIONS,
    useValue: {
      separatorKeyCodes: [ENTER]
    }
  }],
  imports: [MatCommonModule, MatRippleModule, MatCommonModule]
});
var MatChipsModule = _MatChipsModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatChipsModule, [{
    type: NgModule,
    args: [{
      imports: [MatCommonModule, MatRippleModule, MatChipAction, CHIP_DECLARATIONS],
      exports: [MatCommonModule, CHIP_DECLARATIONS],
      providers: [ErrorStateMatcher, {
        provide: MAT_CHIPS_DEFAULT_OPTIONS,
        useValue: {
          separatorKeyCodes: [ENTER]
        }
      }]
    }]
  }], null, null);
})();

// node_modules/@angular/material/fesm2022/autocomplete.mjs
var _c02 = ["panel"];
var _c12 = ["*"];
function MatAutocomplete_ng_template_0_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 1, 0);
    \u0275\u0275listener("@panelAnimation.done", function MatAutocomplete_ng_template_0_Template_div_animation_panelAnimation_done_0_listener($event) {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1._animationDone.next($event));
    });
    \u0275\u0275projection(2);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const formFieldId_r3 = ctx.id;
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275classMap(ctx_r1._classList);
    \u0275\u0275classProp("mat-mdc-autocomplete-visible", ctx_r1.showPanel)("mat-mdc-autocomplete-hidden", !ctx_r1.showPanel)("mat-primary", ctx_r1._color === "primary")("mat-accent", ctx_r1._color === "accent")("mat-warn", ctx_r1._color === "warn");
    \u0275\u0275property("id", ctx_r1.id)("@panelAnimation", ctx_r1.isOpen ? "visible" : "hidden");
    \u0275\u0275attribute("aria-label", ctx_r1.ariaLabel || null)("aria-labelledby", ctx_r1._getPanelAriaLabelledby(formFieldId_r3));
  }
}
var panelAnimation = trigger("panelAnimation", [state("void, hidden", style({
  opacity: 0,
  transform: "scaleY(0.8)"
})), transition(":enter, hidden => visible", [group([animate("0.03s linear", style({
  opacity: 1
})), animate("0.12s cubic-bezier(0, 0, 0.2, 1)", style({
  transform: "scaleY(1)"
}))])]), transition(":leave, visible => hidden", [animate("0.075s linear", style({
  opacity: 0
}))])]);
var _uniqueAutocompleteIdCounter = 0;
var MatAutocompleteSelectedEvent = class {
  constructor(source, option) {
    this.source = source;
    this.option = option;
  }
};
var MAT_AUTOCOMPLETE_DEFAULT_OPTIONS = new InjectionToken("mat-autocomplete-default-options", {
  providedIn: "root",
  factory: MAT_AUTOCOMPLETE_DEFAULT_OPTIONS_FACTORY
});
function MAT_AUTOCOMPLETE_DEFAULT_OPTIONS_FACTORY() {
  return {
    autoActiveFirstOption: false,
    autoSelectActiveOption: false,
    hideSingleSelectionIndicator: false,
    requireSelection: false
  };
}
var _MatAutocomplete = class _MatAutocomplete {
  /** Whether the autocomplete panel is open. */
  get isOpen() {
    return this._isOpen && this.showPanel;
  }
  /** @docs-private Sets the theme color of the panel. */
  _setColor(value) {
    this._color = value;
    this._changeDetectorRef.markForCheck();
  }
  /**
   * Takes classes set on the host mat-autocomplete element and applies them to the panel
   * inside the overlay container to allow for easy styling.
   */
  set classList(value) {
    this._classList = value;
    this._elementRef.nativeElement.className = "";
  }
  /** Whether checkmark indicator for single-selection options is hidden. */
  get hideSingleSelectionIndicator() {
    return this._hideSingleSelectionIndicator;
  }
  set hideSingleSelectionIndicator(value) {
    this._hideSingleSelectionIndicator = value;
    this._syncParentProperties();
  }
  /** Syncs the parent state with the individual options. */
  _syncParentProperties() {
    if (this.options) {
      for (const option of this.options) {
        option._changeDetectorRef.markForCheck();
      }
    }
  }
  constructor(_changeDetectorRef, _elementRef, _defaults, platform) {
    this._changeDetectorRef = _changeDetectorRef;
    this._elementRef = _elementRef;
    this._defaults = _defaults;
    this._activeOptionChanges = Subscription.EMPTY;
    this._animationDone = new EventEmitter();
    this.showPanel = false;
    this._isOpen = false;
    this.displayWith = null;
    this.optionSelected = new EventEmitter();
    this.opened = new EventEmitter();
    this.closed = new EventEmitter();
    this.optionActivated = new EventEmitter();
    this.id = `mat-autocomplete-${_uniqueAutocompleteIdCounter++}`;
    this.inertGroups = platform?.SAFARI || false;
    this.autoActiveFirstOption = !!_defaults.autoActiveFirstOption;
    this.autoSelectActiveOption = !!_defaults.autoSelectActiveOption;
    this.requireSelection = !!_defaults.requireSelection;
    this._hideSingleSelectionIndicator = this._defaults.hideSingleSelectionIndicator ?? false;
  }
  ngAfterContentInit() {
    this._keyManager = new ActiveDescendantKeyManager(this.options).withWrap().skipPredicate(this._skipPredicate);
    this._activeOptionChanges = this._keyManager.change.subscribe((index) => {
      if (this.isOpen) {
        this.optionActivated.emit({
          source: this,
          option: this.options.toArray()[index] || null
        });
      }
    });
    this._setVisibility();
  }
  ngOnDestroy() {
    this._keyManager?.destroy();
    this._activeOptionChanges.unsubscribe();
    this._animationDone.complete();
  }
  /**
   * Sets the panel scrollTop. This allows us to manually scroll to display options
   * above or below the fold, as they are not actually being focused when active.
   */
  _setScrollTop(scrollTop) {
    if (this.panel) {
      this.panel.nativeElement.scrollTop = scrollTop;
    }
  }
  /** Returns the panel's scrollTop. */
  _getScrollTop() {
    return this.panel ? this.panel.nativeElement.scrollTop : 0;
  }
  /** Panel should hide itself when the option list is empty. */
  _setVisibility() {
    this.showPanel = !!this.options.length;
    this._changeDetectorRef.markForCheck();
  }
  /** Emits the `select` event. */
  _emitSelectEvent(option) {
    const event = new MatAutocompleteSelectedEvent(this, option);
    this.optionSelected.emit(event);
  }
  /** Gets the aria-labelledby for the autocomplete panel. */
  _getPanelAriaLabelledby(labelId) {
    if (this.ariaLabel) {
      return null;
    }
    const labelExpression = labelId ? labelId + " " : "";
    return this.ariaLabelledby ? labelExpression + this.ariaLabelledby : labelId;
  }
  // `skipPredicate` determines if key manager should avoid putting a given option in the tab
  // order. Allow disabled list items to receive focus via keyboard to align with WAI ARIA
  // recommendation.
  //
  // Normally WAI ARIA's instructions are to exclude disabled items from the tab order, but it
  // makes a few exceptions for compound widgets.
  //
  // From [Developing a Keyboard Interface](
  // https://www.w3.org/WAI/ARIA/apg/practices/keyboard-interface/):
  //   "For the following composite widget elements, keep them focusable when disabled: Options in a
  //   Listbox..."
  //
  // The user can focus disabled options using the keyboard, but the user cannot click disabled
  // options.
  _skipPredicate() {
    return false;
  }
};
_MatAutocomplete.\u0275fac = function MatAutocomplete_Factory(t) {
  return new (t || _MatAutocomplete)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(MAT_AUTOCOMPLETE_DEFAULT_OPTIONS), \u0275\u0275directiveInject(Platform));
};
_MatAutocomplete.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatAutocomplete,
  selectors: [["mat-autocomplete"]],
  contentQueries: function MatAutocomplete_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatOption, 5);
      \u0275\u0275contentQuery(dirIndex, MAT_OPTGROUP, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.options = _t);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.optionGroups = _t);
    }
  },
  viewQuery: function MatAutocomplete_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(TemplateRef, 7);
      \u0275\u0275viewQuery(_c02, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.template = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.panel = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-autocomplete"],
  inputs: {
    ariaLabel: [InputFlags.None, "aria-label", "ariaLabel"],
    ariaLabelledby: [InputFlags.None, "aria-labelledby", "ariaLabelledby"],
    displayWith: "displayWith",
    autoActiveFirstOption: [InputFlags.HasDecoratorInputTransform, "autoActiveFirstOption", "autoActiveFirstOption", booleanAttribute],
    autoSelectActiveOption: [InputFlags.HasDecoratorInputTransform, "autoSelectActiveOption", "autoSelectActiveOption", booleanAttribute],
    requireSelection: [InputFlags.HasDecoratorInputTransform, "requireSelection", "requireSelection", booleanAttribute],
    panelWidth: "panelWidth",
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    classList: [InputFlags.None, "class", "classList"],
    hideSingleSelectionIndicator: [InputFlags.HasDecoratorInputTransform, "hideSingleSelectionIndicator", "hideSingleSelectionIndicator", booleanAttribute]
  },
  outputs: {
    optionSelected: "optionSelected",
    opened: "opened",
    closed: "closed",
    optionActivated: "optionActivated"
  },
  exportAs: ["matAutocomplete"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_OPTION_PARENT_COMPONENT,
    useExisting: _MatAutocomplete
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c12,
  decls: 1,
  vars: 0,
  consts: [["panel", ""], ["role", "listbox", 1, "mat-mdc-autocomplete-panel", "mdc-menu-surface", "mdc-menu-surface--open", 3, "id"]],
  template: function MatAutocomplete_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275template(0, MatAutocomplete_ng_template_0_Template, 3, 16, "ng-template");
    }
  },
  styles: ["div.mat-mdc-autocomplete-panel{width:100%;max-height:256px;visibility:hidden;transform-origin:center top;overflow:auto;padding:8px 0;box-sizing:border-box;position:static;border-radius:var(--mat-autocomplete-container-shape);box-shadow:var(--mat-autocomplete-container-elevation-shadow);background-color:var(--mat-autocomplete-background-color)}.cdk-high-contrast-active div.mat-mdc-autocomplete-panel{outline:solid 1px}.cdk-overlay-pane:not(.mat-mdc-autocomplete-panel-above) div.mat-mdc-autocomplete-panel{border-top-left-radius:0;border-top-right-radius:0}.mat-mdc-autocomplete-panel-above div.mat-mdc-autocomplete-panel{border-bottom-left-radius:0;border-bottom-right-radius:0;transform-origin:center bottom}div.mat-mdc-autocomplete-panel.mat-mdc-autocomplete-visible{visibility:visible}div.mat-mdc-autocomplete-panel.mat-mdc-autocomplete-hidden{visibility:hidden;pointer-events:none}mat-autocomplete{display:none}"],
  encapsulation: 2,
  data: {
    animation: [panelAnimation]
  },
  changeDetection: 0
});
var MatAutocomplete = _MatAutocomplete;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatAutocomplete, [{
    type: Component,
    args: [{
      selector: "mat-autocomplete",
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      exportAs: "matAutocomplete",
      host: {
        "class": "mat-mdc-autocomplete"
      },
      providers: [{
        provide: MAT_OPTION_PARENT_COMPONENT,
        useExisting: MatAutocomplete
      }],
      animations: [panelAnimation],
      standalone: true,
      template: `<ng-template let-formFieldId="id">
  <div
    class="mat-mdc-autocomplete-panel mdc-menu-surface mdc-menu-surface--open"
    role="listbox"
    [id]="id"
    [class]="_classList"
    [class.mat-mdc-autocomplete-visible]="showPanel"
    [class.mat-mdc-autocomplete-hidden]="!showPanel"
    [class.mat-primary]="_color === 'primary'"
    [class.mat-accent]="_color === 'accent'"
    [class.mat-warn]="_color === 'warn'"
    [attr.aria-label]="ariaLabel || null"
    [attr.aria-labelledby]="_getPanelAriaLabelledby(formFieldId)"
    [@panelAnimation]="isOpen ? 'visible' : 'hidden'"
    (@panelAnimation.done)="_animationDone.next($event)"
    #panel>
    <ng-content></ng-content>
  </div>
</ng-template>
`,
      styles: ["div.mat-mdc-autocomplete-panel{width:100%;max-height:256px;visibility:hidden;transform-origin:center top;overflow:auto;padding:8px 0;box-sizing:border-box;position:static;border-radius:var(--mat-autocomplete-container-shape);box-shadow:var(--mat-autocomplete-container-elevation-shadow);background-color:var(--mat-autocomplete-background-color)}.cdk-high-contrast-active div.mat-mdc-autocomplete-panel{outline:solid 1px}.cdk-overlay-pane:not(.mat-mdc-autocomplete-panel-above) div.mat-mdc-autocomplete-panel{border-top-left-radius:0;border-top-right-radius:0}.mat-mdc-autocomplete-panel-above div.mat-mdc-autocomplete-panel{border-bottom-left-radius:0;border-bottom-right-radius:0;transform-origin:center bottom}div.mat-mdc-autocomplete-panel.mat-mdc-autocomplete-visible{visibility:visible}div.mat-mdc-autocomplete-panel.mat-mdc-autocomplete-hidden{visibility:hidden;pointer-events:none}mat-autocomplete{display:none}"]
    }]
  }], () => [{
    type: ChangeDetectorRef
  }, {
    type: ElementRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_AUTOCOMPLETE_DEFAULT_OPTIONS]
    }]
  }, {
    type: Platform
  }], {
    template: [{
      type: ViewChild,
      args: [TemplateRef, {
        static: true
      }]
    }],
    panel: [{
      type: ViewChild,
      args: ["panel"]
    }],
    options: [{
      type: ContentChildren,
      args: [MatOption, {
        descendants: true
      }]
    }],
    optionGroups: [{
      type: ContentChildren,
      args: [MAT_OPTGROUP, {
        descendants: true
      }]
    }],
    ariaLabel: [{
      type: Input,
      args: ["aria-label"]
    }],
    ariaLabelledby: [{
      type: Input,
      args: ["aria-labelledby"]
    }],
    displayWith: [{
      type: Input
    }],
    autoActiveFirstOption: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    autoSelectActiveOption: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    requireSelection: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    panelWidth: [{
      type: Input
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    optionSelected: [{
      type: Output
    }],
    opened: [{
      type: Output
    }],
    closed: [{
      type: Output
    }],
    optionActivated: [{
      type: Output
    }],
    classList: [{
      type: Input,
      args: ["class"]
    }],
    hideSingleSelectionIndicator: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }]
  });
})();
var _MatAutocompleteOrigin = class _MatAutocompleteOrigin {
  constructor(elementRef) {
    this.elementRef = elementRef;
  }
};
_MatAutocompleteOrigin.\u0275fac = function MatAutocompleteOrigin_Factory(t) {
  return new (t || _MatAutocompleteOrigin)(\u0275\u0275directiveInject(ElementRef));
};
_MatAutocompleteOrigin.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatAutocompleteOrigin,
  selectors: [["", "matAutocompleteOrigin", ""]],
  exportAs: ["matAutocompleteOrigin"],
  standalone: true
});
var MatAutocompleteOrigin = _MatAutocompleteOrigin;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatAutocompleteOrigin, [{
    type: Directive,
    args: [{
      selector: "[matAutocompleteOrigin]",
      exportAs: "matAutocompleteOrigin",
      standalone: true
    }]
  }], () => [{
    type: ElementRef
  }], null);
})();
var MAT_AUTOCOMPLETE_VALUE_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => MatAutocompleteTrigger),
  multi: true
};
function getMatAutocompleteMissingPanelError() {
  return Error("Attempting to open an undefined instance of `mat-autocomplete`. Make sure that the id passed to the `matAutocomplete` is correct and that you're attempting to open it after the ngAfterContentInit hook.");
}
var MAT_AUTOCOMPLETE_SCROLL_STRATEGY = new InjectionToken("mat-autocomplete-scroll-strategy", {
  providedIn: "root",
  factory: () => {
    const overlay = inject(Overlay);
    return () => overlay.scrollStrategies.reposition();
  }
});
function MAT_AUTOCOMPLETE_SCROLL_STRATEGY_FACTORY(overlay) {
  return () => overlay.scrollStrategies.reposition();
}
var MAT_AUTOCOMPLETE_SCROLL_STRATEGY_FACTORY_PROVIDER = {
  provide: MAT_AUTOCOMPLETE_SCROLL_STRATEGY,
  deps: [Overlay],
  useFactory: MAT_AUTOCOMPLETE_SCROLL_STRATEGY_FACTORY
};
var _MatAutocompleteTrigger = class _MatAutocompleteTrigger {
  constructor(_element, _overlay, _viewContainerRef, _zone, _changeDetectorRef, scrollStrategy, _dir, _formField, _document, _viewportRuler, _defaults) {
    this._element = _element;
    this._overlay = _overlay;
    this._viewContainerRef = _viewContainerRef;
    this._zone = _zone;
    this._changeDetectorRef = _changeDetectorRef;
    this._dir = _dir;
    this._formField = _formField;
    this._document = _document;
    this._viewportRuler = _viewportRuler;
    this._defaults = _defaults;
    this._componentDestroyed = false;
    this._manuallyFloatingLabel = false;
    this._viewportSubscription = Subscription.EMPTY;
    this._canOpenOnNextFocus = true;
    this._closeKeyEventStream = new Subject();
    this._windowBlurHandler = () => {
      this._canOpenOnNextFocus = this._document.activeElement !== this._element.nativeElement || this.panelOpen;
    };
    this._onChange = () => {
    };
    this._onTouched = () => {
    };
    this.position = "auto";
    this.autocompleteAttribute = "off";
    this._aboveClass = "mat-mdc-autocomplete-panel-above";
    this._overlayAttached = false;
    this.optionSelections = defer(() => {
      const options = this.autocomplete ? this.autocomplete.options : null;
      if (options) {
        return options.changes.pipe(startWith(options), switchMap(() => merge(...options.map((option) => option.onSelectionChange))));
      }
      return this._zone.onStable.pipe(take(1), switchMap(() => this.optionSelections));
    });
    this._handlePanelKeydown = (event) => {
      if (event.keyCode === ESCAPE && !hasModifierKey(event) || event.keyCode === UP_ARROW && hasModifierKey(event, "altKey")) {
        if (this._pendingAutoselectedOption) {
          this._updateNativeInputValue(this._valueBeforeAutoSelection ?? "");
          this._pendingAutoselectedOption = null;
        }
        this._closeKeyEventStream.next();
        this._resetActiveItem();
        event.stopPropagation();
        event.preventDefault();
      }
    };
    this._trackedModal = null;
    this._scrollStrategy = scrollStrategy;
  }
  ngAfterViewInit() {
    const window2 = this._getWindow();
    if (typeof window2 !== "undefined") {
      this._zone.runOutsideAngular(() => window2.addEventListener("blur", this._windowBlurHandler));
    }
  }
  ngOnChanges(changes) {
    if (changes["position"] && this._positionStrategy) {
      this._setStrategyPositions(this._positionStrategy);
      if (this.panelOpen) {
        this._overlayRef.updatePosition();
      }
    }
  }
  ngOnDestroy() {
    const window2 = this._getWindow();
    if (typeof window2 !== "undefined") {
      window2.removeEventListener("blur", this._windowBlurHandler);
    }
    this._viewportSubscription.unsubscribe();
    this._componentDestroyed = true;
    this._destroyPanel();
    this._closeKeyEventStream.complete();
    this._clearFromModal();
  }
  /** Whether or not the autocomplete panel is open. */
  get panelOpen() {
    return this._overlayAttached && this.autocomplete.showPanel;
  }
  /** Opens the autocomplete suggestion panel. */
  openPanel() {
    this._openPanelInternal();
  }
  /** Closes the autocomplete suggestion panel. */
  closePanel() {
    this._resetLabel();
    if (!this._overlayAttached) {
      return;
    }
    if (this.panelOpen) {
      this._zone.run(() => {
        this.autocomplete.closed.emit();
      });
    }
    if (this.autocomplete._latestOpeningTrigger === this) {
      this.autocomplete._isOpen = false;
      this.autocomplete._latestOpeningTrigger = null;
    }
    this._overlayAttached = false;
    this._pendingAutoselectedOption = null;
    if (this._overlayRef && this._overlayRef.hasAttached()) {
      this._overlayRef.detach();
      this._closingActionsSubscription.unsubscribe();
    }
    this._updatePanelState();
    if (!this._componentDestroyed) {
      this._changeDetectorRef.detectChanges();
    }
    if (this._trackedModal) {
      removeAriaReferencedId(this._trackedModal, "aria-owns", this.autocomplete.id);
    }
  }
  /**
   * Updates the position of the autocomplete suggestion panel to ensure that it fits all options
   * within the viewport.
   */
  updatePosition() {
    if (this._overlayAttached) {
      this._overlayRef.updatePosition();
    }
  }
  /**
   * A stream of actions that should close the autocomplete panel, including
   * when an option is selected, on blur, and when TAB is pressed.
   */
  get panelClosingActions() {
    return merge(this.optionSelections, this.autocomplete._keyManager.tabOut.pipe(filter(() => this._overlayAttached)), this._closeKeyEventStream, this._getOutsideClickStream(), this._overlayRef ? this._overlayRef.detachments().pipe(filter(() => this._overlayAttached)) : of()).pipe(
      // Normalize the output so we return a consistent type.
      map((event) => event instanceof MatOptionSelectionChange ? event : null)
    );
  }
  /** The currently active option, coerced to MatOption type. */
  get activeOption() {
    if (this.autocomplete && this.autocomplete._keyManager) {
      return this.autocomplete._keyManager.activeItem;
    }
    return null;
  }
  /** Stream of clicks outside of the autocomplete panel. */
  _getOutsideClickStream() {
    return merge(fromEvent(this._document, "click"), fromEvent(this._document, "auxclick"), fromEvent(this._document, "touchend")).pipe(filter((event) => {
      const clickTarget = _getEventTarget(event);
      const formField = this._formField ? this._formField.getConnectedOverlayOrigin().nativeElement : null;
      const customOrigin = this.connectedTo ? this.connectedTo.elementRef.nativeElement : null;
      return this._overlayAttached && clickTarget !== this._element.nativeElement && // Normally focus moves inside `mousedown` so this condition will almost always be
      // true. Its main purpose is to handle the case where the input is focused from an
      // outside click which propagates up to the `body` listener within the same sequence
      // and causes the panel to close immediately (see #3106).
      this._document.activeElement !== this._element.nativeElement && (!formField || !formField.contains(clickTarget)) && (!customOrigin || !customOrigin.contains(clickTarget)) && !!this._overlayRef && !this._overlayRef.overlayElement.contains(clickTarget);
    }));
  }
  // Implemented as part of ControlValueAccessor.
  writeValue(value) {
    Promise.resolve(null).then(() => this._assignOptionValue(value));
  }
  // Implemented as part of ControlValueAccessor.
  registerOnChange(fn) {
    this._onChange = fn;
  }
  // Implemented as part of ControlValueAccessor.
  registerOnTouched(fn) {
    this._onTouched = fn;
  }
  // Implemented as part of ControlValueAccessor.
  setDisabledState(isDisabled) {
    this._element.nativeElement.disabled = isDisabled;
  }
  _handleKeydown(event) {
    const keyCode = event.keyCode;
    const hasModifier = hasModifierKey(event);
    if (keyCode === ESCAPE && !hasModifier) {
      event.preventDefault();
    }
    this._valueOnLastKeydown = this._element.nativeElement.value;
    if (this.activeOption && keyCode === ENTER && this.panelOpen && !hasModifier) {
      this.activeOption._selectViaInteraction();
      this._resetActiveItem();
      event.preventDefault();
    } else if (this.autocomplete) {
      const prevActiveItem = this.autocomplete._keyManager.activeItem;
      const isArrowKey = keyCode === UP_ARROW || keyCode === DOWN_ARROW;
      if (keyCode === TAB || isArrowKey && !hasModifier && this.panelOpen) {
        this.autocomplete._keyManager.onKeydown(event);
      } else if (isArrowKey && this._canOpen()) {
        this._openPanelInternal(this._valueOnLastKeydown);
      }
      if (isArrowKey || this.autocomplete._keyManager.activeItem !== prevActiveItem) {
        this._scrollToOption(this.autocomplete._keyManager.activeItemIndex || 0);
        if (this.autocomplete.autoSelectActiveOption && this.activeOption) {
          if (!this._pendingAutoselectedOption) {
            this._valueBeforeAutoSelection = this._valueOnLastKeydown;
          }
          this._pendingAutoselectedOption = this.activeOption;
          this._assignOptionValue(this.activeOption.value);
        }
      }
    }
  }
  _handleInput(event) {
    let target = event.target;
    let value = target.value;
    if (target.type === "number") {
      value = value == "" ? null : parseFloat(value);
    }
    if (this._previousValue !== value) {
      this._previousValue = value;
      this._pendingAutoselectedOption = null;
      if (!this.autocomplete || !this.autocomplete.requireSelection) {
        this._onChange(value);
      }
      if (!value) {
        this._clearPreviousSelectedOption(null, false);
      } else if (this.panelOpen && !this.autocomplete.requireSelection) {
        const selectedOption = this.autocomplete.options?.find((option) => option.selected);
        if (selectedOption) {
          const display = this._getDisplayValue(selectedOption.value);
          if (value !== display) {
            selectedOption.deselect(false);
          }
        }
      }
      if (this._canOpen() && this._document.activeElement === event.target) {
        const valueOnAttach = this._valueOnLastKeydown ?? this._element.nativeElement.value;
        this._valueOnLastKeydown = null;
        this._openPanelInternal(valueOnAttach);
      }
    }
  }
  _handleFocus() {
    if (!this._canOpenOnNextFocus) {
      this._canOpenOnNextFocus = true;
    } else if (this._canOpen()) {
      this._previousValue = this._element.nativeElement.value;
      this._attachOverlay(this._previousValue);
      this._floatLabel(true);
    }
  }
  _handleClick() {
    if (this._canOpen() && !this.panelOpen) {
      this._openPanelInternal();
    }
  }
  /**
   * In "auto" mode, the label will animate down as soon as focus is lost.
   * This causes the value to jump when selecting an option with the mouse.
   * This method manually floats the label until the panel can be closed.
   * @param shouldAnimate Whether the label should be animated when it is floated.
   */
  _floatLabel(shouldAnimate = false) {
    if (this._formField && this._formField.floatLabel === "auto") {
      if (shouldAnimate) {
        this._formField._animateAndLockLabel();
      } else {
        this._formField.floatLabel = "always";
      }
      this._manuallyFloatingLabel = true;
    }
  }
  /** If the label has been manually elevated, return it to its normal state. */
  _resetLabel() {
    if (this._manuallyFloatingLabel) {
      if (this._formField) {
        this._formField.floatLabel = "auto";
      }
      this._manuallyFloatingLabel = false;
    }
  }
  /**
   * This method listens to a stream of panel closing actions and resets the
   * stream every time the option list changes.
   */
  _subscribeToClosingActions() {
    const firstStable = this._zone.onStable.pipe(take(1));
    const optionChanges = this.autocomplete.options.changes.pipe(
      tap(() => this._positionStrategy.reapplyLastPosition()),
      // Defer emitting to the stream until the next tick, because changing
      // bindings in here will cause "changed after checked" errors.
      delay(0)
    );
    return merge(firstStable, optionChanges).pipe(
      // create a new stream of panelClosingActions, replacing any previous streams
      // that were created, and flatten it so our stream only emits closing events...
      switchMap(() => {
        this._zone.run(() => {
          const wasOpen = this.panelOpen;
          this._resetActiveItem();
          this._updatePanelState();
          this._changeDetectorRef.detectChanges();
          if (this.panelOpen) {
            this._overlayRef.updatePosition();
          }
          if (wasOpen !== this.panelOpen) {
            if (this.panelOpen) {
              this._emitOpened();
            } else {
              this.autocomplete.closed.emit();
            }
          }
        });
        return this.panelClosingActions;
      }),
      // when the first closing event occurs...
      take(1)
    ).subscribe((event) => this._setValueAndClose(event));
  }
  /**
   * Emits the opened event once it's known that the panel will be shown and stores
   * the state of the trigger right before the opening sequence was finished.
   */
  _emitOpened() {
    this.autocomplete.opened.emit();
  }
  /** Destroys the autocomplete suggestion panel. */
  _destroyPanel() {
    if (this._overlayRef) {
      this.closePanel();
      this._overlayRef.dispose();
      this._overlayRef = null;
    }
  }
  /** Given a value, returns the string that should be shown within the input. */
  _getDisplayValue(value) {
    const autocomplete = this.autocomplete;
    return autocomplete && autocomplete.displayWith ? autocomplete.displayWith(value) : value;
  }
  _assignOptionValue(value) {
    const toDisplay = this._getDisplayValue(value);
    if (value == null) {
      this._clearPreviousSelectedOption(null, false);
    }
    this._updateNativeInputValue(toDisplay != null ? toDisplay : "");
  }
  _updateNativeInputValue(value) {
    if (this._formField) {
      this._formField._control.value = value;
    } else {
      this._element.nativeElement.value = value;
    }
    this._previousValue = value;
  }
  /**
   * This method closes the panel, and if a value is specified, also sets the associated
   * control to that value. It will also mark the control as dirty if this interaction
   * stemmed from the user.
   */
  _setValueAndClose(event) {
    const panel = this.autocomplete;
    const toSelect = event ? event.source : this._pendingAutoselectedOption;
    if (toSelect) {
      this._clearPreviousSelectedOption(toSelect);
      this._assignOptionValue(toSelect.value);
      this._onChange(toSelect.value);
      panel._emitSelectEvent(toSelect);
      this._element.nativeElement.focus();
    } else if (panel.requireSelection && this._element.nativeElement.value !== this._valueOnAttach) {
      this._clearPreviousSelectedOption(null);
      this._assignOptionValue(null);
      if (panel._animationDone) {
        panel._animationDone.pipe(take(1)).subscribe(() => this._onChange(null));
      } else {
        this._onChange(null);
      }
    }
    this.closePanel();
  }
  /**
   * Clear any previous selected option and emit a selection change event for this option
   */
  _clearPreviousSelectedOption(skip2, emitEvent) {
    this.autocomplete?.options?.forEach((option) => {
      if (option !== skip2 && option.selected) {
        option.deselect(emitEvent);
      }
    });
  }
  _openPanelInternal(valueOnAttach = this._element.nativeElement.value) {
    this._attachOverlay(valueOnAttach);
    this._floatLabel();
    if (this._trackedModal) {
      const panelId = this.autocomplete.id;
      addAriaReferencedId(this._trackedModal, "aria-owns", panelId);
    }
  }
  _attachOverlay(valueOnAttach) {
    if (!this.autocomplete && (typeof ngDevMode === "undefined" || ngDevMode)) {
      throw getMatAutocompleteMissingPanelError();
    }
    let overlayRef = this._overlayRef;
    if (!overlayRef) {
      this._portal = new TemplatePortal(this.autocomplete.template, this._viewContainerRef, {
        id: this._formField?.getLabelId()
      });
      overlayRef = this._overlay.create(this._getOverlayConfig());
      this._overlayRef = overlayRef;
      this._viewportSubscription = this._viewportRuler.change().subscribe(() => {
        if (this.panelOpen && overlayRef) {
          overlayRef.updateSize({
            width: this._getPanelWidth()
          });
        }
      });
    } else {
      this._positionStrategy.setOrigin(this._getConnectedElement());
      overlayRef.updateSize({
        width: this._getPanelWidth()
      });
    }
    if (overlayRef && !overlayRef.hasAttached()) {
      overlayRef.attach(this._portal);
      this._valueOnAttach = valueOnAttach;
      this._valueOnLastKeydown = null;
      this._closingActionsSubscription = this._subscribeToClosingActions();
    }
    const wasOpen = this.panelOpen;
    this.autocomplete._isOpen = this._overlayAttached = true;
    this.autocomplete._latestOpeningTrigger = this;
    this.autocomplete._setColor(this._formField?.color);
    this._updatePanelState();
    this._applyModalPanelOwnership();
    if (this.panelOpen && wasOpen !== this.panelOpen) {
      this._emitOpened();
    }
  }
  /** Updates the panel's visibility state and any trigger state tied to id. */
  _updatePanelState() {
    this.autocomplete._setVisibility();
    if (this.panelOpen) {
      const overlayRef = this._overlayRef;
      if (!this._keydownSubscription) {
        this._keydownSubscription = overlayRef.keydownEvents().subscribe(this._handlePanelKeydown);
      }
      if (!this._outsideClickSubscription) {
        this._outsideClickSubscription = overlayRef.outsidePointerEvents().subscribe();
      }
    } else {
      this._keydownSubscription?.unsubscribe();
      this._outsideClickSubscription?.unsubscribe();
      this._keydownSubscription = this._outsideClickSubscription = null;
    }
  }
  _getOverlayConfig() {
    return new OverlayConfig({
      positionStrategy: this._getOverlayPosition(),
      scrollStrategy: this._scrollStrategy(),
      width: this._getPanelWidth(),
      direction: this._dir ?? void 0,
      panelClass: this._defaults?.overlayPanelClass
    });
  }
  _getOverlayPosition() {
    const strategy = this._overlay.position().flexibleConnectedTo(this._getConnectedElement()).withFlexibleDimensions(false).withPush(false);
    this._setStrategyPositions(strategy);
    this._positionStrategy = strategy;
    return strategy;
  }
  /** Sets the positions on a position strategy based on the directive's input state. */
  _setStrategyPositions(positionStrategy) {
    const belowPositions = [{
      originX: "start",
      originY: "bottom",
      overlayX: "start",
      overlayY: "top"
    }, {
      originX: "end",
      originY: "bottom",
      overlayX: "end",
      overlayY: "top"
    }];
    const panelClass = this._aboveClass;
    const abovePositions = [{
      originX: "start",
      originY: "top",
      overlayX: "start",
      overlayY: "bottom",
      panelClass
    }, {
      originX: "end",
      originY: "top",
      overlayX: "end",
      overlayY: "bottom",
      panelClass
    }];
    let positions;
    if (this.position === "above") {
      positions = abovePositions;
    } else if (this.position === "below") {
      positions = belowPositions;
    } else {
      positions = [...belowPositions, ...abovePositions];
    }
    positionStrategy.withPositions(positions);
  }
  _getConnectedElement() {
    if (this.connectedTo) {
      return this.connectedTo.elementRef;
    }
    return this._formField ? this._formField.getConnectedOverlayOrigin() : this._element;
  }
  _getPanelWidth() {
    return this.autocomplete.panelWidth || this._getHostWidth();
  }
  /** Returns the width of the input element, so the panel width can match it. */
  _getHostWidth() {
    return this._getConnectedElement().nativeElement.getBoundingClientRect().width;
  }
  /**
   * Reset the active item to -1. This is so that pressing arrow keys will activate the correct
   * option.
   *
   * If the consumer opted-in to automatically activatating the first option, activate the first
   * *enabled* option.
   */
  _resetActiveItem() {
    const autocomplete = this.autocomplete;
    if (autocomplete.autoActiveFirstOption) {
      let firstEnabledOptionIndex = -1;
      for (let index = 0; index < autocomplete.options.length; index++) {
        const option = autocomplete.options.get(index);
        if (!option.disabled) {
          firstEnabledOptionIndex = index;
          break;
        }
      }
      autocomplete._keyManager.setActiveItem(firstEnabledOptionIndex);
    } else {
      autocomplete._keyManager.setActiveItem(-1);
    }
  }
  /** Determines whether the panel can be opened. */
  _canOpen() {
    const element = this._element.nativeElement;
    return !element.readOnly && !element.disabled && !this.autocompleteDisabled;
  }
  /** Use defaultView of injected document if available or fallback to global window reference */
  _getWindow() {
    return this._document?.defaultView || window;
  }
  /** Scrolls to a particular option in the list. */
  _scrollToOption(index) {
    const autocomplete = this.autocomplete;
    const labelCount = _countGroupLabelsBeforeOption(index, autocomplete.options, autocomplete.optionGroups);
    if (index === 0 && labelCount === 1) {
      autocomplete._setScrollTop(0);
    } else if (autocomplete.panel) {
      const option = autocomplete.options.toArray()[index];
      if (option) {
        const element = option._getHostElement();
        const newScrollPosition = _getOptionScrollPosition(element.offsetTop, element.offsetHeight, autocomplete._getScrollTop(), autocomplete.panel.nativeElement.offsetHeight);
        autocomplete._setScrollTop(newScrollPosition);
      }
    }
  }
  /**
   * If the autocomplete trigger is inside of an `aria-modal` element, connect
   * that modal to the options panel with `aria-owns`.
   *
   * For some browser + screen reader combinations, when navigation is inside
   * of an `aria-modal` element, the screen reader treats everything outside
   * of that modal as hidden or invisible.
   *
   * This causes a problem when the combobox trigger is _inside_ of a modal, because the
   * options panel is rendered _outside_ of that modal, preventing screen reader navigation
   * from reaching the panel.
   *
   * We can work around this issue by applying `aria-owns` to the modal with the `id` of
   * the options panel. This effectively communicates to assistive technology that the
   * options panel is part of the same interaction as the modal.
   *
   * At time of this writing, this issue is present in VoiceOver.
   * See https://github.com/angular/components/issues/20694
   */
  _applyModalPanelOwnership() {
    const modal = this._element.nativeElement.closest('body > .cdk-overlay-container [aria-modal="true"]');
    if (!modal) {
      return;
    }
    const panelId = this.autocomplete.id;
    if (this._trackedModal) {
      removeAriaReferencedId(this._trackedModal, "aria-owns", panelId);
    }
    addAriaReferencedId(modal, "aria-owns", panelId);
    this._trackedModal = modal;
  }
  /** Clears the references to the listbox overlay element from the modal it was added to. */
  _clearFromModal() {
    if (this._trackedModal) {
      const panelId = this.autocomplete.id;
      removeAriaReferencedId(this._trackedModal, "aria-owns", panelId);
      this._trackedModal = null;
    }
  }
};
_MatAutocompleteTrigger.\u0275fac = function MatAutocompleteTrigger_Factory(t) {
  return new (t || _MatAutocompleteTrigger)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(Overlay), \u0275\u0275directiveInject(ViewContainerRef), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(MAT_AUTOCOMPLETE_SCROLL_STRATEGY), \u0275\u0275directiveInject(Directionality, 8), \u0275\u0275directiveInject(MAT_FORM_FIELD, 9), \u0275\u0275directiveInject(DOCUMENT, 8), \u0275\u0275directiveInject(ViewportRuler), \u0275\u0275directiveInject(MAT_AUTOCOMPLETE_DEFAULT_OPTIONS, 8));
};
_MatAutocompleteTrigger.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatAutocompleteTrigger,
  selectors: [["input", "matAutocomplete", ""], ["textarea", "matAutocomplete", ""]],
  hostAttrs: [1, "mat-mdc-autocomplete-trigger"],
  hostVars: 7,
  hostBindings: function MatAutocompleteTrigger_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("focusin", function MatAutocompleteTrigger_focusin_HostBindingHandler() {
        return ctx._handleFocus();
      })("blur", function MatAutocompleteTrigger_blur_HostBindingHandler() {
        return ctx._onTouched();
      })("input", function MatAutocompleteTrigger_input_HostBindingHandler($event) {
        return ctx._handleInput($event);
      })("keydown", function MatAutocompleteTrigger_keydown_HostBindingHandler($event) {
        return ctx._handleKeydown($event);
      })("click", function MatAutocompleteTrigger_click_HostBindingHandler() {
        return ctx._handleClick();
      });
    }
    if (rf & 2) {
      \u0275\u0275attribute("autocomplete", ctx.autocompleteAttribute)("role", ctx.autocompleteDisabled ? null : "combobox")("aria-autocomplete", ctx.autocompleteDisabled ? null : "list")("aria-activedescendant", ctx.panelOpen && ctx.activeOption ? ctx.activeOption.id : null)("aria-expanded", ctx.autocompleteDisabled ? null : ctx.panelOpen.toString())("aria-controls", ctx.autocompleteDisabled || !ctx.panelOpen ? null : ctx.autocomplete == null ? null : ctx.autocomplete.id)("aria-haspopup", ctx.autocompleteDisabled ? null : "listbox");
    }
  },
  inputs: {
    autocomplete: [InputFlags.None, "matAutocomplete", "autocomplete"],
    position: [InputFlags.None, "matAutocompletePosition", "position"],
    connectedTo: [InputFlags.None, "matAutocompleteConnectedTo", "connectedTo"],
    autocompleteAttribute: [InputFlags.None, "autocomplete", "autocompleteAttribute"],
    autocompleteDisabled: [InputFlags.HasDecoratorInputTransform, "matAutocompleteDisabled", "autocompleteDisabled", booleanAttribute]
  },
  exportAs: ["matAutocompleteTrigger"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([MAT_AUTOCOMPLETE_VALUE_ACCESSOR]), \u0275\u0275InputTransformsFeature, \u0275\u0275NgOnChangesFeature]
});
var MatAutocompleteTrigger = _MatAutocompleteTrigger;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatAutocompleteTrigger, [{
    type: Directive,
    args: [{
      selector: `input[matAutocomplete], textarea[matAutocomplete]`,
      host: {
        "class": "mat-mdc-autocomplete-trigger",
        "[attr.autocomplete]": "autocompleteAttribute",
        "[attr.role]": 'autocompleteDisabled ? null : "combobox"',
        "[attr.aria-autocomplete]": 'autocompleteDisabled ? null : "list"',
        "[attr.aria-activedescendant]": "(panelOpen && activeOption) ? activeOption.id : null",
        "[attr.aria-expanded]": "autocompleteDisabled ? null : panelOpen.toString()",
        "[attr.aria-controls]": "(autocompleteDisabled || !panelOpen) ? null : autocomplete?.id",
        "[attr.aria-haspopup]": 'autocompleteDisabled ? null : "listbox"',
        // Note: we use `focusin`, as opposed to `focus`, in order to open the panel
        // a little earlier. This avoids issues where IE delays the focusing of the input.
        "(focusin)": "_handleFocus()",
        "(blur)": "_onTouched()",
        "(input)": "_handleInput($event)",
        "(keydown)": "_handleKeydown($event)",
        "(click)": "_handleClick()"
      },
      exportAs: "matAutocompleteTrigger",
      providers: [MAT_AUTOCOMPLETE_VALUE_ACCESSOR],
      standalone: true
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: Overlay
  }, {
    type: ViewContainerRef
  }, {
    type: NgZone
  }, {
    type: ChangeDetectorRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_AUTOCOMPLETE_SCROLL_STRATEGY]
    }]
  }, {
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }, {
    type: MatFormField,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_FORM_FIELD]
    }, {
      type: Host
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [DOCUMENT]
    }]
  }, {
    type: ViewportRuler
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_AUTOCOMPLETE_DEFAULT_OPTIONS]
    }]
  }], {
    autocomplete: [{
      type: Input,
      args: ["matAutocomplete"]
    }],
    position: [{
      type: Input,
      args: ["matAutocompletePosition"]
    }],
    connectedTo: [{
      type: Input,
      args: ["matAutocompleteConnectedTo"]
    }],
    autocompleteAttribute: [{
      type: Input,
      args: ["autocomplete"]
    }],
    autocompleteDisabled: [{
      type: Input,
      args: [{
        alias: "matAutocompleteDisabled",
        transform: booleanAttribute
      }]
    }]
  });
})();
var _MatAutocompleteModule = class _MatAutocompleteModule {
};
_MatAutocompleteModule.\u0275fac = function MatAutocompleteModule_Factory(t) {
  return new (t || _MatAutocompleteModule)();
};
_MatAutocompleteModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatAutocompleteModule
});
_MatAutocompleteModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  providers: [MAT_AUTOCOMPLETE_SCROLL_STRATEGY_FACTORY_PROVIDER],
  imports: [OverlayModule, MatOptionModule, MatCommonModule, CommonModule, CdkScrollableModule, MatOptionModule, MatCommonModule]
});
var MatAutocompleteModule = _MatAutocompleteModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatAutocompleteModule, [{
    type: NgModule,
    args: [{
      imports: [OverlayModule, MatOptionModule, MatCommonModule, CommonModule, MatAutocomplete, MatAutocompleteTrigger, MatAutocompleteOrigin],
      exports: [CdkScrollableModule, MatAutocomplete, MatOptionModule, MatCommonModule, MatAutocompleteTrigger, MatAutocompleteOrigin],
      providers: [MAT_AUTOCOMPLETE_SCROLL_STRATEGY_FACTORY_PROVIDER]
    }]
  }], null, null);
})();

// src/app/features/app/components/app-update/app-update.component.ts
var _c03 = ["tagSearchInput"];
function AppUpdateComponent_button_26_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 21);
    \u0275\u0275listener("click", function AppUpdateComponent_button_26_Template_button_click_0_listener() {
      let tmp_6_0;
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView((tmp_6_0 = ctx_r2.myForm.get("groupName")) == null ? null : tmp_6_0.setValue(""));
    });
    \u0275\u0275element(1, "mat-icon", 22);
    \u0275\u0275elementEnd();
  }
}
function AppUpdateComponent_For_53_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-chip-row", 23);
    \u0275\u0275listener("removed", function AppUpdateComponent_For_53_Template_mat_chip_row_removed_0_listener() {
      const tag_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.deleteTag(tag_r5.name));
    });
    \u0275\u0275text(1);
    \u0275\u0275elementStart(2, "button", 24)(3, "mat-icon");
    \u0275\u0275text(4, "cancel");
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const tag_r5 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", tag_r5.name, " ");
  }
}
function AppUpdateComponent_mat_option_63_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 25);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const option_r6 = ctx.$implicit;
    \u0275\u0275property("value", option_r6.name);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", option_r6.name, " ");
  }
}
function AppUpdateComponent_mat_option_67_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 25);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const option_r7 = ctx.$implicit;
    \u0275\u0275property("value", option_r7.name);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", option_r7.name, " ");
  }
}
var _AppUpdateComponent = class _AppUpdateComponent {
  constructor(dialog, snackBar, formBuilder, dialogRef, model, appsService, groupsService, tagsService) {
    this.dialog = dialog;
    this.snackBar = snackBar;
    this.formBuilder = formBuilder;
    this.dialogRef = dialogRef;
    this.model = model;
    this.appsService = appsService;
    this.groupsService = groupsService;
    this.tagsService = tagsService;
    this.groupFirstTimeClicked = true;
    this.tagFirstTimeClicked = true;
    this.prefetchedAppTags = [];
    this.subscriptions = new Subscription();
    this.destroy$ = new Subject();
  }
  ngOnInit() {
    this.myForm = this.formBuilder.group({
      displayName: [this.model.displayName],
      clientName: [this.model.clientName, Validators.required],
      slug: [this.model.slug, Validators.required],
      groupName: [this.model.group?.name ?? ""],
      description: [this.model.description],
      imageUrl: [this.model.imageUrl],
      wikiUrl: [this.model.wikiUrl],
      tags: [[...this.model.tags ?? []]],
      tagSearch: [""]
    });
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
  onAppGroupFieldFocus() {
    if (!this.groupFirstTimeClicked) {
      return;
    }
    this.groupFirstTimeClicked = false;
    const formField = this.myForm.get("groupName");
    const groupName$ = formField.valueChanges.pipe(startWith(formField.value), debounceTime(300), distinctUntilChanged());
    this.filteredGroups$ = groupName$.pipe(switchMap((value) => this.groupsService.getGroups({
      searchTerm: value
    }).pipe(map((response) => response.data?.appGroups ?? []))));
  }
  onAppTagFieldFocus() {
    if (!this.tagFirstTimeClicked) {
      return;
    }
    this.tagFirstTimeClicked = false;
    const formField = this.myForm.get("tagSearch");
    const tagName$ = formField.valueChanges.pipe(startWith(formField.value), debounceTime(300), distinctUntilChanged());
    this.filteredTags$ = tagName$.pipe(switchMap((value) => this.tagsService.getTags({
      searchTerm: value
    }).pipe(map((response) => {
      const responseData = response.data;
      if (!responseData) {
        return [];
      }
      this.prefetchedAppTags = responseData.tags;
      return this.prefetchedAppTags.filter((tag) => !this.tags.some((currentTag) => currentTag.id === tag.id));
    }))));
  }
  onSubmit() {
    if (this.myForm.valid) {
      const formValue = this.myForm.value;
      const updatedClientName = formValue.clientName;
      if (this.model.clientName !== updatedClientName) {
        const title = "Confirm edit";
        const message = 'Updating the "Client Name" may cause problems. Do you want to proceed? (Potential start-up syncing issue)';
        const subscription = this.dialog.open(ConfirmationDialogComponent, {
          width: "500px",
          data: { title, message }
        }).afterClosed().subscribe((result) => {
          if (result) {
            this.update(formValue);
          }
        });
        this.subscriptions.add(subscription);
      } else {
        this.update(formValue);
      }
    }
  }
  update(formValue) {
    const model = {
      displayName: formValue.displayName,
      client: {
        id: this.model.clientId,
        name: formValue.clientName
      },
      slug: formValue.slug,
      group: isNullOrWhiteSpace(formValue.groupName) ? null : {
        name: formValue.groupName
      },
      description: formValue.description,
      imageUrl: formValue.imageUrl,
      wikiUrl: formValue.wikiUrl,
      tags: formValue.tags,
      rowVersion: this.model.rowVersion
    };
    const updateApp = (appId, body) => {
      return this.appsService.updateApp({ appId, body });
    };
    const handleUpdate = (rowVersion) => {
      return updateApp(this.model.appId, model).pipe(switchMap((response) => {
        const responseData = response.data;
        if (!responseData && response.extras) {
          const conflictedData = response.extras["Conflicts"][this.model.appId];
          const availableReturnTypes = ["Discard", "Override", "Fetch Latest"];
          return this.dialog.open(ConflictResolverDialogComponent, {
            width: "400px",
            data: availableReturnTypes,
            autoFocus: false
          }).afterClosed().pipe(switchMap((type) => {
            if (type === "Override") {
              const rowVersion2 = conflictedData.properties["RowVersion"].current;
              model.rowVersion = rowVersion2;
              return handleUpdate(rowVersion2);
            } else if (type === "Fetch Latest") {
              const getAppSubscription = this.appsService.getAppById({ appIdOrSlug: this.model.appId }).subscribe({
                next: (appResponse) => {
                  const appResponseData = appResponse.data;
                  if (!appResponseData) {
                    return;
                  }
                  const appEditComponentReturnModel = {
                    displayName: appResponseData.displayName,
                    clientName: appResponseData.client.name,
                    slug: appResponseData.slug,
                    group: appResponseData.group ? { id: appResponseData.group.id, name: appResponseData.group.name, sortOrder: appResponseData.group.sortOrder } : null,
                    description: appResponseData.description,
                    imageUrl: appResponseData.imageUrl,
                    wikiUrl: appResponseData.wikiUrl,
                    tags: appResponseData.tags.map((t) => ({ id: t.id, name: t.name, sortOrder: t.sortOrder })),
                    rowVersion: appResponseData.rowVersion,
                    type: "Fetch Latest"
                  };
                  this.snackBar.open(`Latest data fetched successfully!`, "Close", {
                    horizontalPosition: "right",
                    verticalPosition: "top",
                    duration: 5e3
                  });
                  this.dialogRef.close(appEditComponentReturnModel);
                }
              });
              this.subscriptions.add(getAppSubscription);
            }
            return of(false);
          }));
        } else if (!responseData) {
          return of(false);
        } else {
          const appEditComponentReturnModel = {
            displayName: responseData.displayName,
            clientName: responseData.clientName,
            slug: responseData.slug,
            group: responseData.group ? { id: responseData.group.id, name: responseData.group.name, sortOrder: responseData.group.sortOrder } : null,
            description: responseData.description,
            imageUrl: responseData.imageUrl,
            wikiUrl: responseData.wikiUrl,
            tags: responseData.tags.map((t) => ({ id: t.id, name: t.name, sortOrder: t.sortOrder })),
            rowVersion: rowVersion ?? responseData.rowVersion
          };
          this.snackBar.open(`Data has been updated successfully!`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 5e3
          });
          this.dialogRef.close(appEditComponentReturnModel);
        }
        return of(true);
      }));
    };
    this.subscriptions.add(handleUpdate().subscribe());
  }
  onCancel() {
    this.dialogRef.close();
  }
  get tags() {
    return this.myForm.get("tags").value;
  }
  onTagEntered(event) {
    const value = event.value || "";
    this.addTag(value);
  }
  addTag(tag) {
    const value = tag.trim();
    const valueLowercase = value.toLowerCase();
    if (value && this.tags.findIndex((t) => t.name.toLowerCase() === valueLowercase) === -1) {
      const id = this.prefetchedAppTags.find((t) => t.name.toLowerCase() === valueLowercase)?.id ?? "0";
      this.tags.push({
        id,
        name: value
      });
    }
    this.myForm.get("tagSearch")?.setValue("");
    this.tagSearchInput.nativeElement.value = "";
  }
  deleteTag(keyword) {
    const index = this.tags.findIndex((tag) => tag.name === keyword);
    if (index !== -1) {
      this.tags.splice(index, 1);
    }
  }
  onTagSelected(event) {
    const value = event.option.value;
    this.addTag(value);
  }
};
_AppUpdateComponent.\u0275fac = function AppUpdateComponent_Factory(t) {
  return new (t || _AppUpdateComponent)(\u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MAT_DIALOG_DATA), \u0275\u0275directiveInject(AppsService), \u0275\u0275directiveInject(GroupsService), \u0275\u0275directiveInject(TagsService));
};
_AppUpdateComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AppUpdateComponent, selectors: [["ng-component"]], viewQuery: function AppUpdateComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c03, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.tagSearchInput = _t.first);
  }
}, decls: 69, vars: 18, consts: [["chipGrid", ""], ["tagSearchInput", ""], ["groupAuto", "matAutocomplete"], ["auto", "matAutocomplete"], [3, "formGroup"], ["mat-dialog-title", ""], ["appearance", "fill"], ["matInput", "", "formControlName", "displayName", 3, "maxLength"], ["matInput", "", "formControlName", "clientName", 3, "maxLength"], ["matInput", "", "formControlName", "slug", 3, "maxLength"], ["matInput", "", "formControlName", "groupName", 3, "focus", "maxLength", "matAutocomplete"], ["mat-icon-button", "", "matSuffix", "", "type", "button", 3, "click", 4, "ngIf"], ["matInput", "", "formControlName", "description", 3, "maxLength"], ["matInput", "", "formControlName", "imageUrl"], ["matInput", "", "formControlName", "wikiUrl"], ["placeholder", "New tag... (press 'Enter' to add)", "formControlName", "tagSearch", 3, "matChipInputTokenEnd", "focus", "matChipInputFor", "matAutocomplete"], [1, "modal-footer"], ["mat-button", "", "mat-dialog-close", ""], ["mat-raised-button", "", "color", "primary", 3, "click", "disabled"], [3, "value", 4, "ngFor", "ngForOf"], [3, "optionSelected"], ["mat-icon-button", "", "matSuffix", "", "type", "button", 3, "click"], ["fontIcon", "clear"], [3, "removed"], ["matChipRemove", ""], [3, "value"]], template: function AppUpdateComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "form", 4)(1, "h2", 5);
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "mat-dialog-content")(4, "mat-form-field", 6)(5, "mat-label");
    \u0275\u0275text(6, "Display Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(7, "input", 7);
    \u0275\u0275elementStart(8, "mat-error");
    \u0275\u0275text(9, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(10, "mat-form-field", 6)(11, "mat-label");
    \u0275\u0275text(12, "Client Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(13, "input", 8);
    \u0275\u0275elementStart(14, "mat-error");
    \u0275\u0275text(15, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(16, "mat-form-field", 6)(17, "mat-label");
    \u0275\u0275text(18, "Slug");
    \u0275\u0275elementEnd();
    \u0275\u0275element(19, "input", 9);
    \u0275\u0275elementStart(20, "mat-error");
    \u0275\u0275text(21, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(22, "mat-form-field", 6)(23, "mat-label");
    \u0275\u0275text(24, "Group");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(25, "input", 10);
    \u0275\u0275listener("focus", function AppUpdateComponent_Template_input_focus_25_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onAppGroupFieldFocus());
    });
    \u0275\u0275elementEnd();
    \u0275\u0275template(26, AppUpdateComponent_button_26_Template, 2, 0, "button", 11);
    \u0275\u0275elementStart(27, "mat-error");
    \u0275\u0275text(28, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(29, "mat-form-field", 6)(30, "mat-label");
    \u0275\u0275text(31, "Description");
    \u0275\u0275elementEnd();
    \u0275\u0275element(32, "textarea", 12);
    \u0275\u0275elementStart(33, "mat-error");
    \u0275\u0275text(34, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(35, "mat-form-field", 6)(36, "mat-label");
    \u0275\u0275text(37, "Image Url");
    \u0275\u0275elementEnd();
    \u0275\u0275element(38, "input", 13);
    \u0275\u0275elementStart(39, "mat-error");
    \u0275\u0275text(40, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(41, "mat-form-field", 6)(42, "mat-label");
    \u0275\u0275text(43, "Wiki Url");
    \u0275\u0275elementEnd();
    \u0275\u0275element(44, "input", 14);
    \u0275\u0275elementStart(45, "mat-error");
    \u0275\u0275text(46, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(47, "mat-form-field", 6)(48, "mat-label");
    \u0275\u0275text(49, "Tags");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(50, "mat-chip-grid", null, 0);
    \u0275\u0275repeaterCreate(52, AppUpdateComponent_For_53_Template, 5, 1, "mat-chip-row", null, \u0275\u0275repeaterTrackByIdentity);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(54, "input", 15, 1);
    \u0275\u0275listener("matChipInputTokenEnd", function AppUpdateComponent_Template_input_matChipInputTokenEnd_54_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onTagEntered($event));
    })("focus", function AppUpdateComponent_Template_input_focus_54_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onAppTagFieldFocus());
    });
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(56, "mat-dialog-actions", 16)(57, "button", 17);
    \u0275\u0275text(58, "Cancel");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(59, "button", 18);
    \u0275\u0275listener("click", function AppUpdateComponent_Template_button_click_59_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onSubmit());
    });
    \u0275\u0275text(60, "Save");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(61, "mat-autocomplete", null, 2);
    \u0275\u0275template(63, AppUpdateComponent_mat_option_63_Template, 2, 2, "mat-option", 19);
    \u0275\u0275pipe(64, "async");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(65, "mat-autocomplete", 20, 3);
    \u0275\u0275listener("optionSelected", function AppUpdateComponent_Template_mat_autocomplete_optionSelected_65_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onTagSelected($event));
    });
    \u0275\u0275template(67, AppUpdateComponent_mat_option_67_Template, 2, 2, "mat-option", 19);
    \u0275\u0275pipe(68, "async");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    let tmp_11_0;
    const chipGrid_r8 = \u0275\u0275reference(51);
    const groupAuto_r9 = \u0275\u0275reference(62);
    const auto_r10 = \u0275\u0275reference(66);
    \u0275\u0275property("formGroup", ctx.myForm);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1("Update - ", ctx.model.clientName, "");
    \u0275\u0275advance(5);
    \u0275\u0275property("maxLength", 50);
    \u0275\u0275advance(6);
    \u0275\u0275property("maxLength", 50);
    \u0275\u0275advance(6);
    \u0275\u0275property("maxLength", 50);
    \u0275\u0275advance(6);
    \u0275\u0275property("maxLength", 50)("matAutocomplete", groupAuto_r9);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", (tmp_11_0 = ctx.myForm.get("groupName")) == null ? null : tmp_11_0.value);
    \u0275\u0275advance(6);
    \u0275\u0275property("maxLength", 250);
    \u0275\u0275advance(20);
    \u0275\u0275repeater(ctx.tags);
    \u0275\u0275advance(2);
    \u0275\u0275property("matChipInputFor", chipGrid_r8)("matAutocomplete", auto_r10);
    \u0275\u0275advance(5);
    \u0275\u0275property("disabled", ctx.myForm.invalid);
    \u0275\u0275advance(4);
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(64, 14, ctx.filteredGroups$));
    \u0275\u0275advance(4);
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(68, 16, ctx.filteredTags$));
  }
}, dependencies: [NgForOf, NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, FormGroupDirective, FormControlName, MatFormField, MatLabel, MatError, MatSuffix, MatIcon, MatOption, MatButton, MatIconButton, MatChipGrid, MatChipInput, MatChipRemove, MatChipRow, MatDialogClose, MatDialogTitle, MatDialogActions, MatDialogContent, MatAutocomplete, MatAutocompleteTrigger, MatInput, AsyncPipe], encapsulation: 2 });
var AppUpdateComponent = _AppUpdateComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AppUpdateComponent, { className: "AppUpdateComponent", filePath: "src\\app\\features\\app\\components\\app-update\\app-update.component.ts", lineNumber: 24 });
})();

// src/app/features/app/components/app-create/app-create.component.ts
var _c04 = ["tagSearchInput"];
function AppCreateComponent_button_26_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 29);
    \u0275\u0275listener("click", function AppCreateComponent_button_26_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.copyToClipboard("clientId"));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
}
function AppCreateComponent_mat_error_27_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-error", 30);
    \u0275\u0275text(1, "Invalid GUID. Please use the format: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.");
    \u0275\u0275elementEnd();
  }
}
function AppCreateComponent_button_37_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 29);
    \u0275\u0275listener("click", function AppCreateComponent_button_37_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.copyToClipboard("clientSecret"));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
}
function AppCreateComponent_mat_error_38_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-error", 30);
    \u0275\u0275text(1, "Invalid GUID. Please use the format: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.");
    \u0275\u0275elementEnd();
  }
}
function AppCreateComponent_button_51_Template(rf, ctx) {
  if (rf & 1) {
    const _r5 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 31);
    \u0275\u0275listener("click", function AppCreateComponent_button_51_Template_button_click_0_listener() {
      let tmp_6_0;
      \u0275\u0275restoreView(_r5);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView((tmp_6_0 = ctx_r2.form.get("groupName")) == null ? null : tmp_6_0.setValue(""));
    });
    \u0275\u0275element(1, "mat-icon", 32);
    \u0275\u0275elementEnd();
  }
}
function AppCreateComponent_For_82_Template(rf, ctx) {
  if (rf & 1) {
    const _r6 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-chip-row", 33);
    \u0275\u0275listener("removed", function AppCreateComponent_For_82_Template_mat_chip_row_removed_0_listener() {
      const tag_r7 = \u0275\u0275restoreView(_r6).$implicit;
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.deleteTag(tag_r7.name));
    });
    \u0275\u0275text(1);
    \u0275\u0275elementStart(2, "button", 34)(3, "mat-icon");
    \u0275\u0275text(4, "cancel");
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const tag_r7 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", tag_r7.name, " ");
  }
}
function AppCreateComponent_mat_option_90_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 35);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const option_r8 = ctx.$implicit;
    \u0275\u0275property("value", option_r8.name);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", option_r8.name, " ");
  }
}
function AppCreateComponent_mat_option_94_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 35);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const option_r9 = ctx.$implicit;
    \u0275\u0275property("value", option_r9.name);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", option_r9.name, " ");
  }
}
var _AppCreateComponent = class _AppCreateComponent {
  constructor(dialogRef, appsService, groupsService, tagsService, formBuilder, utilityService, windowService, snackBar, dialog) {
    this.dialogRef = dialogRef;
    this.appsService = appsService;
    this.groupsService = groupsService;
    this.tagsService = tagsService;
    this.formBuilder = formBuilder;
    this.utilityService = utilityService;
    this.windowService = windowService;
    this.snackBar = snackBar;
    this.dialog = dialog;
    this.isFullScreen = false;
    this.selectedGroupId = null;
    this.groupFirstTimeClicked = true;
    this.tagFirstTimeClicked = true;
    this.prefetchedAppTags = [];
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    this.form = this.formBuilder.group({
      displayName: [""],
      clientName: ["", Validators.required],
      slug: [""],
      clientId: [v4_default(), [Validators.required, CustomValidators.mustGuid]],
      clientSecret: [v4_default(), [Validators.required, CustomValidators.mustGuid]],
      groupName: [""],
      groupId: ["0"],
      description: [""],
      imageUrl: [""],
      wikiUrl: [""],
      tags: [[]],
      tagSearch: [""]
    });
    this.isConnectionSecure = this.windowService.isConnectionSecure;
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  generateGuid(formName) {
    this.form.get(formName)?.setValue(v4_default());
  }
  toggleFullScreen() {
    this.isFullScreen = !this.isFullScreen;
    const dialogElement = document.querySelector(".mat-mdc-dialog-surface");
    if (this.isFullScreen) {
      dialogElement?.setAttribute("style", `
                  border-radius: 0 !important;
                `);
      this.dialogRef.updateSize("100%", "100%");
    } else {
      this.dialogRef.updateSize("1350px", "680px");
      dialogElement?.removeAttribute("style");
    }
  }
  get tags() {
    return this.form.get("tags").value;
  }
  onAppGroupFieldFocus() {
    if (!this.groupFirstTimeClicked) {
      return;
    }
    this.groupFirstTimeClicked = false;
    const formField = this.form.get("groupName");
    const groupName$ = formField.valueChanges.pipe(startWith(formField.value), debounceTime(300), distinctUntilChanged());
    this.filteredGroups$ = groupName$.pipe(switchMap((value) => this.groupsService.getGroups({
      searchTerm: value
    }).pipe(map((response) => {
      const responseData = response.data?.appGroups;
      if (!responseData) {
        return [];
      }
      const selectedGroup = responseData.find((group2) => group2.name.toLowerCase() === value.toLowerCase());
      this.selectedGroupId = selectedGroup ? selectedGroup.id : null;
      return responseData;
    }))));
  }
  onAppTagFieldFocus() {
    if (!this.tagFirstTimeClicked) {
      return;
    }
    this.tagFirstTimeClicked = false;
    const formField = this.form.get("tagSearch");
    const tagName$ = formField.valueChanges.pipe(startWith(formField.value), debounceTime(300), distinctUntilChanged());
    this.filteredTags$ = tagName$.pipe(switchMap((value) => this.tagsService.getTags({
      searchTerm: value
    }).pipe(map((response) => {
      const responseData = response.data;
      if (!responseData) {
        return [];
      }
      this.prefetchedAppTags = responseData.tags;
      return this.prefetchedAppTags.filter((tag) => !this.tags.some((currentTag) => currentTag.id === tag.id));
    }))));
  }
  onSubmit() {
    if (!this.form.valid) {
      return;
    }
    const title = "Warn!";
    const message = 'Unsaved "Client Secret" will not retrievable later. Do you want to proceed?';
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: { title, message }
    }).afterClosed().subscribe((result) => {
      if (result) {
        const formValue = this.form.value;
        this.add(formValue);
      }
    });
    this.subscriptions.add(subscription);
  }
  add(formValue) {
    const model = {
      displayName: formValue.displayName,
      slug: formValue.slug,
      client: {
        name: formValue.clientName,
        id: formValue.clientId,
        secret: formValue.clientSecret
      },
      group: isNullOrWhiteSpace(formValue.groupName) ? null : {
        id: this.selectedGroupId ?? formValue.groupId,
        name: formValue.groupName,
        sortOrder: 0
      },
      description: formValue.description,
      imageUrl: formValue.imageUrl,
      wikiUrl: formValue.wikiUrl,
      tags: formValue.tags
    };
    const subscription = this.appsService.createApp({ body: model }).subscribe((response) => {
      if (response) {
        this.snackBar.open(`Added successfully!`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.dialogRef.close(response.data);
      }
    });
    this.subscriptions.add(subscription);
  }
  onTagEntered(event) {
    const value = event.value || "";
    this.addTag(value);
  }
  addTag(tag) {
    const value = tag.trim();
    const valueLowercase = value.toLowerCase();
    if (value && this.tags.findIndex((t) => t.name.toLowerCase() === valueLowercase) === -1) {
      const id = this.prefetchedAppTags.find((t) => t.name.toLowerCase() === valueLowercase)?.id ?? "0";
      this.tags.push({
        id,
        name: value,
        sortOrder: 0,
        rowVersion: ""
      });
    }
    this.form.get("tagSearch")?.setValue("");
    this.tagSearchInput.nativeElement.value = "";
  }
  deleteTag(keyword) {
    const index = this.tags.findIndex((tag) => tag.name === keyword);
    if (index !== -1) {
      this.tags.splice(index, 1);
    }
  }
  onTagSelected(event) {
    const value = event.option.value;
    this.addTag(value);
  }
  copyToClipboard(input) {
    const form = this.form.get(input);
    if (form) {
      this.utilityService.copyToClipboard(form.value);
    }
  }
};
_AppCreateComponent.\u0275fac = function AppCreateComponent_Factory(t) {
  return new (t || _AppCreateComponent)(\u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(AppsService), \u0275\u0275directiveInject(GroupsService), \u0275\u0275directiveInject(TagsService), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(MatDialog));
};
_AppCreateComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AppCreateComponent, selectors: [["ng-component"]], viewQuery: function AppCreateComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c04, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.tagSearchInput = _t.first);
  }
}, decls: 96, vars: 21, consts: [["chipGrid", ""], ["tagSearchInput", ""], ["groupAuto", "matAutocomplete"], ["auto", "matAutocomplete"], [1, "d-flex", "border-bottom"], [1, "dialog-title"], [1, "spacer"], ["mat-icon-button", "", "matTooltipPosition", "above", 3, "click", "matTooltip"], ["mat-icon-button", "", "mat-dialog-close", "", "matToolTip", "Close", "matTooltipPosition", "above"], [3, "ngSubmit", "formGroup"], ["appearance", "fill"], ["matInput", "", "formControlName", "clientName"], ["matInput", "", "formControlName", "clientId"], ["color", "primary", "type", "button", "matSuffix", "", "mat-icon-button", "", "matTooltip", "Random", "matTooltipPosition", "below", 3, "click"], ["color", "primary", "type", "button", "matSuffix", "", "mat-icon-button", "", "matTooltip", "Copy", "matTooltipPosition", "below", 3, "click", 4, "ngIf"], ["class", "mb-2", 4, "ngIf"], ["matInput", "", "formControlName", "clientSecret"], ["multi", ""], ["expanded", "false"], ["matInput", "", "formControlName", "groupName", 3, "focus", "maxLength", "matAutocomplete"], ["mat-icon-button", "", "matSuffix", "", "type", "button", 3, "click", 4, "ngIf"], ["matInput", "", "formControlName", "displayName", 3, "maxLength"], ["matInput", "", "formControlName", "description", 3, "maxLength"], ["matInput", "", "formControlName", "imageUrl"], ["matInput", "", "formControlName", "wikiUrl"], ["placeholder", "New tag... (press 'Enter' to add)", "formControlName", "tagSearch", 3, "matChipInputTokenEnd", "focus", "matChipInputFor", "matAutocomplete"], ["mat-raised-button", "", "color", "primary", 1, "ml-3", 3, "disabled"], [3, "value", 4, "ngFor", "ngForOf"], [3, "optionSelected"], ["color", "primary", "type", "button", "matSuffix", "", "mat-icon-button", "", "matTooltip", "Copy", "matTooltipPosition", "below", 3, "click"], [1, "mb-2"], ["mat-icon-button", "", "matSuffix", "", "type", "button", 3, "click"], ["fontIcon", "clear"], [3, "removed"], ["matChipRemove", ""], [3, "value"]], template: function AppCreateComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 4)(1, "div", 5);
    \u0275\u0275text(2, "Create a new app");
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "span")(4, "span", 6);
    \u0275\u0275elementStart(5, "button", 7);
    \u0275\u0275listener("click", function AppCreateComponent_Template_button_click_5_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.toggleFullScreen());
    });
    \u0275\u0275elementStart(6, "mat-icon");
    \u0275\u0275text(7);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(8, "button", 8)(9, "mat-icon");
    \u0275\u0275text(10, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(11, "form", 9);
    \u0275\u0275listener("ngSubmit", function AppCreateComponent_Template_form_ngSubmit_11_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onSubmit());
    });
    \u0275\u0275elementStart(12, "mat-dialog-content")(13, "mat-form-field", 10)(14, "mat-label");
    \u0275\u0275text(15, "Client Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(16, "input", 11);
    \u0275\u0275elementStart(17, "mat-hint");
    \u0275\u0275text(18, 'This name should match the project name specified in the project settings and must be unique (also known as the startup project), e.g., "Provider.Api".');
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(19, "mat-form-field", 10)(20, "mat-label");
    \u0275\u0275text(21, "Client Id");
    \u0275\u0275elementEnd();
    \u0275\u0275element(22, "input", 12);
    \u0275\u0275elementStart(23, "button", 13);
    \u0275\u0275listener("click", function AppCreateComponent_Template_button_click_23_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.generateGuid("clientId"));
    });
    \u0275\u0275elementStart(24, "mat-icon");
    \u0275\u0275text(25, "casino");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(26, AppCreateComponent_button_26_Template, 3, 0, "button", 14)(27, AppCreateComponent_mat_error_27_Template, 2, 0, "mat-error", 15);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(28, "mat-form-field", 10)(29, "mat-label");
    \u0275\u0275text(30, "Client Secret");
    \u0275\u0275elementEnd();
    \u0275\u0275element(31, "input", 16);
    \u0275\u0275elementStart(32, "mat-hint");
    \u0275\u0275text(33, "Save it somewhere secure.");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(34, "button", 13);
    \u0275\u0275listener("click", function AppCreateComponent_Template_button_click_34_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.generateGuid("clientSecret"));
    });
    \u0275\u0275elementStart(35, "mat-icon");
    \u0275\u0275text(36, "casino");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(37, AppCreateComponent_button_37_Template, 3, 0, "button", 14);
    \u0275\u0275elementEnd();
    \u0275\u0275template(38, AppCreateComponent_mat_error_38_Template, 2, 0, "mat-error", 15);
    \u0275\u0275elementStart(39, "mat-accordion", 17)(40, "mat-expansion-panel", 18)(41, "mat-expansion-panel-header")(42, "mat-panel-title");
    \u0275\u0275text(43, "Others");
    \u0275\u0275elementEnd();
    \u0275\u0275element(44, "mat-panel-description");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(45, "mat-form-field", 10)(46, "mat-label");
    \u0275\u0275text(47, "Group");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(48, "input", 19);
    \u0275\u0275listener("focus", function AppCreateComponent_Template_input_focus_48_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onAppGroupFieldFocus());
    });
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(49, "mat-error");
    \u0275\u0275text(50, "Please provide a valid value");
    \u0275\u0275elementEnd();
    \u0275\u0275template(51, AppCreateComponent_button_51_Template, 2, 0, "button", 20);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(52, "mat-form-field")(53, "mat-label");
    \u0275\u0275text(54, "Display Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(55, "textarea", 21);
    \u0275\u0275elementStart(56, "mat-error");
    \u0275\u0275text(57, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(58, "mat-form-field")(59, "mat-label");
    \u0275\u0275text(60, "Description");
    \u0275\u0275elementEnd();
    \u0275\u0275element(61, "textarea", 22);
    \u0275\u0275elementStart(62, "mat-error");
    \u0275\u0275text(63, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(64, "mat-form-field")(65, "mat-label");
    \u0275\u0275text(66, "Image Url");
    \u0275\u0275elementEnd();
    \u0275\u0275element(67, "input", 23);
    \u0275\u0275elementStart(68, "mat-error");
    \u0275\u0275text(69, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(70, "mat-form-field")(71, "mat-label");
    \u0275\u0275text(72, "WikiUrl");
    \u0275\u0275elementEnd();
    \u0275\u0275element(73, "input", 24);
    \u0275\u0275elementStart(74, "mat-error");
    \u0275\u0275text(75, "Please provide a valid value");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(76, "mat-form-field", 10)(77, "mat-label");
    \u0275\u0275text(78, "Tags");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(79, "mat-chip-grid", null, 0);
    \u0275\u0275repeaterCreate(81, AppCreateComponent_For_82_Template, 5, 1, "mat-chip-row", null, \u0275\u0275repeaterTrackByIdentity);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(83, "input", 25, 1);
    \u0275\u0275listener("matChipInputTokenEnd", function AppCreateComponent_Template_input_matChipInputTokenEnd_83_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onTagEntered($event));
    })("focus", function AppCreateComponent_Template_input_focus_83_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onAppTagFieldFocus());
    });
    \u0275\u0275elementEnd()()()()();
    \u0275\u0275elementStart(85, "mat-dialog-actions")(86, "button", 26);
    \u0275\u0275text(87, " Create ");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(88, "mat-autocomplete", null, 2);
    \u0275\u0275template(90, AppCreateComponent_mat_option_90_Template, 2, 2, "mat-option", 27);
    \u0275\u0275pipe(91, "async");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(92, "mat-autocomplete", 28, 3);
    \u0275\u0275listener("optionSelected", function AppCreateComponent_Template_mat_autocomplete_optionSelected_92_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onTagSelected($event));
    });
    \u0275\u0275template(94, AppCreateComponent_mat_option_94_Template, 2, 2, "mat-option", 27);
    \u0275\u0275pipe(95, "async");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    let tmp_8_0;
    let tmp_10_0;
    let tmp_13_0;
    const chipGrid_r10 = \u0275\u0275reference(80);
    const groupAuto_r11 = \u0275\u0275reference(89);
    const auto_r12 = \u0275\u0275reference(93);
    \u0275\u0275advance(5);
    \u0275\u0275property("matTooltip", ctx.isFullScreen ? "Exit full screen" : "Enter full screen");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.isFullScreen ? "fullscreen_exit" : "fullscreen");
    \u0275\u0275advance(4);
    \u0275\u0275property("formGroup", ctx.form);
    \u0275\u0275advance(15);
    \u0275\u0275property("ngIf", ctx.isConnectionSecure);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", (tmp_8_0 = ctx.form.get("clientId")) == null ? null : tmp_8_0.hasError("invalidGuid"));
    \u0275\u0275advance(10);
    \u0275\u0275property("ngIf", ctx.isConnectionSecure);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", (tmp_10_0 = ctx.form.get("clientSecret")) == null ? null : tmp_10_0.hasError("invalidGuid"));
    \u0275\u0275advance(10);
    \u0275\u0275property("maxLength", 50)("matAutocomplete", groupAuto_r11);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", (tmp_13_0 = ctx.form.get("groupName")) == null ? null : tmp_13_0.value);
    \u0275\u0275advance(4);
    \u0275\u0275property("maxLength", 250);
    \u0275\u0275advance(6);
    \u0275\u0275property("maxLength", 250);
    \u0275\u0275advance(20);
    \u0275\u0275repeater(ctx.tags);
    \u0275\u0275advance(2);
    \u0275\u0275property("matChipInputFor", chipGrid_r10)("matAutocomplete", auto_r12);
    \u0275\u0275advance(3);
    \u0275\u0275property("disabled", ctx.form.invalid);
    \u0275\u0275advance(4);
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(91, 17, ctx.filteredGroups$));
    \u0275\u0275advance(4);
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(95, 19, ctx.filteredTags$));
  }
}, dependencies: [NgForOf, NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, FormGroupDirective, FormControlName, MatFormField, MatLabel, MatHint, MatError, MatSuffix, MatIcon, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatExpansionPanelDescription, MatOption, MatButton, MatIconButton, MatChipGrid, MatChipInput, MatChipRemove, MatChipRow, MatDialogClose, MatDialogActions, MatDialogContent, MatTooltip, MatAutocomplete, MatAutocompleteTrigger, MatInput, AsyncPipe], styles: ["\n\n  .mat-mdc-form-field-subscript-wrapper {\n  height: 25px;\n}\n/*# sourceMappingURL=app-create.component.css.map */"] });
var AppCreateComponent = _AppCreateComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AppCreateComponent, { className: "AppCreateComponent", filePath: "src\\app\\features\\app\\components\\app-create\\app-create.component.ts", lineNumber: 25 });
})();

// src/app/features/app/app-routes.ts
var APP_ROUTES = {
  base: "",
  create: "create",
  update: ":appId/update",
  view: ":appId"
};
var APP_VIEW_ROUTES = {
  viewNewIdentifierMapping: "new",
  viewSettings: ":identifierId/settings",
  viewSettings2: "settings",
  viewSetting: ":identifierId/settings/:settingId",
  viewConfiguration: ":identifierId/configuration",
  viewCreateSetting: ":identifierId/settings/new",
  viewUpdateSetting: ":identifierId/settings/:settingId/update",
  viewCopySettingTo: ":identifierId/settings/:settingId/copyTo",
  viewSettingHistories: ":identifierId/settings/:settingId/histories",
  viewSettingHistory: ":identifierId/settings/:settingId/histories/:historyId",
  viewInstances: ":identifierId/instances",
  viewInstances2: "instances",
  viewInstance: ":identifierId/instances/:instanceId"
};

// src/app/shared/services/app-identifier-mappings.service.ts
var _AppIdentifierMappingsService = class _AppIdentifierMappingsService {
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
  getAppIdentifierMappingsByAppId(request) {
    const url = this.route + "/v1/apps/" + request.appIdOrSlug + "/identifiers";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getAppIdentifierMappingsByAppSlug(request) {
    const url = this.route + "/v1/apps/slug" + request.appIdOrSlug + "/identifiers";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getAppIdentifierMappingByAppIdAndIdentifierId(request) {
    const url = this.route + "/v1/apps/" + request.appIdOrSlug + "/identifiers/" + request.identifierIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getAppIdentifierMappingByAppSlugAndIdentifierSlug(request) {
    const url = this.route + "/v1/apps/slug/" + request.appIdOrSlug + "/identifiers/" + request.identifierIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  createAppIdentifierMapping(request) {
    const url = this.route + "/v1/apps/" + request.appId + "/identifiers";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  deleteAppIdentifierMapping(request) {
    const url = this.route + "/v1/apps/" + request.appId + "/identifiers/" + request.identifierId + "?rowVersion=" + encodeURIComponent(request.mappingRowVersion);
    return this.httpClient.delete(url, { headers: this.headers });
  }
  updateAppIdentifierMappingSortOrder(request) {
    const url = this.route + "/v1/apps/" + request.appId + "/identifiers/" + request.identifierId + "/sort-order";
    return this.httpClient.put(url, request.body, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
    ;
  }
};
_AppIdentifierMappingsService.\u0275fac = function AppIdentifierMappingsService_Factory(t) {
  return new (t || _AppIdentifierMappingsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_AppIdentifierMappingsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _AppIdentifierMappingsService, factory: _AppIdentifierMappingsService.\u0275fac, providedIn: "root" });
var AppIdentifierMappingsService = _AppIdentifierMappingsService;

// src/app/features/setting/components/identifier-mapping-create/identifier-mapping-create.component.ts
var _c05 = ["input"];
function IdentifierMappingCreateComponent_button_18_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 15);
    \u0275\u0275listener("click", function IdentifierMappingCreateComponent_button_18_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.myForm.get("identifierName").setValue(""));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "clear");
    \u0275\u0275elementEnd()();
  }
}
function IdentifierMappingCreateComponent_mat_error_22_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-error");
    \u0275\u0275text(1, "Identifier already exists.");
    \u0275\u0275elementEnd();
  }
}
function IdentifierMappingCreateComponent_mat_option_33_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 13);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const option_r4 = ctx.$implicit;
    \u0275\u0275property("value", option_r4.name);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", option_r4.name, " ");
  }
}
var _IdentifierMappingCreateComponent = class _IdentifierMappingCreateComponent {
  constructor(snackBar, dialogRef, formBuilder, model, identifiersService, appIdentifierMappingsService) {
    this.snackBar = snackBar;
    this.dialogRef = dialogRef;
    this.formBuilder = formBuilder;
    this.model = model;
    this.identifiersService = identifiersService;
    this.appIdentifierMappingsService = appIdentifierMappingsService;
    this.selectedAppIdentifierId = null;
    this.selectedAppIdentifierOrder = null;
    this.fieldFirstTimeClicked = true;
    this.title = "";
    this.isManualOrder = false;
    this.setSortOrderPositions = SetSortOrderPosition;
    this.defaultPosition = SetSortOrderPosition.Bottom;
    this.destroy$ = new Subject();
    this.subscriptions = new Subscription();
    this.identifierValidator = (control) => {
      if (isNullOrWhiteSpace(control.value)) {
        return { invalidIdentifierName: true };
      }
      if (this.model.identifiers.some((s) => s.name.toLowerCase() === control.value.toLowerCase())) {
        return { identifierExists: true };
      }
      return null;
    };
  }
  ngOnInit() {
    this.title = this.model.title ? this.model.title : `New mapping - ${this.model.clientName}`;
    this.myForm = this.formBuilder.group({
      identifierName: ["", [Validators.required, this.identifierValidator]],
      identifierId: ["0"],
      position: [this.defaultPosition]
    });
  }
  ngAfterViewInit() {
    setTimeout(() => {
      this.input.nativeElement.focus();
    }, 0);
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
    this.subscriptions.unsubscribe();
  }
  onFieldFocus() {
    if (!this.fieldFirstTimeClicked) {
      return;
    }
    this.fieldFirstTimeClicked = false;
    const formField = this.myForm.get("identifierName");
    const identifierName$ = formField.valueChanges.pipe(startWith(formField.value), debounceTime(300), distinctUntilChanged());
    this.filteredAppIdentifiers$ = identifierName$.pipe(switchMap((value) => this.identifiersService.getIdentifiers({
      searchTerm: value
    }).pipe(map((response) => {
      const responseData = response.data;
      if (!responseData) {
        return [];
      }
      const identifiers = responseData.identifiers.filter((s) => !this.model.identifiers.some((i) => i.id === s.id));
      const selectedIdentifier = identifiers.find((group2) => group2.name.toLowerCase() === value.toLowerCase());
      this.selectedAppIdentifierId = selectedIdentifier ? selectedIdentifier.id : null;
      this.selectedAppIdentifierOrder = selectedIdentifier ? selectedIdentifier.sortOrder : null;
      return identifiers;
    }))));
  }
  onSubmit() {
    if (!this.myForm.valid) {
      return;
    }
    const formValue = this.myForm.value;
    const model = {
      setSortOrderPosition: formValue.position,
      identifier: {
        id: this.selectedAppIdentifierId ?? formValue.identifierId,
        name: formValue.identifierName
      }
    };
    const subscription = this.appIdentifierMappingsService.createAppIdentifierMapping({
      appId: this.model.appId,
      body: model
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        const returnModel = {
          mappingSortOrder: responseData.identifier.mappingSortOrder,
          identifierId: responseData.identifier.id,
          identifierName: model.identifier.name,
          identifierSortOrder: responseData.identifier.sortOrder
        };
        this.snackBar.open(`Added successfully!`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.dialogRef.close(returnModel);
      },
      error: (err) => {
        const error = err.error;
        if (error) {
          if (error.errors?.find((e) => e.traces === "MappingAlreadyExists")) {
            const errorSubscription = this.appIdentifierMappingsService.getAppIdentifierMappingByAppSlugAndIdentifierSlug({
              appIdOrSlug: this.model.appSlug,
              identifierIdOrSlug: formValue.identifierName
            }).subscribe((resp) => {
              const responseData = resp.data;
              if (!responseData) {
                return;
              }
              const returnModel = {
                mappingSortOrder: responseData.mappingSortOrder,
                identifierId: responseData.identifier.id,
                identifierName: model.identifier.name,
                identifierSortOrder: responseData.identifier.sortOrder
              };
              this.dialogRef.close(returnModel);
            });
            this.subscriptions.add(errorSubscription);
          }
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  onPositionChange() {
    const position = this.myForm.get("position")?.value;
    if (position === -1) {
      this.isManualOrder = true;
    } else {
      this.isManualOrder = false;
    }
  }
};
_IdentifierMappingCreateComponent.\u0275fac = function IdentifierMappingCreateComponent_Factory(t) {
  return new (t || _IdentifierMappingCreateComponent)(\u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(MAT_DIALOG_DATA), \u0275\u0275directiveInject(IdentifiersService), \u0275\u0275directiveInject(AppIdentifierMappingsService));
};
_IdentifierMappingCreateComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _IdentifierMappingCreateComponent, selectors: [["ng-component"]], viewQuery: function IdentifierMappingCreateComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c05, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.input = _t.first);
  }
}, decls: 35, vars: 12, consts: [["input", ""], ["groupAuto", "matAutocomplete"], [1, "d-flex", "mb-2", "pb-2", "border-bottom"], [1, "spacer"], ["mat-icon-button", "", "mat-dialog-close", "", "matToolTip", "Close", "matTooltipPosition", "above"], [1, "mt-2"], [3, "ngSubmit", "formGroup"], ["appearance", "fill"], ["type", "text", "matInput", "", "formControlName", "identifierName", 3, "focus", "maxLength", "matAutocomplete"], ["mat-icon-button", "", "matSuffix", "", "type", "button", "matTooltip", "clear", 3, "click", 4, "ngIf"], ["mat-icon-button", "", "matSuffix", "", "type", "submit", "color", "primary", 3, "disabled"], [4, "ngIf"], ["formControlName", "position", 3, "selectionChange"], [3, "value"], [3, "value", 4, "ngFor", "ngForOf"], ["mat-icon-button", "", "matSuffix", "", "type", "button", "matTooltip", "clear", 3, "click"]], template: function IdentifierMappingCreateComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 2)(1, "mat-card-header")(2, "mat-card-title");
    \u0275\u0275text(3);
    \u0275\u0275elementEnd()();
    \u0275\u0275element(4, "span")(5, "span", 3);
    \u0275\u0275elementStart(6, "button", 4)(7, "mat-icon");
    \u0275\u0275text(8, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(9, "mat-card-content", 5)(10, "form", 6);
    \u0275\u0275listener("ngSubmit", function IdentifierMappingCreateComponent_Template_form_ngSubmit_10_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onSubmit());
    });
    \u0275\u0275elementStart(11, "mat-form-field", 7)(12, "mat-label");
    \u0275\u0275text(13, "Name");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(14, "input", 8, 0);
    \u0275\u0275listener("focus", function IdentifierMappingCreateComponent_Template_input_focus_14_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onFieldFocus());
    });
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(16, "mat-hint");
    \u0275\u0275text(17, "If identifier missing, will be created along with the mapping.");
    \u0275\u0275elementEnd();
    \u0275\u0275template(18, IdentifierMappingCreateComponent_button_18_Template, 3, 0, "button", 9);
    \u0275\u0275elementStart(19, "button", 10)(20, "mat-icon");
    \u0275\u0275text(21, "check_circle");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(22, IdentifierMappingCreateComponent_mat_error_22_Template, 2, 0, "mat-error", 11);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(23, "mat-form-field", 7)(24, "mat-label");
    \u0275\u0275text(25, "Position");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(26, "mat-select", 12);
    \u0275\u0275listener("selectionChange", function IdentifierMappingCreateComponent_Template_mat_select_selectionChange_26_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onPositionChange());
    });
    \u0275\u0275elementStart(27, "mat-option", 13);
    \u0275\u0275text(28, "Top");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(29, "mat-option", 13);
    \u0275\u0275text(30, "Bottom");
    \u0275\u0275elementEnd()()()()();
    \u0275\u0275elementStart(31, "mat-autocomplete", null, 1);
    \u0275\u0275template(33, IdentifierMappingCreateComponent_mat_option_33_Template, 2, 2, "mat-option", 14);
    \u0275\u0275pipe(34, "async");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    let tmp_8_0;
    const groupAuto_r5 = \u0275\u0275reference(32);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(ctx.title);
    \u0275\u0275advance(7);
    \u0275\u0275property("formGroup", ctx.myForm);
    \u0275\u0275advance(4);
    \u0275\u0275property("maxLength", 50)("matAutocomplete", groupAuto_r5);
    \u0275\u0275advance(4);
    \u0275\u0275property("ngIf", ctx.myForm.get("identifierName").value);
    \u0275\u0275advance();
    \u0275\u0275property("disabled", ctx.myForm.invalid);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", (tmp_8_0 = ctx.myForm.get("identifierName")) == null ? null : tmp_8_0.hasError("identifierExists"));
    \u0275\u0275advance(5);
    \u0275\u0275property("value", ctx.setSortOrderPositions.Top);
    \u0275\u0275advance(2);
    \u0275\u0275property("value", ctx.setSortOrderPositions.Bottom);
    \u0275\u0275advance(4);
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(34, 10, ctx.filteredAppIdentifiers$));
  }
}, dependencies: [NgForOf, NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, FormGroupDirective, FormControlName, MatIcon, MatCardContent, MatCardHeader, MatCardTitle, MatFormField, MatLabel, MatHint, MatError, MatSuffix, MatOption, MatIconButton, MatTooltip, MatInput, MatSelect, MatDialogClose, MatAutocomplete, MatAutocompleteTrigger, AsyncPipe], encapsulation: 2 });
var IdentifierMappingCreateComponent = _IdentifierMappingCreateComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(IdentifierMappingCreateComponent, { className: "IdentifierMappingCreateComponent", filePath: "src\\app\\features\\setting\\components\\identifier-mapping-create\\identifier-mapping-create.component.ts", lineNumber: 20 });
})();

// src/app/features/setting/services/setting.service.ts
var _SettingsService = class _SettingsService {
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
  getSettingsByAppIdAndIdentifierId(request) {
    const url = this.route + "/v1/apps/" + request.appIdOrSlug + "/identifiers/" + request.identifierIdOrSlug + "/settings";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getSettingsByAppSlugAndIdentifierSlug(request) {
    const url = this.route + "/v1/apps/slug" + request.appIdOrSlug + "/identifiers/" + request.identifierIdOrSlug + "/settings";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getSettingsData(request) {
    let url = this.route + "/v1/apps/" + request.appId + "/settings/data";
    let params = new HttpParams();
    if (request.identifierId) {
      params = params.append("identifierId", request.identifierId);
    }
    if (request.ids && request.ids.length > 0) {
      params = params.append("ids", request.ids.join(","));
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  copySettingTo(request) {
    const url = this.route + "/v1/settings/" + request.settingId + "/copy";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  getSettingData(request) {
    const url = this.route + "/v1/settings/" + request.settingId + "/data";
    return this.httpClient.get(url, { headers: this.headers });
  }
  deleteSetting(request) {
    const url = this.route + "/v1/settings/" + request.settingId + "?rowVersion=" + encodeURIComponent(request.rowVersion);
    return this.httpClient.delete(url, { headers: this.headers });
  }
  getSettingById(request) {
    let url = this.route + "/v1/settings/" + request.settingId;
    let params = new HttpParams();
    if (request.excludes) {
      params = params.append("excludes", request.excludes.join(","));
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  updateSetting(request) {
    const url = this.route + "/v1/settings/" + request.settingId;
    return this.httpClient.put(url, request.body, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
    ;
  }
  createSetting(request) {
    const url = this.route + "/v1/settings";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
  updateSettingData(request) {
    const url = this.route + "/v1/settings/" + request.settingId + "/data";
    return this.httpClient.put(url, request.body, { headers: this.headers }).pipe(catchError((response) => {
      if (response.status === 409) {
        return of(response.error);
      }
      throw response;
    }));
  }
};
_SettingsService.\u0275fac = function SettingsService_Factory(t) {
  return new (t || _SettingsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_SettingsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _SettingsService, factory: _SettingsService.\u0275fac, providedIn: "root" });
var SettingsService = _SettingsService;

// node_modules/@angular/material/fesm2022/button-toggle.mjs
var _c06 = ["button"];
var _c13 = ["*"];
function MatButtonToggle_Conditional_3_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "mat-pseudo-checkbox", 3);
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("disabled", ctx_r1.disabled);
  }
}
function MatButtonToggle_Conditional_4_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "mat-pseudo-checkbox", 3);
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("disabled", ctx_r1.disabled);
  }
}
var MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS = new InjectionToken("MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS", {
  providedIn: "root",
  factory: MAT_BUTTON_TOGGLE_GROUP_DEFAULT_OPTIONS_FACTORY
});
function MAT_BUTTON_TOGGLE_GROUP_DEFAULT_OPTIONS_FACTORY() {
  return {
    hideSingleSelectionIndicator: false,
    hideMultipleSelectionIndicator: false
  };
}
var MAT_BUTTON_TOGGLE_GROUP = new InjectionToken("MatButtonToggleGroup");
var MAT_BUTTON_TOGGLE_GROUP_VALUE_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => MatButtonToggleGroup),
  multi: true
};
var uniqueIdCounter = 0;
var MatButtonToggleChange = class {
  constructor(source, value) {
    this.source = source;
    this.value = value;
  }
};
var _MatButtonToggleGroup = class _MatButtonToggleGroup {
  /** `name` attribute for the underlying `input` element. */
  get name() {
    return this._name;
  }
  set name(value) {
    this._name = value;
    this._markButtonsForCheck();
  }
  /** Value of the toggle group. */
  get value() {
    const selected = this._selectionModel ? this._selectionModel.selected : [];
    if (this.multiple) {
      return selected.map((toggle) => toggle.value);
    }
    return selected[0] ? selected[0].value : void 0;
  }
  set value(newValue) {
    this._setSelectionByValue(newValue);
    this.valueChange.emit(this.value);
  }
  /** Selected button toggles in the group. */
  get selected() {
    const selected = this._selectionModel ? this._selectionModel.selected : [];
    return this.multiple ? selected : selected[0] || null;
  }
  /** Whether multiple button toggles can be selected. */
  get multiple() {
    return this._multiple;
  }
  set multiple(value) {
    this._multiple = value;
    this._markButtonsForCheck();
  }
  /** Whether multiple button toggle group is disabled. */
  get disabled() {
    return this._disabled;
  }
  set disabled(value) {
    this._disabled = value;
    this._markButtonsForCheck();
  }
  /** Whether checkmark indicator for single-selection button toggle groups is hidden. */
  get hideSingleSelectionIndicator() {
    return this._hideSingleSelectionIndicator;
  }
  set hideSingleSelectionIndicator(value) {
    this._hideSingleSelectionIndicator = value;
    this._markButtonsForCheck();
  }
  /** Whether checkmark indicator for multiple-selection button toggle groups is hidden. */
  get hideMultipleSelectionIndicator() {
    return this._hideMultipleSelectionIndicator;
  }
  set hideMultipleSelectionIndicator(value) {
    this._hideMultipleSelectionIndicator = value;
    this._markButtonsForCheck();
  }
  constructor(_changeDetector, defaultOptions) {
    this._changeDetector = _changeDetector;
    this._multiple = false;
    this._disabled = false;
    this._controlValueAccessorChangeFn = () => {
    };
    this._onTouched = () => {
    };
    this._name = `mat-button-toggle-group-${uniqueIdCounter++}`;
    this.valueChange = new EventEmitter();
    this.change = new EventEmitter();
    this.appearance = defaultOptions && defaultOptions.appearance ? defaultOptions.appearance : "standard";
    this.hideSingleSelectionIndicator = defaultOptions?.hideSingleSelectionIndicator ?? false;
    this.hideMultipleSelectionIndicator = defaultOptions?.hideMultipleSelectionIndicator ?? false;
  }
  ngOnInit() {
    this._selectionModel = new SelectionModel(this.multiple, void 0, false);
  }
  ngAfterContentInit() {
    this._selectionModel.select(...this._buttonToggles.filter((toggle) => toggle.checked));
  }
  /**
   * Sets the model value. Implemented as part of ControlValueAccessor.
   * @param value Value to be set to the model.
   */
  writeValue(value) {
    this.value = value;
    this._changeDetector.markForCheck();
  }
  // Implemented as part of ControlValueAccessor.
  registerOnChange(fn) {
    this._controlValueAccessorChangeFn = fn;
  }
  // Implemented as part of ControlValueAccessor.
  registerOnTouched(fn) {
    this._onTouched = fn;
  }
  // Implemented as part of ControlValueAccessor.
  setDisabledState(isDisabled) {
    this.disabled = isDisabled;
  }
  /** Dispatch change event with current selection and group value. */
  _emitChangeEvent(toggle) {
    const event = new MatButtonToggleChange(toggle, this.value);
    this._rawValue = event.value;
    this._controlValueAccessorChangeFn(event.value);
    this.change.emit(event);
  }
  /**
   * Syncs a button toggle's selected state with the model value.
   * @param toggle Toggle to be synced.
   * @param select Whether the toggle should be selected.
   * @param isUserInput Whether the change was a result of a user interaction.
   * @param deferEvents Whether to defer emitting the change events.
   */
  _syncButtonToggle(toggle, select, isUserInput = false, deferEvents = false) {
    if (!this.multiple && this.selected && !toggle.checked) {
      this.selected.checked = false;
    }
    if (this._selectionModel) {
      if (select) {
        this._selectionModel.select(toggle);
      } else {
        this._selectionModel.deselect(toggle);
      }
    } else {
      deferEvents = true;
    }
    if (deferEvents) {
      Promise.resolve().then(() => this._updateModelValue(toggle, isUserInput));
    } else {
      this._updateModelValue(toggle, isUserInput);
    }
  }
  /** Checks whether a button toggle is selected. */
  _isSelected(toggle) {
    return this._selectionModel && this._selectionModel.isSelected(toggle);
  }
  /** Determines whether a button toggle should be checked on init. */
  _isPrechecked(toggle) {
    if (typeof this._rawValue === "undefined") {
      return false;
    }
    if (this.multiple && Array.isArray(this._rawValue)) {
      return this._rawValue.some((value) => toggle.value != null && value === toggle.value);
    }
    return toggle.value === this._rawValue;
  }
  /** Updates the selection state of the toggles in the group based on a value. */
  _setSelectionByValue(value) {
    this._rawValue = value;
    if (!this._buttonToggles) {
      return;
    }
    if (this.multiple && value) {
      if (!Array.isArray(value) && (typeof ngDevMode === "undefined" || ngDevMode)) {
        throw Error("Value must be an array in multiple-selection mode.");
      }
      this._clearSelection();
      value.forEach((currentValue) => this._selectValue(currentValue));
    } else {
      this._clearSelection();
      this._selectValue(value);
    }
  }
  /** Clears the selected toggles. */
  _clearSelection() {
    this._selectionModel.clear();
    this._buttonToggles.forEach((toggle) => toggle.checked = false);
  }
  /** Selects a value if there's a toggle that corresponds to it. */
  _selectValue(value) {
    const correspondingOption = this._buttonToggles.find((toggle) => {
      return toggle.value != null && toggle.value === value;
    });
    if (correspondingOption) {
      correspondingOption.checked = true;
      this._selectionModel.select(correspondingOption);
    }
  }
  /** Syncs up the group's value with the model and emits the change event. */
  _updateModelValue(toggle, isUserInput) {
    if (isUserInput) {
      this._emitChangeEvent(toggle);
    }
    this.valueChange.emit(this.value);
  }
  /** Marks all of the child button toggles to be checked. */
  _markButtonsForCheck() {
    this._buttonToggles?.forEach((toggle) => toggle._markForCheck());
  }
};
_MatButtonToggleGroup.\u0275fac = function MatButtonToggleGroup_Factory(t) {
  return new (t || _MatButtonToggleGroup)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS, 8));
};
_MatButtonToggleGroup.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatButtonToggleGroup,
  selectors: [["mat-button-toggle-group"]],
  contentQueries: function MatButtonToggleGroup_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatButtonToggle, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._buttonToggles = _t);
    }
  },
  hostAttrs: ["role", "group", 1, "mat-button-toggle-group"],
  hostVars: 5,
  hostBindings: function MatButtonToggleGroup_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275attribute("aria-disabled", ctx.disabled);
      \u0275\u0275classProp("mat-button-toggle-vertical", ctx.vertical)("mat-button-toggle-group-appearance-standard", ctx.appearance === "standard");
    }
  },
  inputs: {
    appearance: "appearance",
    name: "name",
    vertical: [InputFlags.HasDecoratorInputTransform, "vertical", "vertical", booleanAttribute],
    value: "value",
    multiple: [InputFlags.HasDecoratorInputTransform, "multiple", "multiple", booleanAttribute],
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    hideSingleSelectionIndicator: [InputFlags.HasDecoratorInputTransform, "hideSingleSelectionIndicator", "hideSingleSelectionIndicator", booleanAttribute],
    hideMultipleSelectionIndicator: [InputFlags.HasDecoratorInputTransform, "hideMultipleSelectionIndicator", "hideMultipleSelectionIndicator", booleanAttribute]
  },
  outputs: {
    valueChange: "valueChange",
    change: "change"
  },
  exportAs: ["matButtonToggleGroup"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([MAT_BUTTON_TOGGLE_GROUP_VALUE_ACCESSOR, {
    provide: MAT_BUTTON_TOGGLE_GROUP,
    useExisting: _MatButtonToggleGroup
  }]), \u0275\u0275InputTransformsFeature]
});
var MatButtonToggleGroup = _MatButtonToggleGroup;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatButtonToggleGroup, [{
    type: Directive,
    args: [{
      selector: "mat-button-toggle-group",
      providers: [MAT_BUTTON_TOGGLE_GROUP_VALUE_ACCESSOR, {
        provide: MAT_BUTTON_TOGGLE_GROUP,
        useExisting: MatButtonToggleGroup
      }],
      host: {
        "role": "group",
        "class": "mat-button-toggle-group",
        "[attr.aria-disabled]": "disabled",
        "[class.mat-button-toggle-vertical]": "vertical",
        "[class.mat-button-toggle-group-appearance-standard]": 'appearance === "standard"'
      },
      exportAs: "matButtonToggleGroup",
      standalone: true
    }]
  }], () => [{
    type: ChangeDetectorRef
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS]
    }]
  }], {
    _buttonToggles: [{
      type: ContentChildren,
      args: [forwardRef(() => MatButtonToggle), {
        // Note that this would technically pick up toggles
        // from nested groups, but that's not a case that we support.
        descendants: true
      }]
    }],
    appearance: [{
      type: Input
    }],
    name: [{
      type: Input
    }],
    vertical: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    value: [{
      type: Input
    }],
    valueChange: [{
      type: Output
    }],
    multiple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    change: [{
      type: Output
    }],
    hideSingleSelectionIndicator: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    hideMultipleSelectionIndicator: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }]
  });
})();
var _MatButtonToggle = class _MatButtonToggle {
  /** Unique ID for the underlying `button` element. */
  get buttonId() {
    return `${this.id}-button`;
  }
  /** The appearance style of the button. */
  get appearance() {
    return this.buttonToggleGroup ? this.buttonToggleGroup.appearance : this._appearance;
  }
  set appearance(value) {
    this._appearance = value;
  }
  /** Whether the button is checked. */
  get checked() {
    return this.buttonToggleGroup ? this.buttonToggleGroup._isSelected(this) : this._checked;
  }
  set checked(value) {
    if (value !== this._checked) {
      this._checked = value;
      if (this.buttonToggleGroup) {
        this.buttonToggleGroup._syncButtonToggle(this, this._checked);
      }
      this._changeDetectorRef.markForCheck();
    }
  }
  /** Whether the button is disabled. */
  get disabled() {
    return this._disabled || this.buttonToggleGroup && this.buttonToggleGroup.disabled;
  }
  set disabled(value) {
    this._disabled = value;
  }
  constructor(toggleGroup, _changeDetectorRef, _elementRef, _focusMonitor, defaultTabIndex, defaultOptions) {
    this._changeDetectorRef = _changeDetectorRef;
    this._elementRef = _elementRef;
    this._focusMonitor = _focusMonitor;
    this._checked = false;
    this.ariaLabelledby = null;
    this._disabled = false;
    this.change = new EventEmitter();
    const parsedTabIndex = Number(defaultTabIndex);
    this.tabIndex = parsedTabIndex || parsedTabIndex === 0 ? parsedTabIndex : null;
    this.buttonToggleGroup = toggleGroup;
    this.appearance = defaultOptions && defaultOptions.appearance ? defaultOptions.appearance : "standard";
  }
  ngOnInit() {
    const group2 = this.buttonToggleGroup;
    this.id = this.id || `mat-button-toggle-${uniqueIdCounter++}`;
    if (group2) {
      if (group2._isPrechecked(this)) {
        this.checked = true;
      } else if (group2._isSelected(this) !== this._checked) {
        group2._syncButtonToggle(this, this._checked);
      }
    }
  }
  ngAfterViewInit() {
    this._focusMonitor.monitor(this._elementRef, true);
  }
  ngOnDestroy() {
    const group2 = this.buttonToggleGroup;
    this._focusMonitor.stopMonitoring(this._elementRef);
    if (group2 && group2._isSelected(this)) {
      group2._syncButtonToggle(this, false, false, true);
    }
  }
  /** Focuses the button. */
  focus(options) {
    this._buttonElement.nativeElement.focus(options);
  }
  /** Checks the button toggle due to an interaction with the underlying native button. */
  _onButtonClick() {
    const newChecked = this._isSingleSelector() ? true : !this._checked;
    if (newChecked !== this._checked) {
      this._checked = newChecked;
      if (this.buttonToggleGroup) {
        this.buttonToggleGroup._syncButtonToggle(this, this._checked, true);
        this.buttonToggleGroup._onTouched();
      }
    }
    this.change.emit(new MatButtonToggleChange(this, this.value));
  }
  /**
   * Marks the button toggle as needing checking for change detection.
   * This method is exposed because the parent button toggle group will directly
   * update bound properties of the radio button.
   */
  _markForCheck() {
    this._changeDetectorRef.markForCheck();
  }
  /** Gets the name that should be assigned to the inner DOM node. */
  _getButtonName() {
    if (this._isSingleSelector()) {
      return this.buttonToggleGroup.name;
    }
    return this.name || null;
  }
  /** Whether the toggle is in single selection mode. */
  _isSingleSelector() {
    return this.buttonToggleGroup && !this.buttonToggleGroup.multiple;
  }
};
_MatButtonToggle.\u0275fac = function MatButtonToggle_Factory(t) {
  return new (t || _MatButtonToggle)(\u0275\u0275directiveInject(MAT_BUTTON_TOGGLE_GROUP, 8), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(FocusMonitor), \u0275\u0275injectAttribute("tabindex"), \u0275\u0275directiveInject(MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS, 8));
};
_MatButtonToggle.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatButtonToggle,
  selectors: [["mat-button-toggle"]],
  viewQuery: function MatButtonToggle_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(_c06, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._buttonElement = _t.first);
    }
  },
  hostAttrs: ["role", "presentation", 1, "mat-button-toggle"],
  hostVars: 12,
  hostBindings: function MatButtonToggle_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("focus", function MatButtonToggle_focus_HostBindingHandler() {
        return ctx.focus();
      });
    }
    if (rf & 2) {
      \u0275\u0275attribute("aria-label", null)("aria-labelledby", null)("id", ctx.id)("name", null);
      \u0275\u0275classProp("mat-button-toggle-standalone", !ctx.buttonToggleGroup)("mat-button-toggle-checked", ctx.checked)("mat-button-toggle-disabled", ctx.disabled)("mat-button-toggle-appearance-standard", ctx.appearance === "standard");
    }
  },
  inputs: {
    ariaLabel: [InputFlags.None, "aria-label", "ariaLabel"],
    ariaLabelledby: [InputFlags.None, "aria-labelledby", "ariaLabelledby"],
    id: "id",
    name: "name",
    value: "value",
    tabIndex: "tabIndex",
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    appearance: "appearance",
    checked: [InputFlags.HasDecoratorInputTransform, "checked", "checked", booleanAttribute],
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute]
  },
  outputs: {
    change: "change"
  },
  exportAs: ["matButtonToggle"],
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c13,
  decls: 8,
  vars: 11,
  consts: [["button", ""], ["type", "button", 1, "mat-button-toggle-button", "mat-focus-indicator", 3, "click", "id", "disabled"], [1, "mat-button-toggle-label-content"], ["state", "checked", "aria-hidden", "true", "appearance", "minimal", 1, "mat-mdc-option-pseudo-checkbox", 3, "disabled"], [1, "mat-button-toggle-focus-overlay"], ["matRipple", "", 1, "mat-button-toggle-ripple", 3, "matRippleTrigger", "matRippleDisabled"]],
  template: function MatButtonToggle_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = \u0275\u0275getCurrentView();
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "button", 1, 0);
      \u0275\u0275listener("click", function MatButtonToggle_Template_button_click_0_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onButtonClick());
      });
      \u0275\u0275elementStart(2, "span", 2);
      \u0275\u0275template(3, MatButtonToggle_Conditional_3_Template, 1, 1, "mat-pseudo-checkbox", 3)(4, MatButtonToggle_Conditional_4_Template, 1, 1, "mat-pseudo-checkbox", 3);
      \u0275\u0275projection(5);
      \u0275\u0275elementEnd()();
      \u0275\u0275element(6, "span", 4)(7, "span", 5);
    }
    if (rf & 2) {
      const button_r3 = \u0275\u0275reference(1);
      \u0275\u0275property("id", ctx.buttonId)("disabled", ctx.disabled || null);
      \u0275\u0275attribute("tabindex", ctx.disabled ? -1 : ctx.tabIndex)("aria-pressed", ctx.checked)("name", ctx._getButtonName())("aria-label", ctx.ariaLabel)("aria-labelledby", ctx.ariaLabelledby);
      \u0275\u0275advance(3);
      \u0275\u0275conditional(3, ctx.buttonToggleGroup && ctx.checked && !ctx.buttonToggleGroup.multiple && !ctx.buttonToggleGroup.hideSingleSelectionIndicator ? 3 : -1);
      \u0275\u0275advance();
      \u0275\u0275conditional(4, ctx.buttonToggleGroup && ctx.checked && ctx.buttonToggleGroup.multiple && !ctx.buttonToggleGroup.hideMultipleSelectionIndicator ? 4 : -1);
      \u0275\u0275advance(3);
      \u0275\u0275property("matRippleTrigger", button_r3)("matRippleDisabled", ctx.disableRipple || ctx.disabled);
    }
  },
  dependencies: [MatRipple, MatPseudoCheckbox],
  styles: [".mat-button-toggle-standalone,.mat-button-toggle-group{position:relative;display:inline-flex;flex-direction:row;white-space:nowrap;overflow:hidden;-webkit-tap-highlight-color:rgba(0,0,0,0);transform:translateZ(0);border-radius:var(--mat-legacy-button-toggle-shape)}.mat-button-toggle-standalone:not([class*=mat-elevation-z]),.mat-button-toggle-group:not([class*=mat-elevation-z]){box-shadow:0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12)}.cdk-high-contrast-active .mat-button-toggle-standalone,.cdk-high-contrast-active .mat-button-toggle-group{outline:solid 1px}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard,.mat-button-toggle-group-appearance-standard{border-radius:var(--mat-standard-button-toggle-shape);border:solid 1px var(--mat-standard-button-toggle-divider-color)}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard .mat-pseudo-checkbox,.mat-button-toggle-group-appearance-standard .mat-pseudo-checkbox{--mat-minimal-pseudo-checkbox-selected-checkmark-color: var( --mat-standard-button-toggle-selected-state-text-color )}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard:not([class*=mat-elevation-z]),.mat-button-toggle-group-appearance-standard:not([class*=mat-elevation-z]){box-shadow:none}.cdk-high-contrast-active .mat-button-toggle-standalone.mat-button-toggle-appearance-standard,.cdk-high-contrast-active .mat-button-toggle-group-appearance-standard{outline:0}.mat-button-toggle-vertical{flex-direction:column}.mat-button-toggle-vertical .mat-button-toggle-label-content{display:block}.mat-button-toggle{white-space:nowrap;position:relative;color:var(--mat-legacy-button-toggle-text-color);font-family:var(--mat-legacy-button-toggle-label-text-font);font-size:var(--mat-legacy-button-toggle-label-text-size);line-height:var(--mat-legacy-button-toggle-label-text-line-height);font-weight:var(--mat-legacy-button-toggle-label-text-weight);letter-spacing:var(--mat-legacy-button-toggle-label-text-tracking);--mat-minimal-pseudo-checkbox-selected-checkmark-color: var( --mat-legacy-button-toggle-selected-state-text-color )}.mat-button-toggle.cdk-keyboard-focused .mat-button-toggle-focus-overlay{opacity:var(--mat-legacy-button-toggle-focus-state-layer-opacity)}.mat-button-toggle .mat-icon svg{vertical-align:top}.mat-button-toggle .mat-pseudo-checkbox{margin-right:12px}[dir=rtl] .mat-button-toggle .mat-pseudo-checkbox{margin-right:0;margin-left:12px}.mat-button-toggle-checked{color:var(--mat-legacy-button-toggle-selected-state-text-color);background-color:var(--mat-legacy-button-toggle-selected-state-background-color)}.mat-button-toggle-disabled{color:var(--mat-legacy-button-toggle-disabled-state-text-color);background-color:var(--mat-legacy-button-toggle-disabled-state-background-color);--mat-minimal-pseudo-checkbox-disabled-selected-checkmark-color: var( --mat-legacy-button-toggle-disabled-state-text-color )}.mat-button-toggle-disabled.mat-button-toggle-checked{background-color:var(--mat-legacy-button-toggle-disabled-selected-state-background-color)}.mat-button-toggle-appearance-standard{color:var(--mat-standard-button-toggle-text-color);background-color:var(--mat-standard-button-toggle-background-color);font-family:var(--mat-standard-button-toggle-label-text-font);font-size:var(--mat-standard-button-toggle-label-text-size);line-height:var(--mat-standard-button-toggle-label-text-line-height);font-weight:var(--mat-standard-button-toggle-label-text-weight);letter-spacing:var(--mat-standard-button-toggle-label-text-tracking)}.mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard+.mat-button-toggle-appearance-standard{border-left:solid 1px var(--mat-standard-button-toggle-divider-color)}[dir=rtl] .mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard+.mat-button-toggle-appearance-standard{border-left:none;border-right:solid 1px var(--mat-standard-button-toggle-divider-color)}.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle-appearance-standard+.mat-button-toggle-appearance-standard{border-left:none;border-right:none;border-top:solid 1px var(--mat-standard-button-toggle-divider-color)}.mat-button-toggle-appearance-standard.mat-button-toggle-checked{color:var(--mat-standard-button-toggle-selected-state-text-color);background-color:var(--mat-standard-button-toggle-selected-state-background-color)}.mat-button-toggle-appearance-standard.mat-button-toggle-disabled{color:var(--mat-standard-button-toggle-disabled-state-text-color);background-color:var(--mat-standard-button-toggle-disabled-state-background-color)}.mat-button-toggle-appearance-standard.mat-button-toggle-disabled .mat-pseudo-checkbox{--mat-minimal-pseudo-checkbox-disabled-selected-checkmark-color: var( --mat-standard-button-toggle-disabled-selected-state-text-color )}.mat-button-toggle-appearance-standard.mat-button-toggle-disabled.mat-button-toggle-checked{color:var(--mat-standard-button-toggle-disabled-selected-state-text-color);background-color:var(--mat-standard-button-toggle-disabled-selected-state-background-color)}.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay{background-color:var(--mat-standard-button-toggle-state-layer-color)}.mat-button-toggle-appearance-standard:not(.mat-button-toggle-disabled):hover .mat-button-toggle-focus-overlay{opacity:var(--mat-standard-button-toggle-hover-state-layer-opacity)}.mat-button-toggle-appearance-standard.cdk-keyboard-focused:not(.mat-button-toggle-disabled) .mat-button-toggle-focus-overlay{opacity:var(--mat-standard-button-toggle-focus-state-layer-opacity)}@media(hover: none){.mat-button-toggle-appearance-standard:not(.mat-button-toggle-disabled):hover .mat-button-toggle-focus-overlay{display:none}}.mat-button-toggle-label-content{-webkit-user-select:none;user-select:none;display:inline-block;padding:0 16px;line-height:var(--mat-legacy-button-toggle-height);position:relative}.mat-button-toggle-appearance-standard .mat-button-toggle-label-content{padding:0 12px;line-height:var(--mat-standard-button-toggle-height)}.mat-button-toggle-label-content>*{vertical-align:middle}.mat-button-toggle-focus-overlay{top:0;left:0;right:0;bottom:0;position:absolute;border-radius:inherit;pointer-events:none;opacity:0;background-color:var(--mat-legacy-button-toggle-state-layer-color)}.cdk-high-contrast-active .mat-button-toggle-checked .mat-button-toggle-focus-overlay{border-bottom:solid 500px;opacity:.5;height:0}.cdk-high-contrast-active .mat-button-toggle-checked:hover .mat-button-toggle-focus-overlay{opacity:.6}.cdk-high-contrast-active .mat-button-toggle-checked.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay{border-bottom:solid 500px}.mat-button-toggle .mat-button-toggle-ripple{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none}.mat-button-toggle-button{border:0;background:none;color:inherit;padding:0;margin:0;font:inherit;outline:none;width:100%;cursor:pointer}.mat-button-toggle-disabled .mat-button-toggle-button{cursor:default}.mat-button-toggle-button::-moz-focus-inner{border:0}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard{--mat-focus-indicator-border-radius:var(--mat-standard-button-toggle-shape)}.mat-button-toggle-group-appearance-standard .mat-button-toggle:last-of-type .mat-button-toggle-button::before{border-top-right-radius:var(--mat-standard-button-toggle-shape);border-bottom-right-radius:var(--mat-standard-button-toggle-shape)}.mat-button-toggle-group-appearance-standard .mat-button-toggle:first-of-type .mat-button-toggle-button::before{border-top-left-radius:var(--mat-standard-button-toggle-shape);border-bottom-left-radius:var(--mat-standard-button-toggle-shape)}"],
  encapsulation: 2,
  changeDetection: 0
});
var MatButtonToggle = _MatButtonToggle;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatButtonToggle, [{
    type: Component,
    args: [{
      selector: "mat-button-toggle",
      encapsulation: ViewEncapsulation$1.None,
      exportAs: "matButtonToggle",
      changeDetection: ChangeDetectionStrategy.OnPush,
      host: {
        "[class.mat-button-toggle-standalone]": "!buttonToggleGroup",
        "[class.mat-button-toggle-checked]": "checked",
        "[class.mat-button-toggle-disabled]": "disabled",
        "[class.mat-button-toggle-appearance-standard]": 'appearance === "standard"',
        "class": "mat-button-toggle",
        "[attr.aria-label]": "null",
        "[attr.aria-labelledby]": "null",
        "[attr.id]": "id",
        "[attr.name]": "null",
        "(focus)": "focus()",
        "role": "presentation"
      },
      standalone: true,
      imports: [MatRipple, MatPseudoCheckbox],
      template: '<button #button class="mat-button-toggle-button mat-focus-indicator"\n        type="button"\n        [id]="buttonId"\n        [attr.tabindex]="disabled ? -1 : tabIndex"\n        [attr.aria-pressed]="checked"\n        [disabled]="disabled || null"\n        [attr.name]="_getButtonName()"\n        [attr.aria-label]="ariaLabel"\n        [attr.aria-labelledby]="ariaLabelledby"\n        (click)="_onButtonClick()">\n  <span class="mat-button-toggle-label-content">\n    <!-- Render checkmark at the beginning for single-selection. -->\n    @if (buttonToggleGroup && checked && !buttonToggleGroup.multiple && !buttonToggleGroup.hideSingleSelectionIndicator) {\n      <mat-pseudo-checkbox\n          class="mat-mdc-option-pseudo-checkbox"\n          [disabled]="disabled"\n          state="checked"\n          aria-hidden="true"\n          appearance="minimal"></mat-pseudo-checkbox>\n    }\n    <!-- Render checkmark at the beginning for multiple-selection. -->\n    @if (buttonToggleGroup && checked && buttonToggleGroup.multiple && !buttonToggleGroup.hideMultipleSelectionIndicator) {\n      <mat-pseudo-checkbox\n          class="mat-mdc-option-pseudo-checkbox"\n          [disabled]="disabled"\n          state="checked"\n          aria-hidden="true"\n          appearance="minimal"></mat-pseudo-checkbox>\n    }\n    <ng-content></ng-content>\n  </span>\n</button>\n\n<span class="mat-button-toggle-focus-overlay"></span>\n<span class="mat-button-toggle-ripple" matRipple\n     [matRippleTrigger]="button"\n     [matRippleDisabled]="this.disableRipple || this.disabled">\n</span>\n',
      styles: [".mat-button-toggle-standalone,.mat-button-toggle-group{position:relative;display:inline-flex;flex-direction:row;white-space:nowrap;overflow:hidden;-webkit-tap-highlight-color:rgba(0,0,0,0);transform:translateZ(0);border-radius:var(--mat-legacy-button-toggle-shape)}.mat-button-toggle-standalone:not([class*=mat-elevation-z]),.mat-button-toggle-group:not([class*=mat-elevation-z]){box-shadow:0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12)}.cdk-high-contrast-active .mat-button-toggle-standalone,.cdk-high-contrast-active .mat-button-toggle-group{outline:solid 1px}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard,.mat-button-toggle-group-appearance-standard{border-radius:var(--mat-standard-button-toggle-shape);border:solid 1px var(--mat-standard-button-toggle-divider-color)}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard .mat-pseudo-checkbox,.mat-button-toggle-group-appearance-standard .mat-pseudo-checkbox{--mat-minimal-pseudo-checkbox-selected-checkmark-color: var( --mat-standard-button-toggle-selected-state-text-color )}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard:not([class*=mat-elevation-z]),.mat-button-toggle-group-appearance-standard:not([class*=mat-elevation-z]){box-shadow:none}.cdk-high-contrast-active .mat-button-toggle-standalone.mat-button-toggle-appearance-standard,.cdk-high-contrast-active .mat-button-toggle-group-appearance-standard{outline:0}.mat-button-toggle-vertical{flex-direction:column}.mat-button-toggle-vertical .mat-button-toggle-label-content{display:block}.mat-button-toggle{white-space:nowrap;position:relative;color:var(--mat-legacy-button-toggle-text-color);font-family:var(--mat-legacy-button-toggle-label-text-font);font-size:var(--mat-legacy-button-toggle-label-text-size);line-height:var(--mat-legacy-button-toggle-label-text-line-height);font-weight:var(--mat-legacy-button-toggle-label-text-weight);letter-spacing:var(--mat-legacy-button-toggle-label-text-tracking);--mat-minimal-pseudo-checkbox-selected-checkmark-color: var( --mat-legacy-button-toggle-selected-state-text-color )}.mat-button-toggle.cdk-keyboard-focused .mat-button-toggle-focus-overlay{opacity:var(--mat-legacy-button-toggle-focus-state-layer-opacity)}.mat-button-toggle .mat-icon svg{vertical-align:top}.mat-button-toggle .mat-pseudo-checkbox{margin-right:12px}[dir=rtl] .mat-button-toggle .mat-pseudo-checkbox{margin-right:0;margin-left:12px}.mat-button-toggle-checked{color:var(--mat-legacy-button-toggle-selected-state-text-color);background-color:var(--mat-legacy-button-toggle-selected-state-background-color)}.mat-button-toggle-disabled{color:var(--mat-legacy-button-toggle-disabled-state-text-color);background-color:var(--mat-legacy-button-toggle-disabled-state-background-color);--mat-minimal-pseudo-checkbox-disabled-selected-checkmark-color: var( --mat-legacy-button-toggle-disabled-state-text-color )}.mat-button-toggle-disabled.mat-button-toggle-checked{background-color:var(--mat-legacy-button-toggle-disabled-selected-state-background-color)}.mat-button-toggle-appearance-standard{color:var(--mat-standard-button-toggle-text-color);background-color:var(--mat-standard-button-toggle-background-color);font-family:var(--mat-standard-button-toggle-label-text-font);font-size:var(--mat-standard-button-toggle-label-text-size);line-height:var(--mat-standard-button-toggle-label-text-line-height);font-weight:var(--mat-standard-button-toggle-label-text-weight);letter-spacing:var(--mat-standard-button-toggle-label-text-tracking)}.mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard+.mat-button-toggle-appearance-standard{border-left:solid 1px var(--mat-standard-button-toggle-divider-color)}[dir=rtl] .mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard+.mat-button-toggle-appearance-standard{border-left:none;border-right:solid 1px var(--mat-standard-button-toggle-divider-color)}.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle-appearance-standard+.mat-button-toggle-appearance-standard{border-left:none;border-right:none;border-top:solid 1px var(--mat-standard-button-toggle-divider-color)}.mat-button-toggle-appearance-standard.mat-button-toggle-checked{color:var(--mat-standard-button-toggle-selected-state-text-color);background-color:var(--mat-standard-button-toggle-selected-state-background-color)}.mat-button-toggle-appearance-standard.mat-button-toggle-disabled{color:var(--mat-standard-button-toggle-disabled-state-text-color);background-color:var(--mat-standard-button-toggle-disabled-state-background-color)}.mat-button-toggle-appearance-standard.mat-button-toggle-disabled .mat-pseudo-checkbox{--mat-minimal-pseudo-checkbox-disabled-selected-checkmark-color: var( --mat-standard-button-toggle-disabled-selected-state-text-color )}.mat-button-toggle-appearance-standard.mat-button-toggle-disabled.mat-button-toggle-checked{color:var(--mat-standard-button-toggle-disabled-selected-state-text-color);background-color:var(--mat-standard-button-toggle-disabled-selected-state-background-color)}.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay{background-color:var(--mat-standard-button-toggle-state-layer-color)}.mat-button-toggle-appearance-standard:not(.mat-button-toggle-disabled):hover .mat-button-toggle-focus-overlay{opacity:var(--mat-standard-button-toggle-hover-state-layer-opacity)}.mat-button-toggle-appearance-standard.cdk-keyboard-focused:not(.mat-button-toggle-disabled) .mat-button-toggle-focus-overlay{opacity:var(--mat-standard-button-toggle-focus-state-layer-opacity)}@media(hover: none){.mat-button-toggle-appearance-standard:not(.mat-button-toggle-disabled):hover .mat-button-toggle-focus-overlay{display:none}}.mat-button-toggle-label-content{-webkit-user-select:none;user-select:none;display:inline-block;padding:0 16px;line-height:var(--mat-legacy-button-toggle-height);position:relative}.mat-button-toggle-appearance-standard .mat-button-toggle-label-content{padding:0 12px;line-height:var(--mat-standard-button-toggle-height)}.mat-button-toggle-label-content>*{vertical-align:middle}.mat-button-toggle-focus-overlay{top:0;left:0;right:0;bottom:0;position:absolute;border-radius:inherit;pointer-events:none;opacity:0;background-color:var(--mat-legacy-button-toggle-state-layer-color)}.cdk-high-contrast-active .mat-button-toggle-checked .mat-button-toggle-focus-overlay{border-bottom:solid 500px;opacity:.5;height:0}.cdk-high-contrast-active .mat-button-toggle-checked:hover .mat-button-toggle-focus-overlay{opacity:.6}.cdk-high-contrast-active .mat-button-toggle-checked.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay{border-bottom:solid 500px}.mat-button-toggle .mat-button-toggle-ripple{top:0;left:0;right:0;bottom:0;position:absolute;pointer-events:none}.mat-button-toggle-button{border:0;background:none;color:inherit;padding:0;margin:0;font:inherit;outline:none;width:100%;cursor:pointer}.mat-button-toggle-disabled .mat-button-toggle-button{cursor:default}.mat-button-toggle-button::-moz-focus-inner{border:0}.mat-button-toggle-standalone.mat-button-toggle-appearance-standard{--mat-focus-indicator-border-radius:var(--mat-standard-button-toggle-shape)}.mat-button-toggle-group-appearance-standard .mat-button-toggle:last-of-type .mat-button-toggle-button::before{border-top-right-radius:var(--mat-standard-button-toggle-shape);border-bottom-right-radius:var(--mat-standard-button-toggle-shape)}.mat-button-toggle-group-appearance-standard .mat-button-toggle:first-of-type .mat-button-toggle-button::before{border-top-left-radius:var(--mat-standard-button-toggle-shape);border-bottom-left-radius:var(--mat-standard-button-toggle-shape)}"]
    }]
  }], () => [{
    type: MatButtonToggleGroup,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_BUTTON_TOGGLE_GROUP]
    }]
  }, {
    type: ChangeDetectorRef
  }, {
    type: ElementRef
  }, {
    type: FocusMonitor
  }, {
    type: void 0,
    decorators: [{
      type: Attribute,
      args: ["tabindex"]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS]
    }]
  }], {
    ariaLabel: [{
      type: Input,
      args: ["aria-label"]
    }],
    ariaLabelledby: [{
      type: Input,
      args: ["aria-labelledby"]
    }],
    _buttonElement: [{
      type: ViewChild,
      args: ["button"]
    }],
    id: [{
      type: Input
    }],
    name: [{
      type: Input
    }],
    value: [{
      type: Input
    }],
    tabIndex: [{
      type: Input
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    appearance: [{
      type: Input
    }],
    checked: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    change: [{
      type: Output
    }]
  });
})();
var _MatButtonToggleModule = class _MatButtonToggleModule {
};
_MatButtonToggleModule.\u0275fac = function MatButtonToggleModule_Factory(t) {
  return new (t || _MatButtonToggleModule)();
};
_MatButtonToggleModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatButtonToggleModule
});
_MatButtonToggleModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatCommonModule, MatRippleModule, MatButtonToggle, MatCommonModule]
});
var MatButtonToggleModule = _MatButtonToggleModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatButtonToggleModule, [{
    type: NgModule,
    args: [{
      imports: [MatCommonModule, MatRippleModule, MatButtonToggleGroup, MatButtonToggle],
      exports: [MatCommonModule, MatButtonToggleGroup, MatButtonToggle]
    }]
  }], null, null);
})();

// src/app/features/setting/components/setting-copy-to/setting-copy-to.component.ts
var _c07 = ["appSelect"];
function SettingCopyToComponent_mat_option_16_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 20);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const app_r2 = ctx.$implicit;
    \u0275\u0275property("value", app_r2.id);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(app_r2.client.name);
  }
}
function SettingCopyToComponent_button_21_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 21);
    \u0275\u0275listener("click", function SettingCopyToComponent_button_21_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r3);
      const ctx_r3 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r3.clear());
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "clear");
    \u0275\u0275elementEnd()();
  }
}
function SettingCopyToComponent_mat_error_25_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-error");
    \u0275\u0275text(1, "Setting already exists.");
    \u0275\u0275elementEnd();
  }
}
function SettingCopyToComponent_mat_option_38_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 20);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const option_r5 = ctx.$implicit;
    \u0275\u0275property("value", option_r5.name);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate1(" ", option_r5.name, " ");
  }
}
var _SettingCopyToComponent = class _SettingCopyToComponent {
  constructor(cdr, snackBar, dialogRef, formBuilder, model, settingsService, appsService, identifiersService, windowService) {
    this.cdr = cdr;
    this.snackBar = snackBar;
    this.dialogRef = dialogRef;
    this.formBuilder = formBuilder;
    this.model = model;
    this.settingsService = settingsService;
    this.appsService = appsService;
    this.identifiersService = identifiersService;
    this.windowService = windowService;
    this.selectedAppIdentifierId = null;
    this.selectedAppIdentifierOrder = null;
    this.fieldFirstTimeClicked = true;
    this.selectedApp = null;
    this.isAppsFetched = false;
    this.apps = [];
    this.appFilterType = "1";
    this.subscriptions = new Subscription();
    this.destroy$ = new Subject();
    this.appClientValidator = (control) => {
      if (control.value !== this.model.appId) {
        this.identifierFilterChanged();
        const identifierControl = this.myForm?.get("identifierName");
        if (identifierControl?.hasError("identifierExists")) {
          const currentErrors = identifierControl.errors;
          if (currentErrors) {
            delete currentErrors["identifierExists"];
            identifierControl.setErrors(Object.keys(currentErrors).length ? currentErrors : null);
          }
        }
      } else {
        const identifierControl = this.myForm?.get("identifierName");
        if (identifierControl) {
          if (this.model.notAvailableAppIdentifiers.some((a) => a.name.toLocaleLowerCase() === identifierControl.value.toLocaleLowerCase())) {
            const currentErrors = identifierControl.errors || {};
            currentErrors["identifierExists"] = true;
            identifierControl.setErrors(currentErrors);
          } else {
            const currentErrors = identifierControl.errors;
            if (currentErrors && currentErrors["identifierExists"]) {
              delete currentErrors["identifierExists"];
              identifierControl.setErrors(Object.keys(currentErrors).length ? currentErrors : null);
            }
          }
        }
      }
      return null;
    };
    this.identifierValidator = (control) => {
      if (isNullOrWhiteSpace(control.value)) {
        return { invalidIdentifierName: true };
      }
      if (this.model.appId === this.myForm.get("targetAppId")?.value) {
        if (this.model.notAvailableAppIdentifiers.some((a) => a.name.toLocaleLowerCase() === control.value.toLocaleLowerCase())) {
          return { identifierExists: true };
        }
      }
      return null;
    };
  }
  ngOnInit() {
    this.apps.push({
      id: this.model.appId,
      client: {
        id: this.model.clientId,
        name: this.model.clientName
      }
    });
    this.myForm = this.formBuilder.group({
      targetAppId: [this.model.appId, [Validators.required, this.appClientValidator]],
      identifierName: ["", [Validators.required, this.identifierValidator]],
      identifierId: ["0"]
    });
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
    this.subscriptions.unsubscribe();
  }
  getApps() {
    if (this.isAppsFetched || !this.windowService.isProvider) {
      return;
    }
    this.isAppsFetched = true;
    const subscription = this.appsService.getApps({}).subscribe({
      next: (response) => {
        if (!response.data) {
          return;
        }
        this.apps = response.data;
        this.cdr.detectChanges();
        this.appSelect.open();
      },
      error: () => {
        this.isAppsFetched = false;
      }
    });
    this.subscriptions.add(subscription);
  }
  clear() {
    this.myForm.get("identifierName")?.setValue("");
    this.identifierFilterChanged();
  }
  onFieldFocus() {
    if (!this.fieldFirstTimeClicked) {
      return;
    }
    this.fieldFirstTimeClicked = false;
    const formField = this.myForm.get("identifierName");
    const identifierName$ = formField.valueChanges.pipe(startWith(formField.value), debounceTime(300), distinctUntilChanged());
    this.filteredAppIdentifiers$ = identifierName$.pipe(switchMap((value) => {
      const targetAppId = this.myForm.get("targetAppId").value;
      const appId = this.apps.find((a) => a.id === targetAppId).id;
      return this.identifiersService.getIdentifiers({
        searchTerm: value,
        appId: this.appFilterType ? appId : void 0,
        isAppMapped: this.appFilterType === "1"
      }).pipe(map((response) => {
        if (!response.data) {
          return [];
        }
        const identifiers = appId == this.model.appId ? response.data.identifiers.filter((d) => !this.model.notAvailableAppIdentifiers.some((a) => a.name.toLocaleLowerCase() === d.name.toLocaleLowerCase())) : response.data.identifiers;
        const selectedIdentifier = identifiers.find((group2) => group2.name.toLowerCase() === value.toLowerCase());
        this.selectedAppIdentifierId = selectedIdentifier ? selectedIdentifier.id : null;
        this.selectedAppIdentifierOrder = selectedIdentifier ? selectedIdentifier.sortOrder : null;
        return identifiers;
      }));
    }));
  }
  identifierFilterChanged() {
    const targetAppId = this.myForm.get("targetAppId").value;
    const appId = this.apps.find((a) => a.id === targetAppId).id;
    const formField = this.myForm.get("identifierName");
    this.filteredAppIdentifiers$ = this.identifiersService.getIdentifiers({
      searchTerm: formField.value,
      appId: this.appFilterType ? appId : void 0,
      isAppMapped: this.appFilterType === "1"
    }).pipe(map((response) => {
      if (!response.data) {
        return [];
      }
      const identifiers = appId == this.model.appId ? response.data.identifiers.filter((d) => !this.model.notAvailableAppIdentifiers.some((a) => a.name.toLocaleLowerCase() === d.name.toLocaleLowerCase())) : response.data.identifiers;
      const selectedIdentifier = identifiers.find((group2) => group2.name.toLowerCase() === formField.value.toLowerCase());
      this.selectedAppIdentifierId = selectedIdentifier ? selectedIdentifier.id : null;
      this.selectedAppIdentifierOrder = selectedIdentifier ? selectedIdentifier.sortOrder : null;
      return identifiers;
    }));
  }
  onSubmit() {
    if (!this.myForm.valid) {
      return;
    }
    const formValue = this.myForm.value;
    const model = {
      targetAppId: formValue.targetAppId,
      identifier: {
        id: this.selectedAppIdentifierId ?? formValue.identifierId,
        name: formValue.identifierName
      }
    };
    const subscription = this.settingsService.copySettingTo({
      settingId: this.model.currentSettingId,
      body: model
    }).subscribe((response) => {
      if (response.success) {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        const returnModel = {
          settingId: responseData.setting.id,
          clientId: responseData.clientId,
          appSlug: responseData.appSlug,
          classId: responseData.setting.classId,
          identifierId: responseData.identifier.id,
          identifierName: responseData.identifier.name,
          identifierSortOrder: responseData.identifier.sortOrder,
          identifierMappingSortOrder: responseData.identifier.mappingSortOrder
        };
        this.snackBar.open(`Copied successfully!`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.dialogRef.close(returnModel);
      }
    });
    this.subscriptions.add(subscription);
  }
  close() {
    this.dialogRef.close();
  }
};
_SettingCopyToComponent.\u0275fac = function SettingCopyToComponent_Factory(t) {
  return new (t || _SettingCopyToComponent)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(MAT_DIALOG_DATA), \u0275\u0275directiveInject(SettingsService), \u0275\u0275directiveInject(AppsService), \u0275\u0275directiveInject(IdentifiersService), \u0275\u0275directiveInject(WindowService));
};
_SettingCopyToComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _SettingCopyToComponent, selectors: [["ng-component"]], viewQuery: function SettingCopyToComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c07, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.appSelect = _t.first);
  }
}, decls: 40, vars: 12, consts: [["appSelect", ""], ["groupAuto", "matAutocomplete"], [1, "d-flex", "mb-2", "pb-2", "border-bottom"], [1, "spacer"], ["mat-icon-button", "", "matToolTip", "Close", "matTooltipPosition", "above", 3, "click"], [1, "mt-2"], [3, "ngSubmit", "formGroup"], ["appearance", "fill", 3, "click"], ["formControlName", "targetAppId"], [3, "value", 4, "ngFor", "ngForOf"], ["appearance", "fill"], ["type", "text", "matInput", "", "formControlName", "identifierName", 3, "focus", "maxLength", "matAutocomplete"], ["type", "button", "mat-icon-button", "", "matSuffix", "", "matTooltip", "clear", 3, "click", 4, "ngIf"], ["mat-icon-button", "", "matSuffix", "", "type", "submit", "color", "primary", 3, "disabled"], [4, "ngIf"], [3, "click"], [3, "ngModelChange", "click", "change", "ngModel"], ["value", "1"], ["value", "0"], ["value", ""], [3, "value"], ["type", "button", "mat-icon-button", "", "matSuffix", "", "matTooltip", "clear", 3, "click"]], template: function SettingCopyToComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 2)(1, "mat-card-header")(2, "mat-card-title");
    \u0275\u0275text(3);
    \u0275\u0275elementEnd()();
    \u0275\u0275element(4, "span")(5, "span", 3);
    \u0275\u0275elementStart(6, "button", 4);
    \u0275\u0275listener("click", function SettingCopyToComponent_Template_button_click_6_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.close());
    });
    \u0275\u0275elementStart(7, "mat-icon");
    \u0275\u0275text(8, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(9, "mat-card-content", 5)(10, "form", 6);
    \u0275\u0275listener("ngSubmit", function SettingCopyToComponent_Template_form_ngSubmit_10_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onSubmit());
    });
    \u0275\u0275elementStart(11, "mat-form-field", 7);
    \u0275\u0275listener("click", function SettingCopyToComponent_Template_mat_form_field_click_11_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.getApps());
    });
    \u0275\u0275elementStart(12, "mat-label");
    \u0275\u0275text(13, "Target client name");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(14, "mat-select", 8, 0);
    \u0275\u0275template(16, SettingCopyToComponent_mat_option_16_Template, 2, 2, "mat-option", 9);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(17, "mat-form-field", 10)(18, "mat-label");
    \u0275\u0275text(19, "Target identifier name");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(20, "input", 11);
    \u0275\u0275listener("focus", function SettingCopyToComponent_Template_input_focus_20_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onFieldFocus());
    });
    \u0275\u0275elementEnd();
    \u0275\u0275template(21, SettingCopyToComponent_button_21_Template, 3, 0, "button", 12);
    \u0275\u0275elementStart(22, "button", 13)(23, "mat-icon");
    \u0275\u0275text(24, "check_circle");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(25, SettingCopyToComponent_mat_error_25_Template, 2, 0, "mat-error", 14);
    \u0275\u0275elementStart(26, "mat-hint");
    \u0275\u0275text(27, "If identifier missing, will be created along with the mapping.");
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(28, "mat-autocomplete", null, 1)(30, "mat-option", 15);
    \u0275\u0275listener("click", function SettingCopyToComponent_Template_mat_option_click_30_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView($event.stopPropagation());
    });
    \u0275\u0275elementStart(31, "mat-button-toggle-group", 16);
    \u0275\u0275twoWayListener("ngModelChange", function SettingCopyToComponent_Template_mat_button_toggle_group_ngModelChange_31_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.appFilterType, $event) || (ctx.appFilterType = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275listener("click", function SettingCopyToComponent_Template_mat_button_toggle_group_click_31_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView($event.stopPropagation());
    })("change", function SettingCopyToComponent_Template_mat_button_toggle_group_change_31_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.identifierFilterChanged());
    });
    \u0275\u0275elementStart(32, "mat-button-toggle", 17);
    \u0275\u0275text(33, "Mapped");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(34, "mat-button-toggle", 18);
    \u0275\u0275text(35, "Unmapped");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(36, "mat-button-toggle", 19);
    \u0275\u0275text(37, "All");
    \u0275\u0275elementEnd()()();
    \u0275\u0275template(38, SettingCopyToComponent_mat_option_38_Template, 2, 2, "mat-option", 9);
    \u0275\u0275pipe(39, "async");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    let tmp_9_0;
    const groupAuto_r6 = \u0275\u0275reference(29);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1("Copy '", ctx.model.className, "' to");
    \u0275\u0275advance(7);
    \u0275\u0275property("formGroup", ctx.myForm);
    \u0275\u0275advance(6);
    \u0275\u0275property("ngForOf", ctx.apps);
    \u0275\u0275advance(4);
    \u0275\u0275property("maxLength", 50)("matAutocomplete", groupAuto_r6);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.myForm.get("identifierName").value);
    \u0275\u0275advance();
    \u0275\u0275property("disabled", ctx.myForm.invalid);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", (tmp_9_0 = ctx.myForm.get("identifierName")) == null ? null : tmp_9_0.hasError("identifierExists"));
    \u0275\u0275advance(6);
    \u0275\u0275twoWayProperty("ngModel", ctx.appFilterType);
    \u0275\u0275advance(7);
    \u0275\u0275property("ngForOf", \u0275\u0275pipeBind1(39, 10, ctx.filteredAppIdentifiers$));
  }
}, dependencies: [NgForOf, NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, NgModel, FormGroupDirective, FormControlName, MatIcon, MatCardContent, MatCardHeader, MatCardTitle, MatFormField, MatLabel, MatHint, MatError, MatSuffix, MatOption, MatIconButton, MatTooltip, MatButtonToggleGroup, MatButtonToggle, MatInput, MatSelect, MatAutocomplete, MatAutocompleteTrigger, AsyncPipe], encapsulation: 2 });
var SettingCopyToComponent = _SettingCopyToComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(SettingCopyToComponent, { className: "SettingCopyToComponent", filePath: "src\\app\\features\\setting\\components\\setting-copy-to\\setting-copy-to.component.ts", lineNumber: 19 });
})();

// src/app/features/configuration/services/configurations.service.ts
var _ConfigurationsService = class _ConfigurationsService {
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
  getConfigurationByAppAndIdentifier(request) {
    let url = this.route + `/v1/apps/${request.appId}/identifiers/${request.identifierId}/configuration`;
    return this.httpClient.get(url, { headers: this.headers });
  }
  patchConfiguration(request) {
    let url = this.route + `/v1/apps/${request.appId}/identifiers/${request.identifierId}/configuration`;
    return this.httpClient.patch(url, request.body, { headers: this.headers });
  }
};
_ConfigurationsService.\u0275fac = function ConfigurationsService_Factory(t) {
  return new (t || _ConfigurationsService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_ConfigurationsService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _ConfigurationsService, factory: _ConfigurationsService.\u0275fac, providedIn: "root" });
var ConfigurationsService = _ConfigurationsService;

// src/app/features/app/services/app-view.service.ts
var _AppViewService = class _AppViewService {
  constructor(userPreferencesService) {
    this.userPreferencesService = userPreferencesService;
    this.settingViewSubject = new BehaviorSubject(void 0);
    this.settingView$ = this.settingViewSubject.asObservable();
    this.appViewMultiSelectionEnabledSubject = new BehaviorSubject(userPreferencesService.appViewMultiSelectionEnabled);
    this.appViewMultiSelectionEnabled$ = this.appViewMultiSelectionEnabledSubject.asObservable();
  }
  get settingView() {
    return this.settingViewSubject.getValue();
  }
  get appViewMultiSelectionEnabled() {
    return this.appViewMultiSelectionEnabledSubject.getValue();
  }
  emitSettingView(settingView) {
    this.settingViewSubject.next(settingView);
  }
  emitAppViewMultiSelectionEnabled(isEnabled) {
    this.userPreferencesService.setAppViewMultiSelectionEnabled(isEnabled);
    this.appViewMultiSelectionEnabledSubject.next(isEnabled);
  }
};
_AppViewService.\u0275fac = function AppViewService_Factory(t) {
  return new (t || _AppViewService)(\u0275\u0275inject(UserPreferencesService));
};
_AppViewService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _AppViewService, factory: _AppViewService.\u0275fac, providedIn: "root" });
var AppViewService = _AppViewService;

// src/app/shared/components/json-editor/json-editor.component.ts
var _c08 = ["editorContainer"];
var _c14 = (a0, a1) => ({ height: a0, width: a1 });
var _JsonEditorComponent = class _JsonEditorComponent {
  constructor() {
    this.editorWidth = "100%";
    this.theme = "vs-light";
    this.readonly = false;
    this.value = {};
    this.invalidData = new EventEmitter();
    this.dataChange = new EventEmitter();
    this.onChange = () => {
    };
    this.onTouched = () => {
    };
    this.height = 0;
  }
  ngOnInit() {
    this.initializeEditor();
  }
  ngOnDestroy() {
    if (this.editor) {
      this.editor.dispose();
    }
    if (this.editorChangeSubscription) {
      this.editorChangeSubscription.dispose();
    }
  }
  get editorHeight() {
    return `${this.height}px`;
  }
  initializeEditor() {
    if (this.editor) {
      return;
    }
    const value = this.getJsonValue();
    this.adjustHeight(value);
    this.editor = monaco.editor.create(this.editorContainer.nativeElement, {
      value,
      language: "json",
      theme: this.theme,
      automaticLayout: true,
      readOnly: this.readonly,
      minimap: { enabled: true },
      glyphMargin: false,
      lineNumbers: "on",
      folding: true,
      scrollBeyondLastLine: true,
      renderLineHighlight: "none",
      overviewRulerLanes: 0,
      lineDecorationsWidth: 0,
      hideCursorInOverviewRuler: true,
      occurrencesHighlight: "off",
      quickSuggestions: false,
      codeLens: false,
      renderWhitespace: "none",
      hover: { enabled: false },
      contextmenu: false,
      wordBasedSuggestions: "off",
      fontLigatures: false,
      renderFinalNewline: "off",
      inlayHints: { enabled: "off" },
      suggestOnTriggerCharacters: false
    });
    this.editorChangeSubscription = this.editor.onDidChangeModelContent(() => {
      this.updateEditorValue();
    });
  }
  updateEditorValue() {
    const value = this.editor.getValue();
    this.adjustHeight(value);
    try {
      this.value = JSON.parse(value);
      if (typeof this.value === "object" && this.value !== null) {
        this.emitInvalidData(false);
      } else {
        this.emitInvalidData(true);
      }
    } catch {
      this.emitInvalidData(true);
    }
    this.onChange(this.value);
  }
  emitInvalidData(invalid) {
    this.invalidData.emit(invalid);
  }
  getJsonValue() {
    return this.value ? JSON.stringify(this.value, null, 4) : "{}";
  }
  writeValue(value) {
    this.value = value || {};
    if (this.editor && value) {
      const jsonValue = this.getJsonValue();
      this.editor.setValue(jsonValue);
    }
  }
  registerOnChange(fn) {
    this.onChange = fn;
  }
  registerOnTouched(fn) {
    this.onTouched = fn;
  }
  adjustHeight(value) {
    const height = this.getContentHeight(value);
    this.height = Math.min(300, height);
  }
  getContentHeight(content) {
    const lineHeight = 19;
    const lineCount = (content.match(/\n/g) || []).length + 1;
    return lineHeight * lineCount;
  }
  formatCode() {
    this.editor.getAction("editor.action.formatDocument")?.run();
  }
};
_JsonEditorComponent.\u0275fac = function JsonEditorComponent_Factory(t) {
  return new (t || _JsonEditorComponent)();
};
_JsonEditorComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _JsonEditorComponent, selectors: [["json-editor"]], viewQuery: function JsonEditorComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c08, 7);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.editorContainer = _t.first);
  }
}, inputs: { id: "id", editorWidth: "editorWidth", theme: "theme", readonly: "readonly", value: "value" }, outputs: { invalidData: "invalidData", dataChange: "dataChange" }, features: [\u0275\u0275ProvidersFeature([
  {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => _JsonEditorComponent),
    multi: true
  }
])], decls: 2, vars: 4, consts: [["editorContainer", ""], [1, "editor-container", 3, "ngStyle"]], template: function JsonEditorComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "div", 1, 0);
  }
  if (rf & 2) {
    \u0275\u0275property("ngStyle", \u0275\u0275pureFunction2(1, _c14, ctx.editorHeight, ctx.editorWidth));
  }
}, dependencies: [NgStyle] });
var JsonEditorComponent = _JsonEditorComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(JsonEditorComponent, { className: "JsonEditorComponent", filePath: "src\\app\\shared\\components\\json-editor\\json-editor.component.ts", lineNumber: 17 });
})();

// src/app/features/setting/components/setting-create/setting-create.component.ts
var _c09 = ["textarea"];
function SettingCreateComponent_button_37_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 25);
    \u0275\u0275listener("click", function SettingCreateComponent_button_37_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.copyToClipboard(ctx_r2.computedIdentifierPreview));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275property("disabled", !ctx_r2.computedIdentifierPreview);
  }
}
function SettingCreateComponent_button_54_Template(rf, ctx) {
  if (rf & 1) {
    const _r5 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 26);
    \u0275\u0275listener("click", function SettingCreateComponent_button_54_Template_button_click_0_listener() {
      let tmp_3_0;
      \u0275\u0275restoreView(_r5);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.copyToClipboard((tmp_3_0 = ctx_r2.form.get("data")) == null ? null : tmp_3_0.value));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
}
var _SettingCreateComponent = class _SettingCreateComponent {
  constructor(dialogRef, data, settingsService, formBuilder, utilityService, windowService, snackBar, themeService) {
    this.dialogRef = dialogRef;
    this.data = data;
    this.settingsService = settingsService;
    this.formBuilder = formBuilder;
    this.utilityService = utilityService;
    this.windowService = windowService;
    this.snackBar = snackBar;
    this.themeService = themeService;
    this.isFullScreen = false;
    this.classFullName = "";
    this.computedIdentifierPreview = "";
    this.jsonInvalid = false;
    this.subscriptions = new Subscription();
    this.theme = this.themeService.isDarkTheme() ? "vs-dark" : "vs-light";
  }
  ngOnInit() {
    this.form = this.formBuilder.group({
      computedIdentifier: ["", Validators.required],
      classNamespace: ["", Validators.required],
      className: ["", Validators.required],
      classFullName: ["", Validators.required],
      data: [{}, [Validators.required]],
      storeInSeparateFile: [true],
      ignoreOnFileChange: [false],
      registrationMode: [1]
    });
    this.subscriptions.add(this.form.get("classNamespace").valueChanges.subscribe(() => this.updateClassFullName()));
    this.subscriptions.add(this.form.get("className").valueChanges.subscribe(() => this.updateClassFullName()));
    this.subscriptions.add(this.form.get("computedIdentifier").valueChanges.subscribe((value) => this.updateComputedIdentifierPreview(value)));
    this.isConnectionSecure = this.windowService.isConnectionSecure;
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  updateClassFullName() {
    const classNamespace = this.form.get("classNamespace")?.value;
    const className = this.form.get("className")?.value;
    if (classNamespace && className) {
      const classFullName = `${classNamespace}.${className}`;
      this.form.get("classFullName")?.setValue(classFullName, { emitEvent: false });
      const computedIdentifier = this.form.get("computedIdentifier");
      const classComputedIdentifierValue = computedIdentifier.value;
      if (!classComputedIdentifierValue || classFullName.includes(classComputedIdentifierValue)) {
        computedIdentifier?.setValue(classFullName);
      }
    }
  }
  updateComputedIdentifierPreview(value) {
    if (value && isValidGuid(value)) {
      this.computedIdentifierPreview = value;
    } else if (value) {
      this.computedIdentifierPreview = computeIdentifier(value);
    } else {
      this.computedIdentifierPreview = "";
    }
  }
  toggleFullScreen() {
    this.isFullScreen = !this.isFullScreen;
    const dialogElement = document.querySelector(".mat-mdc-dialog-surface");
    if (this.isFullScreen) {
      dialogElement?.setAttribute("style", `
                  border-radius: 0 !important;
                `);
      this.dialogRef.updateSize("100%", "100%");
    } else {
      this.dialogRef.updateSize("1350px", "680px");
      dialogElement?.removeAttribute("style");
    }
  }
  add() {
    if (this.form.valid) {
      const formValue = this.form.value;
      const rawData = JSON.stringify(formValue.data);
      const model = {
        appId: this.data.appId,
        identifierId: this.data.identifierId,
        computedIdentifier: this.computedIdentifierPreview,
        class: {
          namespace: formValue.classNamespace,
          name: formValue.className,
          fullName: formValue.classFullName
        },
        data: rawData,
        storeInSeparateFile: formValue.storeInSeparateFile,
        ignoreOnFileChange: formValue.ignoreOnFileChange,
        registrationMode: formValue.registrationMode
      };
      const subscription = this.settingsService.createSetting({
        body: model
      }).subscribe((response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        const addAppSettingComponentReturnModel = {
          id: responseData.settingId,
          version: "0",
          classId: responseData.classId,
          computedIdentifier: this.computedIdentifierPreview,
          className: model.class.name,
          classNamespace: model.class.namespace,
          classFullName: model.class.fullName,
          rawData,
          parsedData: __spreadValues({}, formValue.data),
          storeInSeparateFile: model.storeInSeparateFile,
          ignoreOnFileChange: model.ignoreOnFileChange,
          registrationMode: model.registrationMode
        };
        this.snackBar.open(`Added successfully!`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.dialogRef.close(addAppSettingComponentReturnModel);
      });
      this.subscriptions.add(subscription);
    }
  }
  download() {
    const data = this.form.get("data")?.value;
    const value = JSON.stringify(data, null, 4);
    this.utilityService.download(value, this.form.get("className")?.value ?? this.data.clientName);
  }
  upload(event) {
    this.utilityService.upload(event.target.files[0]).then((content) => {
      const parsedData = JSON.parse(content);
      if (typeof parsedData === "object" && parsedData !== null) {
        this.form.get("data")?.setValue(parsedData);
      } else {
        throw "Invalid JSON data";
      }
      this.snackBar.open(`Changes applied. Click Save icon to confirm.`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 5e3
      });
    }).catch((error) => {
      this.snackBar.open(`Error occurred while uploading file. Error: ${error}`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 8e3
      });
    });
  }
  copyToClipboard(input) {
    let value = input ?? "{}";
    if (typeof input === "object") {
      value = JSON.stringify(input, null, 4);
    }
    this.utilityService.copyToClipboard(value);
  }
  invalidData($event) {
    this.jsonInvalid = $event;
  }
};
_SettingCreateComponent.\u0275fac = function SettingCreateComponent_Factory(t) {
  return new (t || _SettingCreateComponent)(\u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MAT_DIALOG_DATA), \u0275\u0275directiveInject(SettingsService), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(ThemeService));
};
_SettingCreateComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _SettingCreateComponent, selectors: [["ng-component"]], viewQuery: function SettingCreateComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c09, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.textareas = _t);
  }
}, decls: 59, vars: 10, consts: [["fileInput", ""], [1, "d-flex", "border-bottom"], [1, "dialog-title"], [1, "dialog-subtitle"], [1, "spacer"], ["mat-icon-button", "", "matTooltipPosition", "above", 3, "click", "matTooltip"], ["mat-icon-button", "", "mat-dialog-close", "", "matToolTip", "Close", "matTooltipPosition", "above"], [3, "ngSubmit", "formGroup"], ["appearance", "fill"], ["matInput", "", "formControlName", "classNamespace"], ["matInput", "", "formControlName", "className"], ["matInput", "", "formControlName", "classFullName"], [1, "d-flex"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "The computer identifier is either provided directly as a GUID or is computed based on the class name (or other string identifier) using an MD5 hash of the UTF-8 bytes of the string. This allows each setting class to have a unique identifier.", 1, "icon-mini"], ["matInput", "", "formControlName", "computedIdentifier"], ["matInput", "", "disabled", "", 3, "value"], ["type", "button", "matSuffix", "", "mat-icon-button", "", "matTooltip", "Copy", "matTooltipPosition", "below", 3, "disabled", "click", 4, "ngIf"], ["multi", ""], ["expanded", ""], ["type", "button", "mat-button", "", "matTooltip", "Download", "color", "primary", 3, "click"], ["type", "button", "mat-button", "", "matTooltip", "Upload", "color", "primary", 3, "click"], ["type", "file", "accept", ".json,.txt", 1, "d-none", 3, "change"], ["type", "button", "mat-button", "", "matTooltip", "Copy", "color", "primary", 3, "click", 4, "ngIf"], ["formControlName", "data", 3, "invalidData", "theme"], ["mat-raised-button", "", "color", "primary", 1, "ml-3", 3, "disabled"], ["type", "button", "matSuffix", "", "mat-icon-button", "", "matTooltip", "Copy", "matTooltipPosition", "below", 3, "click", "disabled"], ["type", "button", "mat-button", "", "matTooltip", "Copy", "color", "primary", 3, "click"]], template: function SettingCreateComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 1)(1, "div", 2);
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "div", 3);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd();
    \u0275\u0275element(5, "span")(6, "span", 4);
    \u0275\u0275elementStart(7, "button", 5);
    \u0275\u0275listener("click", function SettingCreateComponent_Template_button_click_7_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.toggleFullScreen());
    });
    \u0275\u0275elementStart(8, "mat-icon");
    \u0275\u0275text(9);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(10, "button", 6)(11, "mat-icon");
    \u0275\u0275text(12, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(13, "form", 7);
    \u0275\u0275listener("ngSubmit", function SettingCreateComponent_Template_form_ngSubmit_13_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.add());
    });
    \u0275\u0275elementStart(14, "mat-dialog-content")(15, "mat-form-field", 8)(16, "mat-label");
    \u0275\u0275text(17, "Class Namespace");
    \u0275\u0275elementEnd();
    \u0275\u0275element(18, "input", 9);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(19, "mat-form-field", 8)(20, "mat-label");
    \u0275\u0275text(21, "Class Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(22, "input", 10);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(23, "mat-form-field", 8)(24, "mat-label");
    \u0275\u0275text(25, "Class Full Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(26, "input", 11);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(27, "div", 12)(28, "mat-form-field", 8)(29, "mat-label");
    \u0275\u0275text(30, "Computed Identifier ");
    \u0275\u0275element(31, "mat-icon", 13);
    \u0275\u0275elementEnd();
    \u0275\u0275element(32, "input", 14);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(33, "mat-form-field", 8)(34, "mat-label");
    \u0275\u0275text(35, "Computed Identifier Preview");
    \u0275\u0275elementEnd();
    \u0275\u0275element(36, "input", 15);
    \u0275\u0275template(37, SettingCreateComponent_button_37_Template, 3, 1, "button", 16);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(38, "mat-accordion", 17)(39, "mat-expansion-panel", 18)(40, "mat-expansion-panel-header")(41, "mat-panel-title");
    \u0275\u0275text(42, "Data (Json)");
    \u0275\u0275elementEnd();
    \u0275\u0275element(43, "mat-panel-description");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(44, "div", 12);
    \u0275\u0275element(45, "span", 4);
    \u0275\u0275elementStart(46, "button", 19);
    \u0275\u0275listener("click", function SettingCreateComponent_Template_button_click_46_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.download());
    });
    \u0275\u0275elementStart(47, "mat-icon");
    \u0275\u0275text(48, "download");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(49, "button", 20);
    \u0275\u0275listener("click", function SettingCreateComponent_Template_button_click_49_listener() {
      \u0275\u0275restoreView(_r1);
      const fileInput_r4 = \u0275\u0275reference(53);
      return \u0275\u0275resetView(fileInput_r4.click());
    });
    \u0275\u0275elementStart(50, "mat-icon");
    \u0275\u0275text(51, "upload");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(52, "input", 21, 0);
    \u0275\u0275listener("change", function SettingCreateComponent_Template_input_change_52_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.upload($event));
    });
    \u0275\u0275elementEnd()();
    \u0275\u0275template(54, SettingCreateComponent_button_54_Template, 3, 0, "button", 22);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(55, "json-editor", 23);
    \u0275\u0275listener("invalidData", function SettingCreateComponent_Template_json_editor_invalidData_55_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.invalidData($event));
    });
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(56, "mat-dialog-actions")(57, "button", 24);
    \u0275\u0275text(58, " Add ");
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1("Create > ", ctx.data.clientName, "");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.data.identifierName);
    \u0275\u0275advance(3);
    \u0275\u0275property("matTooltip", ctx.isFullScreen ? "Exit full screen" : "Enter full screen");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.isFullScreen ? "fullscreen_exit" : "fullscreen");
    \u0275\u0275advance(4);
    \u0275\u0275property("formGroup", ctx.form);
    \u0275\u0275advance(23);
    \u0275\u0275property("value", ctx.computedIdentifierPreview);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isConnectionSecure);
    \u0275\u0275advance(17);
    \u0275\u0275property("ngIf", ctx.isConnectionSecure);
    \u0275\u0275advance();
    \u0275\u0275property("theme", ctx.theme);
    \u0275\u0275advance(2);
    \u0275\u0275property("disabled", ctx.form.invalid || ctx.jsonInvalid);
  }
}, dependencies: [NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, JsonEditorComponent, FormGroupDirective, FormControlName, MatIcon, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatExpansionPanelDescription, MatFormField, MatLabel, MatSuffix, MatButton, MatIconButton, MatTooltip, MatInput, MatDialogClose, MatDialogActions, MatDialogContent], encapsulation: 2 });
var SettingCreateComponent = _SettingCreateComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(SettingCreateComponent, { className: "SettingCreateComponent", filePath: "src\\app\\features\\setting\\components\\setting-create\\setting-create.component.ts", lineNumber: 18 });
})();

// src/app/features/setting-history/services/setting-histories.service.ts
var _SettingHistoriesService = class _SettingHistoriesService {
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
  getSettingHistoryData(request) {
    const url = this.route + "/v1/setting-histories/" + request.historyId + "/data";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getSettingHistoryById(request) {
    const url = this.route + "/v1/setting-histories/" + request.historyIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getSettingHistoryBySlug(request) {
    const url = this.route + "/v1/setting-histories/slug/" + request.historyIdOrSlug;
    return this.httpClient.get(url, { headers: this.headers });
  }
  getSettingHistories(request) {
    const url = this.route + "/v1/settings/" + request.settingId + "/histories";
    return this.httpClient.get(url, { headers: this.headers });
  }
  restoreSettingHistory(request) {
    const url = this.route + "/v1/setting-histories/" + request.historyId + "/restore";
    return this.httpClient.post(url, request.body, { headers: this.headers });
  }
};
_SettingHistoriesService.\u0275fac = function SettingHistoriesService_Factory(t) {
  return new (t || _SettingHistoriesService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_SettingHistoriesService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _SettingHistoriesService, factory: _SettingHistoriesService.\u0275fac, providedIn: "root" });
var SettingHistoriesService = _SettingHistoriesService;

// node_modules/@angular/material/fesm2022/checkbox.mjs
var _c010 = ["input"];
var _c15 = ["label"];
var _c22 = ["*"];
var MAT_CHECKBOX_DEFAULT_OPTIONS = new InjectionToken("mat-checkbox-default-options", {
  providedIn: "root",
  factory: MAT_CHECKBOX_DEFAULT_OPTIONS_FACTORY
});
function MAT_CHECKBOX_DEFAULT_OPTIONS_FACTORY() {
  return {
    color: "accent",
    clickAction: "check-indeterminate"
  };
}
var TransitionCheckState;
(function(TransitionCheckState2) {
  TransitionCheckState2[TransitionCheckState2["Init"] = 0] = "Init";
  TransitionCheckState2[TransitionCheckState2["Checked"] = 1] = "Checked";
  TransitionCheckState2[TransitionCheckState2["Unchecked"] = 2] = "Unchecked";
  TransitionCheckState2[TransitionCheckState2["Indeterminate"] = 3] = "Indeterminate";
})(TransitionCheckState || (TransitionCheckState = {}));
var MAT_CHECKBOX_CONTROL_VALUE_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => MatCheckbox),
  multi: true
};
var MatCheckboxChange = class {
};
var nextUniqueId2 = 0;
var defaults = MAT_CHECKBOX_DEFAULT_OPTIONS_FACTORY();
var _MatCheckbox = class _MatCheckbox {
  /** Focuses the checkbox. */
  focus() {
    this._inputElement.nativeElement.focus();
  }
  /** Creates the change event that will be emitted by the checkbox. */
  _createChangeEvent(isChecked) {
    const event = new MatCheckboxChange();
    event.source = this;
    event.checked = isChecked;
    return event;
  }
  /** Gets the element on which to add the animation CSS classes. */
  _getAnimationTargetElement() {
    return this._inputElement?.nativeElement;
  }
  /** Returns the unique id for the visual hidden input. */
  get inputId() {
    return `${this.id || this._uniqueId}-input`;
  }
  constructor(_elementRef, _changeDetectorRef, _ngZone, tabIndex, _animationMode, _options) {
    this._elementRef = _elementRef;
    this._changeDetectorRef = _changeDetectorRef;
    this._ngZone = _ngZone;
    this._animationMode = _animationMode;
    this._options = _options;
    this._animationClasses = {
      uncheckedToChecked: "mdc-checkbox--anim-unchecked-checked",
      uncheckedToIndeterminate: "mdc-checkbox--anim-unchecked-indeterminate",
      checkedToUnchecked: "mdc-checkbox--anim-checked-unchecked",
      checkedToIndeterminate: "mdc-checkbox--anim-checked-indeterminate",
      indeterminateToChecked: "mdc-checkbox--anim-indeterminate-checked",
      indeterminateToUnchecked: "mdc-checkbox--anim-indeterminate-unchecked"
    };
    this.ariaLabel = "";
    this.ariaLabelledby = null;
    this.labelPosition = "after";
    this.name = null;
    this.change = new EventEmitter();
    this.indeterminateChange = new EventEmitter();
    this._onTouched = () => {
    };
    this._currentAnimationClass = "";
    this._currentCheckState = TransitionCheckState.Init;
    this._controlValueAccessorChangeFn = () => {
    };
    this._validatorChangeFn = () => {
    };
    this._checked = false;
    this._disabled = false;
    this._indeterminate = false;
    this._options = this._options || defaults;
    this.color = this._options.color || defaults.color;
    this.tabIndex = parseInt(tabIndex) || 0;
    this.id = this._uniqueId = `mat-mdc-checkbox-${++nextUniqueId2}`;
  }
  ngOnChanges(changes) {
    if (changes["required"]) {
      this._validatorChangeFn();
    }
  }
  ngAfterViewInit() {
    this._syncIndeterminate(this._indeterminate);
  }
  /** Whether the checkbox is checked. */
  get checked() {
    return this._checked;
  }
  set checked(value) {
    if (value != this.checked) {
      this._checked = value;
      this._changeDetectorRef.markForCheck();
    }
  }
  /** Whether the checkbox is disabled. */
  get disabled() {
    return this._disabled;
  }
  set disabled(value) {
    if (value !== this.disabled) {
      this._disabled = value;
      this._changeDetectorRef.markForCheck();
    }
  }
  /**
   * Whether the checkbox is indeterminate. This is also known as "mixed" mode and can be used to
   * represent a checkbox with three states, e.g. a checkbox that represents a nested list of
   * checkable items. Note that whenever checkbox is manually clicked, indeterminate is immediately
   * set to false.
   */
  get indeterminate() {
    return this._indeterminate;
  }
  set indeterminate(value) {
    const changed = value != this._indeterminate;
    this._indeterminate = value;
    if (changed) {
      if (this._indeterminate) {
        this._transitionCheckState(TransitionCheckState.Indeterminate);
      } else {
        this._transitionCheckState(this.checked ? TransitionCheckState.Checked : TransitionCheckState.Unchecked);
      }
      this.indeterminateChange.emit(this._indeterminate);
    }
    this._syncIndeterminate(this._indeterminate);
  }
  _isRippleDisabled() {
    return this.disableRipple || this.disabled;
  }
  /** Method being called whenever the label text changes. */
  _onLabelTextChange() {
    this._changeDetectorRef.detectChanges();
  }
  // Implemented as part of ControlValueAccessor.
  writeValue(value) {
    this.checked = !!value;
  }
  // Implemented as part of ControlValueAccessor.
  registerOnChange(fn) {
    this._controlValueAccessorChangeFn = fn;
  }
  // Implemented as part of ControlValueAccessor.
  registerOnTouched(fn) {
    this._onTouched = fn;
  }
  // Implemented as part of ControlValueAccessor.
  setDisabledState(isDisabled) {
    this.disabled = isDisabled;
  }
  // Implemented as a part of Validator.
  validate(control) {
    return this.required && control.value !== true ? {
      "required": true
    } : null;
  }
  // Implemented as a part of Validator.
  registerOnValidatorChange(fn) {
    this._validatorChangeFn = fn;
  }
  _transitionCheckState(newState) {
    let oldState = this._currentCheckState;
    let element = this._getAnimationTargetElement();
    if (oldState === newState || !element) {
      return;
    }
    if (this._currentAnimationClass) {
      element.classList.remove(this._currentAnimationClass);
    }
    this._currentAnimationClass = this._getAnimationClassForCheckStateTransition(oldState, newState);
    this._currentCheckState = newState;
    if (this._currentAnimationClass.length > 0) {
      element.classList.add(this._currentAnimationClass);
      const animationClass = this._currentAnimationClass;
      this._ngZone.runOutsideAngular(() => {
        setTimeout(() => {
          element.classList.remove(animationClass);
        }, 1e3);
      });
    }
  }
  _emitChangeEvent() {
    this._controlValueAccessorChangeFn(this.checked);
    this.change.emit(this._createChangeEvent(this.checked));
    if (this._inputElement) {
      this._inputElement.nativeElement.checked = this.checked;
    }
  }
  /** Toggles the `checked` state of the checkbox. */
  toggle() {
    this.checked = !this.checked;
    this._controlValueAccessorChangeFn(this.checked);
  }
  _handleInputClick() {
    const clickAction = this._options?.clickAction;
    if (!this.disabled && clickAction !== "noop") {
      if (this.indeterminate && clickAction !== "check") {
        Promise.resolve().then(() => {
          this._indeterminate = false;
          this.indeterminateChange.emit(this._indeterminate);
        });
      }
      this._checked = !this._checked;
      this._transitionCheckState(this._checked ? TransitionCheckState.Checked : TransitionCheckState.Unchecked);
      this._emitChangeEvent();
    } else if (!this.disabled && clickAction === "noop") {
      this._inputElement.nativeElement.checked = this.checked;
      this._inputElement.nativeElement.indeterminate = this.indeterminate;
    }
  }
  _onInteractionEvent(event) {
    event.stopPropagation();
  }
  _onBlur() {
    Promise.resolve().then(() => {
      this._onTouched();
      this._changeDetectorRef.markForCheck();
    });
  }
  _getAnimationClassForCheckStateTransition(oldState, newState) {
    if (this._animationMode === "NoopAnimations") {
      return "";
    }
    switch (oldState) {
      case TransitionCheckState.Init:
        if (newState === TransitionCheckState.Checked) {
          return this._animationClasses.uncheckedToChecked;
        } else if (newState == TransitionCheckState.Indeterminate) {
          return this._checked ? this._animationClasses.checkedToIndeterminate : this._animationClasses.uncheckedToIndeterminate;
        }
        break;
      case TransitionCheckState.Unchecked:
        return newState === TransitionCheckState.Checked ? this._animationClasses.uncheckedToChecked : this._animationClasses.uncheckedToIndeterminate;
      case TransitionCheckState.Checked:
        return newState === TransitionCheckState.Unchecked ? this._animationClasses.checkedToUnchecked : this._animationClasses.checkedToIndeterminate;
      case TransitionCheckState.Indeterminate:
        return newState === TransitionCheckState.Checked ? this._animationClasses.indeterminateToChecked : this._animationClasses.indeterminateToUnchecked;
    }
    return "";
  }
  /**
   * Syncs the indeterminate value with the checkbox DOM node.
   *
   * We sync `indeterminate` directly on the DOM node, because in Ivy the check for whether a
   * property is supported on an element boils down to `if (propName in element)`. Domino's
   * HTMLInputElement doesn't have an `indeterminate` property so Ivy will warn during
   * server-side rendering.
   */
  _syncIndeterminate(value) {
    const nativeCheckbox = this._inputElement;
    if (nativeCheckbox) {
      nativeCheckbox.nativeElement.indeterminate = value;
    }
  }
  _onInputClick() {
    this._handleInputClick();
  }
  _onTouchTargetClick() {
    this._handleInputClick();
    if (!this.disabled) {
      this._inputElement.nativeElement.focus();
    }
  }
  /**
   *  Prevent click events that come from the `<label/>` element from bubbling. This prevents the
   *  click handler on the host from triggering twice when clicking on the `<label/>` element. After
   *  the click event on the `<label/>` propagates, the browsers dispatches click on the associated
   *  `<input/>`. By preventing clicks on the label by bubbling, we ensure only one click event
   *  bubbles when the label is clicked.
   */
  _preventBubblingFromLabel(event) {
    if (!!event.target && this._labelElement.nativeElement.contains(event.target)) {
      event.stopPropagation();
    }
  }
};
_MatCheckbox.\u0275fac = function MatCheckbox_Factory(t) {
  return new (t || _MatCheckbox)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(NgZone), \u0275\u0275injectAttribute("tabindex"), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8), \u0275\u0275directiveInject(MAT_CHECKBOX_DEFAULT_OPTIONS, 8));
};
_MatCheckbox.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatCheckbox,
  selectors: [["mat-checkbox"]],
  viewQuery: function MatCheckbox_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(_c010, 5);
      \u0275\u0275viewQuery(_c15, 5);
      \u0275\u0275viewQuery(MatRipple, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._inputElement = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._labelElement = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.ripple = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-checkbox"],
  hostVars: 14,
  hostBindings: function MatCheckbox_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275hostProperty("id", ctx.id);
      \u0275\u0275attribute("tabindex", null)("aria-label", null)("aria-labelledby", null);
      \u0275\u0275classMap(ctx.color ? "mat-" + ctx.color : "mat-accent");
      \u0275\u0275classProp("_mat-animation-noopable", ctx._animationMode === "NoopAnimations")("mdc-checkbox--disabled", ctx.disabled)("mat-mdc-checkbox-disabled", ctx.disabled)("mat-mdc-checkbox-checked", ctx.checked);
    }
  },
  inputs: {
    ariaLabel: [InputFlags.None, "aria-label", "ariaLabel"],
    ariaLabelledby: [InputFlags.None, "aria-labelledby", "ariaLabelledby"],
    ariaDescribedby: [InputFlags.None, "aria-describedby", "ariaDescribedby"],
    id: "id",
    required: [InputFlags.HasDecoratorInputTransform, "required", "required", booleanAttribute],
    labelPosition: "labelPosition",
    name: "name",
    value: "value",
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    tabIndex: [InputFlags.HasDecoratorInputTransform, "tabIndex", "tabIndex", (value) => value == null ? void 0 : numberAttribute(value)],
    color: "color",
    checked: [InputFlags.HasDecoratorInputTransform, "checked", "checked", booleanAttribute],
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    indeterminate: [InputFlags.HasDecoratorInputTransform, "indeterminate", "indeterminate", booleanAttribute]
  },
  outputs: {
    change: "change",
    indeterminateChange: "indeterminateChange"
  },
  exportAs: ["matCheckbox"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([MAT_CHECKBOX_CONTROL_VALUE_ACCESSOR, {
    provide: NG_VALIDATORS,
    useExisting: _MatCheckbox,
    multi: true
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275NgOnChangesFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c22,
  decls: 15,
  vars: 19,
  consts: [["checkbox", ""], ["input", ""], ["label", ""], ["mat-internal-form-field", "", 3, "click", "labelPosition"], [1, "mdc-checkbox"], [1, "mat-mdc-checkbox-touch-target", 3, "click"], ["type", "checkbox", 1, "mdc-checkbox__native-control", 3, "blur", "click", "change", "checked", "indeterminate", "disabled", "id", "required", "tabIndex"], [1, "mdc-checkbox__ripple"], [1, "mdc-checkbox__background"], ["focusable", "false", "viewBox", "0 0 24 24", "aria-hidden", "true", 1, "mdc-checkbox__checkmark"], ["fill", "none", "d", "M1.73,12.91 8.1,19.28 22.79,4.59", 1, "mdc-checkbox__checkmark-path"], [1, "mdc-checkbox__mixedmark"], ["mat-ripple", "", 1, "mat-mdc-checkbox-ripple", "mat-mdc-focus-indicator", 3, "matRippleTrigger", "matRippleDisabled", "matRippleCentered"], [1, "mdc-label", 3, "for"]],
  template: function MatCheckbox_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = \u0275\u0275getCurrentView();
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "div", 3);
      \u0275\u0275listener("click", function MatCheckbox_Template_div_click_0_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._preventBubblingFromLabel($event));
      });
      \u0275\u0275elementStart(1, "div", 4, 0)(3, "div", 5);
      \u0275\u0275listener("click", function MatCheckbox_Template_div_click_3_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onTouchTargetClick());
      });
      \u0275\u0275elementEnd();
      \u0275\u0275elementStart(4, "input", 6, 1);
      \u0275\u0275listener("blur", function MatCheckbox_Template_input_blur_4_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onBlur());
      })("click", function MatCheckbox_Template_input_click_4_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onInputClick());
      })("change", function MatCheckbox_Template_input_change_4_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onInteractionEvent($event));
      });
      \u0275\u0275elementEnd();
      \u0275\u0275element(6, "div", 7);
      \u0275\u0275elementStart(7, "div", 8);
      \u0275\u0275namespaceSVG();
      \u0275\u0275elementStart(8, "svg", 9);
      \u0275\u0275element(9, "path", 10);
      \u0275\u0275elementEnd();
      \u0275\u0275namespaceHTML();
      \u0275\u0275element(10, "div", 11);
      \u0275\u0275elementEnd();
      \u0275\u0275element(11, "div", 12);
      \u0275\u0275elementEnd();
      \u0275\u0275elementStart(12, "label", 13, 2);
      \u0275\u0275projection(14);
      \u0275\u0275elementEnd()();
    }
    if (rf & 2) {
      const checkbox_r2 = \u0275\u0275reference(2);
      \u0275\u0275property("labelPosition", ctx.labelPosition);
      \u0275\u0275advance(4);
      \u0275\u0275classProp("mdc-checkbox--selected", ctx.checked);
      \u0275\u0275property("checked", ctx.checked)("indeterminate", ctx.indeterminate)("disabled", ctx.disabled)("id", ctx.inputId)("required", ctx.required)("tabIndex", ctx.disabled ? -1 : ctx.tabIndex);
      \u0275\u0275attribute("aria-label", ctx.ariaLabel || null)("aria-labelledby", ctx.ariaLabelledby)("aria-describedby", ctx.ariaDescribedby)("aria-checked", ctx.indeterminate ? "mixed" : null)("name", ctx.name)("value", ctx.value);
      \u0275\u0275advance(7);
      \u0275\u0275property("matRippleTrigger", checkbox_r2)("matRippleDisabled", ctx.disableRipple || ctx.disabled)("matRippleCentered", true);
      \u0275\u0275advance();
      \u0275\u0275property("for", ctx.inputId);
    }
  },
  dependencies: [MatRipple, _MatInternalFormField],
  styles: ['.mdc-touch-target-wrapper{display:inline}@keyframes mdc-checkbox-unchecked-checked-checkmark-path{0%,50%{stroke-dashoffset:29.7833385}50%{animation-timing-function:cubic-bezier(0, 0, 0.2, 1)}100%{stroke-dashoffset:0}}@keyframes mdc-checkbox-unchecked-indeterminate-mixedmark{0%,68.2%{transform:scaleX(0)}68.2%{animation-timing-function:cubic-bezier(0, 0, 0, 1)}100%{transform:scaleX(1)}}@keyframes mdc-checkbox-checked-unchecked-checkmark-path{from{animation-timing-function:cubic-bezier(0.4, 0, 1, 1);opacity:1;stroke-dashoffset:0}to{opacity:0;stroke-dashoffset:-29.7833385}}@keyframes mdc-checkbox-checked-indeterminate-checkmark{from{animation-timing-function:cubic-bezier(0, 0, 0.2, 1);transform:rotate(0deg);opacity:1}to{transform:rotate(45deg);opacity:0}}@keyframes mdc-checkbox-indeterminate-checked-checkmark{from{animation-timing-function:cubic-bezier(0.14, 0, 0, 1);transform:rotate(45deg);opacity:0}to{transform:rotate(360deg);opacity:1}}@keyframes mdc-checkbox-checked-indeterminate-mixedmark{from{animation-timing-function:mdc-animation-deceleration-curve-timing-function;transform:rotate(-45deg);opacity:0}to{transform:rotate(0deg);opacity:1}}@keyframes mdc-checkbox-indeterminate-checked-mixedmark{from{animation-timing-function:cubic-bezier(0.14, 0, 0, 1);transform:rotate(0deg);opacity:1}to{transform:rotate(315deg);opacity:0}}@keyframes mdc-checkbox-indeterminate-unchecked-mixedmark{0%{animation-timing-function:linear;transform:scaleX(1);opacity:1}32.8%,100%{transform:scaleX(0);opacity:0}}.mdc-checkbox{display:inline-block;position:relative;flex:0 0 18px;box-sizing:content-box;width:18px;height:18px;line-height:0;white-space:nowrap;cursor:pointer;vertical-align:bottom}.mdc-checkbox[hidden]{display:none}.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring{pointer-events:none;border:2px solid rgba(0,0,0,0);border-radius:6px;box-sizing:content-box;position:absolute;top:50%;left:50%;transform:translate(-50%, -50%);height:100%;width:100%}@media screen and (forced-colors: active){.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring{border-color:CanvasText}}.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring::after,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring::after{content:"";border:2px solid rgba(0,0,0,0);border-radius:8px;display:block;position:absolute;top:50%;left:50%;transform:translate(-50%, -50%);height:calc(100% + 4px);width:calc(100% + 4px)}@media screen and (forced-colors: active){.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring::after,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring::after{border-color:CanvasText}}@media all and (-ms-high-contrast: none){.mdc-checkbox .mdc-checkbox__focus-ring{display:none}}@media screen and (forced-colors: active),(-ms-high-contrast: active){.mdc-checkbox__mixedmark{margin:0 1px}}.mdc-checkbox--disabled{cursor:default;pointer-events:none}.mdc-checkbox__background{display:inline-flex;position:absolute;align-items:center;justify-content:center;box-sizing:border-box;width:18px;height:18px;border:2px solid currentColor;border-radius:2px;background-color:rgba(0,0,0,0);pointer-events:none;will-change:background-color,border-color;transition:background-color 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1),border-color 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox__checkmark{position:absolute;top:0;right:0;bottom:0;left:0;width:100%;opacity:0;transition:opacity 180ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox--upgraded .mdc-checkbox__checkmark{opacity:1}.mdc-checkbox__checkmark-path{transition:stroke-dashoffset 180ms 0ms cubic-bezier(0.4, 0, 0.6, 1);stroke:currentColor;stroke-width:3.12px;stroke-dashoffset:29.7833385;stroke-dasharray:29.7833385}.mdc-checkbox__mixedmark{width:100%;height:0;transform:scaleX(0) rotate(0deg);border-width:1px;border-style:solid;opacity:0;transition:opacity 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1),transform 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__background,.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__background,.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__background,.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__background{animation-duration:180ms;animation-timing-function:linear}.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__checkmark-path{animation:mdc-checkbox-unchecked-checked-checkmark-path 180ms linear 0s;transition:none}.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__mixedmark{animation:mdc-checkbox-unchecked-indeterminate-mixedmark 90ms linear 0s;transition:none}.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__checkmark-path{animation:mdc-checkbox-checked-unchecked-checkmark-path 90ms linear 0s;transition:none}.mdc-checkbox--anim-checked-indeterminate .mdc-checkbox__checkmark{animation:mdc-checkbox-checked-indeterminate-checkmark 90ms linear 0s;transition:none}.mdc-checkbox--anim-checked-indeterminate .mdc-checkbox__mixedmark{animation:mdc-checkbox-checked-indeterminate-mixedmark 90ms linear 0s;transition:none}.mdc-checkbox--anim-indeterminate-checked .mdc-checkbox__checkmark{animation:mdc-checkbox-indeterminate-checked-checkmark 500ms linear 0s;transition:none}.mdc-checkbox--anim-indeterminate-checked .mdc-checkbox__mixedmark{animation:mdc-checkbox-indeterminate-checked-mixedmark 500ms linear 0s;transition:none}.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__mixedmark{animation:mdc-checkbox-indeterminate-unchecked-mixedmark 300ms linear 0s;transition:none}.mdc-checkbox__native-control:checked~.mdc-checkbox__background,.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background{transition:border-color 90ms 0ms cubic-bezier(0, 0, 0.2, 1),background-color 90ms 0ms cubic-bezier(0, 0, 0.2, 1)}.mdc-checkbox__native-control:checked~.mdc-checkbox__background .mdc-checkbox__checkmark-path,.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background .mdc-checkbox__checkmark-path,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background .mdc-checkbox__checkmark-path{stroke-dashoffset:0}.mdc-checkbox__native-control{position:absolute;margin:0;padding:0;opacity:0;cursor:inherit}.mdc-checkbox__native-control:disabled{cursor:default;pointer-events:none}.mdc-checkbox--touch{margin:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2)}.mdc-checkbox--touch .mdc-checkbox__native-control{top:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);right:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);left:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);width:var(--mdc-checkbox-state-layer-size);height:var(--mdc-checkbox-state-layer-size)}.mdc-checkbox__native-control:checked~.mdc-checkbox__background .mdc-checkbox__checkmark{transition:opacity 180ms 0ms cubic-bezier(0, 0, 0.2, 1),transform 180ms 0ms cubic-bezier(0, 0, 0.2, 1);opacity:1}.mdc-checkbox__native-control:checked~.mdc-checkbox__background .mdc-checkbox__mixedmark{transform:scaleX(1) rotate(-45deg)}.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background .mdc-checkbox__checkmark,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background .mdc-checkbox__checkmark{transform:rotate(45deg);opacity:0;transition:opacity 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1),transform 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background .mdc-checkbox__mixedmark,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background .mdc-checkbox__mixedmark{transform:scaleX(1) rotate(0deg);opacity:1}.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__background,.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__checkmark,.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__checkmark-path,.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__mixedmark{transition:none}.mdc-checkbox{padding:calc((var(--mdc-checkbox-state-layer-size) - 18px) / 2);margin:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2)}.mdc-checkbox .mdc-checkbox__native-control[disabled]:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-disabled-unselected-icon-color);background-color:transparent}.mdc-checkbox .mdc-checkbox__native-control[disabled]:checked~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control[disabled]:indeterminate~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control[data-indeterminate=true][disabled]~.mdc-checkbox__background{border-color:transparent;background-color:var(--mdc-checkbox-disabled-selected-icon-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled~.mdc-checkbox__background .mdc-checkbox__checkmark{color:var(--mdc-checkbox-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled~.mdc-checkbox__background .mdc-checkbox__mixedmark{border-color:var(--mdc-checkbox-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:disabled~.mdc-checkbox__background .mdc-checkbox__checkmark{color:var(--mdc-checkbox-disabled-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:disabled~.mdc-checkbox__background .mdc-checkbox__mixedmark{border-color:var(--mdc-checkbox-disabled-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-icon-color);background-color:transparent}.mdc-checkbox .mdc-checkbox__native-control:enabled:checked~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control:enabled:indeterminate~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control[data-indeterminate=true]:enabled~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-icon-color);background-color:var(--mdc-checkbox-selected-icon-color)}@keyframes mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336{0%{border-color:var(--mdc-checkbox-unselected-icon-color);background-color:transparent}50%{border-color:var(--mdc-checkbox-selected-icon-color);background-color:var(--mdc-checkbox-selected-icon-color)}}@keyframes mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336{0%,80%{border-color:var(--mdc-checkbox-selected-icon-color);background-color:var(--mdc-checkbox-selected-icon-color)}100%{border-color:var(--mdc-checkbox-unselected-icon-color);background-color:transparent}}.mdc-checkbox.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox:hover .mdc-checkbox__native-control:enabled:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-hover-icon-color);background-color:transparent}.mdc-checkbox:hover .mdc-checkbox__native-control:enabled:checked~.mdc-checkbox__background,.mdc-checkbox:hover .mdc-checkbox__native-control:enabled:indeterminate~.mdc-checkbox__background,.mdc-checkbox:hover .mdc-checkbox__native-control[data-indeterminate=true]:enabled~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-hover-icon-color);background-color:var(--mdc-checkbox-selected-hover-icon-color)}@keyframes mdc-checkbox-fade-in-background-FF212121FFF4433600000000FFF44336{0%{border-color:var(--mdc-checkbox-unselected-hover-icon-color);background-color:transparent}50%{border-color:var(--mdc-checkbox-selected-hover-icon-color);background-color:var(--mdc-checkbox-selected-hover-icon-color)}}@keyframes mdc-checkbox-fade-out-background-FF212121FFF4433600000000FFF44336{0%,80%{border-color:var(--mdc-checkbox-selected-hover-icon-color);background-color:var(--mdc-checkbox-selected-hover-icon-color)}100%{border-color:var(--mdc-checkbox-unselected-hover-icon-color);background-color:transparent}}.mdc-checkbox:hover.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:hover.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-in-background-FF212121FFF4433600000000FFF44336}.mdc-checkbox:hover.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:hover.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-out-background-FF212121FFF4433600000000FFF44336}.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control:enabled:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-pressed-icon-color);background-color:transparent}.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control:enabled:checked~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control:enabled:indeterminate~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control[data-indeterminate=true]:enabled~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-pressed-icon-color);background-color:var(--mdc-checkbox-selected-pressed-icon-color)}@keyframes mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336{0%{border-color:var(--mdc-checkbox-unselected-pressed-icon-color);background-color:transparent}50%{border-color:var(--mdc-checkbox-selected-pressed-icon-color);background-color:var(--mdc-checkbox-selected-pressed-icon-color)}}@keyframes mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336{0%,80%{border-color:var(--mdc-checkbox-selected-pressed-icon-color);background-color:var(--mdc-checkbox-selected-pressed-icon-color)}100%{border-color:var(--mdc-checkbox-unselected-pressed-icon-color);background-color:transparent}}.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox .mdc-checkbox__background{top:calc((var(--mdc-checkbox-state-layer-size) - 18px) / 2);left:calc((var(--mdc-checkbox-state-layer-size) - 18px) / 2)}.mdc-checkbox .mdc-checkbox__native-control{top:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);right:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);left:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);width:var(--mdc-checkbox-state-layer-size);height:var(--mdc-checkbox-state-layer-size)}.mdc-checkbox .mdc-checkbox__native-control:enabled:focus:focus:not(:checked):not(:indeterminate)~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-focus-icon-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled:focus:checked~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control:enabled:focus:indeterminate~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-focus-icon-color);background-color:var(--mdc-checkbox-selected-focus-icon-color)}.mdc-checkbox:hover .mdc-checkbox__ripple{opacity:var(--mdc-checkbox-unselected-hover-state-layer-opacity);background-color:var(--mdc-checkbox-unselected-hover-state-layer-color)}.mdc-checkbox:hover .mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-unselected-hover-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-unselected-focus-state-layer-opacity);background-color:var(--mdc-checkbox-unselected-focus-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-unselected-focus-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-unselected-pressed-state-layer-opacity);background-color:var(--mdc-checkbox-unselected-pressed-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-unselected-pressed-state-layer-color)}.mdc-checkbox:hover .mdc-checkbox__native-control:checked~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-selected-hover-state-layer-opacity);background-color:var(--mdc-checkbox-selected-hover-state-layer-color)}.mdc-checkbox:hover .mdc-checkbox__native-control:checked~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-selected-hover-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus:checked~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-selected-focus-state-layer-opacity);background-color:var(--mdc-checkbox-selected-focus-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus:checked~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-selected-focus-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control:checked~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-selected-pressed-state-layer-opacity);background-color:var(--mdc-checkbox-selected-pressed-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control:checked~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-selected-pressed-state-layer-color)}.mat-mdc-checkbox{display:inline-block;position:relative;-webkit-tap-highlight-color:rgba(0,0,0,0)}.mat-mdc-checkbox .mdc-checkbox__background{-webkit-print-color-adjust:exact;color-adjust:exact}.mat-mdc-checkbox._mat-animation-noopable *,.mat-mdc-checkbox._mat-animation-noopable *::before{transition:none !important;animation:none !important}.mat-mdc-checkbox label{cursor:pointer}.mat-mdc-checkbox.mat-mdc-checkbox-disabled label{cursor:default;color:var(--mat-checkbox-disabled-label-color)}.mat-mdc-checkbox label:empty{display:none}.cdk-high-contrast-active .mat-mdc-checkbox.mat-mdc-checkbox-disabled{opacity:.5}.cdk-high-contrast-active .mat-mdc-checkbox .mdc-checkbox__checkmark{--mdc-checkbox-selected-checkmark-color: CanvasText;--mdc-checkbox-disabled-selected-checkmark-color: CanvasText}.mat-mdc-checkbox .mdc-checkbox__ripple{opacity:0}.mat-mdc-checkbox-ripple,.mdc-checkbox__ripple{top:0;left:0;right:0;bottom:0;position:absolute;border-radius:50%;pointer-events:none}.mat-mdc-checkbox-ripple:not(:empty),.mdc-checkbox__ripple:not(:empty){transform:translateZ(0)}.mat-mdc-checkbox-ripple .mat-ripple-element{opacity:.1}.mat-mdc-checkbox-touch-target{position:absolute;top:50%;height:48px;left:50%;width:48px;transform:translate(-50%, -50%);display:var(--mat-checkbox-touch-target-display)}.mat-mdc-checkbox-ripple::before{border-radius:50%}.mdc-checkbox__native-control:focus~.mat-mdc-focus-indicator::before{content:""}'],
  encapsulation: 2,
  changeDetection: 0
});
var MatCheckbox = _MatCheckbox;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatCheckbox, [{
    type: Component,
    args: [{
      selector: "mat-checkbox",
      host: {
        "class": "mat-mdc-checkbox",
        "[attr.tabindex]": "null",
        "[attr.aria-label]": "null",
        "[attr.aria-labelledby]": "null",
        "[class._mat-animation-noopable]": `_animationMode === 'NoopAnimations'`,
        "[class.mdc-checkbox--disabled]": "disabled",
        "[id]": "id",
        // Add classes that users can use to more easily target disabled or checked checkboxes.
        "[class.mat-mdc-checkbox-disabled]": "disabled",
        "[class.mat-mdc-checkbox-checked]": "checked",
        "[class]": 'color ? "mat-" + color : "mat-accent"'
      },
      providers: [MAT_CHECKBOX_CONTROL_VALUE_ACCESSOR, {
        provide: NG_VALIDATORS,
        useExisting: MatCheckbox,
        multi: true
      }],
      exportAs: "matCheckbox",
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true,
      imports: [MatRipple, _MatInternalFormField],
      template: `<div mat-internal-form-field [labelPosition]="labelPosition" (click)="_preventBubblingFromLabel($event)">
  <div #checkbox class="mdc-checkbox">
    <!-- Render this element first so the input is on top. -->
    <div class="mat-mdc-checkbox-touch-target" (click)="_onTouchTargetClick()"></div>
    <input #input
           type="checkbox"
           class="mdc-checkbox__native-control"
           [class.mdc-checkbox--selected]="checked"
           [attr.aria-label]="ariaLabel || null"
           [attr.aria-labelledby]="ariaLabelledby"
           [attr.aria-describedby]="ariaDescribedby"
           [attr.aria-checked]="indeterminate ? 'mixed' : null"
           [attr.name]="name"
           [attr.value]="value"
           [checked]="checked"
           [indeterminate]="indeterminate"
           [disabled]="disabled"
           [id]="inputId"
           [required]="required"
           [tabIndex]="disabled ? -1 : tabIndex"
           (blur)="_onBlur()"
           (click)="_onInputClick()"
           (change)="_onInteractionEvent($event)"/>
    <div class="mdc-checkbox__ripple"></div>
    <div class="mdc-checkbox__background">
      <svg class="mdc-checkbox__checkmark"
           focusable="false"
           viewBox="0 0 24 24"
           aria-hidden="true">
        <path class="mdc-checkbox__checkmark-path"
              fill="none"
              d="M1.73,12.91 8.1,19.28 22.79,4.59"/>
      </svg>
      <div class="mdc-checkbox__mixedmark"></div>
    </div>
    <div class="mat-mdc-checkbox-ripple mat-mdc-focus-indicator" mat-ripple
      [matRippleTrigger]="checkbox"
      [matRippleDisabled]="disableRipple || disabled"
      [matRippleCentered]="true"></div>
  </div>
  <!--
    Avoid putting a click handler on the <label/> to fix duplicate navigation stop on Talk Back
    (#14385). Putting a click handler on the <label/> caused this bug because the browser produced
    an unnecessary accessibility tree node.
  -->
  <label class="mdc-label"
         #label
         [for]="inputId">
    <ng-content></ng-content>
  </label>
</div>
`,
      styles: ['.mdc-touch-target-wrapper{display:inline}@keyframes mdc-checkbox-unchecked-checked-checkmark-path{0%,50%{stroke-dashoffset:29.7833385}50%{animation-timing-function:cubic-bezier(0, 0, 0.2, 1)}100%{stroke-dashoffset:0}}@keyframes mdc-checkbox-unchecked-indeterminate-mixedmark{0%,68.2%{transform:scaleX(0)}68.2%{animation-timing-function:cubic-bezier(0, 0, 0, 1)}100%{transform:scaleX(1)}}@keyframes mdc-checkbox-checked-unchecked-checkmark-path{from{animation-timing-function:cubic-bezier(0.4, 0, 1, 1);opacity:1;stroke-dashoffset:0}to{opacity:0;stroke-dashoffset:-29.7833385}}@keyframes mdc-checkbox-checked-indeterminate-checkmark{from{animation-timing-function:cubic-bezier(0, 0, 0.2, 1);transform:rotate(0deg);opacity:1}to{transform:rotate(45deg);opacity:0}}@keyframes mdc-checkbox-indeterminate-checked-checkmark{from{animation-timing-function:cubic-bezier(0.14, 0, 0, 1);transform:rotate(45deg);opacity:0}to{transform:rotate(360deg);opacity:1}}@keyframes mdc-checkbox-checked-indeterminate-mixedmark{from{animation-timing-function:mdc-animation-deceleration-curve-timing-function;transform:rotate(-45deg);opacity:0}to{transform:rotate(0deg);opacity:1}}@keyframes mdc-checkbox-indeterminate-checked-mixedmark{from{animation-timing-function:cubic-bezier(0.14, 0, 0, 1);transform:rotate(0deg);opacity:1}to{transform:rotate(315deg);opacity:0}}@keyframes mdc-checkbox-indeterminate-unchecked-mixedmark{0%{animation-timing-function:linear;transform:scaleX(1);opacity:1}32.8%,100%{transform:scaleX(0);opacity:0}}.mdc-checkbox{display:inline-block;position:relative;flex:0 0 18px;box-sizing:content-box;width:18px;height:18px;line-height:0;white-space:nowrap;cursor:pointer;vertical-align:bottom}.mdc-checkbox[hidden]{display:none}.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring{pointer-events:none;border:2px solid rgba(0,0,0,0);border-radius:6px;box-sizing:content-box;position:absolute;top:50%;left:50%;transform:translate(-50%, -50%);height:100%;width:100%}@media screen and (forced-colors: active){.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring{border-color:CanvasText}}.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring::after,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring::after{content:"";border:2px solid rgba(0,0,0,0);border-radius:8px;display:block;position:absolute;top:50%;left:50%;transform:translate(-50%, -50%);height:calc(100% + 4px);width:calc(100% + 4px)}@media screen and (forced-colors: active){.mdc-checkbox.mdc-ripple-upgraded--background-focused .mdc-checkbox__focus-ring::after,.mdc-checkbox:not(.mdc-ripple-upgraded):focus .mdc-checkbox__focus-ring::after{border-color:CanvasText}}@media all and (-ms-high-contrast: none){.mdc-checkbox .mdc-checkbox__focus-ring{display:none}}@media screen and (forced-colors: active),(-ms-high-contrast: active){.mdc-checkbox__mixedmark{margin:0 1px}}.mdc-checkbox--disabled{cursor:default;pointer-events:none}.mdc-checkbox__background{display:inline-flex;position:absolute;align-items:center;justify-content:center;box-sizing:border-box;width:18px;height:18px;border:2px solid currentColor;border-radius:2px;background-color:rgba(0,0,0,0);pointer-events:none;will-change:background-color,border-color;transition:background-color 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1),border-color 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox__checkmark{position:absolute;top:0;right:0;bottom:0;left:0;width:100%;opacity:0;transition:opacity 180ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox--upgraded .mdc-checkbox__checkmark{opacity:1}.mdc-checkbox__checkmark-path{transition:stroke-dashoffset 180ms 0ms cubic-bezier(0.4, 0, 0.6, 1);stroke:currentColor;stroke-width:3.12px;stroke-dashoffset:29.7833385;stroke-dasharray:29.7833385}.mdc-checkbox__mixedmark{width:100%;height:0;transform:scaleX(0) rotate(0deg);border-width:1px;border-style:solid;opacity:0;transition:opacity 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1),transform 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__background,.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__background,.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__background,.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__background{animation-duration:180ms;animation-timing-function:linear}.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__checkmark-path{animation:mdc-checkbox-unchecked-checked-checkmark-path 180ms linear 0s;transition:none}.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__mixedmark{animation:mdc-checkbox-unchecked-indeterminate-mixedmark 90ms linear 0s;transition:none}.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__checkmark-path{animation:mdc-checkbox-checked-unchecked-checkmark-path 90ms linear 0s;transition:none}.mdc-checkbox--anim-checked-indeterminate .mdc-checkbox__checkmark{animation:mdc-checkbox-checked-indeterminate-checkmark 90ms linear 0s;transition:none}.mdc-checkbox--anim-checked-indeterminate .mdc-checkbox__mixedmark{animation:mdc-checkbox-checked-indeterminate-mixedmark 90ms linear 0s;transition:none}.mdc-checkbox--anim-indeterminate-checked .mdc-checkbox__checkmark{animation:mdc-checkbox-indeterminate-checked-checkmark 500ms linear 0s;transition:none}.mdc-checkbox--anim-indeterminate-checked .mdc-checkbox__mixedmark{animation:mdc-checkbox-indeterminate-checked-mixedmark 500ms linear 0s;transition:none}.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__mixedmark{animation:mdc-checkbox-indeterminate-unchecked-mixedmark 300ms linear 0s;transition:none}.mdc-checkbox__native-control:checked~.mdc-checkbox__background,.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background{transition:border-color 90ms 0ms cubic-bezier(0, 0, 0.2, 1),background-color 90ms 0ms cubic-bezier(0, 0, 0.2, 1)}.mdc-checkbox__native-control:checked~.mdc-checkbox__background .mdc-checkbox__checkmark-path,.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background .mdc-checkbox__checkmark-path,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background .mdc-checkbox__checkmark-path{stroke-dashoffset:0}.mdc-checkbox__native-control{position:absolute;margin:0;padding:0;opacity:0;cursor:inherit}.mdc-checkbox__native-control:disabled{cursor:default;pointer-events:none}.mdc-checkbox--touch{margin:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2)}.mdc-checkbox--touch .mdc-checkbox__native-control{top:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);right:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);left:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);width:var(--mdc-checkbox-state-layer-size);height:var(--mdc-checkbox-state-layer-size)}.mdc-checkbox__native-control:checked~.mdc-checkbox__background .mdc-checkbox__checkmark{transition:opacity 180ms 0ms cubic-bezier(0, 0, 0.2, 1),transform 180ms 0ms cubic-bezier(0, 0, 0.2, 1);opacity:1}.mdc-checkbox__native-control:checked~.mdc-checkbox__background .mdc-checkbox__mixedmark{transform:scaleX(1) rotate(-45deg)}.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background .mdc-checkbox__checkmark,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background .mdc-checkbox__checkmark{transform:rotate(45deg);opacity:0;transition:opacity 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1),transform 90ms 0ms cubic-bezier(0.4, 0, 0.6, 1)}.mdc-checkbox__native-control:indeterminate~.mdc-checkbox__background .mdc-checkbox__mixedmark,.mdc-checkbox__native-control[data-indeterminate=true]~.mdc-checkbox__background .mdc-checkbox__mixedmark{transform:scaleX(1) rotate(0deg);opacity:1}.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__background,.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__checkmark,.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__checkmark-path,.mdc-checkbox.mdc-checkbox--upgraded .mdc-checkbox__mixedmark{transition:none}.mdc-checkbox{padding:calc((var(--mdc-checkbox-state-layer-size) - 18px) / 2);margin:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2)}.mdc-checkbox .mdc-checkbox__native-control[disabled]:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-disabled-unselected-icon-color);background-color:transparent}.mdc-checkbox .mdc-checkbox__native-control[disabled]:checked~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control[disabled]:indeterminate~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control[data-indeterminate=true][disabled]~.mdc-checkbox__background{border-color:transparent;background-color:var(--mdc-checkbox-disabled-selected-icon-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled~.mdc-checkbox__background .mdc-checkbox__checkmark{color:var(--mdc-checkbox-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled~.mdc-checkbox__background .mdc-checkbox__mixedmark{border-color:var(--mdc-checkbox-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:disabled~.mdc-checkbox__background .mdc-checkbox__checkmark{color:var(--mdc-checkbox-disabled-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:disabled~.mdc-checkbox__background .mdc-checkbox__mixedmark{border-color:var(--mdc-checkbox-disabled-selected-checkmark-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-icon-color);background-color:transparent}.mdc-checkbox .mdc-checkbox__native-control:enabled:checked~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control:enabled:indeterminate~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control[data-indeterminate=true]:enabled~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-icon-color);background-color:var(--mdc-checkbox-selected-icon-color)}@keyframes mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336{0%{border-color:var(--mdc-checkbox-unselected-icon-color);background-color:transparent}50%{border-color:var(--mdc-checkbox-selected-icon-color);background-color:var(--mdc-checkbox-selected-icon-color)}}@keyframes mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336{0%,80%{border-color:var(--mdc-checkbox-selected-icon-color);background-color:var(--mdc-checkbox-selected-icon-color)}100%{border-color:var(--mdc-checkbox-unselected-icon-color);background-color:transparent}}.mdc-checkbox.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox:hover .mdc-checkbox__native-control:enabled:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-hover-icon-color);background-color:transparent}.mdc-checkbox:hover .mdc-checkbox__native-control:enabled:checked~.mdc-checkbox__background,.mdc-checkbox:hover .mdc-checkbox__native-control:enabled:indeterminate~.mdc-checkbox__background,.mdc-checkbox:hover .mdc-checkbox__native-control[data-indeterminate=true]:enabled~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-hover-icon-color);background-color:var(--mdc-checkbox-selected-hover-icon-color)}@keyframes mdc-checkbox-fade-in-background-FF212121FFF4433600000000FFF44336{0%{border-color:var(--mdc-checkbox-unselected-hover-icon-color);background-color:transparent}50%{border-color:var(--mdc-checkbox-selected-hover-icon-color);background-color:var(--mdc-checkbox-selected-hover-icon-color)}}@keyframes mdc-checkbox-fade-out-background-FF212121FFF4433600000000FFF44336{0%,80%{border-color:var(--mdc-checkbox-selected-hover-icon-color);background-color:var(--mdc-checkbox-selected-hover-icon-color)}100%{border-color:var(--mdc-checkbox-unselected-hover-icon-color);background-color:transparent}}.mdc-checkbox:hover.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:hover.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-in-background-FF212121FFF4433600000000FFF44336}.mdc-checkbox:hover.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:hover.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-out-background-FF212121FFF4433600000000FFF44336}.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control:enabled:not(:checked):not(:indeterminate):not([data-indeterminate=true])~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-pressed-icon-color);background-color:transparent}.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control:enabled:checked~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control:enabled:indeterminate~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active .mdc-checkbox__native-control[data-indeterminate=true]:enabled~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-pressed-icon-color);background-color:var(--mdc-checkbox-selected-pressed-icon-color)}@keyframes mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336{0%{border-color:var(--mdc-checkbox-unselected-pressed-icon-color);background-color:transparent}50%{border-color:var(--mdc-checkbox-selected-pressed-icon-color);background-color:var(--mdc-checkbox-selected-pressed-icon-color)}}@keyframes mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336{0%,80%{border-color:var(--mdc-checkbox-selected-pressed-icon-color);background-color:var(--mdc-checkbox-selected-pressed-icon-color)}100%{border-color:var(--mdc-checkbox-unselected-pressed-icon-color);background-color:transparent}}.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-unchecked-checked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-unchecked-indeterminate .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-in-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-checked-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background,.mdc-checkbox:not(:disabled):active.mdc-checkbox--anim-indeterminate-unchecked .mdc-checkbox__native-control:enabled~.mdc-checkbox__background{animation-name:mdc-checkbox-fade-out-background-8A000000FFF4433600000000FFF44336}.mdc-checkbox .mdc-checkbox__background{top:calc((var(--mdc-checkbox-state-layer-size) - 18px) / 2);left:calc((var(--mdc-checkbox-state-layer-size) - 18px) / 2)}.mdc-checkbox .mdc-checkbox__native-control{top:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);right:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);left:calc((var(--mdc-checkbox-state-layer-size) - var(--mdc-checkbox-state-layer-size)) / 2);width:var(--mdc-checkbox-state-layer-size);height:var(--mdc-checkbox-state-layer-size)}.mdc-checkbox .mdc-checkbox__native-control:enabled:focus:focus:not(:checked):not(:indeterminate)~.mdc-checkbox__background{border-color:var(--mdc-checkbox-unselected-focus-icon-color)}.mdc-checkbox .mdc-checkbox__native-control:enabled:focus:checked~.mdc-checkbox__background,.mdc-checkbox .mdc-checkbox__native-control:enabled:focus:indeterminate~.mdc-checkbox__background{border-color:var(--mdc-checkbox-selected-focus-icon-color);background-color:var(--mdc-checkbox-selected-focus-icon-color)}.mdc-checkbox:hover .mdc-checkbox__ripple{opacity:var(--mdc-checkbox-unselected-hover-state-layer-opacity);background-color:var(--mdc-checkbox-unselected-hover-state-layer-color)}.mdc-checkbox:hover .mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-unselected-hover-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-unselected-focus-state-layer-opacity);background-color:var(--mdc-checkbox-unselected-focus-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-unselected-focus-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-unselected-pressed-state-layer-opacity);background-color:var(--mdc-checkbox-unselected-pressed-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-unselected-pressed-state-layer-color)}.mdc-checkbox:hover .mdc-checkbox__native-control:checked~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-selected-hover-state-layer-opacity);background-color:var(--mdc-checkbox-selected-hover-state-layer-color)}.mdc-checkbox:hover .mdc-checkbox__native-control:checked~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-selected-hover-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus:checked~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-selected-focus-state-layer-opacity);background-color:var(--mdc-checkbox-selected-focus-state-layer-color)}.mdc-checkbox .mdc-checkbox__native-control:focus:checked~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-selected-focus-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control:checked~.mdc-checkbox__ripple{opacity:var(--mdc-checkbox-selected-pressed-state-layer-opacity);background-color:var(--mdc-checkbox-selected-pressed-state-layer-color)}.mdc-checkbox:active .mdc-checkbox__native-control:checked~.mat-mdc-checkbox-ripple .mat-ripple-element{background-color:var(--mdc-checkbox-selected-pressed-state-layer-color)}.mat-mdc-checkbox{display:inline-block;position:relative;-webkit-tap-highlight-color:rgba(0,0,0,0)}.mat-mdc-checkbox .mdc-checkbox__background{-webkit-print-color-adjust:exact;color-adjust:exact}.mat-mdc-checkbox._mat-animation-noopable *,.mat-mdc-checkbox._mat-animation-noopable *::before{transition:none !important;animation:none !important}.mat-mdc-checkbox label{cursor:pointer}.mat-mdc-checkbox.mat-mdc-checkbox-disabled label{cursor:default;color:var(--mat-checkbox-disabled-label-color)}.mat-mdc-checkbox label:empty{display:none}.cdk-high-contrast-active .mat-mdc-checkbox.mat-mdc-checkbox-disabled{opacity:.5}.cdk-high-contrast-active .mat-mdc-checkbox .mdc-checkbox__checkmark{--mdc-checkbox-selected-checkmark-color: CanvasText;--mdc-checkbox-disabled-selected-checkmark-color: CanvasText}.mat-mdc-checkbox .mdc-checkbox__ripple{opacity:0}.mat-mdc-checkbox-ripple,.mdc-checkbox__ripple{top:0;left:0;right:0;bottom:0;position:absolute;border-radius:50%;pointer-events:none}.mat-mdc-checkbox-ripple:not(:empty),.mdc-checkbox__ripple:not(:empty){transform:translateZ(0)}.mat-mdc-checkbox-ripple .mat-ripple-element{opacity:.1}.mat-mdc-checkbox-touch-target{position:absolute;top:50%;height:48px;left:50%;width:48px;transform:translate(-50%, -50%);display:var(--mat-checkbox-touch-target-display)}.mat-mdc-checkbox-ripple::before{border-radius:50%}.mdc-checkbox__native-control:focus~.mat-mdc-focus-indicator::before{content:""}']
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: ChangeDetectorRef
  }, {
    type: NgZone
  }, {
    type: void 0,
    decorators: [{
      type: Attribute,
      args: ["tabindex"]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_CHECKBOX_DEFAULT_OPTIONS]
    }]
  }], {
    ariaLabel: [{
      type: Input,
      args: ["aria-label"]
    }],
    ariaLabelledby: [{
      type: Input,
      args: ["aria-labelledby"]
    }],
    ariaDescribedby: [{
      type: Input,
      args: ["aria-describedby"]
    }],
    id: [{
      type: Input
    }],
    required: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    labelPosition: [{
      type: Input
    }],
    name: [{
      type: Input
    }],
    change: [{
      type: Output
    }],
    indeterminateChange: [{
      type: Output
    }],
    value: [{
      type: Input
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    _inputElement: [{
      type: ViewChild,
      args: ["input"]
    }],
    _labelElement: [{
      type: ViewChild,
      args: ["label"]
    }],
    tabIndex: [{
      type: Input,
      args: [{
        transform: (value) => value == null ? void 0 : numberAttribute(value)
      }]
    }],
    color: [{
      type: Input
    }],
    ripple: [{
      type: ViewChild,
      args: [MatRipple]
    }],
    checked: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    indeterminate: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }]
  });
})();
var MAT_CHECKBOX_REQUIRED_VALIDATOR = {
  provide: NG_VALIDATORS,
  useExisting: forwardRef(() => MatCheckboxRequiredValidator),
  multi: true
};
var _MatCheckboxRequiredValidator = class _MatCheckboxRequiredValidator extends CheckboxRequiredValidator {
};
_MatCheckboxRequiredValidator.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatCheckboxRequiredValidator_BaseFactory;
  return function MatCheckboxRequiredValidator_Factory(t) {
    return (\u0275MatCheckboxRequiredValidator_BaseFactory || (\u0275MatCheckboxRequiredValidator_BaseFactory = \u0275\u0275getInheritedFactory(_MatCheckboxRequiredValidator)))(t || _MatCheckboxRequiredValidator);
  };
})();
_MatCheckboxRequiredValidator.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatCheckboxRequiredValidator,
  selectors: [["mat-checkbox", "required", "", "formControlName", ""], ["mat-checkbox", "required", "", "formControl", ""], ["mat-checkbox", "required", "", "ngModel", ""]],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([MAT_CHECKBOX_REQUIRED_VALIDATOR]), \u0275\u0275InheritDefinitionFeature]
});
var MatCheckboxRequiredValidator = _MatCheckboxRequiredValidator;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatCheckboxRequiredValidator, [{
    type: Directive,
    args: [{
      selector: `mat-checkbox[required][formControlName],
             mat-checkbox[required][formControl], mat-checkbox[required][ngModel]`,
      providers: [MAT_CHECKBOX_REQUIRED_VALIDATOR],
      standalone: true
    }]
  }], null, null);
})();
var __MatCheckboxRequiredValidatorModule = class __MatCheckboxRequiredValidatorModule {
};
__MatCheckboxRequiredValidatorModule.\u0275fac = function _MatCheckboxRequiredValidatorModule_Factory(t) {
  return new (t || __MatCheckboxRequiredValidatorModule)();
};
__MatCheckboxRequiredValidatorModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: __MatCheckboxRequiredValidatorModule
});
__MatCheckboxRequiredValidatorModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({});
var _MatCheckboxRequiredValidatorModule = __MatCheckboxRequiredValidatorModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(_MatCheckboxRequiredValidatorModule, [{
    type: NgModule,
    args: [{
      imports: [MatCheckboxRequiredValidator],
      exports: [MatCheckboxRequiredValidator]
    }]
  }], null, null);
})();
var _MatCheckboxModule = class _MatCheckboxModule {
};
_MatCheckboxModule.\u0275fac = function MatCheckboxModule_Factory(t) {
  return new (t || _MatCheckboxModule)();
};
_MatCheckboxModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatCheckboxModule
});
_MatCheckboxModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatCheckbox, MatCommonModule, MatCommonModule]
});
var MatCheckboxModule = _MatCheckboxModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatCheckboxModule, [{
    type: NgModule,
    args: [{
      imports: [MatCheckbox, MatCommonModule],
      exports: [MatCheckbox, MatCommonModule]
    }]
  }], null, null);
})();

// src/app/shared/components/json-diff-editor/json-diff-editor.component.ts
var _c011 = ["diffEditorContainer"];
var _JsonDiffEditorComponent = class _JsonDiffEditorComponent {
  constructor() {
    this.originalData = {};
    this.modifiedData = {};
    this.editorWidth = "100%";
    this.theme = "vs-light";
    this.sideBySide = true;
    this.height = 75;
  }
  ngOnInit() {
    this.initializeEditor();
  }
  ngOnDestroy() {
    if (this.diffEditor) {
      this.diffEditor.dispose();
    }
    if (this.originalModel) {
      this.originalModel.dispose();
    }
    if (this.modifiedModel) {
      this.modifiedModel.dispose();
    }
  }
  ngOnChanges(changes) {
    if (changes["originalData"] || changes["modifiedData"]) {
      this.updateEditorContent();
    }
  }
  get editorHeight() {
    return `${this.height}px`;
  }
  initializeEditor() {
    if (this.diffEditor) {
      return;
    }
    this.diffEditor = monaco.editor.createDiffEditor(this.diffEditorContainer.nativeElement, {
      theme: this.theme,
      automaticLayout: true,
      renderSideBySide: this.sideBySide,
      renderOverviewRuler: true,
      minimap: { enabled: true },
      glyphMargin: false,
      lineNumbers: "on",
      folding: true,
      scrollBeyondLastLine: true,
      renderLineHighlight: "line",
      selectionHighlight: true,
      renderWhitespace: "none",
      links: false,
      contextmenu: false,
      cursorBlinking: "solid",
      smoothScrolling: true,
      wordWrap: "on",
      enableSplitViewResizing: true,
      renderIndicators: false,
      readOnly: true,
      ignoreTrimWhitespace: true,
      hideCursorInOverviewRuler: true,
      renderControlCharacters: false
    });
    this.updateEditorContent();
  }
  updateEditorContent() {
    if (!this.diffEditor) {
      return;
    }
    const originalContent = JSON.stringify(this.originalData, null, 4);
    const modifiedContent = JSON.stringify(this.modifiedData, null, 4);
    this.originalModel = monaco.editor.createModel(originalContent, "json");
    this.modifiedModel = monaco.editor.createModel(modifiedContent, "json");
    this.diffEditor.setModel({
      original: this.originalModel,
      modified: this.modifiedModel
    });
    this.adjustHeight(originalContent.length > modifiedContent.length ? originalContent : modifiedContent);
  }
  adjustHeight(value) {
    const height = this.getContentHeight(value);
    this.height = Math.min(300, height);
  }
  getContentHeight(content) {
    const lineHeight = 19;
    const lineCount = (content.match(/\n/g) || []).length + 1;
    return lineHeight * lineCount;
  }
  toggleSideBySide() {
    this.sideBySide = !this.sideBySide;
    if (!this.diffEditor) {
      return;
    }
    this.diffEditor.updateOptions({
      renderSideBySide: this.sideBySide
    });
  }
};
_JsonDiffEditorComponent.\u0275fac = function JsonDiffEditorComponent_Factory(t) {
  return new (t || _JsonDiffEditorComponent)();
};
_JsonDiffEditorComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _JsonDiffEditorComponent, selectors: [["json-diff-editor"]], viewQuery: function JsonDiffEditorComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c011, 7);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.diffEditorContainer = _t.first);
  }
}, inputs: { originalData: "originalData", modifiedData: "modifiedData", editorWidth: "editorWidth", theme: "theme", sideBySide: "sideBySide" }, features: [\u0275\u0275NgOnChangesFeature], decls: 4, vars: 5, consts: [["diffEditorContainer", ""], [3, "click", "checked"]], template: function JsonDiffEditorComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275element(0, "div", null, 0);
    \u0275\u0275elementStart(2, "mat-checkbox", 1);
    \u0275\u0275listener("click", function JsonDiffEditorComponent_Template_mat_checkbox_click_2_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.toggleSideBySide());
    });
    \u0275\u0275text(3, "Render side by side");
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    \u0275\u0275styleProp("width", ctx.editorWidth)("height", ctx.editorHeight);
    \u0275\u0275advance(2);
    \u0275\u0275property("checked", ctx.sideBySide);
  }
}, dependencies: [MatCheckbox] });
var JsonDiffEditorComponent = _JsonDiffEditorComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(JsonDiffEditorComponent, { className: "JsonDiffEditorComponent", filePath: "src\\app\\shared\\components\\json-diff-editor\\json-diff-editor.component.ts", lineNumber: 9 });
})();

// src/app/features/setting-history/components/setting-history-list/setting-history-list.component.ts
var _c012 = ["versionSelection"];
function SettingHistoryListComponent_mat_option_18_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 11);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const history_r2 = ctx.$implicit;
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275property("value", history_r2.version)("disabled", history_r2.version === ctx_r2.data.currentVersion);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate2("v", history_r2.version, " - ", history_r2.createdOn, "");
  }
}
function SettingHistoryListComponent_ng_container_19_button_9_Template(rf, ctx) {
  if (rf & 1) {
    const _r5 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 21);
    \u0275\u0275listener("click", function SettingHistoryListComponent_ng_container_19_button_9_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r5);
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.copyToClipboard());
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
}
function SettingHistoryListComponent_ng_container_19_div_11_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 22)(1, "div", 23);
    \u0275\u0275element(2, "img", 24);
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "div", 25);
    \u0275\u0275elementEnd();
  }
}
function SettingHistoryListComponent_ng_container_19_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementContainerStart(0);
    \u0275\u0275elementStart(1, "div", 12)(2, "button", 13);
    \u0275\u0275listener("click", function SettingHistoryListComponent_ng_container_19_Template_button_click_2_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.restore());
    });
    \u0275\u0275elementStart(3, "mat-icon", 14);
    \u0275\u0275text(4, "restore");
    \u0275\u0275elementEnd()();
    \u0275\u0275element(5, "span", 4);
    \u0275\u0275elementStart(6, "button", 15);
    \u0275\u0275listener("click", function SettingHistoryListComponent_ng_container_19_Template_button_click_6_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.download());
    });
    \u0275\u0275elementStart(7, "mat-icon");
    \u0275\u0275text(8, "download");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(9, SettingHistoryListComponent_ng_container_19_button_9_Template, 3, 0, "button", 16);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(10, "mat-accordion");
    \u0275\u0275template(11, SettingHistoryListComponent_ng_container_19_div_11_Template, 4, 0, "div", 17);
    \u0275\u0275elementStart(12, "mat-expansion-panel", 18)(13, "mat-expansion-panel-header")(14, "mat-panel-title");
    \u0275\u0275text(15, "View Data");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(16, "json-editor", 19);
    \u0275\u0275twoWayListener("ngModelChange", function SettingHistoryListComponent_ng_container_19_Template_json_editor_ngModelChange_16_listener($event) {
      \u0275\u0275restoreView(_r4);
      const ctx_r2 = \u0275\u0275nextContext();
      \u0275\u0275twoWayBindingSet(ctx_r2.selectedData.parsedData, $event) || (ctx_r2.selectedData.parsedData = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(17, "mat-expansion-panel")(18, "mat-expansion-panel-header")(19, "mat-panel-title");
    \u0275\u0275text(20, "Compare Data");
    \u0275\u0275elementEnd()();
    \u0275\u0275element(21, "json-diff-editor", 20);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementContainerEnd();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275advance(2);
    \u0275\u0275property("disabled", !ctx_r2.isRestoreButtonEnabled);
    \u0275\u0275advance(7);
    \u0275\u0275property("ngIf", ctx_r2.isConnectionSecure);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx_r2.selectedVersionToLoading[ctx_r2.selectedVersion]);
    \u0275\u0275advance();
    \u0275\u0275property("expanded", true);
    \u0275\u0275advance(4);
    \u0275\u0275property("readonly", true);
    \u0275\u0275twoWayProperty("ngModel", ctx_r2.selectedData.parsedData);
    \u0275\u0275property("theme", ctx_r2.theme);
    \u0275\u0275advance(5);
    \u0275\u0275property("modifiedData", ctx_r2.selectedData.parsedData)("originalData", ctx_r2.data.currentParsedData)("sideBySide", true)("theme", ctx_r2.theme);
  }
}
var _SettingHistoryListComponent = class _SettingHistoryListComponent {
  constructor(dialog, dialogRef, data, settingHistoriesService, utilityService, windowService, snackBar, themeService) {
    this.dialog = dialog;
    this.dialogRef = dialogRef;
    this.data = data;
    this.settingHistoriesService = settingHistoriesService;
    this.utilityService = utilityService;
    this.windowService = windowService;
    this.snackBar = snackBar;
    this.themeService = themeService;
    this.model = [];
    this.versionToHistoryDictionary = {};
    this.isFullScreen = false;
    this.selectedVersionToLoading = {};
    this.subscriptions = new Subscription();
    this.selectedVersion = "";
    this.selectedData = { rawData: "", parsedData: {} };
    this.isSelected = false;
    this.isRestoreButtonEnabled = true;
    this.isCompareClicked = false;
    this.theme = this.themeService.isDarkTheme() ? "vs-dark" : "vs-light";
    this.isConnectionSecure = this.windowService.isConnectionSecure;
  }
  ngAfterViewInit() {
    setTimeout(() => {
      this.versionSelection.open();
    }, 150);
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  onVersionSelected() {
    this.isRestoreButtonEnabled = true;
    this.isSelected = true;
    const historyData = this.versionToHistoryDictionary[this.selectedVersion];
    if (historyData !== void 0) {
      this.selectedData = { rawData: historyData.rawData, parsedData: historyData.parsedData };
      this.selectedVersionToLoading[this.selectedVersion] = false;
      return;
    }
    this.selectedVersionToLoading[this.selectedVersion] = true;
    const history = this.data.model.find((m) => m.version === this.selectedVersion);
    if (!history) {
      return;
    }
    const subscription = this.settingHistoriesService.getSettingHistoryData({
      historyId: history.id
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        const rawData = responseData.data;
        const parsedData = JSON.parse(responseData.data);
        this.versionToHistoryDictionary[this.selectedVersion] = { historyId: history.id, rawData, parsedData, rowVersion: history.rowVersion };
        this.selectedData = { rawData, parsedData };
        this.selectedVersionToLoading[this.selectedVersion] = false;
      },
      error: (errr) => {
        this.selectedVersionToLoading[this.selectedVersion] = false;
      }
    });
    this.subscriptions.add(subscription);
  }
  copyToClipboard() {
    const value = JSON.stringify(this.selectedData.parsedData, null, 4);
    this.utilityService.copyToClipboard(value);
  }
  download() {
    const value = JSON.stringify(this.selectedData.parsedData, null, 4);
    this.utilityService.download(value, this.data.className);
  }
  restore() {
    const historyData = this.versionToHistoryDictionary[this.selectedVersion];
    this.isRestoreButtonEnabled = false;
    const restoreSettingHistoryRequestBody = {
      settingRowVersion: this.data.rowVersion,
      historyRowVersion: historyData.rowVersion
    };
    let model;
    const subscription = this.settingHistoriesService.restoreSettingHistory({
      historyId: historyData.historyId,
      body: restoreSettingHistoryRequestBody
    }).subscribe({
      next: (response) => {
        if (response.data) {
          this.snackBar.open(`Setting restored!`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 1500
          });
          this.dialogRef.close({
            fetchLatest: true
          });
        }
      },
      error: (err) => {
        const error = err.error;
        if (error.errors) {
          if (error.status === 409) {
            const availableReturnTypes = ["Discard", "Fetch Latest"];
            const conflictResolverDialogComponent = this.dialog.open(ConflictResolverDialogComponent, {
              width: "400px",
              data: availableReturnTypes,
              autoFocus: false
            }).afterClosed().subscribe((type) => {
              if (type === "Fetch Latest") {
                model = {
                  rawData: "",
                  parsedData: {},
                  version: "",
                  settingRowVersion: "",
                  fetchLatest: true
                };
                this.dialogRef.close(model);
              }
            });
            this.subscriptions.add(conflictResolverDialogComponent);
          } else if (error.errors.find((e) => e.traces == "HistoryAlreadyRestored")) {
            model = {
              rawData: "",
              parsedData: {},
              version: "",
              settingRowVersion: "",
              fetchLatest: true
            };
            this.dialogRef.close(model);
          }
        }
        this.isRestoreButtonEnabled = true;
      }
    });
    this.subscriptions.add(subscription);
  }
  toggleFullScreen() {
    this.isFullScreen = !this.isFullScreen;
    const dialogElement = document.querySelector(".mat-mdc-dialog-surface");
    if (this.isFullScreen) {
      dialogElement?.setAttribute("style", `
                  border-radius: 0 !important;
                `);
      this.dialogRef.updateSize("100%", "100%");
    } else {
      this.dialogRef.updateSize("1350px", "680px");
      dialogElement?.removeAttribute("style");
    }
  }
};
_SettingHistoryListComponent.\u0275fac = function SettingHistoryListComponent_Factory(t) {
  return new (t || _SettingHistoryListComponent)(\u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MAT_DIALOG_DATA), \u0275\u0275directiveInject(SettingHistoriesService), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(ThemeService));
};
_SettingHistoryListComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _SettingHistoryListComponent, selectors: [["ng-component"]], viewQuery: function SettingHistoryListComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c012, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.versionSelection = _t.first);
  }
}, decls: 20, vars: 8, consts: [["versionSelection", ""], [1, "d-flex", "border-bottom"], [1, "dialog-title"], [1, "dialog-subtitle"], [1, "spacer"], ["mat-icon-button", "", "matTooltipPosition", "above", 3, "click", "matTooltip"], ["mat-icon-button", "", "mat-dialog-close", "", "matTooltip", "Close", "matTooltipPosition", "above"], [1, "custom-form-field"], [3, "ngModelChange", "selectionChange", "ngModel"], [3, "value", "disabled", 4, "ngFor", "ngForOf"], [4, "ngIf"], [3, "value", "disabled"], [1, "d-flex"], ["mat-button", "", "matTooltip", "Restore", "color", "primary", 3, "click", "disabled"], ["iconPositionEnd", ""], ["mat-button", "", "matTooltip", "Download", "color", "primary", 3, "click"], ["mat-button", "", "matTooltip", "Copy", "color", "primary", 3, "click", 4, "ngIf"], ["class", "loading-container", 4, "ngIf"], [3, "expanded"], [3, "ngModelChange", "readonly", "ngModel", "theme"], [3, "modifiedData", "originalData", "sideBySide", "theme"], ["mat-button", "", "matTooltip", "Copy", "color", "primary", 3, "click"], [1, "loading-container"], [1, "mat-bg-primary", "position-absolute", "rounded-circle", "app-icon-animation"], [1, "app-icon", "bg-white"], [1, "loading-spinner"]], template: function SettingHistoryListComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 1)(1, "div", 2);
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "div", 3);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd();
    \u0275\u0275element(5, "span")(6, "span", 4);
    \u0275\u0275elementStart(7, "button", 5);
    \u0275\u0275listener("click", function SettingHistoryListComponent_Template_button_click_7_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.toggleFullScreen());
    });
    \u0275\u0275elementStart(8, "mat-icon");
    \u0275\u0275text(9);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(10, "button", 6)(11, "mat-icon");
    \u0275\u0275text(12, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(13, "mat-form-field", 7)(14, "mat-label");
    \u0275\u0275text(15, "Version");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(16, "mat-select", 8, 0);
    \u0275\u0275twoWayListener("ngModelChange", function SettingHistoryListComponent_Template_mat_select_ngModelChange_16_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.selectedVersion, $event) || (ctx.selectedVersion = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275listener("selectionChange", function SettingHistoryListComponent_Template_mat_select_selectionChange_16_listener() {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onVersionSelected());
    });
    \u0275\u0275template(18, SettingHistoryListComponent_mat_option_18_Template, 2, 4, "mat-option", 9);
    \u0275\u0275elementEnd()();
    \u0275\u0275template(19, SettingHistoryListComponent_ng_container_19_Template, 22, 11, "ng-container", 10);
  }
  if (rf & 2) {
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1("Histories > ", ctx.data.clientName, "");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate2("", ctx.data.identifierName, " - ", ctx.data.className, "");
    \u0275\u0275advance(3);
    \u0275\u0275property("matTooltip", ctx.isFullScreen ? "Exit full screen" : "Enter full screen");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.isFullScreen ? "fullscreen_exit" : "fullscreen");
    \u0275\u0275advance(7);
    \u0275\u0275twoWayProperty("ngModel", ctx.selectedVersion);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngForOf", ctx.data.model);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isSelected);
  }
}, dependencies: [NgForOf, NgIf, NgControlStatus, NgModel, JsonEditorComponent, JsonDiffEditorComponent, MatIcon, MatTooltip, MatFormField, MatLabel, MatSelect, MatOption, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatButton, MatIconButton, MatDialogClose] });
var SettingHistoryListComponent = _SettingHistoryListComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(SettingHistoryListComponent, { className: "SettingHistoryListComponent", filePath: "src\\app\\features\\setting-history\\components\\setting-history-list\\setting-history-list.component.ts", lineNumber: 39 });
})();

// node_modules/@angular/material/fesm2022/slide-toggle.mjs
var _c013 = ["switch"];
var _c16 = ["*"];
function MatSlideToggle_Conditional_10_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 10);
    \u0275\u0275namespaceSVG();
    \u0275\u0275elementStart(1, "svg", 12);
    \u0275\u0275element(2, "path", 13);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "svg", 14);
    \u0275\u0275element(4, "path", 15);
    \u0275\u0275elementEnd()();
  }
}
var MAT_SLIDE_TOGGLE_DEFAULT_OPTIONS = new InjectionToken("mat-slide-toggle-default-options", {
  providedIn: "root",
  factory: () => ({
    disableToggleValue: false,
    hideIcon: false
  })
});
var MAT_SLIDE_TOGGLE_VALUE_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => MatSlideToggle),
  multi: true
};
var MatSlideToggleChange = class {
  constructor(source, checked) {
    this.source = source;
    this.checked = checked;
  }
};
var nextUniqueId3 = 0;
var _MatSlideToggle = class _MatSlideToggle {
  _createChangeEvent(isChecked) {
    return new MatSlideToggleChange(this, isChecked);
  }
  /** Returns the unique id for the visual hidden button. */
  get buttonId() {
    return `${this.id || this._uniqueId}-button`;
  }
  /** Focuses the slide-toggle. */
  focus() {
    this._switchElement.nativeElement.focus();
  }
  /** Whether the slide-toggle element is checked or not. */
  get checked() {
    return this._checked;
  }
  set checked(value) {
    this._checked = value;
    this._changeDetectorRef.markForCheck();
  }
  /** Returns the unique id for the visual hidden input. */
  get inputId() {
    return `${this.id || this._uniqueId}-input`;
  }
  constructor(_elementRef, _focusMonitor, _changeDetectorRef, tabIndex, defaults2, animationMode) {
    this._elementRef = _elementRef;
    this._focusMonitor = _focusMonitor;
    this._changeDetectorRef = _changeDetectorRef;
    this.defaults = defaults2;
    this._onChange = (_) => {
    };
    this._onTouched = () => {
    };
    this._validatorOnChange = () => {
    };
    this._checked = false;
    this.name = null;
    this.labelPosition = "after";
    this.ariaLabel = null;
    this.ariaLabelledby = null;
    this.disabled = false;
    this.disableRipple = false;
    this.tabIndex = 0;
    this.change = new EventEmitter();
    this.toggleChange = new EventEmitter();
    this.tabIndex = parseInt(tabIndex) || 0;
    this.color = defaults2.color || "accent";
    this._noopAnimations = animationMode === "NoopAnimations";
    this.id = this._uniqueId = `mat-mdc-slide-toggle-${++nextUniqueId3}`;
    this.hideIcon = defaults2.hideIcon ?? false;
    this._labelId = this._uniqueId + "-label";
  }
  ngAfterContentInit() {
    this._focusMonitor.monitor(this._elementRef, true).subscribe((focusOrigin) => {
      if (focusOrigin === "keyboard" || focusOrigin === "program") {
        this._focused = true;
        this._changeDetectorRef.markForCheck();
      } else if (!focusOrigin) {
        Promise.resolve().then(() => {
          this._focused = false;
          this._onTouched();
          this._changeDetectorRef.markForCheck();
        });
      }
    });
  }
  ngOnChanges(changes) {
    if (changes["required"]) {
      this._validatorOnChange();
    }
  }
  ngOnDestroy() {
    this._focusMonitor.stopMonitoring(this._elementRef);
  }
  /** Implemented as part of ControlValueAccessor. */
  writeValue(value) {
    this.checked = !!value;
  }
  /** Implemented as part of ControlValueAccessor. */
  registerOnChange(fn) {
    this._onChange = fn;
  }
  /** Implemented as part of ControlValueAccessor. */
  registerOnTouched(fn) {
    this._onTouched = fn;
  }
  /** Implemented as a part of Validator. */
  validate(control) {
    return this.required && control.value !== true ? {
      "required": true
    } : null;
  }
  /** Implemented as a part of Validator. */
  registerOnValidatorChange(fn) {
    this._validatorOnChange = fn;
  }
  /** Implemented as a part of ControlValueAccessor. */
  setDisabledState(isDisabled) {
    this.disabled = isDisabled;
    this._changeDetectorRef.markForCheck();
  }
  /** Toggles the checked state of the slide-toggle. */
  toggle() {
    this.checked = !this.checked;
    this._onChange(this.checked);
  }
  /**
   * Emits a change event on the `change` output. Also notifies the FormControl about the change.
   */
  _emitChangeEvent() {
    this._onChange(this.checked);
    this.change.emit(this._createChangeEvent(this.checked));
  }
  /** Method being called whenever the underlying button is clicked. */
  _handleClick() {
    this.toggleChange.emit();
    if (!this.defaults.disableToggleValue) {
      this.checked = !this.checked;
      this._onChange(this.checked);
      this.change.emit(new MatSlideToggleChange(this, this.checked));
    }
  }
  _getAriaLabelledBy() {
    if (this.ariaLabelledby) {
      return this.ariaLabelledby;
    }
    return this.ariaLabel ? null : this._labelId;
  }
};
_MatSlideToggle.\u0275fac = function MatSlideToggle_Factory(t) {
  return new (t || _MatSlideToggle)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(FocusMonitor), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275injectAttribute("tabindex"), \u0275\u0275directiveInject(MAT_SLIDE_TOGGLE_DEFAULT_OPTIONS), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8));
};
_MatSlideToggle.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatSlideToggle,
  selectors: [["mat-slide-toggle"]],
  viewQuery: function MatSlideToggle_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(_c013, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._switchElement = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-slide-toggle"],
  hostVars: 13,
  hostBindings: function MatSlideToggle_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275hostProperty("id", ctx.id);
      \u0275\u0275attribute("tabindex", null)("aria-label", null)("name", null)("aria-labelledby", null);
      \u0275\u0275classMap(ctx.color ? "mat-" + ctx.color : "");
      \u0275\u0275classProp("mat-mdc-slide-toggle-focused", ctx._focused)("mat-mdc-slide-toggle-checked", ctx.checked)("_mat-animation-noopable", ctx._noopAnimations);
    }
  },
  inputs: {
    name: "name",
    id: "id",
    labelPosition: "labelPosition",
    ariaLabel: [InputFlags.None, "aria-label", "ariaLabel"],
    ariaLabelledby: [InputFlags.None, "aria-labelledby", "ariaLabelledby"],
    ariaDescribedby: [InputFlags.None, "aria-describedby", "ariaDescribedby"],
    required: [InputFlags.HasDecoratorInputTransform, "required", "required", booleanAttribute],
    color: "color",
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    tabIndex: [InputFlags.HasDecoratorInputTransform, "tabIndex", "tabIndex", (value) => value == null ? 0 : numberAttribute(value)],
    checked: [InputFlags.HasDecoratorInputTransform, "checked", "checked", booleanAttribute],
    hideIcon: [InputFlags.HasDecoratorInputTransform, "hideIcon", "hideIcon", booleanAttribute]
  },
  outputs: {
    change: "change",
    toggleChange: "toggleChange"
  },
  exportAs: ["matSlideToggle"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([MAT_SLIDE_TOGGLE_VALUE_ACCESSOR, {
    provide: NG_VALIDATORS,
    useExisting: _MatSlideToggle,
    multi: true
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275NgOnChangesFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c16,
  decls: 13,
  vars: 24,
  consts: [["switch", ""], ["mat-internal-form-field", "", 3, "labelPosition"], ["role", "switch", "type", "button", 1, "mdc-switch", 3, "click", "tabIndex", "disabled"], [1, "mdc-switch__track"], [1, "mdc-switch__handle-track"], [1, "mdc-switch__handle"], [1, "mdc-switch__shadow"], [1, "mdc-elevation-overlay"], [1, "mdc-switch__ripple"], ["mat-ripple", "", 1, "mat-mdc-slide-toggle-ripple", "mat-mdc-focus-indicator", 3, "matRippleTrigger", "matRippleDisabled", "matRippleCentered"], [1, "mdc-switch__icons"], [1, "mdc-label", 3, "click", "for"], ["viewBox", "0 0 24 24", "aria-hidden", "true", 1, "mdc-switch__icon", "mdc-switch__icon--on"], ["d", "M19.69,5.23L8.96,15.96l-4.23-4.23L2.96,13.5l6,6L21.46,7L19.69,5.23z"], ["viewBox", "0 0 24 24", "aria-hidden", "true", 1, "mdc-switch__icon", "mdc-switch__icon--off"], ["d", "M20 13H4v-2h16v2z"]],
  template: function MatSlideToggle_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = \u0275\u0275getCurrentView();
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "div", 1)(1, "button", 2, 0);
      \u0275\u0275listener("click", function MatSlideToggle_Template_button_click_1_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handleClick());
      });
      \u0275\u0275element(3, "div", 3);
      \u0275\u0275elementStart(4, "div", 4)(5, "div", 5)(6, "div", 6);
      \u0275\u0275element(7, "div", 7);
      \u0275\u0275elementEnd();
      \u0275\u0275elementStart(8, "div", 8);
      \u0275\u0275element(9, "div", 9);
      \u0275\u0275elementEnd();
      \u0275\u0275template(10, MatSlideToggle_Conditional_10_Template, 5, 0, "div", 10);
      \u0275\u0275elementEnd()()();
      \u0275\u0275elementStart(11, "label", 11);
      \u0275\u0275listener("click", function MatSlideToggle_Template_label_click_11_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView($event.stopPropagation());
      });
      \u0275\u0275projection(12);
      \u0275\u0275elementEnd()();
    }
    if (rf & 2) {
      const switch_r2 = \u0275\u0275reference(2);
      \u0275\u0275property("labelPosition", ctx.labelPosition);
      \u0275\u0275advance();
      \u0275\u0275classProp("mdc-switch--selected", ctx.checked)("mdc-switch--unselected", !ctx.checked)("mdc-switch--checked", ctx.checked)("mdc-switch--disabled", ctx.disabled);
      \u0275\u0275property("tabIndex", ctx.disabled ? -1 : ctx.tabIndex)("disabled", ctx.disabled);
      \u0275\u0275attribute("id", ctx.buttonId)("name", ctx.name)("aria-label", ctx.ariaLabel)("aria-labelledby", ctx._getAriaLabelledBy())("aria-describedby", ctx.ariaDescribedby)("aria-required", ctx.required || null)("aria-checked", ctx.checked);
      \u0275\u0275advance(8);
      \u0275\u0275property("matRippleTrigger", switch_r2)("matRippleDisabled", ctx.disableRipple || ctx.disabled)("matRippleCentered", true);
      \u0275\u0275advance();
      \u0275\u0275conditional(10, !ctx.hideIcon ? 10 : -1);
      \u0275\u0275advance();
      \u0275\u0275property("for", ctx.buttonId);
      \u0275\u0275attribute("id", ctx._labelId);
    }
  },
  dependencies: [MatRipple, _MatInternalFormField],
  styles: ['.mdc-elevation-overlay{position:absolute;border-radius:inherit;pointer-events:none;opacity:var(--mdc-elevation-overlay-opacity);transition:opacity 280ms cubic-bezier(0.4, 0, 0.2, 1);background-color:var(--mdc-elevation-overlay-color)}.mdc-switch{align-items:center;background:none;border:none;cursor:pointer;display:inline-flex;flex-shrink:0;margin:0;outline:none;overflow:visible;padding:0;position:relative}.mdc-switch[hidden]{display:none}.mdc-switch:disabled{cursor:default;pointer-events:none}.mdc-switch__track{overflow:hidden;position:relative;width:100%}.mdc-switch__track::before,.mdc-switch__track::after{border:1px solid rgba(0,0,0,0);border-radius:inherit;box-sizing:border-box;content:"";height:100%;left:0;position:absolute;width:100%}@media screen and (forced-colors: active){.mdc-switch__track::before,.mdc-switch__track::after{border-color:currentColor}}.mdc-switch__track::before{transition:transform 75ms 0ms cubic-bezier(0, 0, 0.2, 1);transform:translateX(0)}.mdc-switch__track::after{transition:transform 75ms 0ms cubic-bezier(0.4, 0, 0.6, 1);transform:translateX(-100%)}[dir=rtl] .mdc-switch__track::after,.mdc-switch__track[dir=rtl]::after{transform:translateX(100%)}.mdc-switch--selected .mdc-switch__track::before{transition:transform 75ms 0ms cubic-bezier(0.4, 0, 0.6, 1);transform:translateX(100%)}[dir=rtl] .mdc-switch--selected .mdc-switch__track::before,.mdc-switch--selected .mdc-switch__track[dir=rtl]::before{transform:translateX(-100%)}.mdc-switch--selected .mdc-switch__track::after{transition:transform 75ms 0ms cubic-bezier(0, 0, 0.2, 1);transform:translateX(0)}.mdc-switch__handle-track{height:100%;pointer-events:none;position:absolute;top:0;transition:transform 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);left:0;right:auto;transform:translateX(0)}[dir=rtl] .mdc-switch__handle-track,.mdc-switch__handle-track[dir=rtl]{left:auto;right:0}.mdc-switch--selected .mdc-switch__handle-track{transform:translateX(100%)}[dir=rtl] .mdc-switch--selected .mdc-switch__handle-track,.mdc-switch--selected .mdc-switch__handle-track[dir=rtl]{transform:translateX(-100%)}.mdc-switch__handle{display:flex;pointer-events:auto;position:absolute;top:50%;transform:translateY(-50%);left:0;right:auto}[dir=rtl] .mdc-switch__handle,.mdc-switch__handle[dir=rtl]{left:auto;right:0}.mdc-switch__handle::before,.mdc-switch__handle::after{border:1px solid rgba(0,0,0,0);border-radius:inherit;box-sizing:border-box;content:"";width:100%;height:100%;left:0;position:absolute;top:0;transition:background-color 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1),border-color 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);z-index:-1}@media screen and (forced-colors: active){.mdc-switch__handle::before,.mdc-switch__handle::after{border-color:currentColor}}.mdc-switch__shadow{border-radius:inherit;bottom:0;left:0;position:absolute;right:0;top:0}.mdc-elevation-overlay{bottom:0;left:0;right:0;top:0}.mdc-switch__ripple{left:50%;position:absolute;top:50%;transform:translate(-50%, -50%);z-index:-1}.mdc-switch:disabled .mdc-switch__ripple{display:none}.mdc-switch__icons{height:100%;position:relative;width:100%;z-index:1}.mdc-switch__icon{bottom:0;left:0;margin:auto;position:absolute;right:0;top:0;opacity:0;transition:opacity 30ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mdc-switch--selected .mdc-switch__icon--on,.mdc-switch--unselected .mdc-switch__icon--off{opacity:1;transition:opacity 45ms 30ms cubic-bezier(0, 0, 0.2, 1)}.mat-mdc-slide-toggle .mdc-switch--disabled+label{color:var(--mdc-switch-disabled-label-text-color)}.mdc-switch{width:var(--mdc-switch-track-width)}.mdc-switch.mdc-switch--selected:enabled .mdc-switch__handle::after{background:var(--mdc-switch-selected-handle-color)}.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus):not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-selected-hover-handle-color)}.mdc-switch.mdc-switch--selected:enabled:focus:not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-selected-focus-handle-color)}.mdc-switch.mdc-switch--selected:enabled:active .mdc-switch__handle::after{background:var(--mdc-switch-selected-pressed-handle-color)}.mdc-switch.mdc-switch--selected:disabled .mdc-switch__handle::after{background:var(--mdc-switch-disabled-selected-handle-color)}.mdc-switch.mdc-switch--unselected:enabled .mdc-switch__handle::after{background:var(--mdc-switch-unselected-handle-color)}.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus):not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-unselected-hover-handle-color)}.mdc-switch.mdc-switch--unselected:enabled:focus:not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-unselected-focus-handle-color)}.mdc-switch.mdc-switch--unselected:enabled:active .mdc-switch__handle::after{background:var(--mdc-switch-unselected-pressed-handle-color)}.mdc-switch.mdc-switch--unselected:disabled .mdc-switch__handle::after{background:var(--mdc-switch-disabled-unselected-handle-color)}.mdc-switch .mdc-switch__handle::before{background:var(--mdc-switch-handle-surface-color)}.mdc-switch:enabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-handle-elevation)}.mdc-switch:disabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-disabled-handle-elevation)}.mdc-switch .mdc-switch__focus-ring-wrapper,.mdc-switch .mdc-switch__handle{height:var(--mdc-switch-handle-height)}.mdc-switch .mdc-switch__handle{border-radius:var(--mdc-switch-handle-shape)}.mdc-switch .mdc-switch__handle{width:var(--mdc-switch-handle-width)}.mdc-switch .mdc-switch__handle-track{width:calc(100% - var(--mdc-switch-handle-width))}.mdc-switch.mdc-switch--selected:enabled .mdc-switch__icon{fill:var(--mdc-switch-selected-icon-color)}.mdc-switch.mdc-switch--selected:disabled .mdc-switch__icon{fill:var(--mdc-switch-disabled-selected-icon-color)}.mdc-switch.mdc-switch--unselected:enabled .mdc-switch__icon{fill:var(--mdc-switch-unselected-icon-color)}.mdc-switch.mdc-switch--unselected:disabled .mdc-switch__icon{fill:var(--mdc-switch-disabled-unselected-icon-color)}.mdc-switch.mdc-switch--selected:disabled .mdc-switch__icons{opacity:var(--mdc-switch-disabled-selected-icon-opacity)}.mdc-switch.mdc-switch--unselected:disabled .mdc-switch__icons{opacity:var(--mdc-switch-disabled-unselected-icon-opacity)}.mdc-switch.mdc-switch--selected .mdc-switch__icon{width:var(--mdc-switch-selected-icon-size);height:var(--mdc-switch-selected-icon-size)}.mdc-switch.mdc-switch--unselected .mdc-switch__icon{width:var(--mdc-switch-unselected-icon-size);height:var(--mdc-switch-unselected-icon-size)}.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus) .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus) .mdc-switch__ripple::after{background-color:var(--mdc-switch-selected-hover-state-layer-color)}.mdc-switch.mdc-switch--selected:enabled:focus .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:focus .mdc-switch__ripple::after{background-color:var(--mdc-switch-selected-focus-state-layer-color)}.mdc-switch.mdc-switch--selected:enabled:active .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:active .mdc-switch__ripple::after{background-color:var(--mdc-switch-selected-pressed-state-layer-color)}.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus) .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus) .mdc-switch__ripple::after{background-color:var(--mdc-switch-unselected-hover-state-layer-color)}.mdc-switch.mdc-switch--unselected:enabled:focus .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:focus .mdc-switch__ripple::after{background-color:var(--mdc-switch-unselected-focus-state-layer-color)}.mdc-switch.mdc-switch--unselected:enabled:active .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:active .mdc-switch__ripple::after{background-color:var(--mdc-switch-unselected-pressed-state-layer-color)}.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus):hover .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus).mdc-ripple-surface--hover .mdc-switch__ripple::before{opacity:var(--mdc-switch-selected-hover-state-layer-opacity)}.mdc-switch.mdc-switch--selected:enabled:focus.mdc-ripple-upgraded--background-focused .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:focus:not(.mdc-ripple-upgraded):focus .mdc-switch__ripple::before{transition-duration:75ms;opacity:var(--mdc-switch-selected-focus-state-layer-opacity)}.mdc-switch.mdc-switch--selected:enabled:active:not(.mdc-ripple-upgraded) .mdc-switch__ripple::after{transition:opacity 150ms linear}.mdc-switch.mdc-switch--selected:enabled:active:not(.mdc-ripple-upgraded):active .mdc-switch__ripple::after{transition-duration:75ms;opacity:var(--mdc-switch-selected-pressed-state-layer-opacity)}.mdc-switch.mdc-switch--selected:enabled:active.mdc-ripple-upgraded{--mdc-ripple-fg-opacity:var(--mdc-switch-selected-pressed-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus):hover .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus).mdc-ripple-surface--hover .mdc-switch__ripple::before{opacity:var(--mdc-switch-unselected-hover-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:focus.mdc-ripple-upgraded--background-focused .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:focus:not(.mdc-ripple-upgraded):focus .mdc-switch__ripple::before{transition-duration:75ms;opacity:var(--mdc-switch-unselected-focus-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:active:not(.mdc-ripple-upgraded) .mdc-switch__ripple::after{transition:opacity 150ms linear}.mdc-switch.mdc-switch--unselected:enabled:active:not(.mdc-ripple-upgraded):active .mdc-switch__ripple::after{transition-duration:75ms;opacity:var(--mdc-switch-unselected-pressed-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:active.mdc-ripple-upgraded{--mdc-ripple-fg-opacity:var(--mdc-switch-unselected-pressed-state-layer-opacity)}.mdc-switch .mdc-switch__ripple{height:var(--mdc-switch-state-layer-size);width:var(--mdc-switch-state-layer-size)}.mdc-switch .mdc-switch__track{height:var(--mdc-switch-track-height)}.mdc-switch:disabled .mdc-switch__track{opacity:var(--mdc-switch-disabled-track-opacity)}.mdc-switch:enabled .mdc-switch__track::after{background:var(--mdc-switch-selected-track-color)}.mdc-switch:enabled:hover:not(:focus):not(:active) .mdc-switch__track::after{background:var(--mdc-switch-selected-hover-track-color)}.mdc-switch:enabled:focus:not(:active) .mdc-switch__track::after{background:var(--mdc-switch-selected-focus-track-color)}.mdc-switch:enabled:active .mdc-switch__track::after{background:var(--mdc-switch-selected-pressed-track-color)}.mdc-switch:disabled .mdc-switch__track::after{background:var(--mdc-switch-disabled-selected-track-color)}.mdc-switch:enabled .mdc-switch__track::before{background:var(--mdc-switch-unselected-track-color)}.mdc-switch:enabled:hover:not(:focus):not(:active) .mdc-switch__track::before{background:var(--mdc-switch-unselected-hover-track-color)}.mdc-switch:enabled:focus:not(:active) .mdc-switch__track::before{background:var(--mdc-switch-unselected-focus-track-color)}.mdc-switch:enabled:active .mdc-switch__track::before{background:var(--mdc-switch-unselected-pressed-track-color)}.mdc-switch:disabled .mdc-switch__track::before{background:var(--mdc-switch-disabled-unselected-track-color)}.mdc-switch .mdc-switch__track{border-radius:var(--mdc-switch-track-shape)}.mdc-switch:enabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-handle-elevation-shadow)}.mdc-switch:disabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-disabled-handle-elevation-shadow)}.mat-mdc-slide-toggle{display:inline-block;-webkit-tap-highlight-color:rgba(0,0,0,0);outline:0}.mat-mdc-slide-toggle .mat-mdc-slide-toggle-ripple,.mat-mdc-slide-toggle .mdc-switch__ripple::after{top:0;left:0;right:0;bottom:0;position:absolute;border-radius:50%;pointer-events:none}.mat-mdc-slide-toggle .mat-mdc-slide-toggle-ripple:not(:empty),.mat-mdc-slide-toggle .mdc-switch__ripple::after:not(:empty){transform:translateZ(0)}.mat-mdc-slide-toggle .mdc-switch__ripple::after{content:"";opacity:0}.mat-mdc-slide-toggle .mdc-switch:hover .mdc-switch__ripple::after{opacity:.04;transition:opacity 75ms 0ms cubic-bezier(0, 0, 0.2, 1)}.mat-mdc-slide-toggle.mat-mdc-slide-toggle-focused .mdc-switch .mdc-switch__ripple::after{opacity:.12}.mat-mdc-slide-toggle.mat-mdc-slide-toggle-focused .mat-mdc-focus-indicator::before{content:""}.mat-mdc-slide-toggle .mat-ripple-element{opacity:.12}.mat-mdc-slide-toggle .mat-mdc-focus-indicator::before{border-radius:50%}.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__handle-track,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-elevation-overlay,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__icon,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__handle::before,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__handle::after,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__track::before,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__track::after{transition:none}.mat-mdc-slide-toggle .mdc-switch:enabled+.mdc-label{cursor:pointer}.mdc-switch__handle{transition:width 75ms cubic-bezier(0.4, 0, 0.2, 1),height 75ms cubic-bezier(0.4, 0, 0.2, 1),margin 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-switch--selected .mdc-switch__track::before{opacity:var(--mat-switch-hidden-track-opacity);transition:var(--mat-switch-hidden-track-transition)}.mdc-switch--selected .mdc-switch__track::after{opacity:var(--mat-switch-visible-track-opacity);transition:var(--mat-switch-visible-track-transition)}.mdc-switch--unselected .mdc-switch__track::before{opacity:var(--mat-switch-visible-track-opacity);transition:var(--mat-switch-visible-track-transition)}.mdc-switch--unselected .mdc-switch__track::after{opacity:var(--mat-switch-hidden-track-opacity);transition:var(--mat-switch-hidden-track-transition)}.mat-mdc-slide-toggle .mdc-switch--unselected .mdc-switch__handle{width:var(--mat-switch-unselected-handle-size);height:var(--mat-switch-unselected-handle-size)}.mat-mdc-slide-toggle .mdc-switch--selected .mdc-switch__handle{width:var(--mat-switch-selected-handle-size);height:var(--mat-switch-selected-handle-size)}.mat-mdc-slide-toggle .mdc-switch__handle:has(.mdc-switch__icons){width:var(--mat-switch-with-icon-handle-size);height:var(--mat-switch-with-icon-handle-size)}.mat-mdc-slide-toggle:active .mdc-switch:not(.mdc-switch--disabled) .mdc-switch__handle{width:var(--mat-switch-pressed-handle-size);height:var(--mat-switch-pressed-handle-size)}.mat-mdc-slide-toggle .mdc-switch--selected .mdc-switch__handle{margin:var(--mat-switch-selected-handle-horizontal-margin)}.mat-mdc-slide-toggle .mdc-switch--selected .mdc-switch__handle:has(.mdc-switch__icons){margin:var(--mat-switch-selected-with-icon-handle-horizontal-margin)}.mat-mdc-slide-toggle .mdc-switch--unselected .mdc-switch__handle{margin:var(--mat-switch-unselected-handle-horizontal-margin)}.mat-mdc-slide-toggle .mdc-switch--unselected .mdc-switch__handle:has(.mdc-switch__icons){margin:var(--mat-switch-unselected-with-icon-handle-horizontal-margin)}.mat-mdc-slide-toggle:active .mdc-switch--selected:not(.mdc-switch--disabled) .mdc-switch__handle{margin:var(--mat-switch-selected-pressed-handle-horizontal-margin)}.mat-mdc-slide-toggle:active .mdc-switch--unselected:not(.mdc-switch--disabled) .mdc-switch__handle{margin:var(--mat-switch-unselected-pressed-handle-horizontal-margin)}.mdc-switch__track::after,.mdc-switch__track::before{border-width:var(--mat-switch-track-outline-width);border-color:var(--mat-switch-track-outline-color)}.mdc-switch--selected .mdc-switch__track::after,.mdc-switch--selected .mdc-switch__track::before{border-width:var(--mat-switch-selected-track-outline-width)}.mdc-switch--disabled .mdc-switch__track::after,.mdc-switch--disabled .mdc-switch__track::before{border-width:var(--mat-switch-disabled-unselected-track-outline-width);border-color:var(--mat-switch-disabled-unselected-track-outline-color)}.mdc-switch--disabled.mdc-switch--selected .mdc-switch__handle::after{opacity:var(--mat-switch-disabled-selected-handle-opacity)}.mdc-switch--disabled.mdc-switch--unselected .mdc-switch__handle::after{opacity:var(--mat-switch-disabled-unselected-handle-opacity)}'],
  encapsulation: 2,
  changeDetection: 0
});
var MatSlideToggle = _MatSlideToggle;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatSlideToggle, [{
    type: Component,
    args: [{
      selector: "mat-slide-toggle",
      host: {
        "class": "mat-mdc-slide-toggle",
        "[id]": "id",
        // Needs to be removed since it causes some a11y issues (see #21266).
        "[attr.tabindex]": "null",
        "[attr.aria-label]": "null",
        "[attr.name]": "null",
        "[attr.aria-labelledby]": "null",
        "[class.mat-mdc-slide-toggle-focused]": "_focused",
        "[class.mat-mdc-slide-toggle-checked]": "checked",
        "[class._mat-animation-noopable]": "_noopAnimations",
        "[class]": 'color ? "mat-" + color : ""'
      },
      exportAs: "matSlideToggle",
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      providers: [MAT_SLIDE_TOGGLE_VALUE_ACCESSOR, {
        provide: NG_VALIDATORS,
        useExisting: MatSlideToggle,
        multi: true
      }],
      standalone: true,
      imports: [MatRipple, _MatInternalFormField],
      template: `<div mat-internal-form-field [labelPosition]="labelPosition">
  <button
    class="mdc-switch"
    role="switch"
    type="button"
    [class.mdc-switch--selected]="checked"
    [class.mdc-switch--unselected]="!checked"
    [class.mdc-switch--checked]="checked"
    [class.mdc-switch--disabled]="disabled"
    [tabIndex]="disabled ? -1 : tabIndex"
    [disabled]="disabled"
    [attr.id]="buttonId"
    [attr.name]="name"
    [attr.aria-label]="ariaLabel"
    [attr.aria-labelledby]="_getAriaLabelledBy()"
    [attr.aria-describedby]="ariaDescribedby"
    [attr.aria-required]="required || null"
    [attr.aria-checked]="checked"
    (click)="_handleClick()"
    #switch>
    <div class="mdc-switch__track"></div>
    <div class="mdc-switch__handle-track">
      <div class="mdc-switch__handle">
        <div class="mdc-switch__shadow">
          <div class="mdc-elevation-overlay"></div>
        </div>
        <div class="mdc-switch__ripple">
          <div class="mat-mdc-slide-toggle-ripple mat-mdc-focus-indicator" mat-ripple
            [matRippleTrigger]="switch"
            [matRippleDisabled]="disableRipple || disabled"
            [matRippleCentered]="true"></div>
        </div>
        @if (!hideIcon) {
          <div class="mdc-switch__icons">
            <svg
              class="mdc-switch__icon mdc-switch__icon--on"
              viewBox="0 0 24 24"
              aria-hidden="true">
              <path d="M19.69,5.23L8.96,15.96l-4.23-4.23L2.96,13.5l6,6L21.46,7L19.69,5.23z" />
            </svg>
            <svg
              class="mdc-switch__icon mdc-switch__icon--off"
              viewBox="0 0 24 24"
              aria-hidden="true">
              <path d="M20 13H4v-2h16v2z" />
            </svg>
          </div>
        }
      </div>
    </div>
  </button>

  <!--
    Clicking on the label will trigger another click event from the button.
    Stop propagation here so other listeners further up in the DOM don't execute twice.
  -->
  <label class="mdc-label" [for]="buttonId" [attr.id]="_labelId" (click)="$event.stopPropagation()">
    <ng-content></ng-content>
  </label>
</div>
`,
      styles: ['.mdc-elevation-overlay{position:absolute;border-radius:inherit;pointer-events:none;opacity:var(--mdc-elevation-overlay-opacity);transition:opacity 280ms cubic-bezier(0.4, 0, 0.2, 1);background-color:var(--mdc-elevation-overlay-color)}.mdc-switch{align-items:center;background:none;border:none;cursor:pointer;display:inline-flex;flex-shrink:0;margin:0;outline:none;overflow:visible;padding:0;position:relative}.mdc-switch[hidden]{display:none}.mdc-switch:disabled{cursor:default;pointer-events:none}.mdc-switch__track{overflow:hidden;position:relative;width:100%}.mdc-switch__track::before,.mdc-switch__track::after{border:1px solid rgba(0,0,0,0);border-radius:inherit;box-sizing:border-box;content:"";height:100%;left:0;position:absolute;width:100%}@media screen and (forced-colors: active){.mdc-switch__track::before,.mdc-switch__track::after{border-color:currentColor}}.mdc-switch__track::before{transition:transform 75ms 0ms cubic-bezier(0, 0, 0.2, 1);transform:translateX(0)}.mdc-switch__track::after{transition:transform 75ms 0ms cubic-bezier(0.4, 0, 0.6, 1);transform:translateX(-100%)}[dir=rtl] .mdc-switch__track::after,.mdc-switch__track[dir=rtl]::after{transform:translateX(100%)}.mdc-switch--selected .mdc-switch__track::before{transition:transform 75ms 0ms cubic-bezier(0.4, 0, 0.6, 1);transform:translateX(100%)}[dir=rtl] .mdc-switch--selected .mdc-switch__track::before,.mdc-switch--selected .mdc-switch__track[dir=rtl]::before{transform:translateX(-100%)}.mdc-switch--selected .mdc-switch__track::after{transition:transform 75ms 0ms cubic-bezier(0, 0, 0.2, 1);transform:translateX(0)}.mdc-switch__handle-track{height:100%;pointer-events:none;position:absolute;top:0;transition:transform 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);left:0;right:auto;transform:translateX(0)}[dir=rtl] .mdc-switch__handle-track,.mdc-switch__handle-track[dir=rtl]{left:auto;right:0}.mdc-switch--selected .mdc-switch__handle-track{transform:translateX(100%)}[dir=rtl] .mdc-switch--selected .mdc-switch__handle-track,.mdc-switch--selected .mdc-switch__handle-track[dir=rtl]{transform:translateX(-100%)}.mdc-switch__handle{display:flex;pointer-events:auto;position:absolute;top:50%;transform:translateY(-50%);left:0;right:auto}[dir=rtl] .mdc-switch__handle,.mdc-switch__handle[dir=rtl]{left:auto;right:0}.mdc-switch__handle::before,.mdc-switch__handle::after{border:1px solid rgba(0,0,0,0);border-radius:inherit;box-sizing:border-box;content:"";width:100%;height:100%;left:0;position:absolute;top:0;transition:background-color 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1),border-color 75ms 0ms cubic-bezier(0.4, 0, 0.2, 1);z-index:-1}@media screen and (forced-colors: active){.mdc-switch__handle::before,.mdc-switch__handle::after{border-color:currentColor}}.mdc-switch__shadow{border-radius:inherit;bottom:0;left:0;position:absolute;right:0;top:0}.mdc-elevation-overlay{bottom:0;left:0;right:0;top:0}.mdc-switch__ripple{left:50%;position:absolute;top:50%;transform:translate(-50%, -50%);z-index:-1}.mdc-switch:disabled .mdc-switch__ripple{display:none}.mdc-switch__icons{height:100%;position:relative;width:100%;z-index:1}.mdc-switch__icon{bottom:0;left:0;margin:auto;position:absolute;right:0;top:0;opacity:0;transition:opacity 30ms 0ms cubic-bezier(0.4, 0, 1, 1)}.mdc-switch--selected .mdc-switch__icon--on,.mdc-switch--unselected .mdc-switch__icon--off{opacity:1;transition:opacity 45ms 30ms cubic-bezier(0, 0, 0.2, 1)}.mat-mdc-slide-toggle .mdc-switch--disabled+label{color:var(--mdc-switch-disabled-label-text-color)}.mdc-switch{width:var(--mdc-switch-track-width)}.mdc-switch.mdc-switch--selected:enabled .mdc-switch__handle::after{background:var(--mdc-switch-selected-handle-color)}.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus):not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-selected-hover-handle-color)}.mdc-switch.mdc-switch--selected:enabled:focus:not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-selected-focus-handle-color)}.mdc-switch.mdc-switch--selected:enabled:active .mdc-switch__handle::after{background:var(--mdc-switch-selected-pressed-handle-color)}.mdc-switch.mdc-switch--selected:disabled .mdc-switch__handle::after{background:var(--mdc-switch-disabled-selected-handle-color)}.mdc-switch.mdc-switch--unselected:enabled .mdc-switch__handle::after{background:var(--mdc-switch-unselected-handle-color)}.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus):not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-unselected-hover-handle-color)}.mdc-switch.mdc-switch--unselected:enabled:focus:not(:active) .mdc-switch__handle::after{background:var(--mdc-switch-unselected-focus-handle-color)}.mdc-switch.mdc-switch--unselected:enabled:active .mdc-switch__handle::after{background:var(--mdc-switch-unselected-pressed-handle-color)}.mdc-switch.mdc-switch--unselected:disabled .mdc-switch__handle::after{background:var(--mdc-switch-disabled-unselected-handle-color)}.mdc-switch .mdc-switch__handle::before{background:var(--mdc-switch-handle-surface-color)}.mdc-switch:enabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-handle-elevation)}.mdc-switch:disabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-disabled-handle-elevation)}.mdc-switch .mdc-switch__focus-ring-wrapper,.mdc-switch .mdc-switch__handle{height:var(--mdc-switch-handle-height)}.mdc-switch .mdc-switch__handle{border-radius:var(--mdc-switch-handle-shape)}.mdc-switch .mdc-switch__handle{width:var(--mdc-switch-handle-width)}.mdc-switch .mdc-switch__handle-track{width:calc(100% - var(--mdc-switch-handle-width))}.mdc-switch.mdc-switch--selected:enabled .mdc-switch__icon{fill:var(--mdc-switch-selected-icon-color)}.mdc-switch.mdc-switch--selected:disabled .mdc-switch__icon{fill:var(--mdc-switch-disabled-selected-icon-color)}.mdc-switch.mdc-switch--unselected:enabled .mdc-switch__icon{fill:var(--mdc-switch-unselected-icon-color)}.mdc-switch.mdc-switch--unselected:disabled .mdc-switch__icon{fill:var(--mdc-switch-disabled-unselected-icon-color)}.mdc-switch.mdc-switch--selected:disabled .mdc-switch__icons{opacity:var(--mdc-switch-disabled-selected-icon-opacity)}.mdc-switch.mdc-switch--unselected:disabled .mdc-switch__icons{opacity:var(--mdc-switch-disabled-unselected-icon-opacity)}.mdc-switch.mdc-switch--selected .mdc-switch__icon{width:var(--mdc-switch-selected-icon-size);height:var(--mdc-switch-selected-icon-size)}.mdc-switch.mdc-switch--unselected .mdc-switch__icon{width:var(--mdc-switch-unselected-icon-size);height:var(--mdc-switch-unselected-icon-size)}.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus) .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus) .mdc-switch__ripple::after{background-color:var(--mdc-switch-selected-hover-state-layer-color)}.mdc-switch.mdc-switch--selected:enabled:focus .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:focus .mdc-switch__ripple::after{background-color:var(--mdc-switch-selected-focus-state-layer-color)}.mdc-switch.mdc-switch--selected:enabled:active .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:active .mdc-switch__ripple::after{background-color:var(--mdc-switch-selected-pressed-state-layer-color)}.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus) .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus) .mdc-switch__ripple::after{background-color:var(--mdc-switch-unselected-hover-state-layer-color)}.mdc-switch.mdc-switch--unselected:enabled:focus .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:focus .mdc-switch__ripple::after{background-color:var(--mdc-switch-unselected-focus-state-layer-color)}.mdc-switch.mdc-switch--unselected:enabled:active .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:active .mdc-switch__ripple::after{background-color:var(--mdc-switch-unselected-pressed-state-layer-color)}.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus):hover .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:hover:not(:focus).mdc-ripple-surface--hover .mdc-switch__ripple::before{opacity:var(--mdc-switch-selected-hover-state-layer-opacity)}.mdc-switch.mdc-switch--selected:enabled:focus.mdc-ripple-upgraded--background-focused .mdc-switch__ripple::before,.mdc-switch.mdc-switch--selected:enabled:focus:not(.mdc-ripple-upgraded):focus .mdc-switch__ripple::before{transition-duration:75ms;opacity:var(--mdc-switch-selected-focus-state-layer-opacity)}.mdc-switch.mdc-switch--selected:enabled:active:not(.mdc-ripple-upgraded) .mdc-switch__ripple::after{transition:opacity 150ms linear}.mdc-switch.mdc-switch--selected:enabled:active:not(.mdc-ripple-upgraded):active .mdc-switch__ripple::after{transition-duration:75ms;opacity:var(--mdc-switch-selected-pressed-state-layer-opacity)}.mdc-switch.mdc-switch--selected:enabled:active.mdc-ripple-upgraded{--mdc-ripple-fg-opacity:var(--mdc-switch-selected-pressed-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus):hover .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:hover:not(:focus).mdc-ripple-surface--hover .mdc-switch__ripple::before{opacity:var(--mdc-switch-unselected-hover-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:focus.mdc-ripple-upgraded--background-focused .mdc-switch__ripple::before,.mdc-switch.mdc-switch--unselected:enabled:focus:not(.mdc-ripple-upgraded):focus .mdc-switch__ripple::before{transition-duration:75ms;opacity:var(--mdc-switch-unselected-focus-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:active:not(.mdc-ripple-upgraded) .mdc-switch__ripple::after{transition:opacity 150ms linear}.mdc-switch.mdc-switch--unselected:enabled:active:not(.mdc-ripple-upgraded):active .mdc-switch__ripple::after{transition-duration:75ms;opacity:var(--mdc-switch-unselected-pressed-state-layer-opacity)}.mdc-switch.mdc-switch--unselected:enabled:active.mdc-ripple-upgraded{--mdc-ripple-fg-opacity:var(--mdc-switch-unselected-pressed-state-layer-opacity)}.mdc-switch .mdc-switch__ripple{height:var(--mdc-switch-state-layer-size);width:var(--mdc-switch-state-layer-size)}.mdc-switch .mdc-switch__track{height:var(--mdc-switch-track-height)}.mdc-switch:disabled .mdc-switch__track{opacity:var(--mdc-switch-disabled-track-opacity)}.mdc-switch:enabled .mdc-switch__track::after{background:var(--mdc-switch-selected-track-color)}.mdc-switch:enabled:hover:not(:focus):not(:active) .mdc-switch__track::after{background:var(--mdc-switch-selected-hover-track-color)}.mdc-switch:enabled:focus:not(:active) .mdc-switch__track::after{background:var(--mdc-switch-selected-focus-track-color)}.mdc-switch:enabled:active .mdc-switch__track::after{background:var(--mdc-switch-selected-pressed-track-color)}.mdc-switch:disabled .mdc-switch__track::after{background:var(--mdc-switch-disabled-selected-track-color)}.mdc-switch:enabled .mdc-switch__track::before{background:var(--mdc-switch-unselected-track-color)}.mdc-switch:enabled:hover:not(:focus):not(:active) .mdc-switch__track::before{background:var(--mdc-switch-unselected-hover-track-color)}.mdc-switch:enabled:focus:not(:active) .mdc-switch__track::before{background:var(--mdc-switch-unselected-focus-track-color)}.mdc-switch:enabled:active .mdc-switch__track::before{background:var(--mdc-switch-unselected-pressed-track-color)}.mdc-switch:disabled .mdc-switch__track::before{background:var(--mdc-switch-disabled-unselected-track-color)}.mdc-switch .mdc-switch__track{border-radius:var(--mdc-switch-track-shape)}.mdc-switch:enabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-handle-elevation-shadow)}.mdc-switch:disabled .mdc-switch__shadow{box-shadow:var(--mdc-switch-disabled-handle-elevation-shadow)}.mat-mdc-slide-toggle{display:inline-block;-webkit-tap-highlight-color:rgba(0,0,0,0);outline:0}.mat-mdc-slide-toggle .mat-mdc-slide-toggle-ripple,.mat-mdc-slide-toggle .mdc-switch__ripple::after{top:0;left:0;right:0;bottom:0;position:absolute;border-radius:50%;pointer-events:none}.mat-mdc-slide-toggle .mat-mdc-slide-toggle-ripple:not(:empty),.mat-mdc-slide-toggle .mdc-switch__ripple::after:not(:empty){transform:translateZ(0)}.mat-mdc-slide-toggle .mdc-switch__ripple::after{content:"";opacity:0}.mat-mdc-slide-toggle .mdc-switch:hover .mdc-switch__ripple::after{opacity:.04;transition:opacity 75ms 0ms cubic-bezier(0, 0, 0.2, 1)}.mat-mdc-slide-toggle.mat-mdc-slide-toggle-focused .mdc-switch .mdc-switch__ripple::after{opacity:.12}.mat-mdc-slide-toggle.mat-mdc-slide-toggle-focused .mat-mdc-focus-indicator::before{content:""}.mat-mdc-slide-toggle .mat-ripple-element{opacity:.12}.mat-mdc-slide-toggle .mat-mdc-focus-indicator::before{border-radius:50%}.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__handle-track,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-elevation-overlay,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__icon,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__handle::before,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__handle::after,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__track::before,.mat-mdc-slide-toggle._mat-animation-noopable .mdc-switch__track::after{transition:none}.mat-mdc-slide-toggle .mdc-switch:enabled+.mdc-label{cursor:pointer}.mdc-switch__handle{transition:width 75ms cubic-bezier(0.4, 0, 0.2, 1),height 75ms cubic-bezier(0.4, 0, 0.2, 1),margin 75ms cubic-bezier(0.4, 0, 0.2, 1)}.mdc-switch--selected .mdc-switch__track::before{opacity:var(--mat-switch-hidden-track-opacity);transition:var(--mat-switch-hidden-track-transition)}.mdc-switch--selected .mdc-switch__track::after{opacity:var(--mat-switch-visible-track-opacity);transition:var(--mat-switch-visible-track-transition)}.mdc-switch--unselected .mdc-switch__track::before{opacity:var(--mat-switch-visible-track-opacity);transition:var(--mat-switch-visible-track-transition)}.mdc-switch--unselected .mdc-switch__track::after{opacity:var(--mat-switch-hidden-track-opacity);transition:var(--mat-switch-hidden-track-transition)}.mat-mdc-slide-toggle .mdc-switch--unselected .mdc-switch__handle{width:var(--mat-switch-unselected-handle-size);height:var(--mat-switch-unselected-handle-size)}.mat-mdc-slide-toggle .mdc-switch--selected .mdc-switch__handle{width:var(--mat-switch-selected-handle-size);height:var(--mat-switch-selected-handle-size)}.mat-mdc-slide-toggle .mdc-switch__handle:has(.mdc-switch__icons){width:var(--mat-switch-with-icon-handle-size);height:var(--mat-switch-with-icon-handle-size)}.mat-mdc-slide-toggle:active .mdc-switch:not(.mdc-switch--disabled) .mdc-switch__handle{width:var(--mat-switch-pressed-handle-size);height:var(--mat-switch-pressed-handle-size)}.mat-mdc-slide-toggle .mdc-switch--selected .mdc-switch__handle{margin:var(--mat-switch-selected-handle-horizontal-margin)}.mat-mdc-slide-toggle .mdc-switch--selected .mdc-switch__handle:has(.mdc-switch__icons){margin:var(--mat-switch-selected-with-icon-handle-horizontal-margin)}.mat-mdc-slide-toggle .mdc-switch--unselected .mdc-switch__handle{margin:var(--mat-switch-unselected-handle-horizontal-margin)}.mat-mdc-slide-toggle .mdc-switch--unselected .mdc-switch__handle:has(.mdc-switch__icons){margin:var(--mat-switch-unselected-with-icon-handle-horizontal-margin)}.mat-mdc-slide-toggle:active .mdc-switch--selected:not(.mdc-switch--disabled) .mdc-switch__handle{margin:var(--mat-switch-selected-pressed-handle-horizontal-margin)}.mat-mdc-slide-toggle:active .mdc-switch--unselected:not(.mdc-switch--disabled) .mdc-switch__handle{margin:var(--mat-switch-unselected-pressed-handle-horizontal-margin)}.mdc-switch__track::after,.mdc-switch__track::before{border-width:var(--mat-switch-track-outline-width);border-color:var(--mat-switch-track-outline-color)}.mdc-switch--selected .mdc-switch__track::after,.mdc-switch--selected .mdc-switch__track::before{border-width:var(--mat-switch-selected-track-outline-width)}.mdc-switch--disabled .mdc-switch__track::after,.mdc-switch--disabled .mdc-switch__track::before{border-width:var(--mat-switch-disabled-unselected-track-outline-width);border-color:var(--mat-switch-disabled-unselected-track-outline-color)}.mdc-switch--disabled.mdc-switch--selected .mdc-switch__handle::after{opacity:var(--mat-switch-disabled-selected-handle-opacity)}.mdc-switch--disabled.mdc-switch--unselected .mdc-switch__handle::after{opacity:var(--mat-switch-disabled-unselected-handle-opacity)}']
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: FocusMonitor
  }, {
    type: ChangeDetectorRef
  }, {
    type: void 0,
    decorators: [{
      type: Attribute,
      args: ["tabindex"]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_SLIDE_TOGGLE_DEFAULT_OPTIONS]
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
    _switchElement: [{
      type: ViewChild,
      args: ["switch"]
    }],
    name: [{
      type: Input
    }],
    id: [{
      type: Input
    }],
    labelPosition: [{
      type: Input
    }],
    ariaLabel: [{
      type: Input,
      args: ["aria-label"]
    }],
    ariaLabelledby: [{
      type: Input,
      args: ["aria-labelledby"]
    }],
    ariaDescribedby: [{
      type: Input,
      args: ["aria-describedby"]
    }],
    required: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    color: [{
      type: Input
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    tabIndex: [{
      type: Input,
      args: [{
        transform: (value) => value == null ? 0 : numberAttribute(value)
      }]
    }],
    checked: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    hideIcon: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    change: [{
      type: Output
    }],
    toggleChange: [{
      type: Output
    }]
  });
})();
var MAT_SLIDE_TOGGLE_REQUIRED_VALIDATOR = {
  provide: NG_VALIDATORS,
  useExisting: forwardRef(() => MatSlideToggleRequiredValidator),
  multi: true
};
var _MatSlideToggleRequiredValidator = class _MatSlideToggleRequiredValidator extends CheckboxRequiredValidator {
};
_MatSlideToggleRequiredValidator.\u0275fac = /* @__PURE__ */ (() => {
  let \u0275MatSlideToggleRequiredValidator_BaseFactory;
  return function MatSlideToggleRequiredValidator_Factory(t) {
    return (\u0275MatSlideToggleRequiredValidator_BaseFactory || (\u0275MatSlideToggleRequiredValidator_BaseFactory = \u0275\u0275getInheritedFactory(_MatSlideToggleRequiredValidator)))(t || _MatSlideToggleRequiredValidator);
  };
})();
_MatSlideToggleRequiredValidator.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatSlideToggleRequiredValidator,
  selectors: [["mat-slide-toggle", "required", "", "formControlName", ""], ["mat-slide-toggle", "required", "", "formControl", ""], ["mat-slide-toggle", "required", "", "ngModel", ""]],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([MAT_SLIDE_TOGGLE_REQUIRED_VALIDATOR]), \u0275\u0275InheritDefinitionFeature]
});
var MatSlideToggleRequiredValidator = _MatSlideToggleRequiredValidator;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatSlideToggleRequiredValidator, [{
    type: Directive,
    args: [{
      selector: `mat-slide-toggle[required][formControlName],
             mat-slide-toggle[required][formControl], mat-slide-toggle[required][ngModel]`,
      providers: [MAT_SLIDE_TOGGLE_REQUIRED_VALIDATOR],
      standalone: true
    }]
  }], null, null);
})();
var __MatSlideToggleRequiredValidatorModule = class __MatSlideToggleRequiredValidatorModule {
};
__MatSlideToggleRequiredValidatorModule.\u0275fac = function _MatSlideToggleRequiredValidatorModule_Factory(t) {
  return new (t || __MatSlideToggleRequiredValidatorModule)();
};
__MatSlideToggleRequiredValidatorModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: __MatSlideToggleRequiredValidatorModule
});
__MatSlideToggleRequiredValidatorModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({});
var _MatSlideToggleRequiredValidatorModule = __MatSlideToggleRequiredValidatorModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(_MatSlideToggleRequiredValidatorModule, [{
    type: NgModule,
    args: [{
      imports: [MatSlideToggleRequiredValidator],
      exports: [MatSlideToggleRequiredValidator]
    }]
  }], null, null);
})();
var _MatSlideToggleModule = class _MatSlideToggleModule {
};
_MatSlideToggleModule.\u0275fac = function MatSlideToggleModule_Factory(t) {
  return new (t || _MatSlideToggleModule)();
};
_MatSlideToggleModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatSlideToggleModule
});
_MatSlideToggleModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatSlideToggle, MatCommonModule, MatCommonModule]
});
var MatSlideToggleModule = _MatSlideToggleModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatSlideToggleModule, [{
    type: NgModule,
    args: [{
      imports: [MatSlideToggle, MatCommonModule],
      exports: [MatSlideToggle, MatCommonModule]
    }]
  }], null, null);
})();

// src/app/features/setting/components/setting-update/setting-update.component.ts
function SettingUpdateComponent_button_37_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 32);
    \u0275\u0275listener("click", function SettingUpdateComponent_button_37_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.copyToClipboard(ctx_r1.computedIdentifierPreview));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("disabled", !ctx_r1.computedIdentifierPreview);
  }
}
function SettingUpdateComponent_div_72_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 33)(1, "span", 25);
    \u0275\u0275text(2, "Ignore On File Change");
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "mat-icon", 34)(4, "mat-slide-toggle", 35);
    \u0275\u0275elementEnd();
  }
}
var _SettingUpdateComponent = class _SettingUpdateComponent {
  constructor(dialogRef, data, settingsService, formBuilder, utilityService, windowService, dialog, snackBar) {
    this.dialogRef = dialogRef;
    this.data = data;
    this.settingsService = settingsService;
    this.formBuilder = formBuilder;
    this.utilityService = utilityService;
    this.windowService = windowService;
    this.dialog = dialog;
    this.snackBar = snackBar;
    this.isFullScreen = false;
    this.computedIdentifierPreview = "";
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    this.form = this.formBuilder.group({
      computedIdentifier: [this.data.computedIdentifier, Validators.required],
      classNamespace: [this.data.classNamespace, Validators.required],
      className: [this.data.className, Validators.required],
      classFullName: [this.data.classFullName, Validators.required],
      isDataValidationEnabled: [this.data.isDataValidationEnabled],
      storeInSeparateFile: [this.data.storeInSeparateFile],
      ignoreOnFileChange: [this.data.storeInSeparateFile ? this.data.ignoreOnFileChange ?? false : null],
      registrationMode: [this.data.registrationMode]
    });
    this.computedIdentifierPreview = this.data.computedIdentifier;
    this.subscriptions.add(this.form.get("computedIdentifier").valueChanges.subscribe((value) => this.updateComputedIdentifierPreview(value)));
    this.isConnectionSecure = this.windowService.isConnectionSecure;
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  updateComputedIdentifierPreview(value) {
    if (value && isValidGuid(value)) {
      this.computedIdentifierPreview = value;
    } else if (value) {
      this.computedIdentifierPreview = computeIdentifier(value);
    } else {
      this.computedIdentifierPreview = "";
    }
  }
  toggleFullScreen() {
    this.isFullScreen = !this.isFullScreen;
    const dialogElement = document.querySelector(".mat-mdc-dialog-surface");
    if (this.isFullScreen) {
      dialogElement?.setAttribute("style", `
                  border-radius: 0 !important;
                `);
      this.dialogRef.updateSize("100%", "100%");
    } else {
      this.dialogRef.updateSize("1350px", "680px");
      dialogElement?.removeAttribute("style");
    }
  }
  copyToClipboard(input) {
    this.utilityService.copyToClipboard(input);
  }
  onSubmit() {
    if (!this.form.valid) {
      return;
    }
    const formValue = this.form.value;
    if (this.data.computedIdentifier === this.computedIdentifierPreview) {
      this.edit(formValue);
      return;
    }
    const title = "Confirm edit";
    const message = 'Updating the "Computed Identifier" may cause problems. Do you want to proceed? (Potential unmatching)';
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: { title, message }
    }).afterClosed().subscribe((result) => {
      if (result) {
        this.edit(formValue);
      }
    });
    this.subscriptions.add(subscription);
  }
  edit(formValue) {
    const model = {
      computedIdentifier: this.computedIdentifierPreview,
      dataValidationDisabled: !formValue.isDataValidationEnabled,
      rowVersion: this.data.settingRowVersion,
      class: {
        namespace: formValue.classNamespace,
        name: formValue.className,
        fullName: formValue.classFullName,
        rowVersion: this.data.classRowVersion
      },
      storeInSeparateFile: formValue.storeInSeparateFile,
      ignoreOnFileChange: formValue.ignoreOnFileChange,
      registrationMode: formValue.registrationMode
    };
    let editAppSettingComponentReturnModel;
    const updateSetting = (model2) => {
      return this.settingsService.updateSetting({
        settingId: this.data.id,
        body: model2
      });
    };
    const handleUpdate = (request) => {
      return updateSetting(request).pipe(switchMap((response) => {
        const responseData = response.data;
        editAppSettingComponentReturnModel = {
          computedIdentifier: model.computedIdentifier,
          classNamespace: formValue.classNamespace,
          className: formValue.className,
          classFullName: formValue.classFullName,
          isDataValidationEnabled: formValue.isDataValidationEnabled,
          rowVersion: responseData?.rowVersion ?? "",
          storeInSeparateFile: request.storeInSeparateFile,
          ignoreOnFileChange: request.storeInSeparateFile ? request.ignoreOnFileChange : null,
          registrationMode: request.registrationMode,
          type: editAppSettingComponentReturnModel?.type
        };
        if (!responseData && response.extras) {
          const availableReturnTypes = ["Discard", "Override", "Fetch Latest"];
          return this.dialog.open(ConflictResolverDialogComponent, {
            width: "400px",
            data: availableReturnTypes,
            autoFocus: false
          }).afterClosed().pipe(switchMap((type) => {
            if (type === "Fetch Latest") {
              editAppSettingComponentReturnModel.type = "Fetch Latest";
              return of(true);
            } else if (type === "Override") {
              const settingRowVersion = response.extras["Conflicts"]["SettingId"]?.properties["RowVersion"].current;
              const classRowVersion = response.extras["Conflicts"]["ClassId"]?.properties["RowVersion"].current;
              editAppSettingComponentReturnModel.type = "Override";
              if (settingRowVersion) {
                model.rowVersion = settingRowVersion;
              }
              if (classRowVersion) {
                model.class.rowVersion = classRowVersion;
              }
              return handleUpdate(model);
            }
            return of(false);
          }));
        } else {
          this.snackBar.open(`Data has been updated successfully! A restart is required for the changes to take effect.`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 5e3
          });
          return of(true);
        }
      }));
    };
    const subscription = handleUpdate(model).subscribe({
      next: (close) => {
        if (close) {
          this.dialogRef?.close(editAppSettingComponentReturnModel);
        }
      }
    });
    this.subscriptions.add(subscription);
  }
};
_SettingUpdateComponent.\u0275fac = function SettingUpdateComponent_Factory(t) {
  return new (t || _SettingUpdateComponent)(\u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MAT_DIALOG_DATA), \u0275\u0275directiveInject(SettingsService), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatSnackBar));
};
_SettingUpdateComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _SettingUpdateComponent, selectors: [["ng-component"]], decls: 76, vars: 14, consts: [[1, "d-flex", "border-bottom"], [1, "dialog-title"], [1, "dialog-subtitle"], [1, "spacer"], ["mat-icon-button", "", 3, "click", "matTooltip"], ["mat-icon-button", "", "mat-dialog-close", ""], [3, "ngSubmit", "formGroup"], ["appearance", "fill"], ["matInput", "", "formControlName", "classNamespace"], ["matInput", "", "formControlName", "className"], ["matInput", "", "formControlName", "classFullName"], [1, "d-flex"], ["matInput", "", "formControlName", "computedIdentifier"], ["matSuffix", "", "fontIcon", "info", "matTooltip", "A unique GUID is generated by combining the namespace and class name (unless manually assigned a different value). This GUID is used to uniquely identify each setting class."], ["matInput", "", "disabled", "", 3, "value"], ["type", "button", "matSuffix", "", "mat-icon-button", "", "matTooltip", "Copy", "matTooltipPosition", "below", 3, "disabled", "click", 4, "ngIf"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Defines how the setting is registered in dependency injection, allowing resolution through configuration options or as a singleton service.", 1, "icon-mini"], ["formControlName", "registrationMode"], [1, "custom-option", 3, "value"], ["color", "accent", "mat-icon-button", "", "matTooltipPosition", "left", "matTooltip", "Setting can be resolved through configuration options interfaces, such as IOptions<T>, IOptionsSnapshot<T> and IOptionsMonitor<T>."], ["matIconPosition", "right", "fontIcon", "info"], ["color", "accent", "mat-icon-button", "", "matTooltipPosition", "left", "matTooltip", "Setting can be resolved directly through its own class as a singleton instance."], ["color", "accent", "mat-icon-button", "", "matTooltipPosition", "left", "matTooltip", "Setting can be resolved both through singleton instances and through configuration options interfaces."], [1, "d-flex", "px-3"], [1, "mb-2", "mr-3", "d-flex", "align-items-center"], [1, "field-label-text"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "If enabled, it checks if class properties match the required type or are bindable during data changes.", 1, "icon-mini"], ["labelPosition", "before", "formControlName", "isDataValidationEnabled"], ["matIconPosition", "right", "fontIcon", "info", 1, "icon-mini", 3, "matTooltip"], ["labelPosition", "before", "formControlName", "storeInSeparateFile"], ["class", "mb-2 d-flex align-items-center", 4, "ngIf"], ["mat-raised-button", "", "color", "primary", 1, "ml-3", 3, "disabled"], ["type", "button", "matSuffix", "", "mat-icon-button", "", "matTooltip", "Copy", "matTooltipPosition", "below", 3, "click", "disabled"], [1, "mb-2", "d-flex", "align-items-center"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Indicates whether changes to the file should be ignored when the file is modified.", 1, "icon-mini"], ["labelPosition", "before", "formControlName", "ignoreOnFileChange"]], template: function SettingUpdateComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 0)(1, "div", 1);
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "div", 2);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd();
    \u0275\u0275element(5, "span")(6, "span", 3);
    \u0275\u0275elementStart(7, "button", 4);
    \u0275\u0275listener("click", function SettingUpdateComponent_Template_button_click_7_listener() {
      return ctx.toggleFullScreen();
    });
    \u0275\u0275elementStart(8, "mat-icon");
    \u0275\u0275text(9);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(10, "button", 5)(11, "mat-icon");
    \u0275\u0275text(12, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(13, "form", 6);
    \u0275\u0275listener("ngSubmit", function SettingUpdateComponent_Template_form_ngSubmit_13_listener() {
      return ctx.onSubmit();
    });
    \u0275\u0275elementStart(14, "mat-dialog-content")(15, "mat-form-field", 7)(16, "mat-label");
    \u0275\u0275text(17, "Class Namespace");
    \u0275\u0275elementEnd();
    \u0275\u0275element(18, "input", 8);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(19, "mat-form-field", 7)(20, "mat-label");
    \u0275\u0275text(21, "Class Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(22, "input", 9);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(23, "mat-form-field", 7)(24, "mat-label");
    \u0275\u0275text(25, "Class Full Name");
    \u0275\u0275elementEnd();
    \u0275\u0275element(26, "input", 10);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(27, "div", 11)(28, "mat-form-field", 7)(29, "mat-label");
    \u0275\u0275text(30, "Computed Identifier");
    \u0275\u0275elementEnd();
    \u0275\u0275element(31, "input", 12)(32, "mat-icon", 13);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(33, "mat-form-field", 7)(34, "mat-label");
    \u0275\u0275text(35, "Computed Identifier Preview");
    \u0275\u0275elementEnd();
    \u0275\u0275element(36, "input", 14);
    \u0275\u0275template(37, SettingUpdateComponent_button_37_Template, 3, 1, "button", 15);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(38, "mat-form-field", 7)(39, "mat-label");
    \u0275\u0275text(40, "Registration Mode ");
    \u0275\u0275element(41, "mat-icon", 16);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(42, "mat-select", 17)(43, "mat-option", 18)(44, "span");
    \u0275\u0275text(45, "Configure");
    \u0275\u0275elementEnd();
    \u0275\u0275element(46, "span", 3);
    \u0275\u0275elementStart(47, "button", 19);
    \u0275\u0275element(48, "mat-icon", 20);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(49, "mat-option", 18)(50, "span");
    \u0275\u0275text(51, "Singleton");
    \u0275\u0275elementEnd();
    \u0275\u0275element(52, "span", 3);
    \u0275\u0275elementStart(53, "button", 21);
    \u0275\u0275element(54, "mat-icon", 20);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(55, "mat-option", 18)(56, "span");
    \u0275\u0275text(57, "Both");
    \u0275\u0275elementEnd();
    \u0275\u0275element(58, "span", 3);
    \u0275\u0275elementStart(59, "button", 22);
    \u0275\u0275element(60, "mat-icon", 20);
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(61, "div", 23)(62, "div", 24)(63, "span", 25);
    \u0275\u0275text(64, " Data Validation");
    \u0275\u0275elementEnd();
    \u0275\u0275element(65, "mat-icon", 26)(66, "mat-slide-toggle", 27);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(67, "div", 24)(68, "span", 25);
    \u0275\u0275text(69, "Store In Separate File");
    \u0275\u0275elementEnd();
    \u0275\u0275element(70, "mat-icon", 28)(71, "mat-slide-toggle", 29);
    \u0275\u0275elementEnd();
    \u0275\u0275template(72, SettingUpdateComponent_div_72_Template, 5, 0, "div", 30);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(73, "mat-dialog-actions")(74, "button", 31);
    \u0275\u0275text(75, " Save ");
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    let tmp_10_0;
    let tmp_11_0;
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1("Update > ", ctx.data.clientName, "");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate2("", ctx.data.identifierName, " - ", ctx.data.className, "");
    \u0275\u0275advance(3);
    \u0275\u0275property("matTooltip", ctx.isFullScreen ? "Exit full screen" : "Enter full screen");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.isFullScreen ? "fullscreen_exit" : "fullscreen");
    \u0275\u0275advance(4);
    \u0275\u0275property("formGroup", ctx.form);
    \u0275\u0275advance(23);
    \u0275\u0275property("value", ctx.computedIdentifierPreview);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isConnectionSecure);
    \u0275\u0275advance(6);
    \u0275\u0275property("value", 1);
    \u0275\u0275advance(6);
    \u0275\u0275property("value", 2);
    \u0275\u0275advance(6);
    \u0275\u0275property("value", 3);
    \u0275\u0275advance(15);
    \u0275\u0275property("matTooltip", "Indicates whether the setting should be stored in a separate file 'settings-generated." + ((tmp_10_0 = ctx.form.get("className")) == null ? null : tmp_10_0.value) + ".json'. If not, it will be stored in the default 'settings-generated.json' file.");
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", (tmp_11_0 = ctx.form.get("storeInSeparateFile")) == null ? null : tmp_11_0.value);
    \u0275\u0275advance(2);
    \u0275\u0275property("disabled", ctx.form.invalid);
  }
}, dependencies: [NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, FormGroupDirective, FormControlName, MatIcon, MatFormField, MatLabel, MatSuffix, MatOption, MatButton, MatIconButton, MatTooltip, MatInput, MatSelect, MatDialogClose, MatDialogActions, MatDialogContent, MatSlideToggle], encapsulation: 2 });
var SettingUpdateComponent = _SettingUpdateComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(SettingUpdateComponent, { className: "SettingUpdateComponent", filePath: "src\\app\\features\\setting\\components\\setting-update\\setting-update.component.ts", lineNumber: 20 });
})();

// src/app/features/setting/components/setting-list/setting-list.component.ts
var _c014 = ["textarea"];
var _c17 = ["expansionPanel"];
var _c23 = (a0, a1) => ["./apps", a0, a1, "settings", "new"];
var _c32 = (a0, a1, a2) => ["./apps", a0, a1, "settings", a2, "update"];
var _c42 = (a0, a1, a2) => ["./apps", a0, a1, "settings", a2, "copyTo"];
var _c52 = (a0, a1, a2) => ["./apps", a0, a1, "settings", a2, "histories"];
function SettingListComponent_div_1_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div")(1, "button", 10);
    \u0275\u0275listener("click", function SettingListComponent_div_1_Template_button_click_1_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.expandAll());
    });
    \u0275\u0275elementStart(2, "mat-icon");
    \u0275\u0275text(3, "expand_more");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "button", 11);
    \u0275\u0275listener("click", function SettingListComponent_div_1_Template_button_click_4_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.collapseAll());
    });
    \u0275\u0275elementStart(5, "mat-icon");
    \u0275\u0275text(6, "expand_less");
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275property("disabled", !ctx_r2.data.settingDataList.length);
    \u0275\u0275advance(3);
    \u0275\u0275property("disabled", !ctx_r2.data.settingDataList.length);
  }
}
function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_button_43_Template(rf, ctx) {
  if (rf & 1) {
    const _r7 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 33);
    \u0275\u0275listener("click", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_button_43_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r7);
      const settingData_r5 = \u0275\u0275nextContext().$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.copyToClipboard(settingData_r5.tempData));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
}
function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_div_50_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 34)(1, "div", 35);
    \u0275\u0275element(2, "img", 36);
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "div", 37);
    \u0275\u0275elementEnd();
  }
}
function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_json_editor_51_Template(rf, ctx) {
  if (rf & 1) {
    const _r8 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "json-editor", 38);
    \u0275\u0275listener("invalidData", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_json_editor_51_Template_json_editor_invalidData_0_listener($event) {
      \u0275\u0275restoreView(_r8);
      const settingData_r5 = \u0275\u0275nextContext().$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.invalidData($event, settingData_r5));
    });
    \u0275\u0275twoWayListener("ngModelChange", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_json_editor_51_Template_json_editor_ngModelChange_0_listener($event) {
      \u0275\u0275restoreView(_r8);
      const settingData_r5 = \u0275\u0275nextContext().$implicit;
      \u0275\u0275twoWayBindingSet(settingData_r5.tempData, $event) || (settingData_r5.tempData = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const settingData_r5 = \u0275\u0275nextContext().$implicit;
    const ctx_r2 = \u0275\u0275nextContext(2);
    \u0275\u0275property("id", "editor-" + settingData_r5.settingId);
    \u0275\u0275twoWayProperty("ngModel", settingData_r5.tempData);
    \u0275\u0275property("theme", ctx_r2.theme);
  }
}
function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-expansion-panel", 14, 1);
    \u0275\u0275listener("opened", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_mat_expansion_panel_opened_0_listener() {
      const settingData_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.onPanelExpanded(settingData_r5));
    })("closed", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_mat_expansion_panel_closed_0_listener() {
      const settingData_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.onPanelClosed(settingData_r5));
    });
    \u0275\u0275elementStart(2, "mat-expansion-panel-header")(3, "mat-panel-title")(4, "span", 15);
    \u0275\u0275text(5);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(6, "mat-panel-description")(7, "span", 16);
    \u0275\u0275text(8);
    \u0275\u0275elementEnd();
    \u0275\u0275element(9, "span", 7);
    \u0275\u0275elementStart(10, "span", 17);
    \u0275\u0275text(11);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(12, "span", 18);
    \u0275\u0275text(13);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(14, "mat-menu", null, 2)(16, "button", 19)(17, "mat-icon");
    \u0275\u0275text(18, "edit");
    \u0275\u0275elementEnd();
    \u0275\u0275text(19, " Edit ");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(20, "button", 20);
    \u0275\u0275listener("click", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_button_click_20_listener() {
      const settingData_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.deleteSetting(settingData_r5));
    });
    \u0275\u0275elementStart(21, "mat-icon");
    \u0275\u0275text(22, "delete");
    \u0275\u0275elementEnd();
    \u0275\u0275text(23, " Delete ");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(24, "button", 21);
    \u0275\u0275listener("click", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_button_click_24_listener($event) {
      \u0275\u0275restoreView(_r4);
      return \u0275\u0275resetView($event.stopPropagation());
    });
    \u0275\u0275elementStart(25, "mat-icon");
    \u0275\u0275text(26, "more_vert");
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(27, "div", 22)(28, "button", 23);
    \u0275\u0275listener("click", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_button_click_28_listener() {
      const settingData_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.saveFormData(settingData_r5));
    });
    \u0275\u0275elementStart(29, "mat-icon");
    \u0275\u0275text(30, "save");
    \u0275\u0275elementEnd()();
    \u0275\u0275element(31, "span", 7);
    \u0275\u0275elementStart(32, "button", 24)(33, "mat-icon");
    \u0275\u0275text(34, "send");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(35, "button", 25);
    \u0275\u0275listener("click", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_button_click_35_listener() {
      const settingData_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.download(settingData_r5.tempData, settingData_r5.className, settingData_r5.classFullName));
    });
    \u0275\u0275elementStart(36, "mat-icon");
    \u0275\u0275text(37, "download");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(38, "button", 26);
    \u0275\u0275listener("click", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_button_click_38_listener() {
      \u0275\u0275restoreView(_r4);
      const fileInput_r6 = \u0275\u0275reference(42);
      return \u0275\u0275resetView(fileInput_r6.click());
    });
    \u0275\u0275elementStart(39, "mat-icon");
    \u0275\u0275text(40, "upload");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(41, "input", 27, 3);
    \u0275\u0275listener("change", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_input_change_41_listener($event) {
      const settingData_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.upload($event, settingData_r5));
    });
    \u0275\u0275elementEnd()();
    \u0275\u0275template(43, SettingListComponent_mat_accordion_8_mat_expansion_panel_1_button_43_Template, 3, 0, "button", 28);
    \u0275\u0275elementStart(44, "button", 29);
    \u0275\u0275listener("click", function SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template_button_click_44_listener() {
      const settingData_r5 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.triggerFormat("editor-" + settingData_r5.settingId));
    });
    \u0275\u0275elementStart(45, "mat-icon");
    \u0275\u0275text(46, "text_fields");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(47, "button", 30)(48, "mat-icon");
    \u0275\u0275text(49, "history");
    \u0275\u0275elementEnd()()();
    \u0275\u0275template(50, SettingListComponent_mat_accordion_8_mat_expansion_panel_1_div_50_Template, 4, 0, "div", 31)(51, SettingListComponent_mat_accordion_8_mat_expansion_panel_1_json_editor_51_Template, 1, 3, "json-editor", 32);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const settingData_r5 = ctx.$implicit;
    const menu_r9 = \u0275\u0275reference(15);
    const ctx_r2 = \u0275\u0275nextContext(2);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(settingData_r5.className);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1("v", settingData_r5.version, "");
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(settingData_r5.computedIdentifier);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(settingData_r5.classNamespace);
    \u0275\u0275advance(3);
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction3(13, _c32, settingData_r5.slug, ctx_r2.data.selectedAppIdentifierId, settingData_r5.settingId));
    \u0275\u0275advance(8);
    \u0275\u0275property("matMenuTriggerFor", menu_r9);
    \u0275\u0275advance(4);
    \u0275\u0275property("disabled", ctx_r2.buttons[settingData_r5.settingId]);
    \u0275\u0275advance(4);
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction3(17, _c42, settingData_r5.slug, ctx_r2.data.selectedAppIdentifierId, settingData_r5.settingId));
    \u0275\u0275advance(11);
    \u0275\u0275property("ngIf", ctx_r2.isConnectionSecure);
    \u0275\u0275advance(4);
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction3(21, _c52, settingData_r5.slug, ctx_r2.data.selectedAppIdentifierId, settingData_r5.settingId))("disabled", !settingData_r5.dataRestored && settingData_r5.version === "0");
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", ctx_r2.settingIdToLoading[settingData_r5.settingId]);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", settingData_r5.isDataFetched);
  }
}
function SettingListComponent_mat_accordion_8_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-accordion", 12);
    \u0275\u0275template(1, SettingListComponent_mat_accordion_8_mat_expansion_panel_1_Template, 52, 25, "mat-expansion-panel", 13);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275property("multi", ctx_r2.multiSelectionEnabled);
    \u0275\u0275advance();
    \u0275\u0275property("ngForOf", ctx_r2.data.settingDataList);
  }
}
function SettingListComponent_ng_template_9_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "p", 39);
    \u0275\u0275text(1, "No results found.");
    \u0275\u0275elementEnd();
  }
}
var _SettingListComponent = class _SettingListComponent {
  constructor(dialog, snackBar, utilityService, settingsService, appViewService, settingHistoriesService, themeService, windowService, cdr, route, router) {
    this.dialog = dialog;
    this.snackBar = snackBar;
    this.utilityService = utilityService;
    this.settingsService = settingsService;
    this.appViewService = appViewService;
    this.settingHistoriesService = settingHistoriesService;
    this.themeService = themeService;
    this.windowService = windowService;
    this.cdr = cdr;
    this.route = route;
    this.router = router;
    this.copySettingToIdentifierEmitter = new EventEmitter();
    this.settingDeleteEmitter = new EventEmitter();
    this.fetchLatestEmitter = new EventEmitter();
    this.buttons = {};
    this.multiSelectionEnabled = false;
    this.subscriptions = new Subscription();
    this.selectedSettingId = void 0;
    this.settingIdToLoading = {};
  }
  ngOnInit() {
    this.subscriptions.add(this.appViewService.appViewMultiSelectionEnabled$.subscribe((isEnabled) => {
      this.multiSelectionEnabled = isEnabled;
    }));
    this.theme = this.themeService.isDarkTheme() ? "vs-dark" : "vs-light";
    this.isConnectionSecure = this.windowService.isConnectionSecure;
  }
  ngAfterViewInit() {
    setTimeout(() => {
      const onSettingIdChange = this.appViewService.settingView$.subscribe((settingView) => {
        if (!settingView) {
          return;
        }
        const selectedSettingId = settingView.selectedSettingId;
        switch (settingView.settingViewType) {
          case "viewSetting":
            if (!selectedSettingId) {
              return;
            }
            const settingIndex = this.data.settingDataList.findIndex((s) => s.settingId == selectedSettingId);
            this.expandPanel(settingIndex);
            this.selectedSettingId = selectedSettingId;
            break;
          case "viewCreateSetting":
            this.addSetting();
            break;
          case "viewUpdateSetting":
            if (!selectedSettingId) {
              return;
            }
            const settingForUpdate = this.data.settingDataList.find((s) => s.settingId == selectedSettingId);
            if (settingForUpdate) {
              this.editSetting(settingForUpdate);
            }
            break;
          case "viewCopySettingTo":
            if (!selectedSettingId) {
              return;
            }
            const settingIndexForCopyTo = this.data.settingDataList.findIndex((s) => s.settingId == selectedSettingId);
            if (settingIndexForCopyTo !== -1) {
              this.expandPanel(settingIndexForCopyTo);
              const settingForCopyTo = this.data.settingDataList[settingIndexForCopyTo];
              this.copySettingToIdentifierEmit(settingForCopyTo);
            }
            break;
          case "viewSettingHistories":
            if (!selectedSettingId) {
              return;
            }
            const settingIndexForHistories = this.data.settingDataList.findIndex((s) => s.settingId == selectedSettingId);
            if (settingIndexForHistories !== -1) {
              this.expandPanel(settingIndexForHistories);
              const settingForHistories = this.data.settingDataList[settingIndexForHistories];
              const isDisabled = !settingForHistories.dataRestored && settingForHistories.version === "0";
              if (isDisabled) {
                return;
              }
              this.history(settingForHistories);
            }
            break;
          case "viewSettingHistory":
            if (!selectedSettingId) {
              return;
            }
            const settingIndexForHistory = this.data.settingDataList.findIndex((s) => s.settingId == selectedSettingId);
            if (settingIndexForHistory !== -1) {
              this.expandPanel(settingIndexForHistory);
              const settingForHistory = this.data.settingDataList[settingIndexForHistory];
              const isDisabled = !settingForHistory.dataRestored && settingForHistory.version === "0";
              if (isDisabled) {
                return;
              }
              this.history(settingForHistory);
            }
        }
      });
      this.subscriptions.add(onSettingIdChange);
    }, 0);
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  onToggleMultiSelection(event) {
    this.appViewService.emitAppViewMultiSelectionEnabled(event.checked);
  }
  expandPanel(index) {
    if (index < 0) {
      return;
    }
    const panelArray = this.expansionPanels?.toArray();
    if (panelArray && panelArray[index]) {
      panelArray[index].open();
    }
  }
  onPanelClosed(data) {
    if (this.selectedSettingId === data.settingId) {
      this.selectedSettingId = void 0;
      this.appViewService.emitSettingView(void 0);
      this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
    }
  }
  onPanelExpanded(data) {
    this.settingIdToLoading[data.settingId] = !data.isDataFetched;
    this.selectedSettingId = data.settingId;
    const settingViewType = this.appViewService.settingView?.settingViewType;
    const forbiddenTypes = ["viewCopySettingTo", "viewSettingHistories", "viewSettingHistory"];
    if (settingViewType === void 0 || !forbiddenTypes.includes(settingViewType)) {
      this.appViewService.emitSettingView({
        selectedSettingId: data.settingId,
        settingViewType: "viewSetting"
      });
      this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings", this.selectedSettingId], { relativeTo: this.route, queryParamsHandling: "merge" });
    }
    if (data.isDataFetched) {
      return;
    }
    this.buttons[data.settingId] = true;
    const subscription = this.settingsService.getSettingData({
      settingId: data.settingId
    }).subscribe({
      next: (response) => {
        const model = this.data.settingDataList.find((m) => m.classId === data.classId);
        if (!model) {
          return;
        }
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        model.rawData = responseData.data;
        try {
          model.parsedData = JSON.parse(responseData.data);
        } catch {
          model.parsedData = {};
        }
        model.tempData = __spreadValues({}, model.parsedData);
        model.isDataFetched = true;
        this.settingIdToLoading[data.settingId] = false;
      },
      error: (err) => {
        this.settingIdToLoading[data.settingId] = false;
      }
    });
    this.subscriptions.add(subscription);
  }
  copyToClipboard(tempData) {
    const value = JSON.stringify(tempData, null, 4);
    this.utilityService.copyToClipboard(value);
  }
  download(tempData, className, classFullName) {
    const value = JSON.stringify(tempData, null, 4);
    this.utilityService.download(value, className);
  }
  upload(event, data) {
    this.utilityService.upload(event.target.files[0]).then((content) => {
      const parsedData = JSON.parse(content);
      if (typeof parsedData === "object" && parsedData !== null) {
        data.tempData = parsedData;
      } else {
        throw "Invalid JSON data";
      }
      this.snackBar.open(`Changes applied. Click Save icon to confirm.`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 5e3
      });
      this.buttons[data.settingId] = false;
    }).catch((error) => {
      this.snackBar.open(`Error occurred while uploading file. Error: ${error}`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 8e3
      });
    });
  }
  saveFormData(data) {
    try {
      this.buttons[data.settingId] = true;
      const rawTextareaContent = JSON.stringify(data.tempData);
      if (rawTextareaContent === data.rawData) {
        this.snackBar.open(`There are no changes!`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.buttons[data.settingId] = true;
        return;
      }
      const updateSettingModel = {
        data: rawTextareaContent,
        rowVersion: data.settingRowVersion
      };
      const subscription = this.settingsService.updateSettingData({
        settingId: data.settingId,
        body: updateSettingModel
      }).subscribe({
        next: (response) => {
          const responseData = response.data;
          if (!responseData) {
            if (response.extras) {
              this.buttons[data.settingId] = false;
              const conflictedData = response.extras["Conflicts"][data.settingId];
              const availableReturnTypes = ["Discard", "Fetch Latest"];
              const conflictResolverDialogComponent = this.dialog.open(ConflictResolverDialogComponent, {
                width: "400px",
                data: availableReturnTypes,
                autoFocus: false
              }).afterClosed().subscribe((type) => {
                if (type === "Fetch Latest") {
                  this.fetchLatestEmitter.emit(data.settingId);
                }
              });
              this.subscriptions.add(conflictResolverDialogComponent);
            }
            this.buttons[data.settingId] = false;
            return;
          }
          data.parsedData = __spreadValues({}, data.tempData);
          data.rawData = rawTextareaContent;
          data.version = responseData.setting.currentVersion;
          data.settingRowVersion = responseData.setting.rowVersion;
          this.snackBar.open(`Data has been updated successfully!`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 5e3
          });
        },
        error: (err) => {
          this.buttons[data.settingId] = false;
        }
      });
      this.subscriptions.add(subscription);
    } catch (err) {
      this.snackBar.open(`Error occurred when deserializing settings data!`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 5e3
      });
      this.buttons[data.settingId] = false;
    }
  }
  history(setting) {
    const subscription = this.settingHistoriesService.getSettingHistories({
      settingId: setting.settingId
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        const data = {
          clientName: this.data.clientName,
          identifierName: this.data.selectedAppIdentifierName,
          clientId: setting.clientId,
          settingId: setting.settingId,
          className: setting.className,
          classFullName: setting.classFullName,
          computedIdentifier: setting.computedIdentifier,
          currentVersion: setting.version,
          tempData: setting.tempData,
          currentRawData: setting.rawData,
          currentParsedData: setting.parsedData,
          rowVersion: setting.settingRowVersion,
          model: responseData
        };
        const internalSubscription = this.dialog.open(SettingHistoryListComponent, {
          data,
          width: "1350px",
          height: "680px",
          minWidth: "inherit",
          maxWidth: "inherit",
          autoFocus: false
        }).afterClosed().subscribe((result) => {
          if (result) {
            if (result.fetchLatest) {
              this.fetchLatestEmitter.emit(setting.settingId);
            }
            this.buttons[data.settingId] = false;
          }
          const settingIndex = this.data.settingDataList.findIndex((s) => s.settingId == setting.settingId);
          const panelArray = this.expansionPanels?.toArray();
          if (panelArray && panelArray[settingIndex]) {
            const isExpanded = panelArray[settingIndex].expanded;
            if (isExpanded) {
              this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings", setting.settingId], { relativeTo: this.route, queryParamsHandling: "merge" });
            } else {
              this.appViewService.emitSettingView({
                settingViewType: "viewSetting",
                selectedSettingId: void 0
              });
              this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
            }
          }
        });
        this.subscriptions.add(internalSubscription);
      }
    });
    this.subscriptions.add(subscription);
  }
  expandAll() {
    const settingIds = this.data.settingDataList.filter((s) => !s.isDataFetched).map((s) => s.settingId);
    if (settingIds.length < 2) {
      this.accordion.openAll();
    }
    settingIds.forEach((settingId) => {
      this.buttons[settingId] = true;
    });
    const subscription = this.settingsService.getSettingsData({
      appId: this.data.appId,
      identifierId: this.data.selectedAppIdentifierId,
      ids: settingIds
    }).subscribe((response) => {
      const data = response.data;
      if (!data) {
        return;
      }
      data.settings.forEach((d) => {
        const settingData = this.data.settingDataList.find((s) => s.settingId == d.id);
        if (settingData) {
          settingData.rawData = d.data;
          try {
            settingData.parsedData = JSON.parse(d.data);
          } catch {
            settingData.parsedData = {};
          }
          settingData.tempData = __spreadValues({}, settingData.parsedData);
          settingData.isDataFetched = true;
        }
      });
      this.accordion.openAll();
    });
    this.subscriptions.add(subscription);
  }
  collapseAll() {
    this.accordion.closeAll();
  }
  editSetting(model) {
    const data = {
      id: model.settingId,
      clientId: this.data.clientId,
      clientName: this.data.clientName,
      identifierName: this.data.selectedAppIdentifierName,
      classNamespace: model.classNamespace,
      className: model.className,
      classFullName: model.classFullName,
      computedIdentifier: model.computedIdentifier,
      isDataValidationEnabled: model.dataValidationEnabled,
      settingRowVersion: model.settingRowVersion,
      classRowVersion: model.classRowVersion,
      storeInSeparateFile: model.storeInSeparateFile,
      ignoreOnFileChange: model.ignoreOnFileChange,
      registrationMode: model.registrationMode
    };
    const subscription = this.dialog.open(SettingUpdateComponent, {
      data,
      width: "820px",
      height: "580px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    }).afterClosed().subscribe((result) => {
      if (result) {
        if (result.type === "Fetch Latest") {
          this.fetchLatestEmitterForSettingUpdate(model.settingId);
        } else {
          model.classNamespace = result.classNamespace;
          model.className = result.className;
          model.classFullName = result.classFullName;
          model.computedIdentifier = result.computedIdentifier;
          model.dataValidationEnabled = result.isDataValidationEnabled;
          model.settingRowVersion = result.rowVersion;
          model.classRowVersion = result.rowVersion;
          model.storeInSeparateFile = result.storeInSeparateFile;
          model.ignoreOnFileChange = result.ignoreOnFileChange;
          model.registrationMode = result.registrationMode;
          if (result.type === "Override") {
            this.fetchLatestEmitter.emit(model.settingId);
          }
        }
      }
      const settingIndex = this.data.settingDataList.findIndex((s) => s.settingId == model.settingId);
      const panelArray = this.expansionPanels?.toArray();
      if (panelArray && panelArray[settingIndex]) {
        const isExpanded = panelArray[settingIndex].expanded;
        if (isExpanded) {
          this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings", model.settingId], { relativeTo: this.route, queryParamsHandling: "merge" });
        } else {
          this.appViewService.emitSettingView({
            settingViewType: "viewSetting",
            selectedSettingId: void 0
          });
          this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  addSetting() {
    const data = {
      appId: this.data.appId,
      clientName: this.data.clientName,
      clientId: this.data.clientId,
      identifierName: this.data.selectedAppIdentifierName,
      identifierId: this.data.selectedAppIdentifierId
    };
    const subscription = this.dialog.open(SettingCreateComponent, {
      data,
      width: "1350px",
      height: "680px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    }).afterClosed().subscribe((result) => {
      if (result) {
        const settingData = {
          slug: this.data.slug,
          clientId: this.data.clientId,
          settingId: result.id,
          className: result.className,
          classNamespace: result.classNamespace,
          classFullName: result.classFullName,
          classId: result.classId,
          computedIdentifier: result.computedIdentifier,
          version: result.version,
          isDataFetched: true,
          dataRestored: false,
          dataValidationEnabled: true,
          rawData: result.rawData,
          parsedData: result.parsedData,
          tempData: __spreadValues({}, result.parsedData),
          settingRowVersion: "",
          classRowVersion: "",
          storeInSeparateFile: result.storeInSeparateFile,
          ignoreOnFileChange: result.ignoreOnFileChange,
          registrationMode: result.registrationMode
        };
        this.data.settingDataList.push(settingData);
        this.cdr.detectChanges();
        this.selectedSettingId = result.id;
      }
      this.appViewService.emitSettingView({
        selectedSettingId: this.selectedSettingId,
        settingViewType: "viewSetting"
      });
      if (this.selectedSettingId) {
        this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings", this.selectedSettingId], { relativeTo: this.route, queryParamsHandling: "merge" });
      } else {
        this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
      }
    });
    this.subscriptions.add(subscription);
  }
  deleteSetting(model) {
    const title = "Confirm delete";
    const message = `Are you sure you want to delete the "${model.className}" named setting? This will also delete all associated setting histories. This action cannot be undone.`;
    const requireConfirmation = true;
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: { title, message, requireConfirmation }
    }).afterClosed().subscribe((result) => {
      if (result) {
        const internalSubscription = this.settingsService.deleteSetting({
          settingId: model.settingId,
          rowVersion: model.settingRowVersion
        }).subscribe(() => {
          this.data.settingDataList = this.data.settingDataList.filter((a) => a.settingId !== model.settingId);
          this.snackBar.open(`Deleted successfully!`, "Close", {
            horizontalPosition: "right",
            verticalPosition: "top",
            duration: 5e3
          });
          this.settingDeleteEmitter.emit(model.settingId);
          this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        });
        this.subscriptions.add(internalSubscription);
      }
    });
    this.subscriptions.add(subscription);
  }
  copySettingToIdentifierEmit(model) {
    const settingIndex = this.data.settingDataList.findIndex((s) => s.settingId == model.settingId);
    const panelArray = this.expansionPanels?.toArray();
    let expanded = false;
    if (panelArray && panelArray[settingIndex]) {
      expanded = panelArray[settingIndex].expanded;
    }
    const copySettingToIdentifierEmitData = {
      rawData: model.rawData,
      parsedData: model.parsedData,
      currentSettingId: model.settingId,
      currentAppIdentifierId: this.data.selectedAppIdentifierId,
      currentAppIdentifierName: this.data.selectedAppIdentifierName,
      computedIdentifier: model.computedIdentifier,
      className: model.className,
      classNamespace: model.classNamespace,
      classFullName: model.classFullName,
      isDataValidationEnabled: model.dataValidationEnabled,
      isExpanded: expanded,
      storeInSeparateFile: model.storeInSeparateFile,
      ignoreOnFileChange: model.ignoreOnFileChange,
      registrationMode: model.registrationMode
    };
    this.copySettingToIdentifierEmitter.emit(copySettingToIdentifierEmitData);
  }
  invalidData(invalid, model) {
    this.buttons[model.settingId] = invalid;
  }
  fetchLatestEmitterForSettingUpdate(settingId) {
    this.fetchLatestEmitter.emit(settingId);
    setTimeout(() => {
      const setting = this.data.settingDataList.find((s) => s.settingId == settingId);
      if (setting) {
        this.router.navigate(["./apps", this.data.slug, this.data.selectedAppIdentifierId, "settings", settingId, "update"], { relativeTo: this.route, queryParamsHandling: "merge" });
      }
    }, 1e3);
  }
  triggerFormat(editorId) {
    this.jsonEditors?.find((editor) => editor.id === editorId)?.formatCode();
  }
};
_SettingListComponent.\u0275fac = function SettingListComponent_Factory(t) {
  return new (t || _SettingListComponent)(\u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(SettingsService), \u0275\u0275directiveInject(AppViewService), \u0275\u0275directiveInject(SettingHistoriesService), \u0275\u0275directiveInject(ThemeService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ActivatedRoute), \u0275\u0275directiveInject(Router));
};
_SettingListComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _SettingListComponent, selectors: [["setting-list"]], viewQuery: function SettingListComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(MatAccordion, 5);
    \u0275\u0275viewQuery(_c014, 5);
    \u0275\u0275viewQuery(_c17, 5);
    \u0275\u0275viewQuery(JsonEditorComponent, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.accordion = _t.first);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.textareas = _t);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.expansionPanels = _t);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.jsonEditors = _t);
  }
}, inputs: { data: "data" }, outputs: { copySettingToIdentifierEmitter: "copySettingToIdentifierEmitter", settingDeleteEmitter: "settingDeleteEmitter", fetchLatestEmitter: "fetchLatestEmitter" }, decls: 11, vars: 9, consts: [["noData", ""], ["expansionPanel", ""], ["menu", "matMenu"], ["fileInput", ""], [1, "d-flex", "min-height-50"], [4, "ngIf"], [1, "d-flex", "ml-2", 3, "ngModelChange", "change", "ngModel"], [1, "spacer"], ["mat-icon-button", "", "matTooltip", "Add setting", "matTooltipPosition", "above", "queryParamsHandling", "merge", 3, "routerLink", "disabled"], [3, "multi", 4, "ngIf", "ngIfElse"], ["mat-icon-button", "", "matTooltip", "Expand All", 3, "click", "disabled"], ["mat-icon-button", "", "matTooltip", "Collapse All", 3, "click", "disabled"], [3, "multi"], [3, "opened", "closed", 4, "ngFor", "ngForOf"], [3, "opened", "closed"], ["matTooltip", "Name"], ["matTooltip", "Version"], ["matTooltip", "Computed Identifier", 1, "fs-x-small", "pr-3"], ["matTooltip", "Namespace", 1, "fs-x-small", "pr-1"], ["mat-menu-item", "", "queryParamsHandling", "merge", 3, "routerLink"], ["mat-menu-item", "", 3, "click"], ["mat-icon-button", "", 1, "icon-mini", 3, "click", "matMenuTriggerFor"], [1, "d-flex"], ["mat-button", "", "matTooltip", "Save", "color", "primary", 3, "click", "disabled"], ["mat-button", "", "matTooltip", "Copy setting to", "color", "primary", "queryParamsHandling", "merge", 3, "routerLink"], ["mat-button", "", "matTooltip", "Download", "color", "primary", 3, "click"], ["mat-button", "", "matTooltip", "Upload", "color", "primary", 3, "click"], ["type", "file", "accept", ".json,.txt", 1, "d-none", 3, "change"], ["mat-button", "", "matTooltip", "Copy", "color", "primary", 3, "click", 4, "ngIf"], ["mat-button", "", "matTooltip", "Format (Shift+Alt+F)", "color", "primary", 3, "click"], ["mat-button", "", "matTooltip", "History", "color", "primary", "queryParamsHandling", "merge", 3, "routerLink", "disabled"], ["class", "loading-container", 4, "ngIf"], [3, "id", "ngModel", "theme", "invalidData", "ngModelChange", 4, "ngIf"], ["mat-button", "", "matTooltip", "Copy", "color", "primary", 3, "click"], [1, "loading-container"], [1, "mat-bg-primary", "position-absolute", "rounded-circle", "app-icon-animation"], [1, "app-icon", "bg-white"], [1, "loading-spinner"], [3, "invalidData", "ngModelChange", "id", "ngModel", "theme"], [1, "p-2"]], template: function SettingListComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 4);
    \u0275\u0275template(1, SettingListComponent_div_1_Template, 7, 2, "div", 5);
    \u0275\u0275elementStart(2, "mat-slide-toggle", 6);
    \u0275\u0275twoWayListener("ngModelChange", function SettingListComponent_Template_mat_slide_toggle_ngModelChange_2_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.multiSelectionEnabled, $event) || (ctx.multiSelectionEnabled = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275listener("change", function SettingListComponent_Template_mat_slide_toggle_change_2_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onToggleMultiSelection($event));
    });
    \u0275\u0275text(3, "Multi selection");
    \u0275\u0275elementEnd();
    \u0275\u0275element(4, "span", 7);
    \u0275\u0275elementStart(5, "button", 8)(6, "mat-icon");
    \u0275\u0275text(7, "add");
    \u0275\u0275elementEnd()()();
    \u0275\u0275template(8, SettingListComponent_mat_accordion_8_Template, 2, 2, "mat-accordion", 9)(9, SettingListComponent_ng_template_9_Template, 2, 0, "ng-template", null, 0, \u0275\u0275templateRefExtractor);
  }
  if (rf & 2) {
    const noData_r10 = \u0275\u0275reference(10);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.multiSelectionEnabled);
    \u0275\u0275advance();
    \u0275\u0275twoWayProperty("ngModel", ctx.multiSelectionEnabled);
    \u0275\u0275advance(3);
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction2(6, _c23, ctx.data.slug, ctx.data.selectedAppIdentifierId))("disabled", !ctx.data.selectedAppIdentifierId);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", ctx.data.settingDataList.length)("ngIfElse", noData_r10);
  }
}, dependencies: [NgForOf, NgIf, NgControlStatus, NgModel, RouterLink, JsonEditorComponent, MatIcon, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatExpansionPanelDescription, MatMenu, MatMenuItem, MatMenuTrigger, MatButton, MatIconButton, MatTooltip, MatSlideToggle], encapsulation: 2 });
var SettingListComponent = _SettingListComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(SettingListComponent, { className: "SettingListComponent", filePath: "src\\app\\features\\setting\\components\\setting-list\\setting-list.component.ts", lineNumber: 34 });
})();

// src/app/shared/models/service-type.ts
var ServiceType;
(function(ServiceType2) {
  ServiceType2[ServiceType2["Provider"] = 1] = "Provider";
  ServiceType2[ServiceType2["Consumer"] = 2] = "Consumer";
})(ServiceType || (ServiceType = {}));

// src/app/shared/models/data-access-type.ts
var DataAccessType;
(function(DataAccessType2) {
  DataAccessType2[DataAccessType2["Orm"] = 1] = "Orm";
})(DataAccessType || (DataAccessType = {}));

// src/app/shared/models/reload-strategy.ts
var ReloadStrategy;
(function(ReloadStrategy2) {
  ReloadStrategy2[ReloadStrategy2["Polling"] = 1] = "Polling";
  ReloadStrategy2[ReloadStrategy2["Redis"] = 2] = "Redis";
})(ReloadStrategy || (ReloadStrategy = {}));

// src/app/features/instance/services/instances.service.ts
var _InstancesService = class _InstancesService {
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
  deleteInstance(request) {
    const url = this.route + "/v1/instances/" + request.instanceId;
    return this.httpClient.delete(url, { headers: this.headers });
  }
  getInstancesByAppId(request) {
    let url = this.route + "/v1/apps/" + request.appIdOrSlug + "/instances";
    let params = new HttpParams();
    if (request.identifierId !== void 0) {
      params = params.append("identifierId", request.identifierId);
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getInstancesByAppBySlug(request) {
    let url = this.route + "/v1/apps/slug/" + request.appIdOrSlug + "/instances";
    let params = new HttpParams();
    if (request.identifierId !== void 0) {
      params = params.append("identifierId", request.identifierId);
    }
    const queryParams = params.toString();
    url += queryParams ? "?" + queryParams : "";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getInstancesByAppIdAndIdentifierId(request) {
    let url = this.route + "/v1/apps/" + request.appIdOrSlug + "/identifiers/" + request.identifierId + "/instances";
    return this.httpClient.get(url, { headers: this.headers });
  }
  getInstancesByAppSlugAndIdentifierSlug(request) {
    let url = this.route + "/v1/apps/slug/" + request.appIdOrSlug + "/identifiers/" + request.identifierId + "/instances";
    return this.httpClient.get(url, { headers: this.headers });
  }
};
_InstancesService.\u0275fac = function InstancesService_Factory(t) {
  return new (t || _InstancesService)(\u0275\u0275inject(HttpClient), \u0275\u0275inject(AuthService), \u0275\u0275inject(WindowService));
};
_InstancesService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _InstancesService, factory: _InstancesService.\u0275fac, providedIn: "root" });
var InstancesService = _InstancesService;

// src/app/features/instance/components/instance-list/instance-list.component.ts
function InstanceListComponent_div_1_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div")(1, "button", 6);
    \u0275\u0275listener("click", function InstanceListComponent_div_1_Template_button_click_1_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.expandAll());
    });
    \u0275\u0275elementStart(2, "mat-icon");
    \u0275\u0275text(3, "expand_more");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "button", 7);
    \u0275\u0275listener("click", function InstanceListComponent_div_1_Template_button_click_4_listener() {
      \u0275\u0275restoreView(_r2);
      const ctx_r2 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r2.collapseAll());
    });
    \u0275\u0275elementStart(5, "mat-icon");
    \u0275\u0275text(6, "expand_less");
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275property("disabled", ctx_r2.data.instances === void 0 || ctx_r2.data.instances.length === 0);
    \u0275\u0275advance(3);
    \u0275\u0275property("disabled", ctx_r2.data.instances === void 0 || ctx_r2.data.instances.length === 0);
  }
}
function InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_button_11_Template(rf, ctx) {
  if (rf & 1) {
    const _r5 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 20);
    \u0275\u0275listener("click", function InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_button_11_Template_button_click_0_listener($event) {
      \u0275\u0275restoreView(_r5);
      const data_r6 = \u0275\u0275nextContext().$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.copyToClipboard(data_r6.dynamicId, $event));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
}
function InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_tr_16_mat_list_item_5_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-list-item")(1, "span");
    \u0275\u0275text(2);
    \u0275\u0275elementStart(3, "a", 22)(4, "button", 23)(5, "mat-icon");
    \u0275\u0275text(6, "open_in_new");
    \u0275\u0275elementEnd()()()()();
  }
  if (rf & 2) {
    const url_r7 = ctx.$implicit;
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate1(" ", url_r7, " ");
    \u0275\u0275advance();
    \u0275\u0275property("href", url_r7, \u0275\u0275sanitizeUrl);
  }
}
function InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_tr_16_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "tr")(1, "td", 16);
    \u0275\u0275text(2, "Urls:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "td", 17)(4, "mat-list", 21);
    \u0275\u0275template(5, InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_tr_16_mat_list_item_5_Template, 7, 2, "mat-list-item", 9);
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const data_r6 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275advance(5);
    \u0275\u0275property("ngForOf", data_r6.urls);
  }
}
function InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_tr_47_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "tr")(1, "td", 16);
    \u0275\u0275text(2, "Data access type:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "td", 17);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const data_r6 = \u0275\u0275nextContext().$implicit;
    const ctx_r2 = \u0275\u0275nextContext(2);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate(ctx_r2.getDataAccessType(data_r6.dataAccessType));
  }
}
function InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-expansion-panel")(1, "mat-expansion-panel-header")(2, "mat-panel-title")(3, "span", 10);
    \u0275\u0275text(4);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(5, "mat-panel-description")(6, "span", 11);
    \u0275\u0275text(7);
    \u0275\u0275elementEnd();
    \u0275\u0275element(8, "span", 4);
    \u0275\u0275elementStart(9, "span", 12);
    \u0275\u0275text(10);
    \u0275\u0275template(11, InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_button_11_Template, 3, 0, "button", 13);
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(12, "mat-card", 14)(13, "mat-card-content")(14, "table", 15)(15, "tbody");
    \u0275\u0275template(16, InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_tr_16_Template, 6, 1, "tr", 2);
    \u0275\u0275elementStart(17, "tr")(18, "td", 16);
    \u0275\u0275text(19, "Instance status:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(20, "td", 17);
    \u0275\u0275text(21);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(22, "tr")(23, "td", 16);
    \u0275\u0275text(24, "Ip Address:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(25, "td", 17);
    \u0275\u0275text(26);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(27, "tr")(28, "td", 16);
    \u0275\u0275text(29, "Machine name:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(30, "td", 17);
    \u0275\u0275text(31);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(32, "tr")(33, "td", 16);
    \u0275\u0275text(34, "Environment:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(35, "td", 17);
    \u0275\u0275text(36);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(37, "tr")(38, "td", 16);
    \u0275\u0275text(39, "Reload strategies:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(40, "td", 17);
    \u0275\u0275text(41);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(42, "tr")(43, "td", 16);
    \u0275\u0275text(44, "Service type:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(45, "td", 17);
    \u0275\u0275text(46);
    \u0275\u0275elementEnd()();
    \u0275\u0275template(47, InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_tr_47_Template, 5, 1, "tr", 2);
    \u0275\u0275elementStart(48, "tr")(49, "td", 16);
    \u0275\u0275text(50, "Created on:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(51, "td", 17);
    \u0275\u0275text(52);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(53, "tr")(54, "td", 16);
    \u0275\u0275text(55, "Updated on:");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(56, "td", 17);
    \u0275\u0275text(57);
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(58, "div", 18);
    \u0275\u0275element(59, "span", 4);
    \u0275\u0275elementStart(60, "button", 19);
    \u0275\u0275listener("click", function InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_Template_button_click_60_listener() {
      const data_r6 = \u0275\u0275restoreView(_r4).$implicit;
      const ctx_r2 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r2.delete(data_r6));
    });
    \u0275\u0275text(61, "Delete");
    \u0275\u0275elementEnd()()()()();
  }
  if (rf & 2) {
    const data_r6 = ctx.$implicit;
    const ctx_r2 = \u0275\u0275nextContext(2);
    \u0275\u0275advance(4);
    \u0275\u0275textInterpolate(data_r6.name);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1("v", data_r6.version, "");
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1("", data_r6.dynamicId, " ");
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r2.isConnectionSecure);
    \u0275\u0275advance(5);
    \u0275\u0275property("ngIf", data_r6.urls);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(data_r6.isActive ? "Active" : "Inactive");
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(data_r6.ipAddress || "-");
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(data_r6.machineName);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(data_r6.environment);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(ctx_r2.getReloadStrategies(data_r6.reloadStrategies));
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(ctx_r2.getServiceType(data_r6.serviceType));
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", data_r6.dataAccessType);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(data_r6.createdOn);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(data_r6.updatedOn);
  }
}
function InstanceListComponent_mat_accordion_5_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-accordion", 8);
    \u0275\u0275template(1, InstanceListComponent_mat_accordion_5_mat_expansion_panel_1_Template, 62, 14, "mat-expansion-panel", 9);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275advance();
    \u0275\u0275property("ngForOf", ctx_r2.data.instances);
  }
}
function InstanceListComponent_ng_template_6_p_0_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "p", 25);
    \u0275\u0275text(1, "No results found.");
    \u0275\u0275elementEnd();
  }
}
function InstanceListComponent_ng_template_6_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275template(0, InstanceListComponent_ng_template_6_p_0_Template, 2, 0, "p", 24);
  }
  if (rf & 2) {
    const ctx_r2 = \u0275\u0275nextContext();
    \u0275\u0275property("ngIf", ctx_r2.data.instances !== void 0);
  }
}
var _InstanceListComponent = class _InstanceListComponent {
  constructor(instancesService, utilityService, windowService, dialog, appViewService) {
    this.instancesService = instancesService;
    this.utilityService = utilityService;
    this.windowService = windowService;
    this.dialog = dialog;
    this.appViewService = appViewService;
    this.multiSelectionEnabled = false;
    this.subscriptions = new Subscription();
    this.instanceDeleteEmitter = new EventEmitter();
  }
  ngOnInit() {
    this.subscriptions.add(this.appViewService.appViewMultiSelectionEnabled$.subscribe((isEnabled) => {
      this.multiSelectionEnabled = isEnabled;
    }));
    this.isConnectionSecure = this.windowService.isConnectionSecure;
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  onToggleMultiSelection(event) {
    this.appViewService.emitAppViewMultiSelectionEnabled(event.checked);
  }
  copyToClipboard(content, event) {
    event.stopPropagation();
    this.utilityService.copyToClipboard(content);
  }
  delete(data) {
    const title = "Confirm delete";
    const message = `Is "${data.name}" instance no longer active? You can delete it, and it will be re-created upon restart if it exists.`;
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: { title, message }
    }).afterClosed().subscribe((result) => {
      if (result) {
        const internalSubscription = this.instancesService.deleteInstance({
          instanceId: data.id
        }).subscribe(() => {
          const instance = this.data.instances.findIndex((i) => i.id === data.id);
          this.data.instances.splice(instance, 1);
          this.instanceDeleteEmitter.emit(data.id);
        });
        this.subscriptions.add(internalSubscription);
      }
    });
    this.subscriptions.add(subscription);
  }
  expandAll() {
    this.accordion.openAll();
  }
  collapseAll() {
    this.accordion.closeAll();
  }
  getServiceType(serviceType) {
    return ServiceType[serviceType];
  }
  getDataAccessType(dataAccessType) {
    return DataAccessType[dataAccessType];
  }
  getReloadStrategies(reloadStrategies) {
    return reloadStrategies.map((r) => ReloadStrategy[r]).join(", ");
  }
};
_InstanceListComponent.\u0275fac = function InstanceListComponent_Factory(t) {
  return new (t || _InstanceListComponent)(\u0275\u0275directiveInject(InstancesService), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(AppViewService));
};
_InstanceListComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _InstanceListComponent, selectors: [["instance-list"]], viewQuery: function InstanceListComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(MatAccordion, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.accordion = _t.first);
  }
}, inputs: { data: "data" }, outputs: { instanceDeleteEmitter: "instanceDeleteEmitter" }, decls: 8, vars: 4, consts: [["noData", ""], [1, "d-flex", "min-height-50"], [4, "ngIf"], [1, "d-flex", "ml-2", 3, "ngModelChange", "change", "ngModel"], [1, "spacer"], ["multi", "", 4, "ngIf", "ngIfElse"], ["mat-icon-button", "", "matTooltip", "Expand All", 3, "click", "disabled"], ["mat-icon-button", "", "matTooltip", "Collapse All", 3, "click", "disabled"], ["multi", ""], [4, "ngFor", "ngForOf"], ["matTooltip", "Name"], ["matTooltip", "App Version"], ["matTooltip", "Dynamic Id", 1, "fs-x-small"], ["mat-icon-button", "", "class", "icon-mini", "color", "primary", 3, "click", 4, "ngIf"], [1, "info-card"], [1, "custom-mat-table"], [1, "custom-mat-cell", "key-cell"], [1, "custom-mat-cell"], [1, "d-flex", "mt-2"], ["color", "warn", "mat-raised-button", "", 3, "click"], ["mat-icon-button", "", "color", "primary", 1, "icon-mini", 3, "click"], [1, "d-grid"], ["target", "_blank", 1, "text-decoration-none", 3, "href"], ["mat-icon-button", "", "color", "primary"], ["class", "p-2", 4, "ngIf"], [1, "p-2"]], template: function InstanceListComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 1);
    \u0275\u0275template(1, InstanceListComponent_div_1_Template, 7, 2, "div", 2);
    \u0275\u0275elementStart(2, "mat-slide-toggle", 3);
    \u0275\u0275twoWayListener("ngModelChange", function InstanceListComponent_Template_mat_slide_toggle_ngModelChange_2_listener($event) {
      \u0275\u0275restoreView(_r1);
      \u0275\u0275twoWayBindingSet(ctx.multiSelectionEnabled, $event) || (ctx.multiSelectionEnabled = $event);
      return \u0275\u0275resetView($event);
    });
    \u0275\u0275listener("change", function InstanceListComponent_Template_mat_slide_toggle_change_2_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onToggleMultiSelection($event));
    });
    \u0275\u0275text(3, "Multi selection");
    \u0275\u0275elementEnd();
    \u0275\u0275element(4, "span", 4);
    \u0275\u0275elementEnd();
    \u0275\u0275template(5, InstanceListComponent_mat_accordion_5_Template, 2, 1, "mat-accordion", 5)(6, InstanceListComponent_ng_template_6_Template, 1, 1, "ng-template", null, 0, \u0275\u0275templateRefExtractor);
  }
  if (rf & 2) {
    const noData_r8 = \u0275\u0275reference(7);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.multiSelectionEnabled);
    \u0275\u0275advance();
    \u0275\u0275twoWayProperty("ngModel", ctx.multiSelectionEnabled);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", ctx.data.instances == null ? null : ctx.data.instances.length)("ngIfElse", noData_r8);
  }
}, dependencies: [NgForOf, NgIf, NgControlStatus, NgModel, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatExpansionPanelDescription, MatCard, MatCardContent, MatIcon, MatList, MatListItem, MatButton, MatIconButton, MatSlideToggle, MatTooltip], styles: ["\n\n.info-item[_ngcontent-%COMP%] {\n  display: flex;\n  align-items: center;\n  margin-bottom: 10px;\n  font-size: 15px;\n}\n.info-label[_ngcontent-%COMP%] {\n  font-weight: 500;\n  margin-right: 15px;\n  width: 150px;\n  font-size: 16px;\n}\n.info-value[_ngcontent-%COMP%]    > p[_ngcontent-%COMP%] {\n  padding-left: 16px;\n}\n/*# sourceMappingURL=instance-list.component.css.map */"] });
var InstanceListComponent = _InstanceListComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(InstanceListComponent, { className: "InstanceListComponent", filePath: "src\\app\\features\\instance\\components\\instance-list\\instance-list.component.ts", lineNumber: 23 });
})();

// node_modules/@angular/material/fesm2022/tabs.mjs
var _c015 = ["*"];
function MatTab_ng_template_0_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275projection(0);
  }
}
var _c18 = ["tabListContainer"];
var _c24 = ["tabList"];
var _c33 = ["tabListInner"];
var _c43 = ["nextPaginator"];
var _c53 = ["previousPaginator"];
var _c62 = (a0) => ({
  animationDuration: a0
});
var _c7 = (a0, a1) => ({
  value: a0,
  params: a1
});
function MatTabBody_ng_template_2_Template(rf, ctx) {
}
var _c8 = ["tabBodyWrapper"];
var _c9 = ["tabHeader"];
function MatTabGroup_For_3_Conditional_6_ng_template_0_Template(rf, ctx) {
}
function MatTabGroup_For_3_Conditional_6_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275template(0, MatTabGroup_For_3_Conditional_6_ng_template_0_Template, 0, 0, "ng-template", 12);
  }
  if (rf & 2) {
    const tab_r4 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275property("cdkPortalOutlet", tab_r4.templateLabel);
  }
}
function MatTabGroup_For_3_Conditional_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275text(0);
  }
  if (rf & 2) {
    const tab_r4 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275textInterpolate(tab_r4.textLabel);
  }
}
function MatTabGroup_For_3_Template(rf, ctx) {
  if (rf & 1) {
    const _r2 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 7, 2);
    \u0275\u0275listener("click", function MatTabGroup_For_3_Template_div_click_0_listener() {
      const ctx_r2 = \u0275\u0275restoreView(_r2);
      const tab_r4 = ctx_r2.$implicit;
      const i_r5 = ctx_r2.$index;
      const ctx_r5 = \u0275\u0275nextContext();
      const tabHeader_r7 = \u0275\u0275reference(1);
      return \u0275\u0275resetView(ctx_r5._handleClick(tab_r4, tabHeader_r7, i_r5));
    })("cdkFocusChange", function MatTabGroup_For_3_Template_div_cdkFocusChange_0_listener($event) {
      const i_r5 = \u0275\u0275restoreView(_r2).$index;
      const ctx_r5 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r5._tabFocusChanged($event, i_r5));
    });
    \u0275\u0275element(2, "span", 8)(3, "div", 9);
    \u0275\u0275elementStart(4, "span", 10)(5, "span", 11);
    \u0275\u0275template(6, MatTabGroup_For_3_Conditional_6_Template, 1, 1, null, 12)(7, MatTabGroup_For_3_Conditional_7_Template, 1, 1);
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const tab_r4 = ctx.$implicit;
    const i_r5 = ctx.$index;
    const tabNode_r8 = \u0275\u0275reference(1);
    const ctx_r5 = \u0275\u0275nextContext();
    \u0275\u0275classMap(tab_r4.labelClass);
    \u0275\u0275classProp("mdc-tab--active", ctx_r5.selectedIndex === i_r5);
    \u0275\u0275property("id", ctx_r5._getTabLabelId(i_r5))("disabled", tab_r4.disabled)("fitInkBarToContent", ctx_r5.fitInkBarToContent);
    \u0275\u0275attribute("tabIndex", ctx_r5._getTabIndex(i_r5))("aria-posinset", i_r5 + 1)("aria-setsize", ctx_r5._tabs.length)("aria-controls", ctx_r5._getTabContentId(i_r5))("aria-selected", ctx_r5.selectedIndex === i_r5)("aria-label", tab_r4.ariaLabel || null)("aria-labelledby", !tab_r4.ariaLabel && tab_r4.ariaLabelledby ? tab_r4.ariaLabelledby : null);
    \u0275\u0275advance(3);
    \u0275\u0275property("matRippleTrigger", tabNode_r8)("matRippleDisabled", tab_r4.disabled || ctx_r5.disableRipple);
    \u0275\u0275advance(3);
    \u0275\u0275conditional(6, tab_r4.templateLabel ? 6 : 7);
  }
}
function MatTabGroup_Conditional_4_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275projection(0);
  }
}
function MatTabGroup_For_8_Template(rf, ctx) {
  if (rf & 1) {
    const _r9 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-tab-body", 13);
    \u0275\u0275listener("_onCentered", function MatTabGroup_For_8_Template_mat_tab_body__onCentered_0_listener() {
      \u0275\u0275restoreView(_r9);
      const ctx_r5 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r5._removeTabBodyWrapperHeight());
    })("_onCentering", function MatTabGroup_For_8_Template_mat_tab_body__onCentering_0_listener($event) {
      \u0275\u0275restoreView(_r9);
      const ctx_r5 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r5._setTabBodyWrapperHeight($event));
    });
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const tab_r10 = ctx.$implicit;
    const i_r11 = ctx.$index;
    const ctx_r5 = \u0275\u0275nextContext();
    \u0275\u0275classMap(tab_r10.bodyClass);
    \u0275\u0275classProp("mat-mdc-tab-body-active", ctx_r5.selectedIndex === i_r11);
    \u0275\u0275property("id", ctx_r5._getTabContentId(i_r11))("content", tab_r10.content)("position", tab_r10.position)("origin", tab_r10.origin)("animationDuration", ctx_r5.animationDuration)("preserveContent", ctx_r5.preserveContent);
    \u0275\u0275attribute("tabindex", ctx_r5.contentTabIndex != null && ctx_r5.selectedIndex === i_r11 ? ctx_r5.contentTabIndex : null)("aria-labelledby", ctx_r5._getTabLabelId(i_r11))("aria-hidden", ctx_r5.selectedIndex !== i_r11);
  }
}
var _c10 = ["mat-tab-nav-bar", ""];
var _c11 = ["mat-tab-link", ""];
var MAT_TAB_CONTENT = new InjectionToken("MatTabContent");
var _MatTabContent = class _MatTabContent {
  constructor(template) {
    this.template = template;
  }
};
_MatTabContent.\u0275fac = function MatTabContent_Factory(t) {
  return new (t || _MatTabContent)(\u0275\u0275directiveInject(TemplateRef));
};
_MatTabContent.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatTabContent,
  selectors: [["", "matTabContent", ""]],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_TAB_CONTENT,
    useExisting: _MatTabContent
  }])]
});
var MatTabContent = _MatTabContent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabContent, [{
    type: Directive,
    args: [{
      selector: "[matTabContent]",
      providers: [{
        provide: MAT_TAB_CONTENT,
        useExisting: MatTabContent
      }],
      standalone: true
    }]
  }], () => [{
    type: TemplateRef
  }], null);
})();
var MAT_TAB_LABEL = new InjectionToken("MatTabLabel");
var MAT_TAB = new InjectionToken("MAT_TAB");
var _MatTabLabel = class _MatTabLabel extends CdkPortal {
  constructor(templateRef, viewContainerRef, _closestTab) {
    super(templateRef, viewContainerRef);
    this._closestTab = _closestTab;
  }
};
_MatTabLabel.\u0275fac = function MatTabLabel_Factory(t) {
  return new (t || _MatTabLabel)(\u0275\u0275directiveInject(TemplateRef), \u0275\u0275directiveInject(ViewContainerRef), \u0275\u0275directiveInject(MAT_TAB, 8));
};
_MatTabLabel.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatTabLabel,
  selectors: [["", "mat-tab-label", ""], ["", "matTabLabel", ""]],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_TAB_LABEL,
    useExisting: _MatTabLabel
  }]), \u0275\u0275InheritDefinitionFeature]
});
var MatTabLabel = _MatTabLabel;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabLabel, [{
    type: Directive,
    args: [{
      selector: "[mat-tab-label], [matTabLabel]",
      providers: [{
        provide: MAT_TAB_LABEL,
        useExisting: MatTabLabel
      }],
      standalone: true
    }]
  }], () => [{
    type: TemplateRef
  }, {
    type: ViewContainerRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_TAB]
    }, {
      type: Optional
    }]
  }], null);
})();
var MAT_TAB_GROUP = new InjectionToken("MAT_TAB_GROUP");
var _MatTab = class _MatTab {
  /** Content for the tab label given by `<ng-template mat-tab-label>`. */
  get templateLabel() {
    return this._templateLabel;
  }
  set templateLabel(value) {
    this._setTemplateLabelInput(value);
  }
  /** @docs-private */
  get content() {
    return this._contentPortal;
  }
  constructor(_viewContainerRef, _closestTabGroup) {
    this._viewContainerRef = _viewContainerRef;
    this._closestTabGroup = _closestTabGroup;
    this.disabled = false;
    this._explicitContent = void 0;
    this.textLabel = "";
    this._contentPortal = null;
    this._stateChanges = new Subject();
    this.position = null;
    this.origin = null;
    this.isActive = false;
  }
  ngOnChanges(changes) {
    if (changes.hasOwnProperty("textLabel") || changes.hasOwnProperty("disabled")) {
      this._stateChanges.next();
    }
  }
  ngOnDestroy() {
    this._stateChanges.complete();
  }
  ngOnInit() {
    this._contentPortal = new TemplatePortal(this._explicitContent || this._implicitContent, this._viewContainerRef);
  }
  /**
   * This has been extracted to a util because of TS 4 and VE.
   * View Engine doesn't support property rename inheritance.
   * TS 4.0 doesn't allow properties to override accessors or vice-versa.
   * @docs-private
   */
  _setTemplateLabelInput(value) {
    if (value && value._closestTab === this) {
      this._templateLabel = value;
    }
  }
};
_MatTab.\u0275fac = function MatTab_Factory(t) {
  return new (t || _MatTab)(\u0275\u0275directiveInject(ViewContainerRef), \u0275\u0275directiveInject(MAT_TAB_GROUP, 8));
};
_MatTab.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatTab,
  selectors: [["mat-tab"]],
  contentQueries: function MatTab_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatTabLabel, 5);
      \u0275\u0275contentQuery(dirIndex, MatTabContent, 7, TemplateRef);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.templateLabel = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._explicitContent = _t.first);
    }
  },
  viewQuery: function MatTab_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(TemplateRef, 7);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._implicitContent = _t.first);
    }
  },
  hostAttrs: ["hidden", ""],
  inputs: {
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    textLabel: [InputFlags.None, "label", "textLabel"],
    ariaLabel: [InputFlags.None, "aria-label", "ariaLabel"],
    ariaLabelledby: [InputFlags.None, "aria-labelledby", "ariaLabelledby"],
    labelClass: "labelClass",
    bodyClass: "bodyClass"
  },
  exportAs: ["matTab"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_TAB,
    useExisting: _MatTab
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275NgOnChangesFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c015,
  decls: 1,
  vars: 0,
  template: function MatTab_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275template(0, MatTab_ng_template_0_Template, 1, 0, "ng-template");
    }
  },
  encapsulation: 2
});
var MatTab = _MatTab;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTab, [{
    type: Component,
    args: [{
      selector: "mat-tab",
      changeDetection: ChangeDetectionStrategy.Default,
      encapsulation: ViewEncapsulation$1.None,
      exportAs: "matTab",
      providers: [{
        provide: MAT_TAB,
        useExisting: MatTab
      }],
      standalone: true,
      host: {
        // This element will be rendered on the server in order to support hydration.
        // Hide it so it doesn't cause a layout shift when it's removed on the client.
        "hidden": ""
      },
      template: "<!-- Create a template for the content of the <mat-tab> so that we can grab a reference to this\n    TemplateRef and use it in a Portal to render the tab content in the appropriate place in the\n    tab-group. -->\n<ng-template><ng-content></ng-content></ng-template>\n"
    }]
  }], () => [{
    type: ViewContainerRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_TAB_GROUP]
    }, {
      type: Optional
    }]
  }], {
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    templateLabel: [{
      type: ContentChild,
      args: [MatTabLabel]
    }],
    _explicitContent: [{
      type: ContentChild,
      args: [MatTabContent, {
        read: TemplateRef,
        static: true
      }]
    }],
    _implicitContent: [{
      type: ViewChild,
      args: [TemplateRef, {
        static: true
      }]
    }],
    textLabel: [{
      type: Input,
      args: ["label"]
    }],
    ariaLabel: [{
      type: Input,
      args: ["aria-label"]
    }],
    ariaLabelledby: [{
      type: Input,
      args: ["aria-labelledby"]
    }],
    labelClass: [{
      type: Input
    }],
    bodyClass: [{
      type: Input
    }]
  });
})();
var ACTIVE_CLASS = "mdc-tab-indicator--active";
var NO_TRANSITION_CLASS = "mdc-tab-indicator--no-transition";
var MatInkBar = class {
  constructor(_items) {
    this._items = _items;
  }
  /** Hides the ink bar. */
  hide() {
    this._items.forEach((item) => item.deactivateInkBar());
  }
  /** Aligns the ink bar to a DOM node. */
  alignToElement(element) {
    const correspondingItem = this._items.find((item) => item.elementRef.nativeElement === element);
    const currentItem = this._currentItem;
    if (correspondingItem === currentItem) {
      return;
    }
    currentItem?.deactivateInkBar();
    if (correspondingItem) {
      const domRect = currentItem?.elementRef.nativeElement.getBoundingClientRect?.();
      correspondingItem.activateInkBar(domRect);
      this._currentItem = correspondingItem;
    }
  }
};
var _InkBarItem = class _InkBarItem {
  constructor() {
    this._elementRef = inject(ElementRef);
    this._fitToContent = false;
  }
  /** Whether the ink bar should fit to the entire tab or just its content. */
  get fitInkBarToContent() {
    return this._fitToContent;
  }
  set fitInkBarToContent(newValue) {
    if (this._fitToContent !== newValue) {
      this._fitToContent = newValue;
      if (this._inkBarElement) {
        this._appendInkBarElement();
      }
    }
  }
  /** Aligns the ink bar to the current item. */
  activateInkBar(previousIndicatorClientRect) {
    const element = this._elementRef.nativeElement;
    if (!previousIndicatorClientRect || !element.getBoundingClientRect || !this._inkBarContentElement) {
      element.classList.add(ACTIVE_CLASS);
      return;
    }
    const currentClientRect = element.getBoundingClientRect();
    const widthDelta = previousIndicatorClientRect.width / currentClientRect.width;
    const xPosition = previousIndicatorClientRect.left - currentClientRect.left;
    element.classList.add(NO_TRANSITION_CLASS);
    this._inkBarContentElement.style.setProperty("transform", `translateX(${xPosition}px) scaleX(${widthDelta})`);
    element.getBoundingClientRect();
    element.classList.remove(NO_TRANSITION_CLASS);
    element.classList.add(ACTIVE_CLASS);
    this._inkBarContentElement.style.setProperty("transform", "");
  }
  /** Removes the ink bar from the current item. */
  deactivateInkBar() {
    this._elementRef.nativeElement.classList.remove(ACTIVE_CLASS);
  }
  /** Initializes the foundation. */
  ngOnInit() {
    this._createInkBarElement();
  }
  /** Destroys the foundation. */
  ngOnDestroy() {
    this._inkBarElement?.remove();
    this._inkBarElement = this._inkBarContentElement = null;
  }
  /** Creates and appends the ink bar element. */
  _createInkBarElement() {
    const documentNode = this._elementRef.nativeElement.ownerDocument || document;
    const inkBarElement = this._inkBarElement = documentNode.createElement("span");
    const inkBarContentElement = this._inkBarContentElement = documentNode.createElement("span");
    inkBarElement.className = "mdc-tab-indicator";
    inkBarContentElement.className = "mdc-tab-indicator__content mdc-tab-indicator__content--underline";
    inkBarElement.appendChild(this._inkBarContentElement);
    this._appendInkBarElement();
  }
  /**
   * Appends the ink bar to the tab host element or content, depending on whether
   * the ink bar should fit to content.
   */
  _appendInkBarElement() {
    if (!this._inkBarElement && (typeof ngDevMode === "undefined" || ngDevMode)) {
      throw Error("Ink bar element has not been created and cannot be appended");
    }
    const parentElement = this._fitToContent ? this._elementRef.nativeElement.querySelector(".mdc-tab__content") : this._elementRef.nativeElement;
    if (!parentElement && (typeof ngDevMode === "undefined" || ngDevMode)) {
      throw Error("Missing element to host the ink bar");
    }
    parentElement.appendChild(this._inkBarElement);
  }
};
_InkBarItem.\u0275fac = function InkBarItem_Factory(t) {
  return new (t || _InkBarItem)();
};
_InkBarItem.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _InkBarItem,
  inputs: {
    fitInkBarToContent: [InputFlags.HasDecoratorInputTransform, "fitInkBarToContent", "fitInkBarToContent", booleanAttribute]
  },
  features: [\u0275\u0275InputTransformsFeature]
});
var InkBarItem = _InkBarItem;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(InkBarItem, [{
    type: Directive
  }], null, {
    fitInkBarToContent: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }]
  });
})();
function _MAT_INK_BAR_POSITIONER_FACTORY() {
  const method = (element) => ({
    left: element ? (element.offsetLeft || 0) + "px" : "0",
    width: element ? (element.offsetWidth || 0) + "px" : "0"
  });
  return method;
}
var _MAT_INK_BAR_POSITIONER = new InjectionToken("MatInkBarPositioner", {
  providedIn: "root",
  factory: _MAT_INK_BAR_POSITIONER_FACTORY
});
var _MatTabLabelWrapper = class _MatTabLabelWrapper extends InkBarItem {
  constructor(elementRef) {
    super();
    this.elementRef = elementRef;
    this.disabled = false;
  }
  /** Sets focus on the wrapper element */
  focus() {
    this.elementRef.nativeElement.focus();
  }
  getOffsetLeft() {
    return this.elementRef.nativeElement.offsetLeft;
  }
  getOffsetWidth() {
    return this.elementRef.nativeElement.offsetWidth;
  }
};
_MatTabLabelWrapper.\u0275fac = function MatTabLabelWrapper_Factory(t) {
  return new (t || _MatTabLabelWrapper)(\u0275\u0275directiveInject(ElementRef));
};
_MatTabLabelWrapper.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatTabLabelWrapper,
  selectors: [["", "matTabLabelWrapper", ""]],
  hostVars: 3,
  hostBindings: function MatTabLabelWrapper_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275attribute("aria-disabled", !!ctx.disabled);
      \u0275\u0275classProp("mat-mdc-tab-disabled", ctx.disabled);
    }
  },
  inputs: {
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute]
  },
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature, \u0275\u0275InheritDefinitionFeature]
});
var MatTabLabelWrapper = _MatTabLabelWrapper;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabLabelWrapper, [{
    type: Directive,
    args: [{
      selector: "[matTabLabelWrapper]",
      host: {
        "[class.mat-mdc-tab-disabled]": "disabled",
        "[attr.aria-disabled]": "!!disabled"
      },
      standalone: true
    }]
  }], () => [{
    type: ElementRef
  }], {
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }]
  });
})();
var passiveEventListenerOptions = normalizePassiveListenerOptions({
  passive: true
});
var HEADER_SCROLL_DELAY = 650;
var HEADER_SCROLL_INTERVAL = 100;
var _MatPaginatedTabHeader = class _MatPaginatedTabHeader {
  /** The index of the active tab. */
  get selectedIndex() {
    return this._selectedIndex;
  }
  set selectedIndex(v) {
    const value = isNaN(v) ? 0 : v;
    if (this._selectedIndex != value) {
      this._selectedIndexChanged = true;
      this._selectedIndex = value;
      if (this._keyManager) {
        this._keyManager.updateActiveItem(value);
      }
    }
  }
  constructor(_elementRef, _changeDetectorRef, _viewportRuler, _dir, _ngZone, _platform, _animationMode) {
    this._elementRef = _elementRef;
    this._changeDetectorRef = _changeDetectorRef;
    this._viewportRuler = _viewportRuler;
    this._dir = _dir;
    this._ngZone = _ngZone;
    this._platform = _platform;
    this._animationMode = _animationMode;
    this._scrollDistance = 0;
    this._selectedIndexChanged = false;
    this._destroyed = new Subject();
    this._showPaginationControls = false;
    this._disableScrollAfter = true;
    this._disableScrollBefore = true;
    this._stopScrolling = new Subject();
    this.disablePagination = false;
    this._selectedIndex = 0;
    this.selectFocusedIndex = new EventEmitter();
    this.indexFocused = new EventEmitter();
    _ngZone.runOutsideAngular(() => {
      fromEvent(_elementRef.nativeElement, "mouseleave").pipe(takeUntil(this._destroyed)).subscribe(() => {
        this._stopInterval();
      });
    });
  }
  ngAfterViewInit() {
    fromEvent(this._previousPaginator.nativeElement, "touchstart", passiveEventListenerOptions).pipe(takeUntil(this._destroyed)).subscribe(() => {
      this._handlePaginatorPress("before");
    });
    fromEvent(this._nextPaginator.nativeElement, "touchstart", passiveEventListenerOptions).pipe(takeUntil(this._destroyed)).subscribe(() => {
      this._handlePaginatorPress("after");
    });
  }
  ngAfterContentInit() {
    const dirChange = this._dir ? this._dir.change : of("ltr");
    const resize = this._viewportRuler.change(150);
    const realign = () => {
      this.updatePagination();
      this._alignInkBarToSelectedTab();
    };
    this._keyManager = new FocusKeyManager(this._items).withHorizontalOrientation(this._getLayoutDirection()).withHomeAndEnd().withWrap().skipPredicate(() => false);
    this._keyManager.updateActiveItem(this._selectedIndex);
    this._ngZone.onStable.pipe(take(1)).subscribe(realign);
    merge(dirChange, resize, this._items.changes, this._itemsResized()).pipe(takeUntil(this._destroyed)).subscribe(() => {
      this._ngZone.run(() => {
        Promise.resolve().then(() => {
          this._scrollDistance = Math.max(0, Math.min(this._getMaxScrollDistance(), this._scrollDistance));
          realign();
        });
      });
      this._keyManager.withHorizontalOrientation(this._getLayoutDirection());
    });
    this._keyManager.change.subscribe((newFocusIndex) => {
      this.indexFocused.emit(newFocusIndex);
      this._setTabFocus(newFocusIndex);
    });
  }
  /** Sends any changes that could affect the layout of the items. */
  _itemsResized() {
    if (typeof ResizeObserver !== "function") {
      return EMPTY;
    }
    return this._items.changes.pipe(
      startWith(this._items),
      switchMap((tabItems) => new Observable((observer) => this._ngZone.runOutsideAngular(() => {
        const resizeObserver = new ResizeObserver((entries) => observer.next(entries));
        tabItems.forEach((item) => resizeObserver.observe(item.elementRef.nativeElement));
        return () => {
          resizeObserver.disconnect();
        };
      }))),
      // Skip the first emit since the resize observer emits when an item
      // is observed for new items when the tab is already inserted
      skip(1),
      // Skip emissions where all the elements are invisible since we don't want
      // the header to try and re-render with invalid measurements. See #25574.
      filter((entries) => entries.some((e) => e.contentRect.width > 0 && e.contentRect.height > 0))
    );
  }
  ngAfterContentChecked() {
    if (this._tabLabelCount != this._items.length) {
      this.updatePagination();
      this._tabLabelCount = this._items.length;
      this._changeDetectorRef.markForCheck();
    }
    if (this._selectedIndexChanged) {
      this._scrollToLabel(this._selectedIndex);
      this._checkScrollingControls();
      this._alignInkBarToSelectedTab();
      this._selectedIndexChanged = false;
      this._changeDetectorRef.markForCheck();
    }
    if (this._scrollDistanceChanged) {
      this._updateTabScrollPosition();
      this._scrollDistanceChanged = false;
      this._changeDetectorRef.markForCheck();
    }
  }
  ngOnDestroy() {
    this._keyManager?.destroy();
    this._destroyed.next();
    this._destroyed.complete();
    this._stopScrolling.complete();
  }
  /** Handles keyboard events on the header. */
  _handleKeydown(event) {
    if (hasModifierKey(event)) {
      return;
    }
    switch (event.keyCode) {
      case ENTER:
      case SPACE:
        if (this.focusIndex !== this.selectedIndex) {
          const item = this._items.get(this.focusIndex);
          if (item && !item.disabled) {
            this.selectFocusedIndex.emit(this.focusIndex);
            this._itemSelected(event);
          }
        }
        break;
      default:
        this._keyManager.onKeydown(event);
    }
  }
  /**
   * Callback for when the MutationObserver detects that the content has changed.
   */
  _onContentChanges() {
    const textContent = this._elementRef.nativeElement.textContent;
    if (textContent !== this._currentTextContent) {
      this._currentTextContent = textContent || "";
      this._ngZone.run(() => {
        this.updatePagination();
        this._alignInkBarToSelectedTab();
        this._changeDetectorRef.markForCheck();
      });
    }
  }
  /**
   * Updates the view whether pagination should be enabled or not.
   *
   * WARNING: Calling this method can be very costly in terms of performance. It should be called
   * as infrequently as possible from outside of the Tabs component as it causes a reflow of the
   * page.
   */
  updatePagination() {
    this._checkPaginationEnabled();
    this._checkScrollingControls();
    this._updateTabScrollPosition();
  }
  /** Tracks which element has focus; used for keyboard navigation */
  get focusIndex() {
    return this._keyManager ? this._keyManager.activeItemIndex : 0;
  }
  /** When the focus index is set, we must manually send focus to the correct label */
  set focusIndex(value) {
    if (!this._isValidIndex(value) || this.focusIndex === value || !this._keyManager) {
      return;
    }
    this._keyManager.setActiveItem(value);
  }
  /**
   * Determines if an index is valid.  If the tabs are not ready yet, we assume that the user is
   * providing a valid index and return true.
   */
  _isValidIndex(index) {
    return this._items ? !!this._items.toArray()[index] : true;
  }
  /**
   * Sets focus on the HTML element for the label wrapper and scrolls it into the view if
   * scrolling is enabled.
   */
  _setTabFocus(tabIndex) {
    if (this._showPaginationControls) {
      this._scrollToLabel(tabIndex);
    }
    if (this._items && this._items.length) {
      this._items.toArray()[tabIndex].focus();
      const containerEl = this._tabListContainer.nativeElement;
      const dir = this._getLayoutDirection();
      if (dir == "ltr") {
        containerEl.scrollLeft = 0;
      } else {
        containerEl.scrollLeft = containerEl.scrollWidth - containerEl.offsetWidth;
      }
    }
  }
  /** The layout direction of the containing app. */
  _getLayoutDirection() {
    return this._dir && this._dir.value === "rtl" ? "rtl" : "ltr";
  }
  /** Performs the CSS transformation on the tab list that will cause the list to scroll. */
  _updateTabScrollPosition() {
    if (this.disablePagination) {
      return;
    }
    const scrollDistance = this.scrollDistance;
    const translateX = this._getLayoutDirection() === "ltr" ? -scrollDistance : scrollDistance;
    this._tabList.nativeElement.style.transform = `translateX(${Math.round(translateX)}px)`;
    if (this._platform.TRIDENT || this._platform.EDGE) {
      this._tabListContainer.nativeElement.scrollLeft = 0;
    }
  }
  /** Sets the distance in pixels that the tab header should be transformed in the X-axis. */
  get scrollDistance() {
    return this._scrollDistance;
  }
  set scrollDistance(value) {
    this._scrollTo(value);
  }
  /**
   * Moves the tab list in the 'before' or 'after' direction (towards the beginning of the list or
   * the end of the list, respectively). The distance to scroll is computed to be a third of the
   * length of the tab list view window.
   *
   * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
   * should be called sparingly.
   */
  _scrollHeader(direction) {
    const viewLength = this._tabListContainer.nativeElement.offsetWidth;
    const scrollAmount = (direction == "before" ? -1 : 1) * viewLength / 3;
    return this._scrollTo(this._scrollDistance + scrollAmount);
  }
  /** Handles click events on the pagination arrows. */
  _handlePaginatorClick(direction) {
    this._stopInterval();
    this._scrollHeader(direction);
  }
  /**
   * Moves the tab list such that the desired tab label (marked by index) is moved into view.
   *
   * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
   * should be called sparingly.
   */
  _scrollToLabel(labelIndex) {
    if (this.disablePagination) {
      return;
    }
    const selectedLabel = this._items ? this._items.toArray()[labelIndex] : null;
    if (!selectedLabel) {
      return;
    }
    const viewLength = this._tabListContainer.nativeElement.offsetWidth;
    const {
      offsetLeft,
      offsetWidth
    } = selectedLabel.elementRef.nativeElement;
    let labelBeforePos, labelAfterPos;
    if (this._getLayoutDirection() == "ltr") {
      labelBeforePos = offsetLeft;
      labelAfterPos = labelBeforePos + offsetWidth;
    } else {
      labelAfterPos = this._tabListInner.nativeElement.offsetWidth - offsetLeft;
      labelBeforePos = labelAfterPos - offsetWidth;
    }
    const beforeVisiblePos = this.scrollDistance;
    const afterVisiblePos = this.scrollDistance + viewLength;
    if (labelBeforePos < beforeVisiblePos) {
      this.scrollDistance -= beforeVisiblePos - labelBeforePos;
    } else if (labelAfterPos > afterVisiblePos) {
      this.scrollDistance += Math.min(labelAfterPos - afterVisiblePos, labelBeforePos - beforeVisiblePos);
    }
  }
  /**
   * Evaluate whether the pagination controls should be displayed. If the scroll width of the
   * tab list is wider than the size of the header container, then the pagination controls should
   * be shown.
   *
   * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
   * should be called sparingly.
   */
  _checkPaginationEnabled() {
    if (this.disablePagination) {
      this._showPaginationControls = false;
    } else {
      const isEnabled = this._tabListInner.nativeElement.scrollWidth > this._elementRef.nativeElement.offsetWidth;
      if (!isEnabled) {
        this.scrollDistance = 0;
      }
      if (isEnabled !== this._showPaginationControls) {
        this._changeDetectorRef.markForCheck();
      }
      this._showPaginationControls = isEnabled;
    }
  }
  /**
   * Evaluate whether the before and after controls should be enabled or disabled.
   * If the header is at the beginning of the list (scroll distance is equal to 0) then disable the
   * before button. If the header is at the end of the list (scroll distance is equal to the
   * maximum distance we can scroll), then disable the after button.
   *
   * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
   * should be called sparingly.
   */
  _checkScrollingControls() {
    if (this.disablePagination) {
      this._disableScrollAfter = this._disableScrollBefore = true;
    } else {
      this._disableScrollBefore = this.scrollDistance == 0;
      this._disableScrollAfter = this.scrollDistance == this._getMaxScrollDistance();
      this._changeDetectorRef.markForCheck();
    }
  }
  /**
   * Determines what is the maximum length in pixels that can be set for the scroll distance. This
   * is equal to the difference in width between the tab list container and tab header container.
   *
   * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
   * should be called sparingly.
   */
  _getMaxScrollDistance() {
    const lengthOfTabList = this._tabListInner.nativeElement.scrollWidth;
    const viewLength = this._tabListContainer.nativeElement.offsetWidth;
    return lengthOfTabList - viewLength || 0;
  }
  /** Tells the ink-bar to align itself to the current label wrapper */
  _alignInkBarToSelectedTab() {
    const selectedItem = this._items && this._items.length ? this._items.toArray()[this.selectedIndex] : null;
    const selectedLabelWrapper = selectedItem ? selectedItem.elementRef.nativeElement : null;
    if (selectedLabelWrapper) {
      this._inkBar.alignToElement(selectedLabelWrapper);
    } else {
      this._inkBar.hide();
    }
  }
  /** Stops the currently-running paginator interval.  */
  _stopInterval() {
    this._stopScrolling.next();
  }
  /**
   * Handles the user pressing down on one of the paginators.
   * Starts scrolling the header after a certain amount of time.
   * @param direction In which direction the paginator should be scrolled.
   */
  _handlePaginatorPress(direction, mouseEvent) {
    if (mouseEvent && mouseEvent.button != null && mouseEvent.button !== 0) {
      return;
    }
    this._stopInterval();
    timer(HEADER_SCROLL_DELAY, HEADER_SCROLL_INTERVAL).pipe(takeUntil(merge(this._stopScrolling, this._destroyed))).subscribe(() => {
      const {
        maxScrollDistance,
        distance
      } = this._scrollHeader(direction);
      if (distance === 0 || distance >= maxScrollDistance) {
        this._stopInterval();
      }
    });
  }
  /**
   * Scrolls the header to a given position.
   * @param position Position to which to scroll.
   * @returns Information on the current scroll distance and the maximum.
   */
  _scrollTo(position) {
    if (this.disablePagination) {
      return {
        maxScrollDistance: 0,
        distance: 0
      };
    }
    const maxScrollDistance = this._getMaxScrollDistance();
    this._scrollDistance = Math.max(0, Math.min(maxScrollDistance, position));
    this._scrollDistanceChanged = true;
    this._checkScrollingControls();
    return {
      maxScrollDistance,
      distance: this._scrollDistance
    };
  }
};
_MatPaginatedTabHeader.\u0275fac = function MatPaginatedTabHeader_Factory(t) {
  return new (t || _MatPaginatedTabHeader)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ViewportRuler), \u0275\u0275directiveInject(Directionality, 8), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(Platform), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8));
};
_MatPaginatedTabHeader.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatPaginatedTabHeader,
  inputs: {
    disablePagination: [InputFlags.HasDecoratorInputTransform, "disablePagination", "disablePagination", booleanAttribute],
    selectedIndex: [InputFlags.HasDecoratorInputTransform, "selectedIndex", "selectedIndex", numberAttribute]
  },
  outputs: {
    selectFocusedIndex: "selectFocusedIndex",
    indexFocused: "indexFocused"
  },
  features: [\u0275\u0275InputTransformsFeature]
});
var MatPaginatedTabHeader = _MatPaginatedTabHeader;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatPaginatedTabHeader, [{
    type: Directive
  }], () => [{
    type: ElementRef
  }, {
    type: ChangeDetectorRef
  }, {
    type: ViewportRuler
  }, {
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }, {
    type: NgZone
  }, {
    type: Platform
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }], {
    disablePagination: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    selectedIndex: [{
      type: Input,
      args: [{
        transform: numberAttribute
      }]
    }],
    selectFocusedIndex: [{
      type: Output
    }],
    indexFocused: [{
      type: Output
    }]
  });
})();
var _MatTabHeader = class _MatTabHeader extends MatPaginatedTabHeader {
  constructor(elementRef, changeDetectorRef, viewportRuler, dir, ngZone, platform, animationMode) {
    super(elementRef, changeDetectorRef, viewportRuler, dir, ngZone, platform, animationMode);
    this.disableRipple = false;
  }
  ngAfterContentInit() {
    this._inkBar = new MatInkBar(this._items);
    super.ngAfterContentInit();
  }
  _itemSelected(event) {
    event.preventDefault();
  }
};
_MatTabHeader.\u0275fac = function MatTabHeader_Factory(t) {
  return new (t || _MatTabHeader)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ViewportRuler), \u0275\u0275directiveInject(Directionality, 8), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(Platform), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8));
};
_MatTabHeader.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatTabHeader,
  selectors: [["mat-tab-header"]],
  contentQueries: function MatTabHeader_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatTabLabelWrapper, 4);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._items = _t);
    }
  },
  viewQuery: function MatTabHeader_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(_c18, 7);
      \u0275\u0275viewQuery(_c24, 7);
      \u0275\u0275viewQuery(_c33, 7);
      \u0275\u0275viewQuery(_c43, 5);
      \u0275\u0275viewQuery(_c53, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabListContainer = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabList = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabListInner = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._nextPaginator = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._previousPaginator = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-tab-header"],
  hostVars: 4,
  hostBindings: function MatTabHeader_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275classProp("mat-mdc-tab-header-pagination-controls-enabled", ctx._showPaginationControls)("mat-mdc-tab-header-rtl", ctx._getLayoutDirection() == "rtl");
    }
  },
  inputs: {
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute]
  },
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature, \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c015,
  decls: 13,
  vars: 10,
  consts: [["previousPaginator", ""], ["tabListContainer", ""], ["tabList", ""], ["tabListInner", ""], ["nextPaginator", ""], ["aria-hidden", "true", "type", "button", "mat-ripple", "", "tabindex", "-1", 1, "mat-mdc-tab-header-pagination", "mat-mdc-tab-header-pagination-before", 3, "click", "mousedown", "touchend", "matRippleDisabled", "disabled"], [1, "mat-mdc-tab-header-pagination-chevron"], [1, "mat-mdc-tab-label-container", 3, "keydown"], ["role", "tablist", 1, "mat-mdc-tab-list", 3, "cdkObserveContent"], [1, "mat-mdc-tab-labels"], ["aria-hidden", "true", "type", "button", "mat-ripple", "", "tabindex", "-1", 1, "mat-mdc-tab-header-pagination", "mat-mdc-tab-header-pagination-after", 3, "mousedown", "click", "touchend", "matRippleDisabled", "disabled"]],
  template: function MatTabHeader_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = \u0275\u0275getCurrentView();
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "button", 5, 0);
      \u0275\u0275listener("click", function MatTabHeader_Template_button_click_0_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorClick("before"));
      })("mousedown", function MatTabHeader_Template_button_mousedown_0_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorPress("before", $event));
      })("touchend", function MatTabHeader_Template_button_touchend_0_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._stopInterval());
      });
      \u0275\u0275element(2, "div", 6);
      \u0275\u0275elementEnd();
      \u0275\u0275elementStart(3, "div", 7, 1);
      \u0275\u0275listener("keydown", function MatTabHeader_Template_div_keydown_3_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handleKeydown($event));
      });
      \u0275\u0275elementStart(5, "div", 8, 2);
      \u0275\u0275listener("cdkObserveContent", function MatTabHeader_Template_div_cdkObserveContent_5_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onContentChanges());
      });
      \u0275\u0275elementStart(7, "div", 9, 3);
      \u0275\u0275projection(9);
      \u0275\u0275elementEnd()()();
      \u0275\u0275elementStart(10, "button", 10, 4);
      \u0275\u0275listener("mousedown", function MatTabHeader_Template_button_mousedown_10_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorPress("after", $event));
      })("click", function MatTabHeader_Template_button_click_10_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorClick("after"));
      })("touchend", function MatTabHeader_Template_button_touchend_10_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._stopInterval());
      });
      \u0275\u0275element(12, "div", 6);
      \u0275\u0275elementEnd();
    }
    if (rf & 2) {
      \u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled", ctx._disableScrollBefore);
      \u0275\u0275property("matRippleDisabled", ctx._disableScrollBefore || ctx.disableRipple)("disabled", ctx._disableScrollBefore || null);
      \u0275\u0275advance(3);
      \u0275\u0275classProp("_mat-animation-noopable", ctx._animationMode === "NoopAnimations");
      \u0275\u0275advance(7);
      \u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled", ctx._disableScrollAfter);
      \u0275\u0275property("matRippleDisabled", ctx._disableScrollAfter || ctx.disableRipple)("disabled", ctx._disableScrollAfter || null);
    }
  },
  dependencies: [MatRipple, CdkObserveContent],
  styles: [".mat-mdc-tab-header{display:flex;overflow:hidden;position:relative;flex-shrink:0}.mdc-tab-indicator .mdc-tab-indicator__content{transition-duration:var(--mat-tab-animation-duration, 250ms)}.mat-mdc-tab-header-pagination{-webkit-user-select:none;user-select:none;position:relative;display:none;justify-content:center;align-items:center;min-width:32px;cursor:pointer;z-index:2;-webkit-tap-highlight-color:rgba(0,0,0,0);touch-action:none;box-sizing:content-box;background:none;border:none;outline:0;padding:0}.mat-mdc-tab-header-pagination::-moz-focus-inner{border:0}.mat-mdc-tab-header-pagination .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination{display:flex}.mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after{padding-left:4px}.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(-135deg)}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-pagination-after{padding-right:4px}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(45deg)}.mat-mdc-tab-header-pagination-chevron{border-style:solid;border-width:2px 2px 0 0;height:8px;width:8px;border-color:var(--mat-tab-header-pagination-icon-color)}.mat-mdc-tab-header-pagination-disabled{box-shadow:none;cursor:default;pointer-events:none}.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron{opacity:.4}.mat-mdc-tab-list{flex-grow:1;position:relative;transition:transform 500ms cubic-bezier(0.35, 0, 0.25, 1)}._mat-animation-noopable .mat-mdc-tab-list{transition:none}._mat-animation-noopable span.mdc-tab-indicator__content,._mat-animation-noopable span.mdc-tab__text-label{transition:none}.mat-mdc-tab-label-container{display:flex;flex-grow:1;overflow:hidden;z-index:1;border-bottom-style:solid;border-bottom-width:var(--mat-tab-header-divider-height);border-bottom-color:var(--mat-tab-header-divider-color)}.mat-mdc-tab-group-inverted-header .mat-mdc-tab-label-container{border-bottom:none;border-top-style:solid;border-top-width:var(--mat-tab-header-divider-height);border-top-color:var(--mat-tab-header-divider-color)}.mat-mdc-tab-labels{display:flex;flex:1 0 auto}[mat-align-tabs=center]>.mat-mdc-tab-header .mat-mdc-tab-labels{justify-content:center}[mat-align-tabs=end]>.mat-mdc-tab-header .mat-mdc-tab-labels{justify-content:flex-end}.mat-mdc-tab::before{margin:5px}.cdk-high-contrast-active .mat-mdc-tab[aria-disabled=true]{color:GrayText}"],
  encapsulation: 2
});
var MatTabHeader = _MatTabHeader;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabHeader, [{
    type: Component,
    args: [{
      selector: "mat-tab-header",
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.Default,
      host: {
        "class": "mat-mdc-tab-header",
        "[class.mat-mdc-tab-header-pagination-controls-enabled]": "_showPaginationControls",
        "[class.mat-mdc-tab-header-rtl]": "_getLayoutDirection() == 'rtl'"
      },
      standalone: true,
      imports: [MatRipple, CdkObserveContent],
      template: `<!-- TODO: this also had \`mat-elevation-z4\`. Figure out what we should do with it. -->
<button class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-before"
     #previousPaginator
     aria-hidden="true"
     type="button"
     mat-ripple
     tabindex="-1"
     [matRippleDisabled]="_disableScrollBefore || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollBefore"
     [disabled]="_disableScrollBefore || null"
     (click)="_handlePaginatorClick('before')"
     (mousedown)="_handlePaginatorPress('before', $event)"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</button>

<div
  class="mat-mdc-tab-label-container"
  #tabListContainer
  (keydown)="_handleKeydown($event)"
  [class._mat-animation-noopable]="_animationMode === 'NoopAnimations'">
  <div
    #tabList
    class="mat-mdc-tab-list"
    role="tablist"
    (cdkObserveContent)="_onContentChanges()">
    <div class="mat-mdc-tab-labels" #tabListInner>
      <ng-content></ng-content>
    </div>
  </div>
</div>

<!-- TODO: this also had \`mat-elevation-z4\`. Figure out what we should do with it. -->
<button class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-after"
     #nextPaginator
     aria-hidden="true"
     type="button"
     mat-ripple
     [matRippleDisabled]="_disableScrollAfter || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollAfter"
     [disabled]="_disableScrollAfter || null"
     tabindex="-1"
     (mousedown)="_handlePaginatorPress('after', $event)"
     (click)="_handlePaginatorClick('after')"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</button>
`,
      styles: [".mat-mdc-tab-header{display:flex;overflow:hidden;position:relative;flex-shrink:0}.mdc-tab-indicator .mdc-tab-indicator__content{transition-duration:var(--mat-tab-animation-duration, 250ms)}.mat-mdc-tab-header-pagination{-webkit-user-select:none;user-select:none;position:relative;display:none;justify-content:center;align-items:center;min-width:32px;cursor:pointer;z-index:2;-webkit-tap-highlight-color:rgba(0,0,0,0);touch-action:none;box-sizing:content-box;background:none;border:none;outline:0;padding:0}.mat-mdc-tab-header-pagination::-moz-focus-inner{border:0}.mat-mdc-tab-header-pagination .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination{display:flex}.mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after{padding-left:4px}.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(-135deg)}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-pagination-after{padding-right:4px}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(45deg)}.mat-mdc-tab-header-pagination-chevron{border-style:solid;border-width:2px 2px 0 0;height:8px;width:8px;border-color:var(--mat-tab-header-pagination-icon-color)}.mat-mdc-tab-header-pagination-disabled{box-shadow:none;cursor:default;pointer-events:none}.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron{opacity:.4}.mat-mdc-tab-list{flex-grow:1;position:relative;transition:transform 500ms cubic-bezier(0.35, 0, 0.25, 1)}._mat-animation-noopable .mat-mdc-tab-list{transition:none}._mat-animation-noopable span.mdc-tab-indicator__content,._mat-animation-noopable span.mdc-tab__text-label{transition:none}.mat-mdc-tab-label-container{display:flex;flex-grow:1;overflow:hidden;z-index:1;border-bottom-style:solid;border-bottom-width:var(--mat-tab-header-divider-height);border-bottom-color:var(--mat-tab-header-divider-color)}.mat-mdc-tab-group-inverted-header .mat-mdc-tab-label-container{border-bottom:none;border-top-style:solid;border-top-width:var(--mat-tab-header-divider-height);border-top-color:var(--mat-tab-header-divider-color)}.mat-mdc-tab-labels{display:flex;flex:1 0 auto}[mat-align-tabs=center]>.mat-mdc-tab-header .mat-mdc-tab-labels{justify-content:center}[mat-align-tabs=end]>.mat-mdc-tab-header .mat-mdc-tab-labels{justify-content:flex-end}.mat-mdc-tab::before{margin:5px}.cdk-high-contrast-active .mat-mdc-tab[aria-disabled=true]{color:GrayText}"]
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: ChangeDetectorRef
  }, {
    type: ViewportRuler
  }, {
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }, {
    type: NgZone
  }, {
    type: Platform
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }], {
    _items: [{
      type: ContentChildren,
      args: [MatTabLabelWrapper, {
        descendants: false
      }]
    }],
    _tabListContainer: [{
      type: ViewChild,
      args: ["tabListContainer", {
        static: true
      }]
    }],
    _tabList: [{
      type: ViewChild,
      args: ["tabList", {
        static: true
      }]
    }],
    _tabListInner: [{
      type: ViewChild,
      args: ["tabListInner", {
        static: true
      }]
    }],
    _nextPaginator: [{
      type: ViewChild,
      args: ["nextPaginator"]
    }],
    _previousPaginator: [{
      type: ViewChild,
      args: ["previousPaginator"]
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }]
  });
})();
var MAT_TABS_CONFIG = new InjectionToken("MAT_TABS_CONFIG");
var matTabsAnimations = {
  /** Animation translates a tab along the X axis. */
  translateTab: trigger("translateTab", [
    // Transitions to `none` instead of 0, because some browsers might blur the content.
    state("center, void, left-origin-center, right-origin-center", style({
      transform: "none"
    })),
    // If the tab is either on the left or right, we additionally add a `min-height` of 1px
    // in order to ensure that the element has a height before its state changes. This is
    // necessary because Chrome does seem to skip the transition in RTL mode if the element does
    // not have a static height and is not rendered. See related issue: #9465
    state("left", style({
      transform: "translate3d(-100%, 0, 0)",
      minHeight: "1px",
      // Normally this is redundant since we detach the content from the DOM, but if the user
      // opted into keeping the content in the DOM, we have to hide it so it isn't focusable.
      visibility: "hidden"
    })),
    state("right", style({
      transform: "translate3d(100%, 0, 0)",
      minHeight: "1px",
      visibility: "hidden"
    })),
    transition("* => left, * => right, left => center, right => center", animate("{{animationDuration}} cubic-bezier(0.35, 0, 0.25, 1)")),
    transition("void => left-origin-center", [style({
      transform: "translate3d(-100%, 0, 0)",
      visibility: "hidden"
    }), animate("{{animationDuration}} cubic-bezier(0.35, 0, 0.25, 1)")]),
    transition("void => right-origin-center", [style({
      transform: "translate3d(100%, 0, 0)",
      visibility: "hidden"
    }), animate("{{animationDuration}} cubic-bezier(0.35, 0, 0.25, 1)")])
  ])
};
var _MatTabBodyPortal = class _MatTabBodyPortal extends CdkPortalOutlet {
  constructor(componentFactoryResolver, viewContainerRef, _host, _document) {
    super(componentFactoryResolver, viewContainerRef, _document);
    this._host = _host;
    this._centeringSub = Subscription.EMPTY;
    this._leavingSub = Subscription.EMPTY;
  }
  /** Set initial visibility or set up subscription for changing visibility. */
  ngOnInit() {
    super.ngOnInit();
    this._centeringSub = this._host._beforeCentering.pipe(startWith(this._host._isCenterPosition(this._host._position))).subscribe((isCentering) => {
      if (isCentering && !this.hasAttached()) {
        this.attach(this._host._content);
      }
    });
    this._leavingSub = this._host._afterLeavingCenter.subscribe(() => {
      if (!this._host.preserveContent) {
        this.detach();
      }
    });
  }
  /** Clean up centering subscription. */
  ngOnDestroy() {
    super.ngOnDestroy();
    this._centeringSub.unsubscribe();
    this._leavingSub.unsubscribe();
  }
};
_MatTabBodyPortal.\u0275fac = function MatTabBodyPortal_Factory(t) {
  return new (t || _MatTabBodyPortal)(\u0275\u0275directiveInject(ComponentFactoryResolver$1), \u0275\u0275directiveInject(ViewContainerRef), \u0275\u0275directiveInject(forwardRef(() => MatTabBody)), \u0275\u0275directiveInject(DOCUMENT));
};
_MatTabBodyPortal.\u0275dir = /* @__PURE__ */ \u0275\u0275defineDirective({
  type: _MatTabBodyPortal,
  selectors: [["", "matTabBodyHost", ""]],
  standalone: true,
  features: [\u0275\u0275InheritDefinitionFeature]
});
var MatTabBodyPortal = _MatTabBodyPortal;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabBodyPortal, [{
    type: Directive,
    args: [{
      selector: "[matTabBodyHost]",
      standalone: true
    }]
  }], () => [{
    type: ComponentFactoryResolver$1
  }, {
    type: ViewContainerRef
  }, {
    type: MatTabBody,
    decorators: [{
      type: Inject,
      args: [forwardRef(() => MatTabBody)]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [DOCUMENT]
    }]
  }], null);
})();
var _MatTabBody = class _MatTabBody {
  /** The shifted index position of the tab body, where zero represents the active center tab. */
  set position(position) {
    this._positionIndex = position;
    this._computePositionAnimationState();
  }
  constructor(_elementRef, _dir, changeDetectorRef) {
    this._elementRef = _elementRef;
    this._dir = _dir;
    this._dirChangeSubscription = Subscription.EMPTY;
    this._translateTabComplete = new Subject();
    this._onCentering = new EventEmitter();
    this._beforeCentering = new EventEmitter();
    this._afterLeavingCenter = new EventEmitter();
    this._onCentered = new EventEmitter(true);
    this.animationDuration = "500ms";
    this.preserveContent = false;
    if (_dir) {
      this._dirChangeSubscription = _dir.change.subscribe((dir) => {
        this._computePositionAnimationState(dir);
        changeDetectorRef.markForCheck();
      });
    }
    this._translateTabComplete.pipe(distinctUntilChanged((x, y) => {
      return x.fromState === y.fromState && x.toState === y.toState;
    })).subscribe((event) => {
      if (this._isCenterPosition(event.toState) && this._isCenterPosition(this._position)) {
        this._onCentered.emit();
      }
      if (this._isCenterPosition(event.fromState) && !this._isCenterPosition(this._position)) {
        this._afterLeavingCenter.emit();
      }
    });
  }
  /**
   * After initialized, check if the content is centered and has an origin. If so, set the
   * special position states that transition the tab from the left or right before centering.
   */
  ngOnInit() {
    if (this._position == "center" && this.origin != null) {
      this._position = this._computePositionFromOrigin(this.origin);
    }
  }
  ngOnDestroy() {
    this._dirChangeSubscription.unsubscribe();
    this._translateTabComplete.complete();
  }
  _onTranslateTabStarted(event) {
    const isCentering = this._isCenterPosition(event.toState);
    this._beforeCentering.emit(isCentering);
    if (isCentering) {
      this._onCentering.emit(this._elementRef.nativeElement.clientHeight);
    }
  }
  /** The text direction of the containing app. */
  _getLayoutDirection() {
    return this._dir && this._dir.value === "rtl" ? "rtl" : "ltr";
  }
  /** Whether the provided position state is considered center, regardless of origin. */
  _isCenterPosition(position) {
    return position == "center" || position == "left-origin-center" || position == "right-origin-center";
  }
  /** Computes the position state that will be used for the tab-body animation trigger. */
  _computePositionAnimationState(dir = this._getLayoutDirection()) {
    if (this._positionIndex < 0) {
      this._position = dir == "ltr" ? "left" : "right";
    } else if (this._positionIndex > 0) {
      this._position = dir == "ltr" ? "right" : "left";
    } else {
      this._position = "center";
    }
  }
  /**
   * Computes the position state based on the specified origin position. This is used if the
   * tab is becoming visible immediately after creation.
   */
  _computePositionFromOrigin(origin) {
    const dir = this._getLayoutDirection();
    if (dir == "ltr" && origin <= 0 || dir == "rtl" && origin > 0) {
      return "left-origin-center";
    }
    return "right-origin-center";
  }
};
_MatTabBody.\u0275fac = function MatTabBody_Factory(t) {
  return new (t || _MatTabBody)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(Directionality, 8), \u0275\u0275directiveInject(ChangeDetectorRef));
};
_MatTabBody.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatTabBody,
  selectors: [["mat-tab-body"]],
  viewQuery: function MatTabBody_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(CdkPortalOutlet, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._portalHost = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-tab-body"],
  inputs: {
    _content: [InputFlags.None, "content", "_content"],
    origin: "origin",
    animationDuration: "animationDuration",
    preserveContent: "preserveContent",
    position: "position"
  },
  outputs: {
    _onCentering: "_onCentering",
    _beforeCentering: "_beforeCentering",
    _afterLeavingCenter: "_afterLeavingCenter",
    _onCentered: "_onCentered"
  },
  standalone: true,
  features: [\u0275\u0275StandaloneFeature],
  decls: 3,
  vars: 6,
  consts: [["content", ""], ["cdkScrollable", "", 1, "mat-mdc-tab-body-content"], ["matTabBodyHost", ""]],
  template: function MatTabBody_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = \u0275\u0275getCurrentView();
      \u0275\u0275elementStart(0, "div", 1, 0);
      \u0275\u0275listener("@translateTab.start", function MatTabBody_Template_div_animation_translateTab_start_0_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onTranslateTabStarted($event));
      })("@translateTab.done", function MatTabBody_Template_div_animation_translateTab_done_0_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._translateTabComplete.next($event));
      });
      \u0275\u0275template(2, MatTabBody_ng_template_2_Template, 0, 0, "ng-template", 2);
      \u0275\u0275elementEnd();
    }
    if (rf & 2) {
      \u0275\u0275property("@translateTab", \u0275\u0275pureFunction2(3, _c7, ctx._position, \u0275\u0275pureFunction1(1, _c62, ctx.animationDuration)));
    }
  },
  dependencies: [MatTabBodyPortal, CdkScrollable],
  styles: ['.mat-mdc-tab-body{top:0;left:0;right:0;bottom:0;position:absolute;display:block;overflow:hidden;outline:0;flex-basis:100%}.mat-mdc-tab-body.mat-mdc-tab-body-active{position:relative;overflow-x:hidden;overflow-y:auto;z-index:1;flex-grow:1}.mat-mdc-tab-group.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body.mat-mdc-tab-body-active{overflow-y:hidden}.mat-mdc-tab-body-content{height:100%;overflow:auto}.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body-content{overflow:hidden}.mat-mdc-tab-body-content[style*="visibility: hidden"]{display:none}'],
  encapsulation: 2,
  data: {
    animation: [matTabsAnimations.translateTab]
  }
});
var MatTabBody = _MatTabBody;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabBody, [{
    type: Component,
    args: [{
      selector: "mat-tab-body",
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.Default,
      animations: [matTabsAnimations.translateTab],
      host: {
        "class": "mat-mdc-tab-body"
      },
      standalone: true,
      imports: [MatTabBodyPortal, CdkScrollable],
      template: '<div class="mat-mdc-tab-body-content" #content\n     [@translateTab]="{\n        value: _position,\n        params: {animationDuration: animationDuration}\n     }"\n     (@translateTab.start)="_onTranslateTabStarted($event)"\n     (@translateTab.done)="_translateTabComplete.next($event)"\n     cdkScrollable>\n  <ng-template matTabBodyHost></ng-template>\n</div>\n',
      styles: ['.mat-mdc-tab-body{top:0;left:0;right:0;bottom:0;position:absolute;display:block;overflow:hidden;outline:0;flex-basis:100%}.mat-mdc-tab-body.mat-mdc-tab-body-active{position:relative;overflow-x:hidden;overflow-y:auto;z-index:1;flex-grow:1}.mat-mdc-tab-group.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body.mat-mdc-tab-body-active{overflow-y:hidden}.mat-mdc-tab-body-content{height:100%;overflow:auto}.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body-content{overflow:hidden}.mat-mdc-tab-body-content[style*="visibility: hidden"]{display:none}']
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }, {
    type: ChangeDetectorRef
  }], {
    _onCentering: [{
      type: Output
    }],
    _beforeCentering: [{
      type: Output
    }],
    _afterLeavingCenter: [{
      type: Output
    }],
    _onCentered: [{
      type: Output
    }],
    _portalHost: [{
      type: ViewChild,
      args: [CdkPortalOutlet]
    }],
    _content: [{
      type: Input,
      args: ["content"]
    }],
    origin: [{
      type: Input
    }],
    animationDuration: [{
      type: Input
    }],
    preserveContent: [{
      type: Input
    }],
    position: [{
      type: Input
    }]
  });
})();
var nextId = 0;
var ENABLE_BACKGROUND_INPUT = true;
var _MatTabGroup = class _MatTabGroup {
  /** Whether the ink bar should fit its width to the size of the tab label content. */
  get fitInkBarToContent() {
    return this._fitInkBarToContent;
  }
  set fitInkBarToContent(value) {
    this._fitInkBarToContent = value;
    this._changeDetectorRef.markForCheck();
  }
  /** The index of the active tab. */
  get selectedIndex() {
    return this._selectedIndex;
  }
  set selectedIndex(value) {
    this._indexToSelect = isNaN(value) ? null : value;
  }
  /** Duration for the tab animation. Will be normalized to milliseconds if no units are set. */
  get animationDuration() {
    return this._animationDuration;
  }
  set animationDuration(value) {
    const stringValue = value + "";
    this._animationDuration = /^\d+$/.test(stringValue) ? value + "ms" : stringValue;
  }
  /**
   * `tabindex` to be set on the inner element that wraps the tab content. Can be used for improved
   * accessibility when the tab does not have focusable elements or if it has scrollable content.
   * The `tabindex` will be removed automatically for inactive tabs.
   * Read more at https://www.w3.org/TR/wai-aria-practices/examples/tabs/tabs-2/tabs.html
   */
  get contentTabIndex() {
    return this._contentTabIndex;
  }
  set contentTabIndex(value) {
    this._contentTabIndex = isNaN(value) ? null : value;
  }
  /**
   * Background color of the tab group.
   * @deprecated The background color should be customized through Sass theming APIs.
   * @breaking-change 20.0.0 Remove this input
   */
  get backgroundColor() {
    return this._backgroundColor;
  }
  set backgroundColor(value) {
    if (!ENABLE_BACKGROUND_INPUT) {
      throw new Error(`mat-tab-group background color must be set through the Sass theming API`);
    }
    const classList = this._elementRef.nativeElement.classList;
    classList.remove("mat-tabs-with-background", `mat-background-${this.backgroundColor}`);
    if (value) {
      classList.add("mat-tabs-with-background", `mat-background-${value}`);
    }
    this._backgroundColor = value;
  }
  constructor(_elementRef, _changeDetectorRef, defaultConfig, _animationMode) {
    this._elementRef = _elementRef;
    this._changeDetectorRef = _changeDetectorRef;
    this._animationMode = _animationMode;
    this._tabs = new QueryList();
    this._indexToSelect = 0;
    this._lastFocusedTabIndex = null;
    this._tabBodyWrapperHeight = 0;
    this._tabsSubscription = Subscription.EMPTY;
    this._tabLabelSubscription = Subscription.EMPTY;
    this._fitInkBarToContent = false;
    this.stretchTabs = true;
    this.dynamicHeight = false;
    this._selectedIndex = null;
    this.headerPosition = "above";
    this.disablePagination = false;
    this.disableRipple = false;
    this.preserveContent = false;
    this.selectedIndexChange = new EventEmitter();
    this.focusChange = new EventEmitter();
    this.animationDone = new EventEmitter();
    this.selectedTabChange = new EventEmitter(true);
    this._isServer = !inject(Platform).isBrowser;
    this._groupId = nextId++;
    this.animationDuration = defaultConfig && defaultConfig.animationDuration ? defaultConfig.animationDuration : "500ms";
    this.disablePagination = defaultConfig && defaultConfig.disablePagination != null ? defaultConfig.disablePagination : false;
    this.dynamicHeight = defaultConfig && defaultConfig.dynamicHeight != null ? defaultConfig.dynamicHeight : false;
    if (defaultConfig?.contentTabIndex != null) {
      this.contentTabIndex = defaultConfig.contentTabIndex;
    }
    this.preserveContent = !!defaultConfig?.preserveContent;
    this.fitInkBarToContent = defaultConfig && defaultConfig.fitInkBarToContent != null ? defaultConfig.fitInkBarToContent : false;
    this.stretchTabs = defaultConfig && defaultConfig.stretchTabs != null ? defaultConfig.stretchTabs : true;
  }
  /**
   * After the content is checked, this component knows what tabs have been defined
   * and what the selected index should be. This is where we can know exactly what position
   * each tab should be in according to the new selected index, and additionally we know how
   * a new selected tab should transition in (from the left or right).
   */
  ngAfterContentChecked() {
    const indexToSelect = this._indexToSelect = this._clampTabIndex(this._indexToSelect);
    if (this._selectedIndex != indexToSelect) {
      const isFirstRun = this._selectedIndex == null;
      if (!isFirstRun) {
        this.selectedTabChange.emit(this._createChangeEvent(indexToSelect));
        const wrapper = this._tabBodyWrapper.nativeElement;
        wrapper.style.minHeight = wrapper.clientHeight + "px";
      }
      Promise.resolve().then(() => {
        this._tabs.forEach((tab, index) => tab.isActive = index === indexToSelect);
        if (!isFirstRun) {
          this.selectedIndexChange.emit(indexToSelect);
          this._tabBodyWrapper.nativeElement.style.minHeight = "";
        }
      });
    }
    this._tabs.forEach((tab, index) => {
      tab.position = index - indexToSelect;
      if (this._selectedIndex != null && tab.position == 0 && !tab.origin) {
        tab.origin = indexToSelect - this._selectedIndex;
      }
    });
    if (this._selectedIndex !== indexToSelect) {
      this._selectedIndex = indexToSelect;
      this._lastFocusedTabIndex = null;
      this._changeDetectorRef.markForCheck();
    }
  }
  ngAfterContentInit() {
    this._subscribeToAllTabChanges();
    this._subscribeToTabLabels();
    this._tabsSubscription = this._tabs.changes.subscribe(() => {
      const indexToSelect = this._clampTabIndex(this._indexToSelect);
      if (indexToSelect === this._selectedIndex) {
        const tabs = this._tabs.toArray();
        let selectedTab;
        for (let i = 0; i < tabs.length; i++) {
          if (tabs[i].isActive) {
            this._indexToSelect = this._selectedIndex = i;
            this._lastFocusedTabIndex = null;
            selectedTab = tabs[i];
            break;
          }
        }
        if (!selectedTab && tabs[indexToSelect]) {
          Promise.resolve().then(() => {
            tabs[indexToSelect].isActive = true;
            this.selectedTabChange.emit(this._createChangeEvent(indexToSelect));
          });
        }
      }
      this._changeDetectorRef.markForCheck();
    });
  }
  /** Listens to changes in all of the tabs. */
  _subscribeToAllTabChanges() {
    this._allTabs.changes.pipe(startWith(this._allTabs)).subscribe((tabs) => {
      this._tabs.reset(tabs.filter((tab) => {
        return tab._closestTabGroup === this || !tab._closestTabGroup;
      }));
      this._tabs.notifyOnChanges();
    });
  }
  ngOnDestroy() {
    this._tabs.destroy();
    this._tabsSubscription.unsubscribe();
    this._tabLabelSubscription.unsubscribe();
  }
  /** Re-aligns the ink bar to the selected tab element. */
  realignInkBar() {
    if (this._tabHeader) {
      this._tabHeader._alignInkBarToSelectedTab();
    }
  }
  /**
   * Recalculates the tab group's pagination dimensions.
   *
   * WARNING: Calling this method can be very costly in terms of performance. It should be called
   * as infrequently as possible from outside of the Tabs component as it causes a reflow of the
   * page.
   */
  updatePagination() {
    if (this._tabHeader) {
      this._tabHeader.updatePagination();
    }
  }
  /**
   * Sets focus to a particular tab.
   * @param index Index of the tab to be focused.
   */
  focusTab(index) {
    const header = this._tabHeader;
    if (header) {
      header.focusIndex = index;
    }
  }
  _focusChanged(index) {
    this._lastFocusedTabIndex = index;
    this.focusChange.emit(this._createChangeEvent(index));
  }
  _createChangeEvent(index) {
    const event = new MatTabChangeEvent();
    event.index = index;
    if (this._tabs && this._tabs.length) {
      event.tab = this._tabs.toArray()[index];
    }
    return event;
  }
  /**
   * Subscribes to changes in the tab labels. This is needed, because the @Input for the label is
   * on the MatTab component, whereas the data binding is inside the MatTabGroup. In order for the
   * binding to be updated, we need to subscribe to changes in it and trigger change detection
   * manually.
   */
  _subscribeToTabLabels() {
    if (this._tabLabelSubscription) {
      this._tabLabelSubscription.unsubscribe();
    }
    this._tabLabelSubscription = merge(...this._tabs.map((tab) => tab._stateChanges)).subscribe(() => this._changeDetectorRef.markForCheck());
  }
  /** Clamps the given index to the bounds of 0 and the tabs length. */
  _clampTabIndex(index) {
    return Math.min(this._tabs.length - 1, Math.max(index || 0, 0));
  }
  /** Returns a unique id for each tab label element */
  _getTabLabelId(i) {
    return `mat-tab-label-${this._groupId}-${i}`;
  }
  /** Returns a unique id for each tab content element */
  _getTabContentId(i) {
    return `mat-tab-content-${this._groupId}-${i}`;
  }
  /**
   * Sets the height of the body wrapper to the height of the activating tab if dynamic
   * height property is true.
   */
  _setTabBodyWrapperHeight(tabHeight) {
    if (!this.dynamicHeight || !this._tabBodyWrapperHeight) {
      return;
    }
    const wrapper = this._tabBodyWrapper.nativeElement;
    wrapper.style.height = this._tabBodyWrapperHeight + "px";
    if (this._tabBodyWrapper.nativeElement.offsetHeight) {
      wrapper.style.height = tabHeight + "px";
    }
  }
  /** Removes the height of the tab body wrapper. */
  _removeTabBodyWrapperHeight() {
    const wrapper = this._tabBodyWrapper.nativeElement;
    this._tabBodyWrapperHeight = wrapper.clientHeight;
    wrapper.style.height = "";
    this.animationDone.emit();
  }
  /** Handle click events, setting new selected index if appropriate. */
  _handleClick(tab, tabHeader, index) {
    tabHeader.focusIndex = index;
    if (!tab.disabled) {
      this.selectedIndex = index;
    }
  }
  /** Retrieves the tabindex for the tab. */
  _getTabIndex(index) {
    const targetIndex = this._lastFocusedTabIndex ?? this.selectedIndex;
    return index === targetIndex ? 0 : -1;
  }
  /** Callback for when the focused state of a tab has changed. */
  _tabFocusChanged(focusOrigin, index) {
    if (focusOrigin && focusOrigin !== "mouse" && focusOrigin !== "touch") {
      this._tabHeader.focusIndex = index;
    }
  }
};
_MatTabGroup.\u0275fac = function MatTabGroup_Factory(t) {
  return new (t || _MatTabGroup)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(MAT_TABS_CONFIG, 8), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8));
};
_MatTabGroup.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatTabGroup,
  selectors: [["mat-tab-group"]],
  contentQueries: function MatTabGroup_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatTab, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._allTabs = _t);
    }
  },
  viewQuery: function MatTabGroup_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(_c8, 5);
      \u0275\u0275viewQuery(_c9, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabBodyWrapper = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabHeader = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-tab-group"],
  hostVars: 10,
  hostBindings: function MatTabGroup_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275classMap("mat-" + (ctx.color || "primary"));
      \u0275\u0275styleProp("--mat-tab-animation-duration", ctx.animationDuration);
      \u0275\u0275classProp("mat-mdc-tab-group-dynamic-height", ctx.dynamicHeight)("mat-mdc-tab-group-inverted-header", ctx.headerPosition === "below")("mat-mdc-tab-group-stretch-tabs", ctx.stretchTabs);
    }
  },
  inputs: {
    color: "color",
    fitInkBarToContent: [InputFlags.HasDecoratorInputTransform, "fitInkBarToContent", "fitInkBarToContent", booleanAttribute],
    stretchTabs: [InputFlags.HasDecoratorInputTransform, "mat-stretch-tabs", "stretchTabs", booleanAttribute],
    dynamicHeight: [InputFlags.HasDecoratorInputTransform, "dynamicHeight", "dynamicHeight", booleanAttribute],
    selectedIndex: [InputFlags.HasDecoratorInputTransform, "selectedIndex", "selectedIndex", numberAttribute],
    headerPosition: "headerPosition",
    animationDuration: "animationDuration",
    contentTabIndex: [InputFlags.HasDecoratorInputTransform, "contentTabIndex", "contentTabIndex", numberAttribute],
    disablePagination: [InputFlags.HasDecoratorInputTransform, "disablePagination", "disablePagination", booleanAttribute],
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    preserveContent: [InputFlags.HasDecoratorInputTransform, "preserveContent", "preserveContent", booleanAttribute],
    backgroundColor: "backgroundColor"
  },
  outputs: {
    selectedIndexChange: "selectedIndexChange",
    focusChange: "focusChange",
    animationDone: "animationDone",
    selectedTabChange: "selectedTabChange"
  },
  exportAs: ["matTabGroup"],
  standalone: true,
  features: [\u0275\u0275ProvidersFeature([{
    provide: MAT_TAB_GROUP,
    useExisting: _MatTabGroup
  }]), \u0275\u0275InputTransformsFeature, \u0275\u0275StandaloneFeature],
  ngContentSelectors: _c015,
  decls: 9,
  vars: 6,
  consts: [["tabHeader", ""], ["tabBodyWrapper", ""], ["tabNode", ""], [3, "indexFocused", "selectFocusedIndex", "selectedIndex", "disableRipple", "disablePagination"], ["role", "tab", "matTabLabelWrapper", "", "cdkMonitorElementFocus", "", 1, "mdc-tab", "mat-mdc-tab", "mat-mdc-focus-indicator", 3, "id", "mdc-tab--active", "class", "disabled", "fitInkBarToContent"], [1, "mat-mdc-tab-body-wrapper"], ["role", "tabpanel", 3, "id", "mat-mdc-tab-body-active", "class", "content", "position", "origin", "animationDuration", "preserveContent"], ["role", "tab", "matTabLabelWrapper", "", "cdkMonitorElementFocus", "", 1, "mdc-tab", "mat-mdc-tab", "mat-mdc-focus-indicator", 3, "click", "cdkFocusChange", "id", "disabled", "fitInkBarToContent"], [1, "mdc-tab__ripple"], ["mat-ripple", "", 1, "mat-mdc-tab-ripple", 3, "matRippleTrigger", "matRippleDisabled"], [1, "mdc-tab__content"], [1, "mdc-tab__text-label"], [3, "cdkPortalOutlet"], ["role", "tabpanel", 3, "_onCentered", "_onCentering", "id", "content", "position", "origin", "animationDuration", "preserveContent"]],
  template: function MatTabGroup_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = \u0275\u0275getCurrentView();
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "mat-tab-header", 3, 0);
      \u0275\u0275listener("indexFocused", function MatTabGroup_Template_mat_tab_header_indexFocused_0_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._focusChanged($event));
      })("selectFocusedIndex", function MatTabGroup_Template_mat_tab_header_selectFocusedIndex_0_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx.selectedIndex = $event);
      });
      \u0275\u0275repeaterCreate(2, MatTabGroup_For_3_Template, 8, 17, "div", 4, \u0275\u0275repeaterTrackByIdentity);
      \u0275\u0275elementEnd();
      \u0275\u0275template(4, MatTabGroup_Conditional_4_Template, 1, 0);
      \u0275\u0275elementStart(5, "div", 5, 1);
      \u0275\u0275repeaterCreate(7, MatTabGroup_For_8_Template, 1, 13, "mat-tab-body", 6, \u0275\u0275repeaterTrackByIdentity);
      \u0275\u0275elementEnd();
    }
    if (rf & 2) {
      \u0275\u0275property("selectedIndex", ctx.selectedIndex || 0)("disableRipple", ctx.disableRipple)("disablePagination", ctx.disablePagination);
      \u0275\u0275advance(2);
      \u0275\u0275repeater(ctx._tabs);
      \u0275\u0275advance(2);
      \u0275\u0275conditional(4, ctx._isServer ? 4 : -1);
      \u0275\u0275advance();
      \u0275\u0275classProp("_mat-animation-noopable", ctx._animationMode === "NoopAnimations");
      \u0275\u0275advance(2);
      \u0275\u0275repeater(ctx._tabs);
    }
  },
  dependencies: [MatTabHeader, MatTabLabelWrapper, CdkMonitorFocus, MatRipple, CdkPortalOutlet, MatTabBody],
  styles: ['.mdc-tab{min-width:90px;padding-right:24px;padding-left:24px;display:flex;flex:1 0 auto;justify-content:center;box-sizing:border-box;margin:0;padding-top:0;padding-bottom:0;border:none;outline:none;text-align:center;white-space:nowrap;cursor:pointer;-webkit-appearance:none;z-index:1}.mdc-tab::-moz-focus-inner{padding:0;border:0}.mdc-tab[hidden]{display:none}.mdc-tab--min-width{flex:0 1 auto}.mdc-tab__content{display:flex;align-items:center;justify-content:center;height:inherit;pointer-events:none}.mdc-tab__text-label{transition:150ms color linear;display:inline-block;line-height:1;z-index:2}.mdc-tab__icon{transition:150ms color linear;z-index:2}.mdc-tab--stacked .mdc-tab__content{flex-direction:column;align-items:center;justify-content:center}.mdc-tab--stacked .mdc-tab__text-label{padding-top:6px;padding-bottom:4px}.mdc-tab--active .mdc-tab__text-label,.mdc-tab--active .mdc-tab__icon{transition-delay:100ms}.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label{padding-left:8px;padding-right:0}[dir=rtl] .mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label,.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label[dir=rtl]{padding-left:0;padding-right:8px}.mdc-tab-indicator{display:flex;position:absolute;top:0;left:0;justify-content:center;width:100%;height:100%;pointer-events:none;z-index:1}.mdc-tab-indicator__content{transform-origin:left;opacity:0}.mdc-tab-indicator__content--underline{align-self:flex-end;box-sizing:border-box;width:100%;border-top-style:solid}.mdc-tab-indicator__content--icon{align-self:center;margin:0 auto}.mdc-tab-indicator--active .mdc-tab-indicator__content{opacity:1}.mdc-tab-indicator .mdc-tab-indicator__content{transition:250ms transform cubic-bezier(0.4, 0, 0.2, 1)}.mdc-tab-indicator--no-transition .mdc-tab-indicator__content{transition:none}.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition:150ms opacity linear}.mdc-tab-indicator--active.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition-delay:100ms}.mat-mdc-tab-ripple{position:absolute;top:0;left:0;bottom:0;right:0;pointer-events:none}.mat-mdc-tab{-webkit-tap-highlight-color:rgba(0,0,0,0);-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;text-decoration:none;background:none;font-family:var(--mat-tab-header-label-text-font);font-size:var(--mat-tab-header-label-text-size);letter-spacing:var(--mat-tab-header-label-text-tracking);line-height:var(--mat-tab-header-label-text-line-height);font-weight:var(--mat-tab-header-label-text-weight)}.mat-mdc-tab .mdc-tab-indicator__content--underline{border-color:var(--mdc-tab-indicator-active-indicator-color)}.mat-mdc-tab .mdc-tab-indicator__content--underline{border-top-width:var(--mdc-tab-indicator-active-indicator-height)}.mat-mdc-tab .mdc-tab-indicator__content--underline{border-radius:var(--mdc-tab-indicator-active-indicator-shape)}.mat-mdc-tab:not(.mdc-tab--stacked){height:var(--mdc-secondary-navigation-tab-container-height)}.mat-mdc-tab:not(:disabled).mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):hover.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):focus.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):active.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:disabled.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):hover:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):focus:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):active:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:disabled:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab.mdc-tab{flex-grow:0}.mat-mdc-tab:hover .mdc-tab__text-label{color:var(--mat-tab-header-inactive-hover-label-text-color)}.mat-mdc-tab:focus .mdc-tab__text-label{color:var(--mat-tab-header-inactive-focus-label-text-color)}.mat-mdc-tab.mdc-tab--active .mdc-tab__text-label{color:var(--mat-tab-header-active-label-text-color)}.mat-mdc-tab.mdc-tab--active .mdc-tab__ripple::before,.mat-mdc-tab.mdc-tab--active .mat-ripple-element{background-color:var(--mat-tab-header-active-ripple-color)}.mat-mdc-tab.mdc-tab--active:hover .mdc-tab__text-label{color:var(--mat-tab-header-active-hover-label-text-color)}.mat-mdc-tab.mdc-tab--active:hover .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-hover-indicator-color)}.mat-mdc-tab.mdc-tab--active:focus .mdc-tab__text-label{color:var(--mat-tab-header-active-focus-label-text-color)}.mat-mdc-tab.mdc-tab--active:focus .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-focus-indicator-color)}.mat-mdc-tab.mat-mdc-tab-disabled{opacity:.4;pointer-events:none}.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__content{pointer-events:none}.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__ripple::before,.mat-mdc-tab.mat-mdc-tab-disabled .mat-ripple-element{background-color:var(--mat-tab-header-disabled-ripple-color)}.mat-mdc-tab .mdc-tab__ripple::before{content:"";display:block;position:absolute;top:0;left:0;right:0;bottom:0;opacity:0;pointer-events:none;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab .mdc-tab__text-label{color:var(--mat-tab-header-inactive-label-text-color);display:inline-flex;align-items:center}.mat-mdc-tab .mdc-tab__content{position:relative;pointer-events:auto}.mat-mdc-tab:hover .mdc-tab__ripple::before{opacity:.04}.mat-mdc-tab.cdk-program-focused .mdc-tab__ripple::before,.mat-mdc-tab.cdk-keyboard-focused .mdc-tab__ripple::before{opacity:.12}.mat-mdc-tab .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-group.mat-mdc-tab-group-stretch-tabs>.mat-mdc-tab-header .mat-mdc-tab{flex-grow:1}.mat-mdc-tab-group{display:flex;flex-direction:column;max-width:100%}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination{background-color:var(--mat-tab-header-with-background-background-color)}.mat-mdc-tab-group.mat-tabs-with-background.mat-primary>.mat-mdc-tab-header .mat-mdc-tab .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background.mat-primary>.mat-mdc-tab-header .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-mdc-focus-indicator::before,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-focus-indicator::before{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-ripple-element,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mdc-tab__ripple::before,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-ripple-element,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mdc-tab__ripple::before{background-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header{flex-direction:column-reverse}.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header .mdc-tab-indicator__content--underline{align-self:flex-start}.mat-mdc-tab-body-wrapper{position:relative;overflow:hidden;display:flex;transition:height 500ms cubic-bezier(0.35, 0, 0.25, 1)}.mat-mdc-tab-body-wrapper._mat-animation-noopable{transition:none !important;animation:none !important}'],
  encapsulation: 2
});
var MatTabGroup = _MatTabGroup;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabGroup, [{
    type: Component,
    args: [{
      selector: "mat-tab-group",
      exportAs: "matTabGroup",
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.Default,
      providers: [{
        provide: MAT_TAB_GROUP,
        useExisting: MatTabGroup
      }],
      host: {
        "class": "mat-mdc-tab-group",
        "[class]": '"mat-" + (color || "primary")',
        "[class.mat-mdc-tab-group-dynamic-height]": "dynamicHeight",
        "[class.mat-mdc-tab-group-inverted-header]": 'headerPosition === "below"',
        "[class.mat-mdc-tab-group-stretch-tabs]": "stretchTabs",
        "[style.--mat-tab-animation-duration]": "animationDuration"
      },
      standalone: true,
      imports: [MatTabHeader, MatTabLabelWrapper, CdkMonitorFocus, MatRipple, CdkPortalOutlet, MatTabBody],
      template: '<mat-tab-header #tabHeader\n                [selectedIndex]="selectedIndex || 0"\n                [disableRipple]="disableRipple"\n                [disablePagination]="disablePagination"\n                (indexFocused)="_focusChanged($event)"\n                (selectFocusedIndex)="selectedIndex = $event">\n\n  @for (tab of _tabs; track tab; let i = $index) {\n    <div class="mdc-tab mat-mdc-tab mat-mdc-focus-indicator"\n        #tabNode\n        role="tab"\n        matTabLabelWrapper\n        cdkMonitorElementFocus\n        [id]="_getTabLabelId(i)"\n        [attr.tabIndex]="_getTabIndex(i)"\n        [attr.aria-posinset]="i + 1"\n        [attr.aria-setsize]="_tabs.length"\n        [attr.aria-controls]="_getTabContentId(i)"\n        [attr.aria-selected]="selectedIndex === i"\n        [attr.aria-label]="tab.ariaLabel || null"\n        [attr.aria-labelledby]="(!tab.ariaLabel && tab.ariaLabelledby) ? tab.ariaLabelledby : null"\n        [class.mdc-tab--active]="selectedIndex === i"\n        [class]="tab.labelClass"\n        [disabled]="tab.disabled"\n        [fitInkBarToContent]="fitInkBarToContent"\n        (click)="_handleClick(tab, tabHeader, i)"\n        (cdkFocusChange)="_tabFocusChanged($event, i)">\n      <span class="mdc-tab__ripple"></span>\n\n      <!-- Needs to be a separate element, because we can\'t put\n          `overflow: hidden` on tab due to the ink bar. -->\n      <div\n        class="mat-mdc-tab-ripple"\n        mat-ripple\n        [matRippleTrigger]="tabNode"\n        [matRippleDisabled]="tab.disabled || disableRipple"></div>\n\n      <span class="mdc-tab__content">\n        <span class="mdc-tab__text-label">\n          <!--\n            If there is a label template, use it, otherwise fall back to the text label.\n            Note that we don\'t have indentation around the text label, because it adds\n            whitespace around the text which breaks some internal tests.\n          -->\n          @if (tab.templateLabel) {\n            <ng-template [cdkPortalOutlet]="tab.templateLabel"></ng-template>\n          } @else {{{tab.textLabel}}}\n        </span>\n      </span>\n    </div>\n  }\n</mat-tab-header>\n\n<!--\n  We need to project the content somewhere to avoid hydration errors. Some observations:\n  1. This is only necessary on the server.\n  2. We get a hydration error if there aren\'t any nodes after the `ng-content`.\n  3. We get a hydration error if `ng-content` is wrapped in another element.\n-->\n@if (_isServer) {\n  <ng-content/>\n}\n\n<div\n  class="mat-mdc-tab-body-wrapper"\n  [class._mat-animation-noopable]="_animationMode === \'NoopAnimations\'"\n  #tabBodyWrapper>\n  @for (tab of _tabs; track tab; let i = $index) {\n    <mat-tab-body role="tabpanel"\n                 [id]="_getTabContentId(i)"\n                 [attr.tabindex]="(contentTabIndex != null && selectedIndex === i) ? contentTabIndex : null"\n                 [attr.aria-labelledby]="_getTabLabelId(i)"\n                 [attr.aria-hidden]="selectedIndex !== i"\n                 [class.mat-mdc-tab-body-active]="selectedIndex === i"\n                 [class]="tab.bodyClass"\n                 [content]="tab.content!"\n                 [position]="tab.position!"\n                 [origin]="tab.origin"\n                 [animationDuration]="animationDuration"\n                 [preserveContent]="preserveContent"\n                 (_onCentered)="_removeTabBodyWrapperHeight()"\n                 (_onCentering)="_setTabBodyWrapperHeight($event)">\n    </mat-tab-body>\n  }\n</div>\n',
      styles: ['.mdc-tab{min-width:90px;padding-right:24px;padding-left:24px;display:flex;flex:1 0 auto;justify-content:center;box-sizing:border-box;margin:0;padding-top:0;padding-bottom:0;border:none;outline:none;text-align:center;white-space:nowrap;cursor:pointer;-webkit-appearance:none;z-index:1}.mdc-tab::-moz-focus-inner{padding:0;border:0}.mdc-tab[hidden]{display:none}.mdc-tab--min-width{flex:0 1 auto}.mdc-tab__content{display:flex;align-items:center;justify-content:center;height:inherit;pointer-events:none}.mdc-tab__text-label{transition:150ms color linear;display:inline-block;line-height:1;z-index:2}.mdc-tab__icon{transition:150ms color linear;z-index:2}.mdc-tab--stacked .mdc-tab__content{flex-direction:column;align-items:center;justify-content:center}.mdc-tab--stacked .mdc-tab__text-label{padding-top:6px;padding-bottom:4px}.mdc-tab--active .mdc-tab__text-label,.mdc-tab--active .mdc-tab__icon{transition-delay:100ms}.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label{padding-left:8px;padding-right:0}[dir=rtl] .mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label,.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label[dir=rtl]{padding-left:0;padding-right:8px}.mdc-tab-indicator{display:flex;position:absolute;top:0;left:0;justify-content:center;width:100%;height:100%;pointer-events:none;z-index:1}.mdc-tab-indicator__content{transform-origin:left;opacity:0}.mdc-tab-indicator__content--underline{align-self:flex-end;box-sizing:border-box;width:100%;border-top-style:solid}.mdc-tab-indicator__content--icon{align-self:center;margin:0 auto}.mdc-tab-indicator--active .mdc-tab-indicator__content{opacity:1}.mdc-tab-indicator .mdc-tab-indicator__content{transition:250ms transform cubic-bezier(0.4, 0, 0.2, 1)}.mdc-tab-indicator--no-transition .mdc-tab-indicator__content{transition:none}.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition:150ms opacity linear}.mdc-tab-indicator--active.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition-delay:100ms}.mat-mdc-tab-ripple{position:absolute;top:0;left:0;bottom:0;right:0;pointer-events:none}.mat-mdc-tab{-webkit-tap-highlight-color:rgba(0,0,0,0);-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;text-decoration:none;background:none;font-family:var(--mat-tab-header-label-text-font);font-size:var(--mat-tab-header-label-text-size);letter-spacing:var(--mat-tab-header-label-text-tracking);line-height:var(--mat-tab-header-label-text-line-height);font-weight:var(--mat-tab-header-label-text-weight)}.mat-mdc-tab .mdc-tab-indicator__content--underline{border-color:var(--mdc-tab-indicator-active-indicator-color)}.mat-mdc-tab .mdc-tab-indicator__content--underline{border-top-width:var(--mdc-tab-indicator-active-indicator-height)}.mat-mdc-tab .mdc-tab-indicator__content--underline{border-radius:var(--mdc-tab-indicator-active-indicator-shape)}.mat-mdc-tab:not(.mdc-tab--stacked){height:var(--mdc-secondary-navigation-tab-container-height)}.mat-mdc-tab:not(:disabled).mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):hover.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):focus.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):active.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:disabled.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):hover:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):focus:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:not(:disabled):active:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab:disabled:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab.mdc-tab{flex-grow:0}.mat-mdc-tab:hover .mdc-tab__text-label{color:var(--mat-tab-header-inactive-hover-label-text-color)}.mat-mdc-tab:focus .mdc-tab__text-label{color:var(--mat-tab-header-inactive-focus-label-text-color)}.mat-mdc-tab.mdc-tab--active .mdc-tab__text-label{color:var(--mat-tab-header-active-label-text-color)}.mat-mdc-tab.mdc-tab--active .mdc-tab__ripple::before,.mat-mdc-tab.mdc-tab--active .mat-ripple-element{background-color:var(--mat-tab-header-active-ripple-color)}.mat-mdc-tab.mdc-tab--active:hover .mdc-tab__text-label{color:var(--mat-tab-header-active-hover-label-text-color)}.mat-mdc-tab.mdc-tab--active:hover .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-hover-indicator-color)}.mat-mdc-tab.mdc-tab--active:focus .mdc-tab__text-label{color:var(--mat-tab-header-active-focus-label-text-color)}.mat-mdc-tab.mdc-tab--active:focus .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-focus-indicator-color)}.mat-mdc-tab.mat-mdc-tab-disabled{opacity:.4;pointer-events:none}.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__content{pointer-events:none}.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__ripple::before,.mat-mdc-tab.mat-mdc-tab-disabled .mat-ripple-element{background-color:var(--mat-tab-header-disabled-ripple-color)}.mat-mdc-tab .mdc-tab__ripple::before{content:"";display:block;position:absolute;top:0;left:0;right:0;bottom:0;opacity:0;pointer-events:none;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab .mdc-tab__text-label{color:var(--mat-tab-header-inactive-label-text-color);display:inline-flex;align-items:center}.mat-mdc-tab .mdc-tab__content{position:relative;pointer-events:auto}.mat-mdc-tab:hover .mdc-tab__ripple::before{opacity:.04}.mat-mdc-tab.cdk-program-focused .mdc-tab__ripple::before,.mat-mdc-tab.cdk-keyboard-focused .mdc-tab__ripple::before{opacity:.12}.mat-mdc-tab .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-group.mat-mdc-tab-group-stretch-tabs>.mat-mdc-tab-header .mat-mdc-tab{flex-grow:1}.mat-mdc-tab-group{display:flex;flex-direction:column;max-width:100%}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination{background-color:var(--mat-tab-header-with-background-background-color)}.mat-mdc-tab-group.mat-tabs-with-background.mat-primary>.mat-mdc-tab-header .mat-mdc-tab .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background.mat-primary>.mat-mdc-tab-header .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-mdc-focus-indicator::before,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-focus-indicator::before{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-ripple-element,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mdc-tab__ripple::before,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-ripple-element,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mdc-tab__ripple::before{background-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-group.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header{flex-direction:column-reverse}.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header .mdc-tab-indicator__content--underline{align-self:flex-start}.mat-mdc-tab-body-wrapper{position:relative;overflow:hidden;display:flex;transition:height 500ms cubic-bezier(0.35, 0, 0.25, 1)}.mat-mdc-tab-body-wrapper._mat-animation-noopable{transition:none !important;animation:none !important}']
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: ChangeDetectorRef
  }, {
    type: void 0,
    decorators: [{
      type: Inject,
      args: [MAT_TABS_CONFIG]
    }, {
      type: Optional
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
    _allTabs: [{
      type: ContentChildren,
      args: [MatTab, {
        descendants: true
      }]
    }],
    _tabBodyWrapper: [{
      type: ViewChild,
      args: ["tabBodyWrapper"]
    }],
    _tabHeader: [{
      type: ViewChild,
      args: ["tabHeader"]
    }],
    color: [{
      type: Input
    }],
    fitInkBarToContent: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    stretchTabs: [{
      type: Input,
      args: [{
        alias: "mat-stretch-tabs",
        transform: booleanAttribute
      }]
    }],
    dynamicHeight: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    selectedIndex: [{
      type: Input,
      args: [{
        transform: numberAttribute
      }]
    }],
    headerPosition: [{
      type: Input
    }],
    animationDuration: [{
      type: Input
    }],
    contentTabIndex: [{
      type: Input,
      args: [{
        transform: numberAttribute
      }]
    }],
    disablePagination: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    preserveContent: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    backgroundColor: [{
      type: Input
    }],
    selectedIndexChange: [{
      type: Output
    }],
    focusChange: [{
      type: Output
    }],
    animationDone: [{
      type: Output
    }],
    selectedTabChange: [{
      type: Output
    }]
  });
})();
var MatTabChangeEvent = class {
};
var nextUniqueId4 = 0;
var _MatTabNav = class _MatTabNav extends MatPaginatedTabHeader {
  /** Whether the ink bar should fit its width to the size of the tab label content. */
  get fitInkBarToContent() {
    return this._fitInkBarToContent.value;
  }
  set fitInkBarToContent(value) {
    this._fitInkBarToContent.next(value);
    this._changeDetectorRef.markForCheck();
  }
  get animationDuration() {
    return this._animationDuration;
  }
  set animationDuration(value) {
    const stringValue = value + "";
    this._animationDuration = /^\d+$/.test(stringValue) ? value + "ms" : stringValue;
  }
  /** Background color of the tab nav. */
  get backgroundColor() {
    return this._backgroundColor;
  }
  set backgroundColor(value) {
    const classList = this._elementRef.nativeElement.classList;
    classList.remove("mat-tabs-with-background", `mat-background-${this.backgroundColor}`);
    if (value) {
      classList.add("mat-tabs-with-background", `mat-background-${value}`);
    }
    this._backgroundColor = value;
  }
  constructor(elementRef, dir, ngZone, changeDetectorRef, viewportRuler, platform, animationMode, defaultConfig) {
    super(elementRef, changeDetectorRef, viewportRuler, dir, ngZone, platform, animationMode);
    this._fitInkBarToContent = new BehaviorSubject(false);
    this.stretchTabs = true;
    this.disableRipple = false;
    this.color = "primary";
    this.disablePagination = defaultConfig && defaultConfig.disablePagination != null ? defaultConfig.disablePagination : false;
    this.fitInkBarToContent = defaultConfig && defaultConfig.fitInkBarToContent != null ? defaultConfig.fitInkBarToContent : false;
    this.stretchTabs = defaultConfig && defaultConfig.stretchTabs != null ? defaultConfig.stretchTabs : true;
  }
  _itemSelected() {
  }
  ngAfterContentInit() {
    this._inkBar = new MatInkBar(this._items);
    this._items.changes.pipe(startWith(null), takeUntil(this._destroyed)).subscribe(() => {
      this.updateActiveLink();
    });
    super.ngAfterContentInit();
  }
  ngAfterViewInit() {
    if (!this.tabPanel && (typeof ngDevMode === "undefined" || ngDevMode)) {
      throw new Error("A mat-tab-nav-panel must be specified via [tabPanel].");
    }
    super.ngAfterViewInit();
  }
  /** Notifies the component that the active link has been changed. */
  updateActiveLink() {
    if (!this._items) {
      return;
    }
    const items = this._items.toArray();
    for (let i = 0; i < items.length; i++) {
      if (items[i].active) {
        this.selectedIndex = i;
        this._changeDetectorRef.markForCheck();
        if (this.tabPanel) {
          this.tabPanel._activeTabId = items[i].id;
        }
        return;
      }
    }
    this.selectedIndex = -1;
    this._inkBar.hide();
  }
  _getRole() {
    return this.tabPanel ? "tablist" : this._elementRef.nativeElement.getAttribute("role");
  }
};
_MatTabNav.\u0275fac = function MatTabNav_Factory(t) {
  return new (t || _MatTabNav)(\u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(Directionality, 8), \u0275\u0275directiveInject(NgZone), \u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(ViewportRuler), \u0275\u0275directiveInject(Platform), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8), \u0275\u0275directiveInject(MAT_TABS_CONFIG, 8));
};
_MatTabNav.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatTabNav,
  selectors: [["", "mat-tab-nav-bar", ""]],
  contentQueries: function MatTabNav_ContentQueries(rf, ctx, dirIndex) {
    if (rf & 1) {
      \u0275\u0275contentQuery(dirIndex, MatTabLink, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._items = _t);
    }
  },
  viewQuery: function MatTabNav_Query(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275viewQuery(_c18, 7);
      \u0275\u0275viewQuery(_c24, 7);
      \u0275\u0275viewQuery(_c33, 7);
      \u0275\u0275viewQuery(_c43, 5);
      \u0275\u0275viewQuery(_c53, 5);
    }
    if (rf & 2) {
      let _t;
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabListContainer = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabList = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._tabListInner = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._nextPaginator = _t.first);
      \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx._previousPaginator = _t.first);
    }
  },
  hostAttrs: [1, "mat-mdc-tab-nav-bar", "mat-mdc-tab-header"],
  hostVars: 17,
  hostBindings: function MatTabNav_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275attribute("role", ctx._getRole());
      \u0275\u0275styleProp("--mat-tab-animation-duration", ctx.animationDuration);
      \u0275\u0275classProp("mat-mdc-tab-header-pagination-controls-enabled", ctx._showPaginationControls)("mat-mdc-tab-header-rtl", ctx._getLayoutDirection() == "rtl")("mat-mdc-tab-nav-bar-stretch-tabs", ctx.stretchTabs)("mat-primary", ctx.color !== "warn" && ctx.color !== "accent")("mat-accent", ctx.color === "accent")("mat-warn", ctx.color === "warn")("_mat-animation-noopable", ctx._animationMode === "NoopAnimations");
    }
  },
  inputs: {
    fitInkBarToContent: [InputFlags.HasDecoratorInputTransform, "fitInkBarToContent", "fitInkBarToContent", booleanAttribute],
    stretchTabs: [InputFlags.HasDecoratorInputTransform, "mat-stretch-tabs", "stretchTabs", booleanAttribute],
    animationDuration: "animationDuration",
    backgroundColor: "backgroundColor",
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    color: "color",
    tabPanel: "tabPanel"
  },
  exportAs: ["matTabNavBar", "matTabNav"],
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature, \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  attrs: _c10,
  ngContentSelectors: _c015,
  decls: 13,
  vars: 8,
  consts: [["previousPaginator", ""], ["tabListContainer", ""], ["tabList", ""], ["tabListInner", ""], ["nextPaginator", ""], ["aria-hidden", "true", "type", "button", "mat-ripple", "", "tabindex", "-1", 1, "mat-mdc-tab-header-pagination", "mat-mdc-tab-header-pagination-before", 3, "click", "mousedown", "touchend", "matRippleDisabled", "disabled"], [1, "mat-mdc-tab-header-pagination-chevron"], [1, "mat-mdc-tab-link-container", 3, "keydown"], [1, "mat-mdc-tab-list", 3, "cdkObserveContent"], [1, "mat-mdc-tab-links"], ["aria-hidden", "true", "type", "button", "mat-ripple", "", "tabindex", "-1", 1, "mat-mdc-tab-header-pagination", "mat-mdc-tab-header-pagination-after", 3, "mousedown", "click", "touchend", "matRippleDisabled", "disabled"]],
  template: function MatTabNav_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = \u0275\u0275getCurrentView();
      \u0275\u0275projectionDef();
      \u0275\u0275elementStart(0, "button", 5, 0);
      \u0275\u0275listener("click", function MatTabNav_Template_button_click_0_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorClick("before"));
      })("mousedown", function MatTabNav_Template_button_mousedown_0_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorPress("before", $event));
      })("touchend", function MatTabNav_Template_button_touchend_0_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._stopInterval());
      });
      \u0275\u0275element(2, "div", 6);
      \u0275\u0275elementEnd();
      \u0275\u0275elementStart(3, "div", 7, 1);
      \u0275\u0275listener("keydown", function MatTabNav_Template_div_keydown_3_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handleKeydown($event));
      });
      \u0275\u0275elementStart(5, "div", 8, 2);
      \u0275\u0275listener("cdkObserveContent", function MatTabNav_Template_div_cdkObserveContent_5_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._onContentChanges());
      });
      \u0275\u0275elementStart(7, "div", 9, 3);
      \u0275\u0275projection(9);
      \u0275\u0275elementEnd()()();
      \u0275\u0275elementStart(10, "button", 10, 4);
      \u0275\u0275listener("mousedown", function MatTabNav_Template_button_mousedown_10_listener($event) {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorPress("after", $event));
      })("click", function MatTabNav_Template_button_click_10_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._handlePaginatorClick("after"));
      })("touchend", function MatTabNav_Template_button_touchend_10_listener() {
        \u0275\u0275restoreView(_r1);
        return \u0275\u0275resetView(ctx._stopInterval());
      });
      \u0275\u0275element(12, "div", 6);
      \u0275\u0275elementEnd();
    }
    if (rf & 2) {
      \u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled", ctx._disableScrollBefore);
      \u0275\u0275property("matRippleDisabled", ctx._disableScrollBefore || ctx.disableRipple)("disabled", ctx._disableScrollBefore || null);
      \u0275\u0275advance(10);
      \u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled", ctx._disableScrollAfter);
      \u0275\u0275property("matRippleDisabled", ctx._disableScrollAfter || ctx.disableRipple)("disabled", ctx._disableScrollAfter || null);
    }
  },
  dependencies: [MatRipple, CdkObserveContent],
  styles: [".mdc-tab{min-width:90px;padding-right:24px;padding-left:24px;display:flex;flex:1 0 auto;justify-content:center;box-sizing:border-box;margin:0;padding-top:0;padding-bottom:0;border:none;outline:none;text-align:center;white-space:nowrap;cursor:pointer;-webkit-appearance:none;z-index:1}.mdc-tab::-moz-focus-inner{padding:0;border:0}.mdc-tab[hidden]{display:none}.mdc-tab--min-width{flex:0 1 auto}.mdc-tab__content{display:flex;align-items:center;justify-content:center;height:inherit;pointer-events:none}.mdc-tab__text-label{transition:150ms color linear;display:inline-block;line-height:1;z-index:2}.mdc-tab__icon{transition:150ms color linear;z-index:2}.mdc-tab--stacked .mdc-tab__content{flex-direction:column;align-items:center;justify-content:center}.mdc-tab--stacked .mdc-tab__text-label{padding-top:6px;padding-bottom:4px}.mdc-tab--active .mdc-tab__text-label,.mdc-tab--active .mdc-tab__icon{transition-delay:100ms}.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label{padding-left:8px;padding-right:0}[dir=rtl] .mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label,.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label[dir=rtl]{padding-left:0;padding-right:8px}.mdc-tab-indicator{display:flex;position:absolute;top:0;left:0;justify-content:center;width:100%;height:100%;pointer-events:none;z-index:1}.mdc-tab-indicator__content{transform-origin:left;opacity:0}.mdc-tab-indicator__content--underline{align-self:flex-end;box-sizing:border-box;width:100%;border-top-style:solid}.mdc-tab-indicator__content--icon{align-self:center;margin:0 auto}.mdc-tab-indicator--active .mdc-tab-indicator__content{opacity:1}.mdc-tab-indicator .mdc-tab-indicator__content{transition:250ms transform cubic-bezier(0.4, 0, 0.2, 1)}.mdc-tab-indicator--no-transition .mdc-tab-indicator__content{transition:none}.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition:150ms opacity linear}.mdc-tab-indicator--active.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition-delay:100ms}.mat-mdc-tab-ripple{position:absolute;top:0;left:0;bottom:0;right:0;pointer-events:none}.mat-mdc-tab-header{display:flex;overflow:hidden;position:relative;flex-shrink:0}.mdc-tab-indicator .mdc-tab-indicator__content{transition-duration:var(--mat-tab-animation-duration, 250ms)}.mat-mdc-tab-header-pagination{-webkit-user-select:none;user-select:none;position:relative;display:none;justify-content:center;align-items:center;min-width:32px;cursor:pointer;z-index:2;-webkit-tap-highlight-color:rgba(0,0,0,0);touch-action:none;box-sizing:content-box;background:none;border:none;outline:0;padding:0}.mat-mdc-tab-header-pagination::-moz-focus-inner{border:0}.mat-mdc-tab-header-pagination .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination{display:flex}.mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after{padding-left:4px}.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(-135deg)}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-pagination-after{padding-right:4px}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(45deg)}.mat-mdc-tab-header-pagination-chevron{border-style:solid;border-width:2px 2px 0 0;height:8px;width:8px;border-color:var(--mat-tab-header-pagination-icon-color)}.mat-mdc-tab-header-pagination-disabled{box-shadow:none;cursor:default;pointer-events:none}.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron{opacity:.4}.mat-mdc-tab-list{flex-grow:1;position:relative;transition:transform 500ms cubic-bezier(0.35, 0, 0.25, 1)}._mat-animation-noopable .mat-mdc-tab-list{transition:none}._mat-animation-noopable span.mdc-tab-indicator__content,._mat-animation-noopable span.mdc-tab__text-label{transition:none}.mat-mdc-tab-links{display:flex;flex:1 0 auto}[mat-align-tabs=center]>.mat-mdc-tab-link-container .mat-mdc-tab-links{justify-content:center}[mat-align-tabs=end]>.mat-mdc-tab-link-container .mat-mdc-tab-links{justify-content:flex-end}.mat-mdc-tab-link-container{display:flex;flex-grow:1;overflow:hidden;z-index:1;border-bottom-style:solid;border-bottom-width:var(--mat-tab-header-divider-height);border-bottom-color:var(--mat-tab-header-divider-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination{background-color:var(--mat-tab-header-with-background-background-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary>.mat-mdc-tab-link-container .mat-mdc-tab-link .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary>.mat-mdc-tab-link-container .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-mdc-focus-indicator::before,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-focus-indicator::before{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-ripple-element,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mdc-tab__ripple::before,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-ripple-element,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mdc-tab__ripple::before{background-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron{color:var(--mat-tab-header-with-background-foreground-color)}"],
  encapsulation: 2
});
var MatTabNav = _MatTabNav;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabNav, [{
    type: Component,
    args: [{
      selector: "[mat-tab-nav-bar]",
      exportAs: "matTabNavBar, matTabNav",
      host: {
        "[attr.role]": "_getRole()",
        "class": "mat-mdc-tab-nav-bar mat-mdc-tab-header",
        "[class.mat-mdc-tab-header-pagination-controls-enabled]": "_showPaginationControls",
        "[class.mat-mdc-tab-header-rtl]": "_getLayoutDirection() == 'rtl'",
        "[class.mat-mdc-tab-nav-bar-stretch-tabs]": "stretchTabs",
        "[class.mat-primary]": 'color !== "warn" && color !== "accent"',
        "[class.mat-accent]": 'color === "accent"',
        "[class.mat-warn]": 'color === "warn"',
        "[class._mat-animation-noopable]": '_animationMode === "NoopAnimations"',
        "[style.--mat-tab-animation-duration]": "animationDuration"
      },
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.Default,
      standalone: true,
      imports: [MatRipple, CdkObserveContent],
      template: `<!-- TODO: this also had \`mat-elevation-z4\`. Figure out what we should do with it. -->
<button class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-before"
     #previousPaginator
     aria-hidden="true"
     type="button"
     mat-ripple
     tabindex="-1"
     [matRippleDisabled]="_disableScrollBefore || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollBefore"
     [disabled]="_disableScrollBefore || null"
     (click)="_handlePaginatorClick('before')"
     (mousedown)="_handlePaginatorPress('before', $event)"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</button>

<div class="mat-mdc-tab-link-container" #tabListContainer (keydown)="_handleKeydown($event)">
  <div class="mat-mdc-tab-list" #tabList (cdkObserveContent)="_onContentChanges()">
    <div class="mat-mdc-tab-links" #tabListInner>
      <ng-content></ng-content>
    </div>
  </div>
</div>

<!-- TODO: this also had \`mat-elevation-z4\`. Figure out what we should do with it. -->
<button class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-after"
     #nextPaginator
     aria-hidden="true"
     type="button"
     mat-ripple
     [matRippleDisabled]="_disableScrollAfter || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollAfter"
     [disabled]="_disableScrollAfter || null"
     tabindex="-1"
     (mousedown)="_handlePaginatorPress('after', $event)"
     (click)="_handlePaginatorClick('after')"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</button>
`,
      styles: [".mdc-tab{min-width:90px;padding-right:24px;padding-left:24px;display:flex;flex:1 0 auto;justify-content:center;box-sizing:border-box;margin:0;padding-top:0;padding-bottom:0;border:none;outline:none;text-align:center;white-space:nowrap;cursor:pointer;-webkit-appearance:none;z-index:1}.mdc-tab::-moz-focus-inner{padding:0;border:0}.mdc-tab[hidden]{display:none}.mdc-tab--min-width{flex:0 1 auto}.mdc-tab__content{display:flex;align-items:center;justify-content:center;height:inherit;pointer-events:none}.mdc-tab__text-label{transition:150ms color linear;display:inline-block;line-height:1;z-index:2}.mdc-tab__icon{transition:150ms color linear;z-index:2}.mdc-tab--stacked .mdc-tab__content{flex-direction:column;align-items:center;justify-content:center}.mdc-tab--stacked .mdc-tab__text-label{padding-top:6px;padding-bottom:4px}.mdc-tab--active .mdc-tab__text-label,.mdc-tab--active .mdc-tab__icon{transition-delay:100ms}.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label{padding-left:8px;padding-right:0}[dir=rtl] .mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label,.mdc-tab:not(.mdc-tab--stacked) .mdc-tab__icon+.mdc-tab__text-label[dir=rtl]{padding-left:0;padding-right:8px}.mdc-tab-indicator{display:flex;position:absolute;top:0;left:0;justify-content:center;width:100%;height:100%;pointer-events:none;z-index:1}.mdc-tab-indicator__content{transform-origin:left;opacity:0}.mdc-tab-indicator__content--underline{align-self:flex-end;box-sizing:border-box;width:100%;border-top-style:solid}.mdc-tab-indicator__content--icon{align-self:center;margin:0 auto}.mdc-tab-indicator--active .mdc-tab-indicator__content{opacity:1}.mdc-tab-indicator .mdc-tab-indicator__content{transition:250ms transform cubic-bezier(0.4, 0, 0.2, 1)}.mdc-tab-indicator--no-transition .mdc-tab-indicator__content{transition:none}.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition:150ms opacity linear}.mdc-tab-indicator--active.mdc-tab-indicator--fade .mdc-tab-indicator__content{transition-delay:100ms}.mat-mdc-tab-ripple{position:absolute;top:0;left:0;bottom:0;right:0;pointer-events:none}.mat-mdc-tab-header{display:flex;overflow:hidden;position:relative;flex-shrink:0}.mdc-tab-indicator .mdc-tab-indicator__content{transition-duration:var(--mat-tab-animation-duration, 250ms)}.mat-mdc-tab-header-pagination{-webkit-user-select:none;user-select:none;position:relative;display:none;justify-content:center;align-items:center;min-width:32px;cursor:pointer;z-index:2;-webkit-tap-highlight-color:rgba(0,0,0,0);touch-action:none;box-sizing:content-box;background:none;border:none;outline:0;padding:0}.mat-mdc-tab-header-pagination::-moz-focus-inner{border:0}.mat-mdc-tab-header-pagination .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination{display:flex}.mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after{padding-left:4px}.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(-135deg)}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,.mat-mdc-tab-header-pagination-after{padding-right:4px}.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron{transform:rotate(45deg)}.mat-mdc-tab-header-pagination-chevron{border-style:solid;border-width:2px 2px 0 0;height:8px;width:8px;border-color:var(--mat-tab-header-pagination-icon-color)}.mat-mdc-tab-header-pagination-disabled{box-shadow:none;cursor:default;pointer-events:none}.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron{opacity:.4}.mat-mdc-tab-list{flex-grow:1;position:relative;transition:transform 500ms cubic-bezier(0.35, 0, 0.25, 1)}._mat-animation-noopable .mat-mdc-tab-list{transition:none}._mat-animation-noopable span.mdc-tab-indicator__content,._mat-animation-noopable span.mdc-tab__text-label{transition:none}.mat-mdc-tab-links{display:flex;flex:1 0 auto}[mat-align-tabs=center]>.mat-mdc-tab-link-container .mat-mdc-tab-links{justify-content:center}[mat-align-tabs=end]>.mat-mdc-tab-link-container .mat-mdc-tab-links{justify-content:flex-end}.mat-mdc-tab-link-container{display:flex;flex-grow:1;overflow:hidden;z-index:1;border-bottom-style:solid;border-bottom-width:var(--mat-tab-header-divider-height);border-bottom-color:var(--mat-tab-header-divider-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination{background-color:var(--mat-tab-header-with-background-background-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary>.mat-mdc-tab-link-container .mat-mdc-tab-link .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary>.mat-mdc-tab-link-container .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab__text-label{color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary)>.mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-mdc-focus-indicator::before,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-focus-indicator::before{border-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-ripple-element,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mdc-tab__ripple::before,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-ripple-element,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mdc-tab__ripple::before{background-color:var(--mat-tab-header-with-background-foreground-color)}.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron,.mat-mdc-tab-nav-bar.mat-tabs-with-background>.mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron{color:var(--mat-tab-header-with-background-foreground-color)}"]
    }]
  }], () => [{
    type: ElementRef
  }, {
    type: Directionality,
    decorators: [{
      type: Optional
    }]
  }, {
    type: NgZone
  }, {
    type: ChangeDetectorRef
  }, {
    type: ViewportRuler
  }, {
    type: Platform
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_TABS_CONFIG]
    }]
  }], {
    fitInkBarToContent: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    stretchTabs: [{
      type: Input,
      args: [{
        alias: "mat-stretch-tabs",
        transform: booleanAttribute
      }]
    }],
    animationDuration: [{
      type: Input
    }],
    _items: [{
      type: ContentChildren,
      args: [forwardRef(() => MatTabLink), {
        descendants: true
      }]
    }],
    backgroundColor: [{
      type: Input
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    color: [{
      type: Input
    }],
    tabPanel: [{
      type: Input
    }],
    _tabListContainer: [{
      type: ViewChild,
      args: ["tabListContainer", {
        static: true
      }]
    }],
    _tabList: [{
      type: ViewChild,
      args: ["tabList", {
        static: true
      }]
    }],
    _tabListInner: [{
      type: ViewChild,
      args: ["tabListInner", {
        static: true
      }]
    }],
    _nextPaginator: [{
      type: ViewChild,
      args: ["nextPaginator"]
    }],
    _previousPaginator: [{
      type: ViewChild,
      args: ["previousPaginator"]
    }]
  });
})();
var _MatTabLink = class _MatTabLink extends InkBarItem {
  /** Whether the link is active. */
  get active() {
    return this._isActive;
  }
  set active(value) {
    if (value !== this._isActive) {
      this._isActive = value;
      this._tabNavBar.updateActiveLink();
    }
  }
  /**
   * Whether ripples are disabled on interaction.
   * @docs-private
   */
  get rippleDisabled() {
    return this.disabled || this.disableRipple || this._tabNavBar.disableRipple || !!this.rippleConfig.disabled;
  }
  constructor(_tabNavBar, elementRef, globalRippleOptions, tabIndex, _focusMonitor, animationMode) {
    super();
    this._tabNavBar = _tabNavBar;
    this.elementRef = elementRef;
    this._focusMonitor = _focusMonitor;
    this._destroyed = new Subject();
    this._isActive = false;
    this.disabled = false;
    this.disableRipple = false;
    this.tabIndex = 0;
    this.id = `mat-tab-link-${nextUniqueId4++}`;
    this.rippleConfig = globalRippleOptions || {};
    this.tabIndex = parseInt(tabIndex) || 0;
    if (animationMode === "NoopAnimations") {
      this.rippleConfig.animation = {
        enterDuration: 0,
        exitDuration: 0
      };
    }
    _tabNavBar._fitInkBarToContent.pipe(takeUntil(this._destroyed)).subscribe((fitInkBarToContent) => {
      this.fitInkBarToContent = fitInkBarToContent;
    });
  }
  /** Focuses the tab link. */
  focus() {
    this.elementRef.nativeElement.focus();
  }
  ngAfterViewInit() {
    this._focusMonitor.monitor(this.elementRef);
  }
  ngOnDestroy() {
    this._destroyed.next();
    this._destroyed.complete();
    super.ngOnDestroy();
    this._focusMonitor.stopMonitoring(this.elementRef);
  }
  _handleFocus() {
    this._tabNavBar.focusIndex = this._tabNavBar._items.toArray().indexOf(this);
  }
  _handleKeydown(event) {
    if (event.keyCode === SPACE || event.keyCode === ENTER) {
      if (this.disabled) {
        event.preventDefault();
      } else if (this._tabNavBar.tabPanel) {
        if (event.keyCode === SPACE) {
          event.preventDefault();
        }
        this.elementRef.nativeElement.click();
      }
    }
  }
  _getAriaControls() {
    return this._tabNavBar.tabPanel ? this._tabNavBar.tabPanel?.id : this.elementRef.nativeElement.getAttribute("aria-controls");
  }
  _getAriaSelected() {
    if (this._tabNavBar.tabPanel) {
      return this.active ? "true" : "false";
    } else {
      return this.elementRef.nativeElement.getAttribute("aria-selected");
    }
  }
  _getAriaCurrent() {
    return this.active && !this._tabNavBar.tabPanel ? "page" : null;
  }
  _getRole() {
    return this._tabNavBar.tabPanel ? "tab" : this.elementRef.nativeElement.getAttribute("role");
  }
  _getTabIndex() {
    if (this._tabNavBar.tabPanel) {
      return this._isActive && !this.disabled ? 0 : -1;
    } else {
      return this.disabled ? -1 : this.tabIndex;
    }
  }
};
_MatTabLink.\u0275fac = function MatTabLink_Factory(t) {
  return new (t || _MatTabLink)(\u0275\u0275directiveInject(MatTabNav), \u0275\u0275directiveInject(ElementRef), \u0275\u0275directiveInject(MAT_RIPPLE_GLOBAL_OPTIONS, 8), \u0275\u0275injectAttribute("tabindex"), \u0275\u0275directiveInject(FocusMonitor), \u0275\u0275directiveInject(ANIMATION_MODULE_TYPE, 8));
};
_MatTabLink.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatTabLink,
  selectors: [["", "mat-tab-link", ""], ["", "matTabLink", ""]],
  hostAttrs: [1, "mdc-tab", "mat-mdc-tab-link", "mat-mdc-focus-indicator"],
  hostVars: 11,
  hostBindings: function MatTabLink_HostBindings(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275listener("focus", function MatTabLink_focus_HostBindingHandler() {
        return ctx._handleFocus();
      })("keydown", function MatTabLink_keydown_HostBindingHandler($event) {
        return ctx._handleKeydown($event);
      });
    }
    if (rf & 2) {
      \u0275\u0275attribute("aria-controls", ctx._getAriaControls())("aria-current", ctx._getAriaCurrent())("aria-disabled", ctx.disabled)("aria-selected", ctx._getAriaSelected())("id", ctx.id)("tabIndex", ctx._getTabIndex())("role", ctx._getRole());
      \u0275\u0275classProp("mat-mdc-tab-disabled", ctx.disabled)("mdc-tab--active", ctx.active);
    }
  },
  inputs: {
    active: [InputFlags.HasDecoratorInputTransform, "active", "active", booleanAttribute],
    disabled: [InputFlags.HasDecoratorInputTransform, "disabled", "disabled", booleanAttribute],
    disableRipple: [InputFlags.HasDecoratorInputTransform, "disableRipple", "disableRipple", booleanAttribute],
    tabIndex: [InputFlags.HasDecoratorInputTransform, "tabIndex", "tabIndex", (value) => value == null ? 0 : numberAttribute(value)],
    id: "id"
  },
  exportAs: ["matTabLink"],
  standalone: true,
  features: [\u0275\u0275InputTransformsFeature, \u0275\u0275InheritDefinitionFeature, \u0275\u0275StandaloneFeature],
  attrs: _c11,
  ngContentSelectors: _c015,
  decls: 5,
  vars: 2,
  consts: [[1, "mdc-tab__ripple"], ["mat-ripple", "", 1, "mat-mdc-tab-ripple", 3, "matRippleTrigger", "matRippleDisabled"], [1, "mdc-tab__content"], [1, "mdc-tab__text-label"]],
  template: function MatTabLink_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275element(0, "span", 0)(1, "div", 1);
      \u0275\u0275elementStart(2, "span", 2)(3, "span", 3);
      \u0275\u0275projection(4);
      \u0275\u0275elementEnd()();
    }
    if (rf & 2) {
      \u0275\u0275advance();
      \u0275\u0275property("matRippleTrigger", ctx.elementRef.nativeElement)("matRippleDisabled", ctx.rippleDisabled);
    }
  },
  dependencies: [MatRipple],
  styles: ['.mat-mdc-tab-link{-webkit-tap-highlight-color:rgba(0,0,0,0);-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;text-decoration:none;background:none;font-family:var(--mat-tab-header-label-text-font);font-size:var(--mat-tab-header-label-text-size);letter-spacing:var(--mat-tab-header-label-text-tracking);line-height:var(--mat-tab-header-label-text-line-height);font-weight:var(--mat-tab-header-label-text-weight)}.mat-mdc-tab-link .mdc-tab-indicator__content--underline{border-color:var(--mdc-tab-indicator-active-indicator-color)}.mat-mdc-tab-link .mdc-tab-indicator__content--underline{border-top-width:var(--mdc-tab-indicator-active-indicator-height)}.mat-mdc-tab-link .mdc-tab-indicator__content--underline{border-radius:var(--mdc-tab-indicator-active-indicator-shape)}.mat-mdc-tab-link:not(.mdc-tab--stacked){height:var(--mdc-secondary-navigation-tab-container-height)}.mat-mdc-tab-link:not(:disabled).mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):hover.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):focus.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):active.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:disabled.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):hover:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):focus:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):active:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:disabled:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link.mdc-tab{flex-grow:0}.mat-mdc-tab-link:hover .mdc-tab__text-label{color:var(--mat-tab-header-inactive-hover-label-text-color)}.mat-mdc-tab-link:focus .mdc-tab__text-label{color:var(--mat-tab-header-inactive-focus-label-text-color)}.mat-mdc-tab-link.mdc-tab--active .mdc-tab__text-label{color:var(--mat-tab-header-active-label-text-color)}.mat-mdc-tab-link.mdc-tab--active .mdc-tab__ripple::before,.mat-mdc-tab-link.mdc-tab--active .mat-ripple-element{background-color:var(--mat-tab-header-active-ripple-color)}.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab__text-label{color:var(--mat-tab-header-active-hover-label-text-color)}.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-hover-indicator-color)}.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab__text-label{color:var(--mat-tab-header-active-focus-label-text-color)}.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-focus-indicator-color)}.mat-mdc-tab-link.mat-mdc-tab-disabled{opacity:.4;pointer-events:none}.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__content{pointer-events:none}.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__ripple::before,.mat-mdc-tab-link.mat-mdc-tab-disabled .mat-ripple-element{background-color:var(--mat-tab-header-disabled-ripple-color)}.mat-mdc-tab-link .mdc-tab__ripple::before{content:"";display:block;position:absolute;top:0;left:0;right:0;bottom:0;opacity:0;pointer-events:none;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-link .mdc-tab__text-label{color:var(--mat-tab-header-inactive-label-text-color);display:inline-flex;align-items:center}.mat-mdc-tab-link .mdc-tab__content{position:relative;pointer-events:auto}.mat-mdc-tab-link:hover .mdc-tab__ripple::before{opacity:.04}.mat-mdc-tab-link.cdk-program-focused .mdc-tab__ripple::before,.mat-mdc-tab-link.cdk-keyboard-focused .mdc-tab__ripple::before{opacity:.12}.mat-mdc-tab-link .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-header.mat-mdc-tab-nav-bar-stretch-tabs .mat-mdc-tab-link{flex-grow:1}.mat-mdc-tab-link::before{margin:5px}@media(max-width: 599px){.mat-mdc-tab-link{min-width:72px}}'],
  encapsulation: 2,
  changeDetection: 0
});
var MatTabLink = _MatTabLink;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabLink, [{
    type: Component,
    args: [{
      selector: "[mat-tab-link], [matTabLink]",
      exportAs: "matTabLink",
      changeDetection: ChangeDetectionStrategy.OnPush,
      encapsulation: ViewEncapsulation$1.None,
      host: {
        "class": "mdc-tab mat-mdc-tab-link mat-mdc-focus-indicator",
        "[attr.aria-controls]": "_getAriaControls()",
        "[attr.aria-current]": "_getAriaCurrent()",
        "[attr.aria-disabled]": "disabled",
        "[attr.aria-selected]": "_getAriaSelected()",
        "[attr.id]": "id",
        "[attr.tabIndex]": "_getTabIndex()",
        "[attr.role]": "_getRole()",
        "[class.mat-mdc-tab-disabled]": "disabled",
        "[class.mdc-tab--active]": "active",
        "(focus)": "_handleFocus()",
        "(keydown)": "_handleKeydown($event)"
      },
      standalone: true,
      imports: [MatRipple],
      template: '<span class="mdc-tab__ripple"></span>\n\n<div\n  class="mat-mdc-tab-ripple"\n  mat-ripple\n  [matRippleTrigger]="elementRef.nativeElement"\n  [matRippleDisabled]="rippleDisabled"></div>\n\n<span class="mdc-tab__content">\n  <span class="mdc-tab__text-label">\n    <ng-content></ng-content>\n  </span>\n</span>\n\n',
      styles: ['.mat-mdc-tab-link{-webkit-tap-highlight-color:rgba(0,0,0,0);-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;text-decoration:none;background:none;font-family:var(--mat-tab-header-label-text-font);font-size:var(--mat-tab-header-label-text-size);letter-spacing:var(--mat-tab-header-label-text-tracking);line-height:var(--mat-tab-header-label-text-line-height);font-weight:var(--mat-tab-header-label-text-weight)}.mat-mdc-tab-link .mdc-tab-indicator__content--underline{border-color:var(--mdc-tab-indicator-active-indicator-color)}.mat-mdc-tab-link .mdc-tab-indicator__content--underline{border-top-width:var(--mdc-tab-indicator-active-indicator-height)}.mat-mdc-tab-link .mdc-tab-indicator__content--underline{border-radius:var(--mdc-tab-indicator-active-indicator-shape)}.mat-mdc-tab-link:not(.mdc-tab--stacked){height:var(--mdc-secondary-navigation-tab-container-height)}.mat-mdc-tab-link:not(:disabled).mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):hover.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):focus.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):active.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:disabled.mdc-tab--active .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):hover:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):focus:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:not(:disabled):active:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link:disabled:not(.mdc-tab--active) .mdc-tab__icon{fill:currentColor}.mat-mdc-tab-link.mdc-tab{flex-grow:0}.mat-mdc-tab-link:hover .mdc-tab__text-label{color:var(--mat-tab-header-inactive-hover-label-text-color)}.mat-mdc-tab-link:focus .mdc-tab__text-label{color:var(--mat-tab-header-inactive-focus-label-text-color)}.mat-mdc-tab-link.mdc-tab--active .mdc-tab__text-label{color:var(--mat-tab-header-active-label-text-color)}.mat-mdc-tab-link.mdc-tab--active .mdc-tab__ripple::before,.mat-mdc-tab-link.mdc-tab--active .mat-ripple-element{background-color:var(--mat-tab-header-active-ripple-color)}.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab__text-label{color:var(--mat-tab-header-active-hover-label-text-color)}.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-hover-indicator-color)}.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab__text-label{color:var(--mat-tab-header-active-focus-label-text-color)}.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab-indicator__content--underline{border-color:var(--mat-tab-header-active-focus-indicator-color)}.mat-mdc-tab-link.mat-mdc-tab-disabled{opacity:.4;pointer-events:none}.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__content{pointer-events:none}.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__ripple::before,.mat-mdc-tab-link.mat-mdc-tab-disabled .mat-ripple-element{background-color:var(--mat-tab-header-disabled-ripple-color)}.mat-mdc-tab-link .mdc-tab__ripple::before{content:"";display:block;position:absolute;top:0;left:0;right:0;bottom:0;opacity:0;pointer-events:none;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-link .mdc-tab__text-label{color:var(--mat-tab-header-inactive-label-text-color);display:inline-flex;align-items:center}.mat-mdc-tab-link .mdc-tab__content{position:relative;pointer-events:auto}.mat-mdc-tab-link:hover .mdc-tab__ripple::before{opacity:.04}.mat-mdc-tab-link.cdk-program-focused .mdc-tab__ripple::before,.mat-mdc-tab-link.cdk-keyboard-focused .mdc-tab__ripple::before{opacity:.12}.mat-mdc-tab-link .mat-ripple-element{opacity:.12;background-color:var(--mat-tab-header-inactive-ripple-color)}.mat-mdc-tab-header.mat-mdc-tab-nav-bar-stretch-tabs .mat-mdc-tab-link{flex-grow:1}.mat-mdc-tab-link::before{margin:5px}@media(max-width: 599px){.mat-mdc-tab-link{min-width:72px}}']
    }]
  }], () => [{
    type: MatTabNav
  }, {
    type: ElementRef
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [MAT_RIPPLE_GLOBAL_OPTIONS]
    }]
  }, {
    type: void 0,
    decorators: [{
      type: Attribute,
      args: ["tabindex"]
    }]
  }, {
    type: FocusMonitor
  }, {
    type: void 0,
    decorators: [{
      type: Optional
    }, {
      type: Inject,
      args: [ANIMATION_MODULE_TYPE]
    }]
  }], {
    active: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disabled: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    disableRipple: [{
      type: Input,
      args: [{
        transform: booleanAttribute
      }]
    }],
    tabIndex: [{
      type: Input,
      args: [{
        transform: (value) => value == null ? 0 : numberAttribute(value)
      }]
    }],
    id: [{
      type: Input
    }]
  });
})();
var _MatTabNavPanel = class _MatTabNavPanel {
  constructor() {
    this.id = `mat-tab-nav-panel-${nextUniqueId4++}`;
  }
};
_MatTabNavPanel.\u0275fac = function MatTabNavPanel_Factory(t) {
  return new (t || _MatTabNavPanel)();
};
_MatTabNavPanel.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatTabNavPanel,
  selectors: [["mat-tab-nav-panel"]],
  hostAttrs: ["role", "tabpanel", 1, "mat-mdc-tab-nav-panel"],
  hostVars: 2,
  hostBindings: function MatTabNavPanel_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275attribute("aria-labelledby", ctx._activeTabId)("id", ctx.id);
    }
  },
  inputs: {
    id: "id"
  },
  exportAs: ["matTabNavPanel"],
  standalone: true,
  features: [\u0275\u0275StandaloneFeature],
  ngContentSelectors: _c015,
  decls: 1,
  vars: 0,
  template: function MatTabNavPanel_Template(rf, ctx) {
    if (rf & 1) {
      \u0275\u0275projectionDef();
      \u0275\u0275projection(0);
    }
  },
  encapsulation: 2,
  changeDetection: 0
});
var MatTabNavPanel = _MatTabNavPanel;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabNavPanel, [{
    type: Component,
    args: [{
      selector: "mat-tab-nav-panel",
      exportAs: "matTabNavPanel",
      template: "<ng-content></ng-content>",
      host: {
        "[attr.aria-labelledby]": "_activeTabId",
        "[attr.id]": "id",
        "class": "mat-mdc-tab-nav-panel",
        "role": "tabpanel"
      },
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true
    }]
  }], null, {
    id: [{
      type: Input
    }]
  });
})();
var _MatTabsModule = class _MatTabsModule {
};
_MatTabsModule.\u0275fac = function MatTabsModule_Factory(t) {
  return new (t || _MatTabsModule)();
};
_MatTabsModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatTabsModule
});
_MatTabsModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatCommonModule, MatCommonModule]
});
var MatTabsModule = _MatTabsModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatTabsModule, [{
    type: NgModule,
    args: [{
      imports: [MatCommonModule, MatTabContent, MatTabLabel, MatTab, MatTabGroup, MatTabNav, MatTabNavPanel, MatTabLink],
      exports: [MatCommonModule, MatTabContent, MatTabLabel, MatTab, MatTabGroup, MatTabNav, MatTabNavPanel, MatTabLink]
    }]
  }], null, null);
})();

// src/app/features/configuration/components/configuration-update/configuration-update.component.ts
var _c016 = ["selectRef"];
function ConfigurationUpdateComponent_div_0_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 51)(1, "div", 52);
    \u0275\u0275element(2, "img", 53);
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "div", 54);
    \u0275\u0275elementEnd();
  }
}
var _ConfigurationUpdateComponent = class _ConfigurationUpdateComponent {
  constructor(snackBar, formBuilder, configurationsService, utilityService) {
    this.snackBar = snackBar;
    this.formBuilder = formBuilder;
    this.configurationsService = configurationsService;
    this.utilityService = utilityService;
    this.subscriptions = new Subscription();
    this.isLoading = false;
    this.configUpdateEmitter = new EventEmitter();
  }
  ngOnInit() {
    this.form = this.formBuilder.group({
      allowAnonymousAccess: [this.data.allowAnonymousAccess],
      storeInSeparateFile: [this.data.storeInSeparateFile],
      ignoreOnFileChange: [this.data.storeInSeparateFile ? this.data.ignoreOnFileChange ?? false : null],
      registrationMode: [this.data.registrationMode],
      consumer: this.formBuilder.group({
        requestEncodings: [this.data.consumer.requestEncodings],
        isRedisActive: [this.data.consumer.isRedisActive],
        pollingSettingsWorker: this.formBuilder.group({
          isActive: [this.data.consumer.pollingSettingsWorker.isActive],
          startsIn: [this.data.consumer.pollingSettingsWorker.startsIn],
          period: [this.data.consumer.pollingSettingsWorker.period]
        })
      }),
      provider: this.formBuilder.group({
        redis: this.formBuilder.group({
          isActive: [this.data.provider.redis.isActive],
          configuration: [this.data.provider.redis.configuration],
          channel: [this.data.provider.redis.channel]
        }),
        compressionType: [this.data.provider.compressionType],
        compressionLevel: [this.data.provider.compressionLevel]
      })
    });
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  ngOnChanges(changes) {
    if (changes["data"] && this.data) {
      this.form?.patchValue({
        allowAnonymousAccess: this.data.allowAnonymousAccess,
        storeInSeparateFile: this.data.storeInSeparateFile,
        ignoreOnFileChange: this.data.ignoreOnFileChange,
        registrationMode: this.data.registrationMode,
        consumer: {
          requestEncodings: [...this.data.consumer.requestEncodings],
          isRedisActive: this.data.consumer.isRedisActive,
          pollingSettingsWorker: {
            isActive: this.data.consumer.pollingSettingsWorker.isActive,
            startsIn: this.data.consumer.pollingSettingsWorker.startsIn,
            period: this.data.consumer.pollingSettingsWorker.period
          }
        },
        provider: {
          redis: {
            isActive: this.data.provider.redis.isActive,
            configuration: this.data.provider.redis.configuration,
            channel: this.data.provider.redis.channel
          },
          compressionType: this.data.provider.compressionType,
          compressionLevel: this.data.provider.compressionLevel
        }
      });
    }
  }
  onSelectionChange(event) {
    if (this.data.registrationMode === event.value) {
      return;
    }
    this.isLoading = true;
    const registrationMode = event.value;
    let updatedFieldNameToValue = {};
    updatedFieldNameToValue["registrationMode"] = registrationMode;
    const subscription = this.configurationsService.patchConfiguration({
      appId: this.data.appId,
      identifierId: this.data.selectedIdentifierId,
      body: {
        rowVersion: this.data.rowVersion,
        updatedFieldNameToValue
      }
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        this.configUpdateEmitter.emit({
          formControlName: "registrationMode",
          registrationMode: responseData.updatedFieldNameToValue["RegistrationMode"],
          rowVersion: responseData.rowVersion
        });
        this.snackBar.open(`Configuration has been successfully updated! A restart is required for the changes to take effect.`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.isLoading = false;
      },
      error: (err) => {
        this.form.get("registrationMode")?.setValue(this.data.registrationMode);
        if (this.selectRef) {
          this.selectRef.value = this.data.registrationMode;
        }
        const error = err.error;
        if (error && error.status === 409 && error.errors) {
          this.isLoading = false;
          this.utilityService.error(error.errors, 3500);
          this.fetchLatestConfiguration();
        } else {
          this.isLoading = false;
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  onToggleChange(event, formControlName) {
    this.isLoading = true;
    let updatedFieldNameToValue = {};
    updatedFieldNameToValue[formControlName] = event.checked;
    const subscription = this.configurationsService.patchConfiguration({
      appId: this.data.appId,
      identifierId: this.data.selectedIdentifierId,
      body: {
        rowVersion: this.data.rowVersion,
        updatedFieldNameToValue
      }
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        this.data.rowVersion = responseData.rowVersion;
        switch (formControlName) {
          case "allowAnonymousAccess":
            this.configUpdateEmitter.emit({
              formControlName,
              allowAnonymousAccess: responseData.updatedFieldNameToValue["AllowAnonymousAccess"],
              rowVersion: responseData.rowVersion
            });
            break;
          case "storeInSeparateFile":
            this.configUpdateEmitter.emit({
              formControlName,
              storeInSeparateFile: responseData.updatedFieldNameToValue["StoreInSeparateFile"],
              rowVersion: responseData.rowVersion
            });
            break;
          case "ignoreOnFileChange":
            this.configUpdateEmitter.emit({
              formControlName,
              ignoreOnFileChange: responseData.updatedFieldNameToValue["IgnoreOnFileChange"],
              rowVersion: responseData.rowVersion
            });
            break;
        }
        this.snackBar.open(`Configuration has been successfully updated! A restart is required for the changes to take effect.`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.isLoading = false;
      },
      error: (err) => {
        this.form.get(formControlName)?.setValue(!event.checked);
        const error = err.error;
        if (error && error.status === 409 && error.errors) {
          this.isLoading = false;
          this.utilityService.error(error.errors, 3500);
          this.fetchLatestConfiguration();
        } else {
          this.isLoading = false;
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  saveConsumerSettings(event) {
    event.stopPropagation();
    this.isLoading = true;
    let updatedFieldNameToValue = {};
    updatedFieldNameToValue["consumer"] = __spreadValues({}, this.form.value.consumer);
    const subscription = this.configurationsService.patchConfiguration({
      appId: this.data.appId,
      identifierId: this.data.selectedIdentifierId,
      body: {
        rowVersion: this.data.rowVersion,
        updatedFieldNameToValue
      }
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        this.data.rowVersion = responseData.rowVersion;
        this.configUpdateEmitter.emit({
          formControlName: "consumer",
          consumer: responseData.updatedFieldNameToValue["Consumer"],
          rowVersion: responseData.rowVersion
        });
        this.snackBar.open(`Configuration has been successfully updated! A restart is required for the changes to take effect.`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.isLoading = false;
      },
      error: (err) => {
        this.form.get("consumer")?.setValue(__spreadValues({}, this.data.consumer));
        const error = err.error;
        if (error && error.status === 409 && error.errors) {
          this.isLoading = false;
          this.utilityService.error(error.errors, 3500);
          this.fetchLatestConfiguration();
        } else {
          this.isLoading = false;
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  saveProviderSettings(event) {
    event.stopPropagation();
    this.isLoading = true;
    let updatedFieldNameToValue = {};
    updatedFieldNameToValue["provider"] = __spreadValues({}, this.form.value.provider);
    const subscription = this.configurationsService.patchConfiguration({
      appId: this.data.appId,
      identifierId: this.data.selectedIdentifierId,
      body: {
        rowVersion: this.data.rowVersion,
        updatedFieldNameToValue
      }
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        this.data.rowVersion = responseData.rowVersion;
        this.configUpdateEmitter.emit({
          formControlName: "provider",
          provider: responseData.updatedFieldNameToValue["Provider"],
          rowVersion: responseData.rowVersion
        });
        this.snackBar.open(`Configuration has been successfully updated! A restart is required for the changes to take effect.`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
        this.isLoading = false;
      },
      error: (err) => {
        this.form.get("provider")?.setValue(__spreadValues({}, this.data.provider));
        const error = err.error;
        if (error && error.status === 409 && error.errors) {
          this.isLoading = false;
          this.utilityService.error(error.errors, 3500);
          this.fetchLatestConfiguration();
        } else {
          this.isLoading = false;
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  fetchLatestConfiguration() {
    const subscription = this.configurationsService.getConfigurationByAppAndIdentifier({
      appId: this.data.appId,
      identifierId: this.data.selectedIdentifierId
    }).subscribe({
      next: (response) => {
        const responseData = response.data;
        if (!responseData) {
          return;
        }
        this.configUpdateEmitter.emit({
          allowAnonymousAccess: responseData.allowAnonymousAccess,
          storeInSeparateFile: responseData.storeInSeparateFile,
          ignoreOnFileChange: responseData.ignoreOnFileChange,
          registrationMode: responseData.registrationMode,
          consumer: responseData.consumer,
          provider: responseData.provider,
          rowVersion: responseData.rowVersion
        });
        this.isLoading = false;
      },
      error: (err) => {
        this.isLoading = false;
      }
    });
    this.subscriptions.add(subscription);
  }
};
_ConfigurationUpdateComponent.\u0275fac = function ConfigurationUpdateComponent_Factory(t) {
  return new (t || _ConfigurationUpdateComponent)(\u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(FormBuilder), \u0275\u0275directiveInject(ConfigurationsService), \u0275\u0275directiveInject(UtilityService));
};
_ConfigurationUpdateComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _ConfigurationUpdateComponent, selectors: [["configuration-update"]], viewQuery: function ConfigurationUpdateComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c016, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.selectRef = _t.first);
  }
}, inputs: { data: "data" }, outputs: { configUpdateEmitter: "configUpdateEmitter" }, features: [\u0275\u0275NgOnChangesFeature], decls: 185, vars: 21, consts: [["selectRef", ""], ["class", "loading-container", 4, "ngIf"], [3, "formGroup"], ["appearance", "fill"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Specifies how single settings file ( separate setting files should be configured its own setting or setting class ) can be registered and resolved within the service. Supports resolving via configuration options or as a singleton service.", 1, "icon-mini"], ["formControlName", "registrationMode", 3, "selectionChange"], [1, "custom-option", 3, "value"], [1, "spacer"], ["color", "accent", "mat-icon-button", "", "matTooltipPosition", "left", "matTooltip", "Settings can be resolved through configuration options interfaces, such as IOptions<T>, IOptionsSnapshot<T> and IOptionsMonitor<T>."], ["matIconPosition", "right", "fontIcon", "info"], ["color", "accent", "mat-icon-button", "", "matTooltipPosition", "left", "matTooltip", "Settings can be resolved directly through its own class as a singleton instance."], ["color", "accent", "mat-icon-button", "", "matTooltipPosition", "left", "matTooltip", "Settings can be resolved both through singleton instances and through configuration options interfaces."], [1, "d-flex", "px-3"], [1, "mb-2", "mr-3", "d-flex", "align-items-center"], [1, "field-label-text"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Indicates whether anonymous access is allowed. When disabled, its typically forces to pre-registration of the app or user.", 1, "icon-mini"], ["labelPosition", "before", "formControlName", "allowAnonymousAccess", 3, "change"], ["matIconPosition", "right", "fontIcon", "info", 1, "icon-mini", 3, "matTooltip"], ["labelPosition", "before", "formControlName", "storeInSeparateFile", 3, "change"], [1, "mb-2", "d-flex", "align-items-center"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Indicates whether changes to the file should be ignored when the file is modified.", 1, "icon-mini"], ["labelPosition", "before", "formControlName", "ignoreOnFileChange", 3, "change"], ["multi", "true"], ["expanded", "true"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "It is only used when the instance is running in consumer mode.", 1, "icon-mini"], ["color", "primary", "mat-icon-button", "", "matTooltip", "Save", 1, "icon-mini", 3, "click"], ["multi", "true", "formGroupName", "consumer"], ["expanded", "false", "formGroupName", "pollingSettingsWorker"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Represents a worker that handles polling for the latest settings within a specified period.", 1, "icon-mini"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Indicates whether anonymous access is allowed. Changes require a restart.", 1, "icon-mini"], ["labelPosition", "before", "formControlName", "isActive"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "The time span to wait before starting the polling.", 1, "icon-mini"], ["matInput", "", "formControlName", "startsIn"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "The time span between polling period.", 1, "icon-mini"], ["matInput", "", "formControlName", "period"], ["expanded", "false"], ["formControlName", "requestEncodings", "multiple", ""], [3, "value"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "The flag indicates whether Redis is active for the consumer configuration. Redis connection details sent by the provider.", 1, "icon-mini"], ["labelPosition", "before", "formControlName", "isRedisActive"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "It is only used when the instance is running in provider mode.", 1, "icon-mini"], ["multi", "true", "formGroupName", "provider"], ["expanded", "false", "formGroupName", "redis"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "The configuration string for Redis.", 1, "icon-mini"], ["matInput", "", "formControlName", "configuration"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "The channel used to send or receive messages related to settings such as notifiying data change.", 1, "icon-mini"], ["matInput", "", "formControlName", "channel"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Defines which compression type is applied when storing the setting data.", 1, "icon-mini"], ["formControlName", "compressionType"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "Defines which compression level is applied when storing the setting data.", 1, "icon-mini"], ["formControlName", "compressionLevel"], [1, "loading-container"], [1, "mat-bg-primary", "position-absolute", "rounded-circle", "app-icon-animation"], [1, "app-icon", "bg-white"], [1, "loading-spinner"]], template: function ConfigurationUpdateComponent_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275template(0, ConfigurationUpdateComponent_div_0_Template, 4, 0, "div", 1);
    \u0275\u0275elementStart(1, "form", 2)(2, "mat-form-field", 3)(3, "mat-label");
    \u0275\u0275text(4, "Registration Mode ");
    \u0275\u0275element(5, "mat-icon", 4);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(6, "mat-select", 5, 0);
    \u0275\u0275listener("selectionChange", function ConfigurationUpdateComponent_Template_mat_select_selectionChange_6_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onSelectionChange($event));
    });
    \u0275\u0275elementStart(8, "mat-option", 6)(9, "span");
    \u0275\u0275text(10, "Configure");
    \u0275\u0275elementEnd();
    \u0275\u0275element(11, "span", 7);
    \u0275\u0275elementStart(12, "button", 8);
    \u0275\u0275element(13, "mat-icon", 9);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(14, "mat-option", 6)(15, "span");
    \u0275\u0275text(16, "Singleton");
    \u0275\u0275elementEnd();
    \u0275\u0275element(17, "span", 7);
    \u0275\u0275elementStart(18, "button", 10);
    \u0275\u0275element(19, "mat-icon", 9);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(20, "mat-option", 6)(21, "span");
    \u0275\u0275text(22, "Both");
    \u0275\u0275elementEnd();
    \u0275\u0275element(23, "span", 7);
    \u0275\u0275elementStart(24, "button", 11);
    \u0275\u0275element(25, "mat-icon", 9);
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(26, "div", 12)(27, "div", 13)(28, "span", 14);
    \u0275\u0275text(29, "Allow Anonymous Access");
    \u0275\u0275elementEnd();
    \u0275\u0275element(30, "mat-icon", 15);
    \u0275\u0275elementStart(31, "mat-slide-toggle", 16);
    \u0275\u0275listener("change", function ConfigurationUpdateComponent_Template_mat_slide_toggle_change_31_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onToggleChange($event, "allowAnonymousAccess"));
    });
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(32, "div", 13)(33, "span", 14);
    \u0275\u0275text(34, "Store In Separate File (global)");
    \u0275\u0275elementEnd();
    \u0275\u0275element(35, "mat-icon", 17);
    \u0275\u0275elementStart(36, "mat-slide-toggle", 18);
    \u0275\u0275listener("change", function ConfigurationUpdateComponent_Template_mat_slide_toggle_change_36_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onToggleChange($event, "storeInSeparateFile"));
    });
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(37, "div", 19)(38, "span", 14);
    \u0275\u0275text(39, "Ignore On File Change (global)");
    \u0275\u0275elementEnd();
    \u0275\u0275element(40, "mat-icon", 20);
    \u0275\u0275elementStart(41, "mat-slide-toggle", 21);
    \u0275\u0275listener("change", function ConfigurationUpdateComponent_Template_mat_slide_toggle_change_41_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.onToggleChange($event, "ignoreOnFileChange"));
    });
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(42, "mat-accordion", 22)(43, "mat-expansion-panel", 23)(44, "mat-expansion-panel-header")(45, "mat-panel-title");
    \u0275\u0275text(46, " Consumer Settings ");
    \u0275\u0275element(47, "mat-icon", 24);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(48, "mat-panel-description");
    \u0275\u0275element(49, "span", 7);
    \u0275\u0275elementStart(50, "button", 25);
    \u0275\u0275listener("click", function ConfigurationUpdateComponent_Template_button_click_50_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.saveConsumerSettings($event));
    });
    \u0275\u0275elementStart(51, "mat-icon");
    \u0275\u0275text(52, "save");
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(53, "mat-accordion", 26)(54, "mat-expansion-panel", 27)(55, "mat-expansion-panel-header")(56, "mat-panel-title");
    \u0275\u0275text(57, " Polling Settings Worker ");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(58, "mat-panel-description");
    \u0275\u0275element(59, "span", 7)(60, "mat-icon", 28);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(61, "div", 13)(62, "span", 14);
    \u0275\u0275text(63, "Is Active");
    \u0275\u0275elementEnd();
    \u0275\u0275element(64, "mat-icon", 29)(65, "mat-slide-toggle", 30);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(66, "mat-form-field")(67, "mat-label");
    \u0275\u0275text(68, "Starts In ");
    \u0275\u0275element(69, "mat-icon", 31);
    \u0275\u0275elementEnd();
    \u0275\u0275element(70, "input", 32);
    \u0275\u0275elementStart(71, "mat-hint");
    \u0275\u0275text(72, "Format: HH:mm:ss");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(73, "mat-form-field")(74, "mat-label");
    \u0275\u0275text(75, "Period ");
    \u0275\u0275element(76, "mat-icon", 33);
    \u0275\u0275elementEnd();
    \u0275\u0275element(77, "input", 34);
    \u0275\u0275elementStart(78, "mat-hint");
    \u0275\u0275text(79, "Format: HH:mm:ss");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(80, "mat-expansion-panel", 35)(81, "mat-expansion-panel-header")(82, "mat-panel-title");
    \u0275\u0275text(83, " Others ");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(84, "mat-form-field")(85, "mat-label");
    \u0275\u0275text(86, "Request Encodings");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(87, "mat-select", 36)(88, "mat-option", 37)(89, "span");
    \u0275\u0275text(90, "None");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(91, "mat-option", 37)(92, "span");
    \u0275\u0275text(93, "Snappy");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(94, "mat-option", 37)(95, "span");
    \u0275\u0275text(96, "Deflate");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(97, "mat-option", 37)(98, "span");
    \u0275\u0275text(99, "Gzip");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(100, "mat-option", 37)(101, "span");
    \u0275\u0275text(102, "Zstd");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(103, "mat-option", 37)(104, "span");
    \u0275\u0275text(105, "Brotli");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(106, "mat-hint");
    \u0275\u0275text(107, "The consumer can request its desired encodings, but the ultimate decision is made by the provider.");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(108, "div", 13)(109, "span", 14);
    \u0275\u0275text(110, "Is Redis Active");
    \u0275\u0275elementEnd();
    \u0275\u0275element(111, "mat-icon", 38)(112, "mat-slide-toggle", 39);
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(113, "mat-expansion-panel", 23)(114, "mat-expansion-panel-header")(115, "mat-panel-title");
    \u0275\u0275text(116, " Provider Settings ");
    \u0275\u0275element(117, "mat-icon", 40);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(118, "mat-panel-description");
    \u0275\u0275element(119, "span", 7);
    \u0275\u0275elementStart(120, "button", 25);
    \u0275\u0275listener("click", function ConfigurationUpdateComponent_Template_button_click_120_listener($event) {
      \u0275\u0275restoreView(_r1);
      return \u0275\u0275resetView(ctx.saveProviderSettings($event));
    });
    \u0275\u0275elementStart(121, "mat-icon");
    \u0275\u0275text(122, "save");
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(123, "mat-accordion", 41)(124, "mat-expansion-panel", 42)(125, "mat-expansion-panel-header")(126, "mat-panel-title");
    \u0275\u0275text(127, " Redis Settings ");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(128, "div", 13)(129, "span", 14);
    \u0275\u0275text(130, "Is Active");
    \u0275\u0275elementEnd();
    \u0275\u0275element(131, "mat-slide-toggle", 30);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(132, "mat-form-field")(133, "mat-label");
    \u0275\u0275text(134, "Configuration ");
    \u0275\u0275element(135, "mat-icon", 43);
    \u0275\u0275elementEnd();
    \u0275\u0275element(136, "input", 44);
    \u0275\u0275elementStart(137, "mat-hint");
    \u0275\u0275text(138, "e.g. localhost:6379,password=******,abortConnect=false");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(139, "mat-form-field")(140, "mat-label");
    \u0275\u0275text(141, "Channel ");
    \u0275\u0275element(142, "mat-icon", 45);
    \u0275\u0275elementEnd();
    \u0275\u0275element(143, "input", 46);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(144, "mat-expansion-panel", 35)(145, "mat-expansion-panel-header")(146, "mat-panel-title");
    \u0275\u0275text(147, " Others ");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(148, "mat-form-field")(149, "mat-label");
    \u0275\u0275text(150, "Compression Type ");
    \u0275\u0275element(151, "mat-icon", 47);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(152, "mat-select", 48)(153, "mat-option", 6)(154, "span");
    \u0275\u0275text(155, "None");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(156, "mat-option", 6)(157, "span");
    \u0275\u0275text(158, "Snappy");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(159, "mat-option", 6)(160, "span");
    \u0275\u0275text(161, "Deflate");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(162, "mat-option", 6)(163, "span");
    \u0275\u0275text(164, "Gzip");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(165, "mat-option", 6)(166, "span");
    \u0275\u0275text(167, "Zstd");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(168, "mat-option", 6)(169, "span");
    \u0275\u0275text(170, "Brotli");
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(171, "mat-form-field")(172, "mat-label");
    \u0275\u0275text(173, "Compression Level ");
    \u0275\u0275element(174, "mat-icon", 49);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(175, "mat-select", 50)(176, "mat-option", 6)(177, "span");
    \u0275\u0275text(178, "Optimal");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(179, "mat-option", 6)(180, "span");
    \u0275\u0275text(181, "Fastest");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(182, "mat-option", 6)(183, "span");
    \u0275\u0275text(184, "NoCompression");
    \u0275\u0275elementEnd()()()()()()()()();
  }
  if (rf & 2) {
    \u0275\u0275property("ngIf", ctx.isLoading);
    \u0275\u0275advance();
    \u0275\u0275property("formGroup", ctx.form);
    \u0275\u0275advance(7);
    \u0275\u0275property("value", 1);
    \u0275\u0275advance(6);
    \u0275\u0275property("value", 2);
    \u0275\u0275advance(6);
    \u0275\u0275property("value", 3);
    \u0275\u0275advance(15);
    \u0275\u0275property("matTooltip", "Indicates whether the settings should be stored in a separate file 'settings-generated.*.json'. If not, it will be stored in the default 'settings-generated.json' file.");
    \u0275\u0275advance(53);
    \u0275\u0275property("value", 0);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 1);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 2);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 3);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 4);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 5);
    \u0275\u0275advance(50);
    \u0275\u0275property("value", 0);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 1);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 2);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 3);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 4);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 5);
    \u0275\u0275advance(8);
    \u0275\u0275property("value", 0);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 1);
    \u0275\u0275advance(3);
    \u0275\u0275property("value", 2);
  }
}, dependencies: [NgIf, \u0275NgNoValidate, DefaultValueAccessor, NgControlStatus, NgControlStatusGroup, FormGroupDirective, FormControlName, FormGroupName, MatIcon, MatFormField, MatLabel, MatHint, MatOption, MatIconButton, MatTooltip, MatInput, MatSelect, MatSlideToggle, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatExpansionPanelDescription] });
var ConfigurationUpdateComponent = _ConfigurationUpdateComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(ConfigurationUpdateComponent, { className: "ConfigurationUpdateComponent", filePath: "src\\app\\features\\configuration\\components\\configuration-update\\configuration-update.component.ts", lineNumber: 19 });
})();

// src/app/features/app/components/app-view/app-view.component.ts
var _c017 = (a0) => ["./apps", a0, "new"];
function AppViewComponent_mat_option_16_button_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 23);
    \u0275\u0275listener("click", function AppViewComponent_mat_option_16_button_5_Template_button_click_0_listener($event) {
      \u0275\u0275restoreView(_r3);
      const identifier_r4 = \u0275\u0275nextContext().$implicit;
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.moveSortOrder(identifier_r4.id, $event, false));
    });
    \u0275\u0275element(1, "mat-icon", 24);
    \u0275\u0275elementEnd();
  }
}
function AppViewComponent_mat_option_16_button_6_Template(rf, ctx) {
  if (rf & 1) {
    const _r5 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 25);
    \u0275\u0275listener("click", function AppViewComponent_mat_option_16_button_6_Template_button_click_0_listener($event) {
      \u0275\u0275restoreView(_r5);
      const identifier_r4 = \u0275\u0275nextContext().$implicit;
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.moveSortOrder(identifier_r4.id, $event, true));
    });
    \u0275\u0275element(1, "mat-icon", 26);
    \u0275\u0275elementEnd();
  }
}
function AppViewComponent_mat_option_16_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-option", 18);
    \u0275\u0275listener("onSelectionChange", function AppViewComponent_mat_option_16_Template_mat_option_onSelectionChange_0_listener($event) {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onIdentifierChanged($event));
    });
    \u0275\u0275elementStart(1, "span");
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "span", 2);
    \u0275\u0275elementStart(4, "span");
    \u0275\u0275template(5, AppViewComponent_mat_option_16_button_5_Template, 2, 0, "button", 19)(6, AppViewComponent_mat_option_16_button_6_Template, 2, 0, "button", 20);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(7, "button", 21);
    \u0275\u0275listener("click", function AppViewComponent_mat_option_16_Template_button_click_7_listener($event) {
      const identifier_r4 = \u0275\u0275restoreView(_r1).$implicit;
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.deleteIdentifier(identifier_r4.id, $event));
    });
    \u0275\u0275element(8, "mat-icon", 22);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const identifier_r4 = ctx.$implicit;
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("value", identifier_r4.id);
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(identifier_r4.name);
    \u0275\u0275advance(3);
    \u0275\u0275property("ngIf", ctx_r1.appData.identifierInfo.mappingMinSortOrder !== identifier_r4.mappingSortOrder);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r1.appData.identifierInfo.mappingMaxSortOrder !== identifier_r4.mappingSortOrder);
  }
}
function AppViewComponent_setting_list_24_Template(rf, ctx) {
  if (rf & 1) {
    const _r6 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "setting-list", 27);
    \u0275\u0275listener("copySettingToIdentifierEmitter", function AppViewComponent_setting_list_24_Template_setting_list_copySettingToIdentifierEmitter_0_listener($event) {
      \u0275\u0275restoreView(_r6);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.copySettingToIdentifierEmitted($event));
    })("settingDeleteEmitter", function AppViewComponent_setting_list_24_Template_setting_list_settingDeleteEmitter_0_listener($event) {
      \u0275\u0275restoreView(_r6);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onSettingDeleteEmitted($event));
    })("fetchLatestEmitter", function AppViewComponent_setting_list_24_Template_setting_list_fetchLatestEmitter_0_listener($event) {
      \u0275\u0275restoreView(_r6);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.fetchLatestEmitted($event));
    });
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("data", ctx_r1.settingListComponentData);
  }
}
function AppViewComponent_instance_list_27_Template(rf, ctx) {
  if (rf & 1) {
    const _r7 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "instance-list", 28);
    \u0275\u0275listener("instanceDeleteEmitter", function AppViewComponent_instance_list_27_Template_instance_list_instanceDeleteEmitter_0_listener($event) {
      \u0275\u0275restoreView(_r7);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onInstanceDeleted($event));
    });
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("data", ctx_r1.appInstanceListComponentData);
  }
}
function AppViewComponent_configuration_update_30_Template(rf, ctx) {
  if (rf & 1) {
    const _r8 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "configuration-update", 29);
    \u0275\u0275listener("configUpdateEmitter", function AppViewComponent_configuration_update_30_Template_configuration_update_configUpdateEmitter_0_listener($event) {
      \u0275\u0275restoreView(_r8);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onConfigUpdateEmitted($event));
    });
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275property("data", ctx_r1.configurationUpdateComponentData);
  }
}
var _AppViewComponent = class _AppViewComponent {
  constructor(dialogRef, data, appsService, configurationsService, settingsService, appIdentifierMappingsService, dialog, snackBar, dummyComponentService, appViewService, utilityService, route, router) {
    this.dialogRef = dialogRef;
    this.data = data;
    this.appsService = appsService;
    this.configurationsService = configurationsService;
    this.settingsService = settingsService;
    this.appIdentifierMappingsService = appIdentifierMappingsService;
    this.dialog = dialog;
    this.snackBar = snackBar;
    this.dummyComponentService = dummyComponentService;
    this.appViewService = appViewService;
    this.utilityService = utilityService;
    this.route = route;
    this.router = router;
    this.appData = {
      identifierInfo: { minSortOrder: 0, maxSortOrder: 0, mappingMinSortOrder: 0, mappingMaxSortOrder: 0 },
      identifierIdToIdentifier: {},
      identifierIdToConfiguration: {},
      identifierIdToSettings: {},
      identifierIdToInstances: {}
    };
    this.identifierIdToSettingsDataMap = {};
    this.identifierIdToInstancesDataMap = {};
    this.selectedIdentifierId = "";
    this.previousSelectedIdentifierId = "";
    this.isFullScreen = false;
    this.isLoaded = false;
    this.subscriptions = new Subscription();
  }
  ngOnInit() {
    this.handleRouting(this.loadData$());
  }
  ngOnDestroy() {
    this.appViewService.emitSettingView(void 0);
    this.subscriptions.unsubscribe();
  }
  get identifiers() {
    return this.sortIdentifiers(Object.values(this.appData.identifierIdToIdentifier));
  }
  loadDefaultBehavior() {
    const identifiers = this.identifiers;
    if (identifiers.length == 0) {
      this.createIdentifier("Add an identifier to start");
      return;
    }
    const identifierId = identifiers[0].id;
    switch (this.tabIndex) {
      case ViewTab.Configuration:
        setTimeout(() => {
          this.router.navigate(["./apps", this.data.appSlug, identifierId, "configuration"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }, 150);
        break;
      case ViewTab.Instances:
        setTimeout(() => {
          this.router.navigate(["./apps", this.data.appSlug, identifierId, "instances"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }, 150);
        break;
      case ViewTab.Settings:
        setTimeout(() => {
          this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }, 150);
        break;
    }
    this.changeIdentifier(identifierId);
  }
  viewNewIdentifierMapping() {
    const viewNewIdentifierMappingObservable = this.loadData$().pipe(tap(() => {
      this.createIdentifier();
    }));
    this.subscriptions.add(viewNewIdentifierMappingObservable.subscribe());
  }
  viewSetting(event) {
    this.tabIndex = ViewTab.Settings;
    const viewSettingUpdateParamSubscription = event.activatedRoute.paramMap.subscribe((params) => {
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultBehavior();
        this.router.navigate(["./apps", this.data.appSlug], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const settingId = params.get("settingId");
      if (!settingId) {
        this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const observable = this.loadData$().pipe(tap(() => {
        if (!(identifierId in this.appData.identifierIdToSettings)) {
          this.loadDefaultBehavior();
          return;
        }
        const setting = this.appData.identifierIdToSettings[identifierId].find((s) => s.id === settingId);
        if (setting) {
          this.appViewService.emitSettingView({
            selectedSettingId: setting.id,
            settingViewType: "viewSetting"
          });
        } else {
          this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }
        this.changeIdentifier(identifierId);
      }));
      this.subscriptions.add(observable.subscribe());
    });
    this.subscriptions.add(viewSettingUpdateParamSubscription);
  }
  viewCreateSetting(event) {
    this.tabIndex = ViewTab.Settings;
    const subscription = event.activatedRoute.paramMap.subscribe((params) => {
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultBehavior();
        this.router.navigate(["./apps", this.data.appSlug], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const observable = this.loadData$().pipe(tap(() => {
        if (!(identifierId in this.appData.identifierIdToSettings)) {
          this.loadDefaultBehavior();
          return;
        }
        this.appViewService.emitSettingView({
          selectedSettingId: this.appViewService.settingView?.selectedSettingId,
          settingViewType: "viewCreateSetting"
        });
        this.changeIdentifier(identifierId);
      }));
      this.subscriptions.add(observable.subscribe());
    });
    this.subscriptions.add(subscription);
  }
  viewUpdateSetting(event) {
    this.tabIndex = ViewTab.Settings;
    const subscription = event.activatedRoute.paramMap.subscribe((params) => {
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultBehavior();
        this.router.navigate(["./apps", this.data.appSlug], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const settingId = params.get("settingId");
      if (!settingId) {
        this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const observable = this.loadData$().pipe(tap(() => {
        const settings = this.appData.identifierIdToSettings[identifierId];
        if (!settings) {
          this.loadDefaultBehavior();
          return;
        }
        const setting = settings.find((s) => s.id === settingId);
        if (!setting) {
          const internalSubscription = this.updateSetting(settingId)?.subscribe((response) => {
            if (response) {
              this.appViewService.emitSettingView({
                settingViewType: "viewUpdateSetting",
                selectedSettingId: settingId
              });
              this.changeIdentifier(identifierId);
            } else {
              this.loadDefaultBehavior();
            }
          });
          if (internalSubscription) {
            this.subscriptions.add(internalSubscription);
          }
        } else {
          this.appViewService.emitSettingView({
            settingViewType: "viewUpdateSetting",
            selectedSettingId: setting.id
          });
          this.changeIdentifier(identifierId);
        }
      }));
      this.subscriptions.add(observable.subscribe());
    });
    this.subscriptions.add(subscription);
  }
  viewCopySettingTo(event) {
    this.tabIndex = ViewTab.Settings;
    const subscription = event.activatedRoute.paramMap.subscribe((params) => {
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultBehavior();
        this.router.navigate(["./apps", this.data.appSlug], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const settingId = params.get("settingId");
      if (!settingId) {
        this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const observable = this.loadData$().pipe(tap(() => {
        const settings = this.appData.identifierIdToSettings[identifierId];
        if (!settings) {
          this.loadDefaultBehavior();
          return;
        }
        let setting = settings.find((s) => s.id === settingId);
        if (!setting) {
          const settingInDataList = this.settingListComponentData?.settingDataList.find((s) => s.settingId === settingId);
          if (settingInDataList) {
            setting = {
              id: settingId,
              computedIdentifier: settingInDataList.computedIdentifier,
              class: {
                id: settingInDataList.classId,
                namespace: settingInDataList.classNamespace,
                name: settingInDataList.className,
                fullName: settingInDataList.classFullName,
                rowVersion: ""
              },
              dataValidationDisabled: !settingInDataList.dataValidationEnabled,
              dataRestored: settingInDataList.dataRestored,
              version: settingInDataList.version,
              rowVersion: "",
              storeInSeparateFile: settingInDataList.storeInSeparateFile,
              ignoreOnFileChange: settingInDataList.ignoreOnFileChange,
              registrationMode: settingInDataList.registrationMode
            };
            settings.push(setting);
          } else {
            this.loadDefaultBehavior();
            return;
          }
        }
        this.appViewService.emitSettingView({
          settingViewType: "viewCopySettingTo",
          selectedSettingId: setting.id
        });
        this.changeIdentifier(identifierId);
      }));
      this.subscriptions.add(observable.subscribe());
    });
    this.subscriptions.add(subscription);
  }
  viewSettingHistories(event) {
    this.tabIndex = ViewTab.Settings;
    const subscription = event.activatedRoute.paramMap.subscribe((params) => {
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultBehavior();
        this.router.navigate(["./apps", this.data.appSlug], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const settingId = params.get("settingId");
      if (!settingId) {
        this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const observable = this.loadData$().pipe(tap(() => {
        const settings = this.appData.identifierIdToSettings[identifierId];
        if (!settings) {
          this.loadDefaultBehavior();
          return;
        }
        const setting = settings.find((s) => s.id === settingId);
        if (!setting) {
          this.loadDefaultBehavior();
          return;
        }
        this.appViewService.emitSettingView({
          settingViewType: "viewSettingHistories",
          selectedSettingId: setting.id
        });
        this.changeIdentifier(identifierId);
      }));
      this.subscriptions.add(observable.subscribe());
    });
    this.subscriptions.add(subscription);
  }
  viewSettingHistory(event) {
    this.tabIndex = ViewTab.Settings;
    const subscription = event.activatedRoute.paramMap.subscribe((params) => {
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultBehavior();
        this.router.navigate(["./apps", this.data.appSlug], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const settingId = params.get("settingId");
      if (!settingId) {
        this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      var historyId = params.get("historyId");
      if (!historyId) {
        this.router.navigate(["./apps", this.data.appSlug, identifierId, "settings", settingId, "histories"], { relativeTo: this.route, queryParamsHandling: "merge" });
        return;
      }
      const observable = this.loadData$().pipe(tap(() => {
        const settings = this.appData.identifierIdToSettings[identifierId];
        if (!settings) {
          this.loadDefaultBehavior();
          return;
        }
        const setting = settings.find((s) => s.id === settingId);
        if (!setting) {
          this.loadDefaultBehavior();
          return;
        }
        this.appViewService.emitSettingView({
          settingViewType: "viewSettingHistory",
          selectedSettingId: setting.id,
          selectedHistoryId: historyId
        });
        this.changeIdentifier(identifierId);
      }));
      this.subscriptions.add(observable.subscribe());
    });
    this.subscriptions.add(subscription);
  }
  viewInstance(event) {
    this.tabIndex = ViewTab.Instances;
    const subscription = event.activatedRoute.paramMap.subscribe((params) => {
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultBehavior();
        return;
      }
      const instanceId = params.get("instanceId");
      if (!instanceId) {
        this.loadDefaultBehavior();
        return;
      }
      const viewSettingsObservable = this.loadData$().pipe(tap(() => {
        const settings = this.appData.identifierIdToSettings[identifierId];
        if (!settings) {
          this.loadDefaultBehavior();
          return;
        }
        this.selectedInstanceId = instanceId;
        this.tabIndex = ViewTab.Instances;
        this.changeIdentifier(identifierId);
      }));
      this.subscriptions.add(viewSettingsObservable.subscribe());
    });
    this.subscriptions.add(subscription);
  }
  viewTabs(event, viewTab) {
    const subscription = event.activatedRoute.paramMap.subscribe((params) => {
      this.tabIndex = viewTab;
      const identifierId = params.get("identifierId");
      if (!identifierId) {
        this.loadDefaultSubscription();
        return;
      }
      const viewSettingsObservable = this.loadData$().pipe(tap(() => {
        const settings = this.appData.identifierIdToSettings[identifierId];
        if (!settings) {
          this.loadDefaultBehavior();
          this.router.navigate(["./apps", this.data.appSlug], { relativeTo: this.route, queryParamsHandling: "merge" });
          return;
        }
        this.tabIndex = viewTab;
        this.changeIdentifier(identifierId);
      }));
      this.subscriptions.add(viewSettingsObservable.subscribe());
    });
    this.subscriptions.add(subscription);
  }
  loadDefaultSubscription() {
    const subscription = this.loadData$().pipe(tap(() => {
      this.loadDefaultBehavior();
    })).subscribe();
    this.subscriptions.add(subscription);
  }
  handleRouting(loadData$) {
    const subscription = this.dummyComponentService.event$.subscribe((event) => {
      setTimeout(() => {
        if (event === void 0) {
          if (!this.isLoaded) {
            this.loadDefaultSubscription();
          }
          return;
        }
        switch (event.path) {
          case APP_VIEW_ROUTES.viewNewIdentifierMapping:
            this.viewNewIdentifierMapping();
            break;
          case APP_VIEW_ROUTES.viewSettings:
          case APP_VIEW_ROUTES.viewSettings2:
            this.viewTabs(event, ViewTab.Settings);
            break;
          case APP_VIEW_ROUTES.viewSetting:
            this.viewSetting(event);
            break;
          case APP_VIEW_ROUTES.viewCreateSetting:
            this.viewCreateSetting(event);
            break;
          case APP_VIEW_ROUTES.viewUpdateSetting:
            this.viewUpdateSetting(event);
            break;
          case APP_VIEW_ROUTES.viewCopySettingTo:
            this.viewCopySettingTo(event);
            break;
          case APP_VIEW_ROUTES.viewSettingHistories:
            this.viewSettingHistories(event);
            break;
          case APP_VIEW_ROUTES.viewSettingHistory:
            this.viewSettingHistory(event);
            break;
          case APP_VIEW_ROUTES.viewInstances:
          case APP_VIEW_ROUTES.viewInstances2:
            this.viewTabs(event, ViewTab.Instances);
            break;
          case APP_VIEW_ROUTES.viewInstance:
            this.viewInstance(event);
            break;
          case APP_VIEW_ROUTES.viewConfiguration:
            this.viewTabs(event, ViewTab.Configuration);
            break;
          default:
            this.loadDefaultSubscription();
            break;
        }
      }, 0);
    });
    this.subscriptions.add(subscription);
  }
  onIdentifierChanged(event) {
    this.previousSelectedIdentifierId = this.selectedIdentifierId;
    if (!event.source.value) {
      event.preventDefault();
      return;
    }
    if (event.isUserInput && this.selectedIdentifierId !== event.source.value) {
      this.appViewService.emitSettingView(void 0);
      if (!(event.source.value in this.appData.identifierIdToSettings)) {
        return;
      }
      this.changeIdentifier(event.source.value);
      const settingView = this.appViewService.settingView;
      if (settingView) {
        switch (settingView.settingViewType) {
          case "viewCreateSetting":
            this.router.navigate(["./apps", this.data.appSlug, event.source.value, "settings", "new"], { relativeTo: this.route, queryParamsHandling: "merge" });
            return;
        }
        const selectedSettingId = settingView.selectedSettingId;
        if (selectedSettingId) {
          switch (this.appViewService.settingView.settingViewType) {
            case "viewUpdateSetting":
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "settings", selectedSettingId, "update"], { relativeTo: this.route, queryParamsHandling: "merge" });
              return;
            case "viewCopySettingTo":
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "settings", selectedSettingId, "copyTo"], { relativeTo: this.route, queryParamsHandling: "merge" });
              return;
            case "viewSettingHistories":
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "settings", selectedSettingId, "histories"], { relativeTo: this.route, queryParamsHandling: "merge" });
              return;
            case "viewSettingHistory":
              const historyId = settingView.selectedHistoryId;
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "settings", selectedSettingId, "histories", historyId], { relativeTo: this.route, queryParamsHandling: "merge" });
              return;
            default:
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "settings", selectedSettingId], { relativeTo: this.route, queryParamsHandling: "merge" });
              return;
          }
        }
      } else {
        switch (this.tabIndex) {
          case ViewTab.Configuration:
            setTimeout(() => {
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "configuration"], { relativeTo: this.route, queryParamsHandling: "merge" });
            }, 0);
            break;
          case ViewTab.Instances:
            setTimeout(() => {
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "instances"], { relativeTo: this.route, queryParamsHandling: "merge" });
            }, 0);
            break;
          case ViewTab.Settings:
            setTimeout(() => {
              this.router.navigate(["./apps", this.data.appSlug, event.source.value, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
            }, 0);
            break;
        }
      }
    }
  }
  changeIdentifier(settingIdenfierId) {
    this.selectedIdentifierId = settingIdenfierId;
    const settings = this.appData.identifierIdToSettings[settingIdenfierId];
    const instances = this.appData.identifierIdToInstances[settingIdenfierId];
    const configuration = this.appData.identifierIdToConfiguration[settingIdenfierId];
    this.updateSettingData(settingIdenfierId, settings);
    this.updateInstances(settingIdenfierId, instances);
    this.updateConfiguration(settingIdenfierId, configuration);
  }
  updateSettingData(identifierId, settings) {
    const identifier = this.appData.identifierIdToIdentifier[identifierId];
    let settingsData = this.identifierIdToSettingsDataMap[identifierId];
    if (settingsData === void 0) {
      settingsData = this.identifierIdToSettingsDataMap[identifierId] = [];
      settings?.forEach((setting) => {
        settingsData.push({
          slug: this.data.appSlug,
          clientId: this.data.clientId,
          settingId: setting.id,
          className: setting.class.name,
          classNamespace: setting.class.namespace,
          classFullName: setting.class.fullName,
          classId: setting.class.id,
          computedIdentifier: setting.computedIdentifier,
          version: setting.version,
          isDataFetched: false,
          dataRestored: setting.dataRestored,
          dataValidationEnabled: !setting.dataValidationDisabled,
          rawData: "",
          parsedData: {},
          tempData: {},
          settingRowVersion: setting.rowVersion,
          classRowVersion: setting.class.rowVersion,
          storeInSeparateFile: setting.storeInSeparateFile,
          ignoreOnFileChange: setting.ignoreOnFileChange,
          registrationMode: setting.registrationMode
        });
      });
    }
    this.settingListComponentData = {
      slug: this.data.appSlug,
      clientId: this.data.clientId,
      clientName: this.data.clientName,
      appId: this.data.appId,
      selectedAppIdentifierId: this.selectedIdentifierId,
      selectedAppIdentifierName: identifier.name,
      settingDataList: this.identifierIdToSettingsDataMap[this.selectedIdentifierId]
    };
  }
  updateInstances(identifierId, instances) {
    let instancesData = this.identifierIdToInstancesDataMap[identifierId];
    if (instancesData === void 0) {
      instancesData = this.identifierIdToInstancesDataMap[identifierId] = [];
      instances?.forEach((instance) => {
        instancesData.push({
          id: instance.id,
          dynamicId: instance.dynamicId,
          name: instance.name,
          urls: instance.urls,
          isActive: instance.isActive,
          ipAddress: instance.ipAddress,
          machineName: instance.machineName,
          environment: instance.environment,
          reloadStrategies: instance.reloadStrategies,
          serviceType: instance.serviceType,
          version: instance.version,
          createdOn: instance.createdOn,
          updatedOn: instance.updatedOn
        });
      });
    }
    this.appInstanceListComponentData = {
      clientId: this.data.clientId,
      identifierId,
      instances: instancesData
    };
  }
  updateConfiguration(identifierId, configuration) {
    if (!configuration) {
      return;
    }
    this.configurationUpdateComponentData = {
      configurationId: configuration.id,
      appId: this.data.appId,
      selectedIdentifierId: identifierId,
      allowAnonymousAccess: configuration.allowAnonymousAccess,
      storeInSeparateFile: configuration.storeInSeparateFile,
      ignoreOnFileChange: configuration.ignoreOnFileChange,
      registrationMode: configuration.registrationMode,
      consumer: configuration.consumer,
      provider: configuration.provider,
      rowVersion: configuration.rowVersion
    };
  }
  onTabChange(index) {
    if (this.selectedIdentifierId === void 0) {
      return;
    }
    this.tabIndex = index;
    switch (index) {
      case ViewTab.Settings:
        const settings = this.appData.identifierIdToSettings[this.selectedIdentifierId];
        if (settings) {
          this.updateSettingData(this.selectedIdentifierId, settings);
          setTimeout(() => {
            this.router.navigate(["./apps", this.data.appSlug, this.selectedIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
          }, 55);
        }
        break;
      case ViewTab.Instances:
        const instances = this.appData.identifierIdToInstances[this.selectedIdentifierId];
        this.updateInstances(this.selectedIdentifierId, instances);
        setTimeout(() => {
          if (this.selectedInstanceId) {
            this.router.navigate(["./apps", this.data.appSlug, this.selectedIdentifierId, "instances", this.selectedInstanceId], { relativeTo: this.route, queryParamsHandling: "merge" });
          } else {
            this.router.navigate(["./apps", this.data.appSlug, this.selectedIdentifierId, "instances"], { relativeTo: this.route, queryParamsHandling: "merge" });
          }
        }, 55);
        break;
      case ViewTab.Configuration:
        const configuration = this.appData.identifierIdToConfiguration[this.selectedIdentifierId];
        this.updateConfiguration(this.selectedIdentifierId, configuration);
        setTimeout(() => {
          this.router.navigate(["./apps", this.data.appSlug, this.selectedIdentifierId, "configuration"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }, 55);
        break;
    }
  }
  toggleFullScreen() {
    this.isFullScreen = !this.isFullScreen;
    const dialogElement = document.querySelector(".mat-mdc-dialog-surface");
    if (this.isFullScreen) {
      dialogElement?.setAttribute("style", `
                  border-radius: 0 !important;
                `);
      this.dialogRef.updateSize("100%", "100%");
    } else {
      this.dialogRef.updateSize("1350px", "680px");
      dialogElement?.removeAttribute("style");
    }
  }
  createIdentifier(title) {
    const identifiers = this.identifiers.map((g) => ({
      id: g.id,
      name: g.name
    }));
    const data = {
      clientName: this.data.clientName,
      appSlug: this.data.appSlug,
      appId: this.data.appId,
      identifiers,
      title
    };
    const reloadIdentifier = (identifierId) => {
      return this.appsService.getGroupedAppDataByAppIdAndIdentifierId({
        appIdOrSlug: data.appId,
        identifierIdOrSlug: identifierId
      }).pipe(switchMap((response) => {
        const responseData = response.data;
        if (!responseData) {
          return of(null);
        }
        this.appData.identifierIdToIdentifier[identifierId] = responseData.identifier;
        this.appData.identifierIdToConfiguration[identifierId] = responseData.configuration;
        this.appData.identifierIdToSettings[identifierId] = responseData.settings;
        this.appData.identifierIdToInstances[identifierId] = responseData.instances;
        if (this.appData.identifierInfo) {
          this.appData.identifierInfo.minSortOrder = Math.min(this.appData.identifierInfo.minSortOrder, responseData.identifier.sortOrder);
          this.appData.identifierInfo.maxSortOrder = Math.max(this.appData.identifierInfo.maxSortOrder, responseData.identifier.sortOrder);
          this.appData.identifierInfo.mappingMinSortOrder = Math.min(this.appData.identifierInfo.mappingMinSortOrder, responseData.identifier.mappingSortOrder);
          this.appData.identifierInfo.mappingMaxSortOrder = Math.max(this.appData.identifierInfo.mappingMaxSortOrder, responseData.identifier.mappingSortOrder);
        } else {
          this.appData.identifierInfo = {
            minSortOrder: responseData.identifier.sortOrder,
            maxSortOrder: responseData.identifier.sortOrder,
            mappingMinSortOrder: responseData.identifier.mappingSortOrder,
            mappingMaxSortOrder: responseData.identifier.mappingSortOrder
          };
        }
        this.changeIdentifier(identifierId);
        return of(null);
      }));
    };
    const subscription = this.dialog.open(IdentifierMappingCreateComponent, {
      data,
      width: "500px",
      height: "170",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    }).afterClosed().subscribe((result) => {
      if (result && !this.appData.identifierIdToSettings[result.identifierId]) {
        const secondSubscription = reloadIdentifier(result.identifierId).subscribe(() => {
          let tabName;
          switch (this.tabIndex) {
            case ViewTab.Configuration:
              tabName = "configuration";
              break;
            case ViewTab.Instances:
              tabName = "instances";
              break;
            case ViewTab.Settings:
              tabName = "settings";
              break;
          }
          this.router.navigate(["./apps", this.data.appSlug, result.identifierId, tabName], { relativeTo: this.route, queryParamsHandling: "merge" });
        });
        this.subscriptions.add(secondSubscription);
      } else if (title) {
        this.router.navigate(["apps"]);
        this.dialogRef.close();
      } else {
        if (this.previousSelectedIdentifierId in this.identifiers) {
          if (this.tabIndex === ViewTab.Settings) {
            const selectedSettingId = this.appViewService.settingView?.selectedSettingId;
            if (selectedSettingId) {
              this.router.navigate(["./apps", this.data.appSlug, this.previousSelectedIdentifierId, "settings", selectedSettingId], { relativeTo: this.route, queryParamsHandling: "merge" });
            } else {
              this.router.navigate(["./apps", this.data.appSlug, this.previousSelectedIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
            }
          } else if (this.tabIndex === ViewTab.Instances) {
            this.router.navigate(["./apps", this.data.appSlug, this.previousSelectedIdentifierId, "instances"], { relativeTo: this.route, queryParamsHandling: "merge" });
          } else {
            this.router.navigate(["./apps", this.data.appSlug, this.previousSelectedIdentifierId, "configuration"], { relativeTo: this.route, queryParamsHandling: "merge" });
          }
          this.changeIdentifier(this.previousSelectedIdentifierId);
        } else {
          this.router.navigate(["./apps", this.data.appSlug, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  onSettingDeleteEmitted(settingId) {
    const settings = this.appData.identifierIdToSettings[this.selectedIdentifierId];
    if (!settings) {
      return;
    }
    const settingIndex = settings.findIndex((i) => i.id === settingId);
    if (settingIndex === -1) {
      return;
    }
    settings.splice(settingIndex, 1);
    const settingsDataSource = this.identifierIdToSettingsDataMap[this.selectedIdentifierId];
    if (!settingsDataSource) {
      return;
    }
    const settingDataSourceIndex = settingsDataSource.findIndex((i) => i.settingId === settingId);
    if (settingDataSourceIndex === -1) {
      return;
    }
    settingsDataSource.splice(settingDataSourceIndex, 1);
  }
  onConfigUpdateEmitted(data) {
    if (!this.configurationUpdateComponentData) {
      return;
    }
    const configuration = this.appData.identifierIdToConfiguration[this.selectedIdentifierId];
    configuration.rowVersion = this.configurationUpdateComponentData.rowVersion = data.rowVersion;
    if (data.formControlName) {
      switch (data.formControlName) {
        case "allowAnonymousAccess":
          configuration.allowAnonymousAccess = this.configurationUpdateComponentData.allowAnonymousAccess = data.allowAnonymousAccess;
          break;
        case "storeInSeparateFile":
          configuration.storeInSeparateFile = this.configurationUpdateComponentData.storeInSeparateFile = data.storeInSeparateFile;
          break;
        case "ignoreOnFileChange":
          configuration.ignoreOnFileChange = this.configurationUpdateComponentData.ignoreOnFileChange = data.ignoreOnFileChange;
          break;
        case "registrationMode":
          configuration.registrationMode = this.configurationUpdateComponentData.registrationMode = data.registrationMode;
          break;
        case "consumer":
          configuration.consumer = this.configurationUpdateComponentData.consumer = data.consumer;
          break;
        case "provider":
          configuration.provider = this.configurationUpdateComponentData.provider = data.provider;
          break;
      }
    } else {
      configuration.allowAnonymousAccess = this.configurationUpdateComponentData.allowAnonymousAccess = data.allowAnonymousAccess;
      configuration.storeInSeparateFile = this.configurationUpdateComponentData.storeInSeparateFile = data.storeInSeparateFile;
      configuration.ignoreOnFileChange = this.configurationUpdateComponentData.ignoreOnFileChange = data.ignoreOnFileChange;
      configuration.registrationMode = this.configurationUpdateComponentData.registrationMode = data.registrationMode;
      configuration.consumer = this.configurationUpdateComponentData.consumer = data.consumer;
      configuration.provider = this.configurationUpdateComponentData.provider = data.provider;
    }
  }
  fetchLatestEmitted(settingId) {
    const subscription = this.updateSetting(settingId)?.subscribe((isSuccess) => {
      if (isSuccess) {
        this.snackBar.open(`Latest data fetched successfully!`, "Close", {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration: 5e3
        });
      }
    });
    if (subscription) {
      this.subscriptions.add(subscription);
    }
  }
  updateSetting(settingId) {
    const settings = this.appData.identifierIdToSettings[this.selectedIdentifierId];
    if (!settings) {
      return;
    }
    let setting = settings.find((i) => i.id === settingId);
    return this.settingsService.getSettingById({ settingId }).pipe(switchMap((response) => {
      if (!response.data || response.data.identifierId !== this.selectedIdentifierId) {
        return of(null);
      }
      if (!setting) {
        setting = {
          id: settingId,
          computedIdentifier: response.data.computedIdentifier,
          dataRestored: response.data.dataRestored,
          registrationMode: response.data.registrationMode,
          dataValidationDisabled: response.data.dataValidationDisabled,
          storeInSeparateFile: response.data.storeInSeparateFile,
          ignoreOnFileChange: response.data.ignoreOnFileChange,
          version: response.data.version,
          rowVersion: response.data.rowVersion,
          class: {
            id: response.data.class.id,
            namespace: response.data.class.namespace,
            name: response.data.class.name,
            fullName: response.data.class.fullName,
            rowVersion: response.data.class.rowVersion
          }
        };
        settings.push(setting);
      } else {
        setting.computedIdentifier = response.data.computedIdentifier;
        setting.dataRestored = response.data.dataRestored;
        setting.registrationMode = response.data.registrationMode;
        setting.dataValidationDisabled = response.data.dataValidationDisabled;
        setting.storeInSeparateFile = response.data.storeInSeparateFile;
        setting.ignoreOnFileChange = response.data.ignoreOnFileChange;
        setting.version = response.data.version;
        setting.rowVersion = response.data.rowVersion;
        setting.class.id = response.data.class.id;
        setting.class.namespace = response.data.class.namespace;
        setting.class.name = response.data.class.name;
        setting.class.fullName = response.data.class.fullName;
        setting.class.rowVersion = response.data.class.rowVersion;
      }
      const settingsData = this.identifierIdToSettingsDataMap[this.selectedIdentifierId];
      let settingData = settingsData.find((s) => s.settingId === settingId);
      let parsedData, tempData;
      try {
        parsedData = JSON.parse(response.data.data);
      } catch {
        parsedData = {};
      }
      tempData = __spreadValues({}, parsedData);
      if (!settingData) {
        settingData = {
          slug: this.data.appSlug,
          clientId: this.data.clientId,
          settingId,
          computedIdentifier: response.data.computedIdentifier,
          dataRestored: response.data.dataRestored,
          registrationMode: response.data.registrationMode,
          dataValidationEnabled: !response.data.dataValidationDisabled,
          storeInSeparateFile: response.data.storeInSeparateFile,
          ignoreOnFileChange: response.data.ignoreOnFileChange,
          version: response.data.version,
          settingRowVersion: response.data.rowVersion,
          classId: response.data.class.id,
          classNamespace: response.data.class.namespace,
          className: response.data.class.name,
          classFullName: response.data.class.fullName,
          classRowVersion: response.data.class.rowVersion,
          isDataFetched: true,
          rawData: response.data.data,
          parsedData,
          tempData
        };
        settingsData.push(settingData);
      } else {
        settingData.computedIdentifier = setting.computedIdentifier;
        settingData.dataRestored = setting.dataRestored;
        settingData.registrationMode = setting.registrationMode;
        settingData.dataValidationEnabled = !setting.dataValidationDisabled;
        settingData.storeInSeparateFile = setting.storeInSeparateFile;
        settingData.ignoreOnFileChange = setting.ignoreOnFileChange;
        settingData.version = setting.version;
        settingData.settingRowVersion = setting.rowVersion;
        settingData.classNamespace = setting.class.namespace;
        settingData.className = setting.class.name;
        settingData.classFullName = setting.class.fullName;
        settingData.classRowVersion = setting.class.rowVersion;
        settingData.isDataFetched = true;
        settingData.rawData = response.data.data;
        settingData.parsedData = parsedData;
        settingData.tempData = tempData;
      }
      return of(true);
    }));
  }
  onInstanceDeleted(instanceId) {
    const model = this.appData.identifierIdToInstances[this.selectedIdentifierId];
    if (!model) {
      return;
    }
    const index = model.findIndex((m) => m.id === instanceId);
    if (index === -1) {
      return;
    }
    model.splice(index, 1);
  }
  copySettingToIdentifierEmitted(emitData) {
    const notAvailableAppIdentifiers = Object.entries(this.appData.identifierIdToSettings).filter((g) => g[1].some((i) => i.computedIdentifier == emitData.computedIdentifier)).map((g) => {
      const identifier = this.appData.identifierIdToIdentifier[g[0]];
      return {
        id: identifier.id,
        name: identifier.name
      };
    });
    const data = {
      clientId: this.data.clientId,
      clientName: this.data.clientName,
      computedIdentifier: emitData.computedIdentifier,
      className: emitData.className,
      appId: this.data.appId,
      currentSettingId: emitData.currentSettingId,
      currentAppIdentifierName: emitData.currentAppIdentifierName,
      currentAppIdentifierId: emitData.currentAppIdentifierId,
      notAvailableAppIdentifiers
    };
    const subscription = this.dialog.open(SettingCopyToComponent, {
      data,
      width: "500px",
      height: "240px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    }).afterClosed().subscribe((result) => {
      const selectedSettingId = result?.settingId ?? (emitData.isExpanded ? this.appViewService.settingView?.selectedSettingId : void 0);
      if (result === void 0) {
        if (selectedSettingId) {
          this.router.navigate(["./apps", this.data.appSlug, this.selectedIdentifierId, "settings", selectedSettingId], { relativeTo: this.route, queryParamsHandling: "merge" });
        } else {
          this.router.navigate(["./apps", this.data.appSlug, this.selectedIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
        }
        return;
      }
      if (data.clientId !== result.clientId) {
        this.dialogRef.close();
        setTimeout(() => {
          if (selectedSettingId) {
            this.router.navigate(["./apps", result.appSlug, result?.identifierId ?? this.selectedIdentifierId, "settings", selectedSettingId], { relativeTo: this.route, queryParamsHandling: "merge" });
          } else {
            this.router.navigate(["./apps", result.appSlug, result?.identifierId ?? this.selectedIdentifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
          }
        }, 500);
        return;
      } else {
        const configurationSubscription = this.configurationsService.getConfigurationByAppAndIdentifier({
          appId: this.data.appId,
          identifierId: result.identifierId
        }).subscribe({
          next: (response) => {
            const responseData = response.data;
            if (!responseData) {
              return;
            }
            this.appData.identifierIdToConfiguration[result.identifierId] = {
              id: responseData.id,
              allowAnonymousAccess: responseData.allowAnonymousAccess,
              storeInSeparateFile: responseData.storeInSeparateFile,
              ignoreOnFileChange: responseData.ignoreOnFileChange,
              registrationMode: responseData.registrationMode,
              consumer: responseData.consumer,
              provider: responseData.provider,
              rowVersion: responseData.rowVersion
            };
          }
        });
        this.subscriptions.add(configurationSubscription);
      }
      let groupedSetting = this.appData.identifierIdToSettings[result.identifierId];
      if (!groupedSetting) {
        const identifier = {
          id: result.identifierId,
          name: result.identifierName,
          sortOrder: result.identifierSortOrder,
          mappingSortOrder: result.identifierMappingSortOrder,
          mappingRowVersion: ""
        };
        this.appData.identifierIdToSettings[result.identifierId] = [];
        this.appData.identifierIdToIdentifier[result.identifierId] = identifier;
        groupedSetting = this.appData.identifierIdToSettings[result.identifierId];
        this.sortIdentifiers(Object.values(this.appData.identifierIdToIdentifier));
      }
      groupedSetting.push({
        id: result.settingId,
        version: "0",
        dataValidationDisabled: !emitData.isDataValidationEnabled,
        dataRestored: false,
        computedIdentifier: emitData.computedIdentifier,
        rowVersion: "",
        class: {
          name: emitData.className,
          namespace: emitData.classNamespace,
          fullName: emitData.classFullName,
          id: result.classId,
          rowVersion: ""
        },
        storeInSeparateFile: emitData.storeInSeparateFile,
        ignoreOnFileChange: emitData.ignoreOnFileChange,
        registrationMode: emitData.registrationMode
      });
      let model = this.identifierIdToSettingsDataMap[result.identifierId];
      if (model === void 0) {
        this.updateSettingData(result.identifierId, groupedSetting);
        model = this.identifierIdToSettingsDataMap[result.identifierId];
      } else {
        model.push({
          slug: this.data.appSlug,
          clientId: this.data.clientId,
          settingId: result.settingId,
          className: emitData.className,
          classNamespace: emitData.classNamespace,
          classFullName: emitData.classFullName,
          classId: result.classId,
          computedIdentifier: emitData.computedIdentifier,
          version: "0",
          isDataFetched: true,
          dataRestored: false,
          dataValidationEnabled: emitData.isDataValidationEnabled,
          rawData: emitData.rawData,
          parsedData: emitData.parsedData,
          tempData: __spreadValues({}, emitData.parsedData),
          settingRowVersion: "",
          classRowVersion: "",
          storeInSeparateFile: emitData.storeInSeparateFile,
          ignoreOnFileChange: emitData.ignoreOnFileChange,
          registrationMode: emitData.registrationMode
        });
      }
      this.changeIdentifier(result.identifierId);
      this.appViewService.emitSettingView({
        selectedSettingId: result.settingId,
        settingViewType: "viewSetting"
      });
      if (selectedSettingId) {
        this.router.navigate(["./apps", this.data.appSlug, result.identifierId, "settings", result.settingId], { relativeTo: this.route, queryParamsHandling: "merge" });
      } else {
        this.router.navigate(["./apps", this.data.appSlug, result.identifierId, "settings"], { relativeTo: this.route, queryParamsHandling: "merge" });
      }
    });
    this.subscriptions.add(subscription);
  }
  deleteIdentifier(key, event) {
    event.stopPropagation();
    const title = "Confirm delete";
    const message = `Are you sure you want to delete the "${key}" identifier? This action will remove the mapping, but existing settings will remain.`;
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: { title, message }
    }).afterClosed().subscribe((result) => {
      if (result) {
        const identifier = this.appData.identifierIdToIdentifier[key];
        if (identifier) {
          const internalSubscription = this.appIdentifierMappingsService.deleteAppIdentifierMapping({
            appId: this.data.appId,
            identifierId: key,
            mappingRowVersion: identifier.mappingRowVersion
          }).subscribe(() => {
            this.snackBar.open(`Deleted successfully!`, "Close", {
              horizontalPosition: "right",
              verticalPosition: "top",
              duration: 5e3
            });
            if (key in this.appData.identifierIdToIdentifier) {
              delete this.appData.identifierIdToIdentifier[key];
            }
            if (key in this.appData.identifierIdToSettings) {
              delete this.appData.identifierIdToSettings[key];
            }
            if (key in this.identifierIdToSettingsDataMap) {
              delete this.identifierIdToSettingsDataMap[key];
            }
            if (key in this.appData.identifierIdToInstances) {
              delete this.appData.identifierIdToInstances[key];
            }
            if (key in this.identifierIdToInstancesDataMap) {
              delete this.identifierIdToInstancesDataMap[key];
            }
            this.calculateIdentifierInfo();
            const keys = Object.keys(this.appData.identifierIdToSettings);
            if (keys.length === 0) {
              this.selectedIdentifierId = "";
              this.settingListComponentData = void 0;
              return;
            }
            if (this.selectedIdentifierId === key) {
              const identifierId = keys[0];
              this.changeIdentifier(identifierId);
            }
          });
          this.subscriptions.add(internalSubscription);
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  calculateIdentifierInfo() {
    const values = Object.values(this.appData.identifierIdToIdentifier);
    if (values.length === 0) {
      this.appData.identifierInfo = {
        minSortOrder: 0,
        maxSortOrder: 0,
        mappingMinSortOrder: 0,
        mappingMaxSortOrder: 0
      };
      return;
    }
    var firstValue = values[0];
    let minSortOrder = firstValue.sortOrder, maxSortOrder = firstValue.sortOrder, mappingMinOrder = firstValue.mappingSortOrder, mappingMaxOrder = firstValue.mappingSortOrder;
    values.forEach((value) => {
      minSortOrder = Math.min(minSortOrder, value.sortOrder);
      maxSortOrder = Math.max(maxSortOrder, value.sortOrder);
      mappingMinOrder = Math.min(mappingMinOrder, value.mappingSortOrder);
      mappingMaxOrder = Math.max(mappingMaxOrder, value.mappingSortOrder);
    });
    this.appData.identifierInfo = {
      minSortOrder,
      maxSortOrder,
      mappingMinSortOrder: mappingMinOrder,
      mappingMaxSortOrder: mappingMaxOrder
    };
  }
  moveSortOrder(identifierId, event, ascent) {
    event.stopPropagation();
    const identifier = this.appData.identifierIdToIdentifier[identifierId];
    const reloadIdentifiers = () => {
      return this.appIdentifierMappingsService.getAppIdentifierMappingsByAppId({ appIdOrSlug: this.data.appId }).pipe(switchMap((response) => {
        const responseData = response.data;
        if (!responseData) {
          return of(null);
        }
        this.appData.identifierInfo = {
          minSortOrder: responseData.minSortOrder,
          maxSortOrder: responseData.maxSortOrder,
          mappingMinSortOrder: responseData.mappingMinSortOrder,
          mappingMaxSortOrder: responseData.mappingMaxSortOrder
        };
        responseData.identifiers.forEach((item) => {
          const identifier2 = this.appData.identifierIdToIdentifier[item.id];
          if (identifier2) {
            identifier2.mappingSortOrder = item.mappingSortOrder;
            identifier2.mappingRowVersion = item.mappingRowVersion;
            identifier2.sortOrder = item.sortOrder;
          }
        });
        return of(null);
      }));
    };
    const subscription = this.appIdentifierMappingsService.updateAppIdentifierMappingSortOrder({
      appId: this.data.appId,
      identifierId,
      body: {
        ascent,
        rowVersion: identifier.mappingRowVersion
      }
    }).subscribe({
      next: (resp) => {
        if (resp.status === 409 && resp.errors) {
          this.utilityService.error(resp.errors, 3500);
        }
        this.subscriptions.add(reloadIdentifiers().subscribe());
      },
      error: (err) => {
        const error = err.error;
        if (error) {
          if (error.errors?.find((e) => e.traces === "MappingNotFound")) {
            delete this.appData.identifierIdToInstances[identifierId];
            delete this.appData.identifierIdToConfiguration[identifierId];
            delete this.appData.identifierIdToIdentifier[identifierId];
            delete this.appData.identifierIdToSettings[identifierId];
            if (this.selectedIdentifierId === identifierId) {
              const identifiers = this.identifiers;
              if (identifiers.length == 0) {
                this.createIdentifier("Add an identifier to start");
                return;
              }
              const identifierId2 = identifiers[0].id;
              this.changeIdentifier(identifierId2);
            }
            this.subscriptions.add(reloadIdentifiers().subscribe());
          }
        }
      }
    });
    this.subscriptions.add(subscription);
  }
  sortIdentifiers(identifiers) {
    return identifiers.sort((a, b) => {
      if (a.mappingSortOrder !== b.mappingSortOrder) {
        return a.mappingSortOrder - b.mappingSortOrder;
      }
      if (a.sortOrder !== b.sortOrder) {
        return a.sortOrder - b.sortOrder;
      }
      return a.id.localeCompare(b.id);
    });
  }
  loadData$() {
    return of(null).pipe(switchMap(() => {
      if (this.isLoaded) {
        return of(null);
      }
      return this.appsService.getGroupedAppDataByAppSlug({ appIdOrSlug: this.data.appSlug });
    }), tap((response) => {
      this.isLoaded = true;
      const responseData = response?.data;
      if (responseData) {
        this.appData = responseData;
      }
    }));
  }
};
_AppViewComponent.\u0275fac = function AppViewComponent_Factory(t) {
  return new (t || _AppViewComponent)(\u0275\u0275directiveInject(MatDialogRef), \u0275\u0275directiveInject(MAT_DIALOG_DATA), \u0275\u0275directiveInject(AppsService), \u0275\u0275directiveInject(ConfigurationsService), \u0275\u0275directiveInject(SettingsService), \u0275\u0275directiveInject(AppIdentifierMappingsService), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(DummyComponentService), \u0275\u0275directiveInject(AppViewService), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(ActivatedRoute), \u0275\u0275directiveInject(Router));
};
_AppViewComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AppViewComponent, selectors: [["ng-component"]], decls: 31, vars: 15, consts: [[1, "d-flex", "border-bottom"], [1, "dialog-title"], [1, "spacer"], ["mat-icon-button", "", "matTooltipPosition", "above", 3, "click", "matTooltip"], ["mat-icon-button", "", "mat-dialog-close", "", "matTooltip", "Close", "matTooltipPosition", "above"], [1, "custom-form-field"], ["matIconPosition", "right", "fontIcon", "info", "matTooltip", "The identifier can be used to distinguish between different environments, such as Production, Development, etc.", 1, "icon-mini"], [3, "valueChange", "value"], ["class", "custom-option", 3, "value", "onSelectionChange", 4, "ngFor", "ngForOf"], ["queryParamsHandling", "merge", 3, "routerLink"], ["animationDuration", "0ms", 3, "selectedIndexChange", "selectedTabChange", "selectedIndex"], ["label", "Settings", 3, "disabled"], [1, "p-0"], [3, "data", "copySettingToIdentifierEmitter", "settingDeleteEmitter", "fetchLatestEmitter", 4, "ngIf"], ["label", "Instances", 3, "disabled"], [3, "data", "instanceDeleteEmitter", 4, "ngIf"], ["label", "Configuration", 3, "disabled"], [3, "data", "configUpdateEmitter", 4, "ngIf"], [1, "custom-option", 3, "onSelectionChange", "value"], ["mat-icon-button", "", "matTooltip", "Up", "matTooltipPosition", "left", 3, "click", 4, "ngIf"], ["mat-icon-button", "", "matTooltip", "Down", "matTooltipPosition", "left", 3, "click", 4, "ngIf"], ["color", "warn", "mat-icon-button", "", "matTooltip", "Delete", "matTooltipPosition", "right", 3, "click"], ["fontIcon", "delete"], ["mat-icon-button", "", "matTooltip", "Up", "matTooltipPosition", "left", 3, "click"], ["fontIcon", "arrow_upward"], ["mat-icon-button", "", "matTooltip", "Down", "matTooltipPosition", "left", 3, "click"], ["fontIcon", "arrow_downward"], [3, "copySettingToIdentifierEmitter", "settingDeleteEmitter", "fetchLatestEmitter", "data"], [3, "instanceDeleteEmitter", "data"], [3, "configUpdateEmitter", "data"]], template: function AppViewComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 0)(1, "div", 1);
    \u0275\u0275text(2);
    \u0275\u0275elementEnd();
    \u0275\u0275element(3, "span")(4, "span", 2);
    \u0275\u0275elementStart(5, "button", 3);
    \u0275\u0275listener("click", function AppViewComponent_Template_button_click_5_listener() {
      return ctx.toggleFullScreen();
    });
    \u0275\u0275elementStart(6, "mat-icon");
    \u0275\u0275text(7);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(8, "button", 4)(9, "mat-icon");
    \u0275\u0275text(10, "close");
    \u0275\u0275elementEnd()()();
    \u0275\u0275elementStart(11, "mat-form-field", 5)(12, "mat-label");
    \u0275\u0275text(13, "Select the identifier ");
    \u0275\u0275element(14, "mat-icon", 6);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(15, "mat-select", 7);
    \u0275\u0275twoWayListener("valueChange", function AppViewComponent_Template_mat_select_valueChange_15_listener($event) {
      \u0275\u0275twoWayBindingSet(ctx.selectedIdentifierId, $event) || (ctx.selectedIdentifierId = $event);
      return $event;
    });
    \u0275\u0275template(16, AppViewComponent_mat_option_16_Template, 9, 4, "mat-option", 8);
    \u0275\u0275elementStart(17, "mat-option", 9);
    \u0275\u0275text(18, "New identifier mapping ");
    \u0275\u0275elementStart(19, "mat-icon");
    \u0275\u0275text(20, "add_circle");
    \u0275\u0275elementEnd()()()();
    \u0275\u0275elementStart(21, "mat-tab-group", 10);
    \u0275\u0275twoWayListener("selectedIndexChange", function AppViewComponent_Template_mat_tab_group_selectedIndexChange_21_listener($event) {
      \u0275\u0275twoWayBindingSet(ctx.tabIndex, $event) || (ctx.tabIndex = $event);
      return $event;
    });
    \u0275\u0275listener("selectedTabChange", function AppViewComponent_Template_mat_tab_group_selectedTabChange_21_listener($event) {
      return ctx.onTabChange($event.index);
    });
    \u0275\u0275elementStart(22, "mat-tab", 11)(23, "mat-dialog-content", 12);
    \u0275\u0275template(24, AppViewComponent_setting_list_24_Template, 1, 1, "setting-list", 13);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(25, "mat-tab", 14)(26, "mat-dialog-content", 12);
    \u0275\u0275template(27, AppViewComponent_instance_list_27_Template, 1, 1, "instance-list", 15);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(28, "mat-tab", 16)(29, "mat-dialog-content", 12);
    \u0275\u0275template(30, AppViewComponent_configuration_update_30_Template, 1, 1, "configuration-update", 17);
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    let tmp_9_0;
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.data.clientName);
    \u0275\u0275advance(3);
    \u0275\u0275property("matTooltip", ctx.isFullScreen ? "Exit full screen" : "Enter full screen");
    \u0275\u0275advance(2);
    \u0275\u0275textInterpolate(ctx.isFullScreen ? "fullscreen_exit" : "fullscreen");
    \u0275\u0275advance(8);
    \u0275\u0275twoWayProperty("value", ctx.selectedIdentifierId);
    \u0275\u0275advance();
    \u0275\u0275property("ngForOf", ctx.identifiers);
    \u0275\u0275advance();
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction1(13, _c017, ctx.data.appSlug));
    \u0275\u0275advance(4);
    \u0275\u0275twoWayProperty("selectedIndex", ctx.tabIndex);
    \u0275\u0275advance();
    \u0275\u0275property("disabled", !ctx.settingListComponentData || !ctx.isLoaded);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx.settingListComponentData);
    \u0275\u0275advance();
    \u0275\u0275property("disabled", !((tmp_9_0 = ctx.appInstanceListComponentData == null ? null : ctx.appInstanceListComponentData.instances == null ? null : ctx.appInstanceListComponentData.instances.length) !== null && tmp_9_0 !== void 0 ? tmp_9_0 : 0 > 0) || !ctx.isLoaded);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx.appInstanceListComponentData);
    \u0275\u0275advance();
    \u0275\u0275property("disabled", !ctx.isLoaded);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx.configurationUpdateComponentData);
  }
}, dependencies: [NgForOf, NgIf, RouterLink, SettingListComponent, InstanceListComponent, MatFormField, MatLabel, MatIcon, MatOption, MatIconButton, MatDialogClose, MatDialogContent, MatTab, MatTabGroup, MatSelect, MatTooltip, ConfigurationUpdateComponent], styles: ["\n\n  .mat-mdc-tab-header {\n  box-shadow: 0px 1px 0px 0px rgba(0, 0, 0, 0.1);\n}\n  .mat-mdc-card-title {\n  padding: 8px 8px 0;\n}\n/*# sourceMappingURL=app-view.component.css.map */"] });
var AppViewComponent = _AppViewComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AppViewComponent, { className: "AppViewComponent", filePath: "src\\app\\features\\app\\components\\app-view\\app-view.component.ts", lineNumber: 38 });
})();
var ViewTab;
(function(ViewTab2) {
  ViewTab2[ViewTab2["Settings"] = 0] = "Settings";
  ViewTab2[ViewTab2["Instances"] = 1] = "Instances";
  ViewTab2[ViewTab2["Configuration"] = 2] = "Configuration";
})(ViewTab || (ViewTab = {}));

// src/app/features/app/components/app-list/app-list.component.ts
var _c018 = ["groupSelect"];
var _c19 = ["searchTermInput"];
var _c25 = (a0) => [a0, "update"];
var _c34 = (a0) => [a0];
var _c44 = () => ["./create"];
function AppListComponent_div_4_mat_option_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-option", 23);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const group_r3 = ctx.$implicit;
    \u0275\u0275property("value", group_r3.id);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(group_r3.name);
  }
}
function AppListComponent_div_4_mat_hint_15_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-hint");
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext(2);
    \u0275\u0275advance();
    \u0275\u0275textInterpolate2("", ctx_r1.groupsCount, " groups, ", ctx_r1.appsCount, " apps match");
  }
}
function AppListComponent_div_4_button_16_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 24);
    \u0275\u0275listener("click", function AppListComponent_div_4_button_16_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r4);
      const ctx_r1 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r1.clearSelection());
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "clear");
    \u0275\u0275elementEnd();
    \u0275\u0275text(3, " Clear selection ");
    \u0275\u0275elementEnd();
  }
}
function AppListComponent_div_4_Template(rf, ctx) {
  if (rf & 1) {
    const _r1 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "div", 10)(1, "div", 11)(2, "mat-form-field", 12);
    \u0275\u0275listener("click", function AppListComponent_div_4_Template_mat_form_field_click_2_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.getGroups());
    });
    \u0275\u0275elementStart(3, "mat-label");
    \u0275\u0275text(4, "Group");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(5, "mat-select", 13, 0);
    \u0275\u0275listener("selectionChange", function AppListComponent_div_4_Template_mat_select_selectionChange_5_listener($event) {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.onGroupChange($event));
    });
    \u0275\u0275template(7, AppListComponent_div_4_mat_option_7_Template, 2, 2, "mat-option", 14);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(8, "mat-form-field", 15)(9, "mat-label");
    \u0275\u0275text(10, "Search");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(11, "input", 16, 1);
    \u0275\u0275listener("keyup", function AppListComponent_div_4_Template_input_keyup_11_listener($event) {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.applyFilter($event));
    });
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(13, "mat-icon", 17);
    \u0275\u0275text(14, "search");
    \u0275\u0275elementEnd();
    \u0275\u0275template(15, AppListComponent_div_4_mat_hint_15_Template, 2, 2, "mat-hint", 18);
    \u0275\u0275elementEnd();
    \u0275\u0275template(16, AppListComponent_div_4_button_16_Template, 4, 0, "button", 19);
    \u0275\u0275element(17, "span", 20);
    \u0275\u0275elementStart(18, "button", 21);
    \u0275\u0275listener("click", function AppListComponent_div_4_Template_button_click_18_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.expandAll());
    });
    \u0275\u0275elementStart(19, "mat-icon");
    \u0275\u0275text(20, "expand_more");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(21, "button", 22);
    \u0275\u0275listener("click", function AppListComponent_div_4_Template_button_click_21_listener() {
      \u0275\u0275restoreView(_r1);
      const ctx_r1 = \u0275\u0275nextContext();
      return \u0275\u0275resetView(ctx_r1.collapseAll());
    });
    \u0275\u0275elementStart(22, "mat-icon");
    \u0275\u0275text(23, "expand_less");
    \u0275\u0275elementEnd()()()();
  }
  if (rf & 2) {
    const ctx_r1 = \u0275\u0275nextContext();
    \u0275\u0275advance(7);
    \u0275\u0275property("ngForOf", ctx_r1.groups);
    \u0275\u0275advance(8);
    \u0275\u0275property("ngIf", ctx_r1.appsFetched);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx_r1.queryParams.searchTerm || ctx_r1.queryParams.groupId);
    \u0275\u0275advance(2);
    \u0275\u0275property("disabled", !ctx_r1.groupedApps.length);
    \u0275\u0275advance(3);
    \u0275\u0275property("disabled", !ctx_r1.groupedApps.length);
  }
}
function AppListComponent_mat_expansion_panel_6_mat_card_5_button_12_Template(rf, ctx) {
  if (rf & 1) {
    const _r6 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "button", 42);
    \u0275\u0275listener("click", function AppListComponent_mat_expansion_panel_6_mat_card_5_button_12_Template_button_click_0_listener() {
      \u0275\u0275restoreView(_r6);
      const app_r7 = \u0275\u0275nextContext().$implicit;
      const ctx_r1 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r1.copyToClipboard(app_r7.client.id));
    });
    \u0275\u0275elementStart(1, "mat-icon");
    \u0275\u0275text(2, "content_copy");
    \u0275\u0275elementEnd()();
  }
}
function AppListComponent_mat_expansion_panel_6_mat_card_5_a_29_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "a", 43)(1, "mat-icon");
    \u0275\u0275text(2, "open_in_new");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(3, "span");
    \u0275\u0275text(4, "Wiki");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const app_r7 = \u0275\u0275nextContext().$implicit;
    \u0275\u0275propertyInterpolate("href", app_r7.wikiUrl, \u0275\u0275sanitizeUrl);
  }
}
function AppListComponent_mat_expansion_panel_6_mat_card_5_mat_chip_35_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-chip", 44);
    \u0275\u0275text(1);
    \u0275\u0275elementEnd();
  }
  if (rf & 2) {
    const tag_r8 = ctx.$implicit;
    \u0275\u0275advance();
    \u0275\u0275textInterpolate(tag_r8.name);
  }
}
function AppListComponent_mat_expansion_panel_6_mat_card_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r5 = \u0275\u0275getCurrentView();
    \u0275\u0275elementStart(0, "mat-card", 28)(1, "mat-card-header")(2, "div", 29);
    \u0275\u0275element(3, "img", 30);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(4, "mat-card-title");
    \u0275\u0275text(5);
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(6, "mat-card-subtitle", 11)(7, "span", 31);
    \u0275\u0275text(8, "ClientId: ");
    \u0275\u0275elementStart(9, "span");
    \u0275\u0275text(10);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(11, "span", 32);
    \u0275\u0275template(12, AppListComponent_mat_expansion_panel_6_mat_card_5_button_12_Template, 3, 0, "button", 33);
    \u0275\u0275elementEnd()();
    \u0275\u0275element(13, "span", 20);
    \u0275\u0275elementStart(14, "button", 34)(15, "mat-icon");
    \u0275\u0275text(16, "more_vert");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(17, "mat-menu", null, 2)(19, "button", 35)(20, "mat-icon");
    \u0275\u0275text(21, "edit");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(22, "span");
    \u0275\u0275text(23, "Update");
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(24, "button", 36);
    \u0275\u0275listener("click", function AppListComponent_mat_expansion_panel_6_mat_card_5_Template_button_click_24_listener() {
      const app_r7 = \u0275\u0275restoreView(_r5).$implicit;
      const ctx_r1 = \u0275\u0275nextContext(2);
      return \u0275\u0275resetView(ctx_r1.delete(app_r7));
    });
    \u0275\u0275elementStart(25, "mat-icon");
    \u0275\u0275text(26, "delete");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(27, "span");
    \u0275\u0275text(28, "Delete");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(29, AppListComponent_mat_expansion_panel_6_mat_card_5_a_29_Template, 5, 1, "a", 37);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(30, "mat-card-content", 38)(31, "p");
    \u0275\u0275text(32);
    \u0275\u0275pipe(33, "truncate");
    \u0275\u0275elementEnd();
    \u0275\u0275elementStart(34, "mat-chip-set");
    \u0275\u0275template(35, AppListComponent_mat_expansion_panel_6_mat_card_5_mat_chip_35_Template, 2, 1, "mat-chip", 39);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(36, "mat-card-actions", 40)(37, "button", 41);
    \u0275\u0275text(38, "View");
    \u0275\u0275elementEnd()()();
  }
  if (rf & 2) {
    const app_r7 = ctx.$implicit;
    const menu_r9 = \u0275\u0275reference(18);
    const ctx_r1 = \u0275\u0275nextContext(2);
    \u0275\u0275property("ngClass", ctx_r1.menuOpened ? "card-item-two" : "card-item-three");
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(app_r7.displayName);
    \u0275\u0275advance(5);
    \u0275\u0275textInterpolate(app_r7.client.id);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngIf", ctx_r1.isConnectionSecure);
    \u0275\u0275advance(2);
    \u0275\u0275property("matMenuTriggerFor", menu_r9);
    \u0275\u0275advance(5);
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction1(13, _c25, app_r7.slug));
    \u0275\u0275advance(10);
    \u0275\u0275property("ngIf", app_r7.wikiUrl);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate(\u0275\u0275pipeBind2(33, 10, app_r7.description, 250));
    \u0275\u0275advance(3);
    \u0275\u0275property("ngForOf", app_r7.tags);
    \u0275\u0275advance(2);
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction1(15, _c34, app_r7.slug));
  }
}
function AppListComponent_mat_expansion_panel_6_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "mat-expansion-panel", 25)(1, "mat-expansion-panel-header")(2, "mat-panel-title");
    \u0275\u0275text(3);
    \u0275\u0275elementEnd()();
    \u0275\u0275elementStart(4, "div", 26);
    \u0275\u0275template(5, AppListComponent_mat_expansion_panel_6_mat_card_5_Template, 39, 17, "mat-card", 27);
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    const group_r10 = ctx.$implicit;
    \u0275\u0275property("expanded", true);
    \u0275\u0275advance(3);
    \u0275\u0275textInterpolate1(" ", group_r10.key, " ");
    \u0275\u0275advance(2);
    \u0275\u0275property("ngForOf", group_r10.apps);
  }
}
function AppListComponent_button_7_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "button", 45)(1, "mat-icon");
    \u0275\u0275text(2, "add");
    \u0275\u0275elementEnd()();
  }
  if (rf & 2) {
    \u0275\u0275property("routerLink", \u0275\u0275pureFunction0(1, _c44));
  }
}
function AppListComponent_mat_progress_bar_8_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275element(0, "mat-progress-bar", 46);
  }
}
var _AppListComponent = class _AppListComponent {
  constructor(cdr, dialog, snackBar, appsService, groupsService, authService, utilityService, windowService, defaultLayoutService, dummyComponentService, route, router) {
    this.cdr = cdr;
    this.dialog = dialog;
    this.snackBar = snackBar;
    this.appsService = appsService;
    this.groupsService = groupsService;
    this.authService = authService;
    this.utilityService = utilityService;
    this.windowService = windowService;
    this.defaultLayoutService = defaultLayoutService;
    this.dummyComponentService = dummyComponentService;
    this.route = route;
    this.router = router;
    this.groupedApps = [];
    this.groups = [];
    this.isGroupsFetched = false;
    this.groupsCount = 0;
    this.appsCount = 0;
    this.appsFetched = false;
    this.queryParams = {
      searchTerm: null,
      groupId: null
    };
    this.searchTermSubject = new Subject();
    this.isProvider = false;
    this.menuOpened = false;
    this.subscriptions = new Subscription();
    this.isLoading = false;
  }
  ngOnInit() {
    this.isProvider = this.windowService.isProvider;
    this.handleRouting();
    this.setupMenusubscription();
    this.setupSearchTermSubscription();
    this.isConnectionSecure = this.windowService.isConnectionSecure;
  }
  ngAfterViewInit() {
    setTimeout(() => {
      this.setupQueryParams();
    });
  }
  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
  setupMenusubscription() {
    const subscription = this.defaultLayoutService.menuOpened$.subscribe((menuOpened) => this.menuOpened = menuOpened);
    this.subscriptions.add(subscription);
  }
  setupQueryParams() {
    if (this.queryParamSubscription) {
      return;
    }
    this.queryParamSubscription = this.route.queryParams.subscribe((params) => {
      const searchTerm = this.getSearchTermFromRoute(params);
      const groupId = this.getGroupId(params);
      if (this.queryParams.searchTerm === searchTerm && this.queryParams.groupId === groupId) {
        return;
      }
      if (this.isProvider) {
        this.queryParams.searchTerm = this.searchTermInput.nativeElement.value = searchTerm;
        this.queryParams.groupId = this.groupSelect.value = groupId;
      }
      this.loadData();
    });
    this.subscriptions.add(this.queryParamSubscription);
  }
  setupSearchTermSubscription() {
    if (this.searchTermSubscription) {
      return;
    }
    this.searchTermSubscription = this.searchTermSubject.pipe(debounceTime(300)).subscribe((searchTerm) => {
      this.queryParams.searchTerm = searchTerm;
      this.loadData();
    });
    this.subscriptions.add(this.searchTermSubscription);
  }
  getSearchTermFromRoute(params) {
    let hasDifferentCaseSearchTerm = false;
    const filterKeys = Object.keys(params).filter((key) => {
      const isMatches = key.toLocaleLowerCase() === "searchterm";
      if (!hasDifferentCaseSearchTerm) {
        hasDifferentCaseSearchTerm = isMatches && key !== "searchTerm";
      }
      return isMatches;
    });
    return filterKeys.length > 0 ? hasDifferentCaseSearchTerm ? this.updateQueryParamsForSearchTerm(filterKeys, params) : params["searchTerm"] ?? "" : "";
  }
  getGroupId(params) {
    const groupId = params["groupId"] || "";
    if (groupId) {
      this.getGroups(groupId);
    }
    return groupId;
  }
  updateQueryParamsForSearchTerm(searchTermKeys, params) {
    let searchTerm = "";
    const updatedParams = {};
    searchTermKeys.forEach((key) => {
      searchTerm += params[key] + ",";
      updatedParams[key] = null;
    });
    searchTerm = searchTerm.substring(0, searchTerm.length - 1);
    updatedParams["searchTerm"] = searchTerm;
    this.router.navigate([], {
      queryParams: updatedParams,
      queryParamsHandling: "merge"
    });
    return searchTerm;
  }
  loadData() {
    this.startFetching();
    const fetchingSubscription = this.appsService.getGroupedApps({
      searchTerm: this.queryParams.searchTerm ?? void 0,
      groupId: this.queryParams.groupId
    }).subscribe({
      next: (response) => {
        if (!response.data) {
          return;
        }
        this.groupedApps = this.mapGroupedAppsToArray(response.data.groupNameToApps);
        this.groupsCount = response.data.groupsCount;
        this.appsCount = response.data.appsCount;
        this.appsFetched = true;
      },
      error: () => {
        this.stopFetching(true);
      },
      complete: () => {
        this.stopFetching();
        this.updateUrl();
      }
    });
    this.subscriptions.add(fetchingSubscription);
  }
  startFetching() {
    this.isLoading = true;
  }
  stopFetching(hasError) {
    this.isLoading = false;
    if (hasError) {
      return;
    }
  }
  mapGroupedAppsToArray(groupedApps) {
    return Object.entries(groupedApps).map(([key, apps]) => ({ key, apps }));
  }
  getGroups(groupId) {
    if (this.isGroupsFetched || this.authService.isAuthorizationRequired && !this.authService.isAuthenticated) {
      return;
    }
    this.isGroupsFetched = true;
    const groupSubscription = this.groupsService.getGroups({ hasMappings: true }).subscribe({
      next: (response) => {
        this.groups = [
          { id: "-1", name: "Filter > Ungrouped apps", sortOrder: 0, rowVersion: "" },
          { id: "0", name: "Filter > Grouped apps", sortOrder: 0, rowVersion: "" },
          ...response?.data?.appGroups ?? []
        ];
        this.cdr.detectChanges();
        if (!groupId) {
          this.groupSelect?.open();
        }
      },
      error: () => {
        this.isGroupsFetched = false;
      }
    });
    this.subscriptions.add(groupSubscription);
  }
  applyFilter(event) {
    const searchTerm = event.target.value;
    if (searchTerm === this.queryParams.searchTerm) {
      return;
    }
    this.searchTermSubject.next(searchTerm);
  }
  onGroupChange(event) {
    this.queryParams.groupId = event.value;
    this.loadData();
  }
  clearSelection() {
    if (this.queryParams.groupId === "" && this.queryParams.searchTerm === "") {
      return;
    }
    if (this.isProvider) {
      this.queryParams.groupId = this.groupSelect.value = "";
      this.searchTermInput.nativeElement.value = this.queryParams.searchTerm = "";
    }
    this.loadData();
  }
  updateUrl() {
    this.router.navigate([], {
      queryParams: {
        searchTerm: this.queryParams.searchTerm === "" ? null : this.queryParams.searchTerm,
        groupId: this.queryParams.groupId === "" ? null : this.queryParams.groupId
      },
      queryParamsHandling: "merge"
    });
  }
  handleRouting() {
    const dummyComponentSubscription = this.dummyComponentService.event$.subscribe((event) => {
      setTimeout(() => {
        if (event === void 0) {
          return;
        }
        switch (event.path) {
          case APP_ROUTES.create:
            this.add();
            break;
          case APP_ROUTES.update:
            const updateParamSubscription = event.activatedRoute.paramMap.subscribe((params) => {
              const slug = params.get("appId");
              if (!slug) {
                return;
              }
              const app = this.groupedApps.flatMap((g) => g.apps).find((app2) => app2.slug == slug);
              if (app) {
                this.edit(app);
                return;
              }
              const getAppSubscription = this.appsService.getAppBySlug({
                appIdOrSlug: slug
              }).subscribe((resp) => {
                if (resp.data) {
                  this.edit(resp.data);
                } else {
                  this.snackBar.open(`No data found for the given Id: ${slug}`, "Close", {
                    duration: 3e3,
                    horizontalPosition: "right",
                    verticalPosition: "top"
                  });
                  this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
                }
              });
              this.subscriptions.add(getAppSubscription);
            });
            this.subscriptions.add(updateParamSubscription);
            break;
          case APP_ROUTES.view:
            const viewParamSubscription = event.activatedRoute.paramMap.subscribe((params) => {
              const slug = params.get("appId");
              if (!slug) {
                return;
              }
              const app = this.groupedApps.flatMap((g) => g.apps).find((app2) => app2.slug == slug);
              if (app) {
                this.view(app.client.id, app.slug, app.client.name, app.id);
                return;
              }
              const getAppSubscription = this.appsService.getAppBySlug({
                appIdOrSlug: slug
              }).subscribe((response) => {
                const data = response.data;
                if (data) {
                  this.view(data.client.id, data.slug, data.client.name, data.id);
                } else {
                  this.snackBar.open(`No data found for the given Id: ${slug}`, "Close", {
                    duration: 3e3,
                    horizontalPosition: "right",
                    verticalPosition: "top"
                  });
                  this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
                }
              });
              this.subscriptions.add(getAppSubscription);
            });
            this.subscriptions.add(viewParamSubscription);
            break;
        }
      });
    });
    this.subscriptions.add(dummyComponentSubscription);
  }
  add() {
    const subscription = this.dialog.open(AppCreateComponent, {
      width: "1018px",
      height: "550px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false
    }).afterClosed().subscribe((result) => {
      if (result) {
        this.appsCount++;
        const group2 = result.group?.name ?? "Ungrouped apps";
        const groupIndex = this.groupedApps.findIndex((g) => g.key === group2);
        if (this.isGroupsFetched && group2 !== "Ungrouped apps" && result.group && !this.groups.some((g) => g.id === result.group.id)) {
          this.groups.push({
            id: result.group.id,
            name: result.group.name,
            sortOrder: result.group.sortOrder,
            rowVersion: ""
          });
        }
        if (groupIndex > -1) {
          this.groupedApps[groupIndex].apps.push(result);
        } else {
          this.groupedApps.push({ key: group2, apps: [result] });
          this.groupsCount++;
        }
      }
      this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
    });
    this.subscriptions.add(subscription);
  }
  edit(model) {
    const appEditorComponentModel = {
      displayName: model.displayName,
      clientName: model.client.name,
      slug: model.slug,
      appId: model.id,
      clientId: model.client.id,
      description: model.description,
      imageUrl: model.imageUrl,
      wikiUrl: model.wikiUrl,
      group: model.group,
      tags: model.tags,
      rowVersion: model.rowVersion
    };
    if (model.group?.id === "-1") {
      appEditorComponentModel.group = null;
    }
    const subscription = this.dialog.open(AppUpdateComponent, {
      data: appEditorComponentModel,
      minWidth: 500,
      maxWidth: 500
    }).afterClosed().subscribe((result) => {
      if (result) {
        const oldGroupName = appEditorComponentModel.group?.name || "Ungrouped apps";
        const newGroupName = result.group?.name || "Ungrouped apps";
        const hasGroupNameChanged = oldGroupName !== newGroupName;
        if (hasGroupNameChanged) {
          this.moveAppBetweenGroups(model.client.id, oldGroupName, newGroupName, result);
        } else {
          this.updateAppInGroup(model.client.id, result);
        }
        if (result.type === "Fetch Latest") {
          setTimeout(() => {
            this.router.navigate([`./${model.slug}/update`], { relativeTo: this.route, queryParamsHandling: "merge" });
          }, 500);
        }
      }
      this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
    });
    this.subscriptions.add(subscription);
  }
  updateAppInGroup(clientId, updatedApp) {
    const currentGroupName = updatedApp.group?.name || "Ungrouped apps";
    const group2 = this.groupedApps.find((g) => g.key === currentGroupName);
    if (group2) {
      const appInGroup = group2.apps.find((a) => a.client.id === clientId);
      if (appInGroup) {
        this.assignAppProperies(appInGroup, updatedApp);
      }
    }
  }
  moveAppBetweenGroups(clientId, oldGroupName, newGroup, updatedApp) {
    if (!updatedApp.group) {
      updatedApp.group = { id: "-1", name: "Ungrouped apps", sortOrder: 0 };
    }
    const oldGroupIndex = this.groupedApps.findIndex((g) => g.key === oldGroupName);
    const newGroupIndex = this.groupedApps.findIndex((g) => g.key === newGroup);
    if (oldGroupIndex === -1) {
      return;
    }
    const oldGroupApps = this.groupedApps[oldGroupIndex].apps;
    const appIndex = oldGroupApps.findIndex((a) => a.client.id === clientId);
    if (appIndex === -1) {
      return;
    }
    const app = oldGroupApps[appIndex];
    this.assignAppProperies(app, updatedApp);
    if (newGroupIndex > -1) {
      this.groupedApps[newGroupIndex].apps.push(app);
    } else {
      this.groupedApps.push({ key: newGroup, apps: [app] });
      this.groupsCount++;
      if (updatedApp.group.id !== "-1") {
        this.groups.push({
          id: updatedApp.group.id,
          name: updatedApp.group.name,
          sortOrder: updatedApp.group.sortOrder,
          rowVersion: ""
        });
      }
    }
    oldGroupApps.splice(appIndex, 1);
    if (oldGroupApps.length === 0) {
      this.groupedApps.splice(oldGroupIndex, 1);
      this.groupsCount--;
      const oldGroupInGroups = this.groups.findIndex((g) => g.name === oldGroupName);
      const group2 = this.groups[oldGroupInGroups];
      if (oldGroupInGroups !== -1 && group2.id !== "-1" && group2.id !== "0") {
        this.groups.splice(oldGroupInGroups, 1);
      }
    }
  }
  assignAppProperies(app, result) {
    app.displayName = result.displayName;
    app.client.name = result.clientName;
    app.slug = result.slug;
    app.description = result.description;
    app.imageUrl = result.imageUrl;
    app.wikiUrl = result.wikiUrl;
    app.tags = result.tags;
    app.group = result.group == null ? null : {
      id: result.group.id,
      name: result.group.name,
      sortOrder: result.group.sortOrder
    };
    app.rowVersion = result.rowVersion;
  }
  delete(app) {
    const title = "Confirm delete";
    const message = `Are you sure you want to delete the "${app.client.name}" app? This action cannot be undone.`;
    const confirmationDialogComponentModel = {
      title,
      message,
      requireConfirmation: true
    };
    const subscription = this.dialog.open(ConfirmationDialogComponent, {
      width: "500px",
      data: confirmationDialogComponentModel
    }).afterClosed().subscribe((result) => {
      if (result) {
        const internalSubscription = this.appsService.deleteApp({ appId: app.id, rowVersion: app.rowVersion }).subscribe(() => {
          this.appsCount--;
          const groupName = app.group?.name ?? "Ungrouped apps";
          const groupIndex = this.groupedApps.findIndex((g) => g.key === groupName);
          if (groupIndex > -1) {
            const appIndex = this.groupedApps[groupIndex].apps.findIndex((a) => a.client.id === app.client.id);
            if (appIndex > -1) {
              this.groupedApps[groupIndex].apps.splice(appIndex, 1);
              if (this.groupedApps[groupIndex].apps.length === 0) {
                this.groupedApps.splice(groupIndex, 1);
                this.groupsCount--;
              }
            }
          }
        });
        this.subscriptions.add(internalSubscription);
      }
    });
    this.subscriptions.add(subscription);
  }
  view(clientId, slug, clientName, appId) {
    const data = { clientId, appSlug: slug, clientName, appId };
    const subscription = this.dialog.open(AppViewComponent, {
      data,
      width: "1350px",
      height: "680px",
      minWidth: "inherit",
      maxWidth: "inherit",
      autoFocus: false,
      closeOnNavigation: false
    }).afterClosed().subscribe(() => {
      this.router.navigate(["./"], { relativeTo: this.route, queryParamsHandling: "merge" });
    });
    this.subscriptions.add(subscription);
  }
  copyToClipboard(content) {
    this.utilityService.copyToClipboard(content);
  }
  expandAll() {
    this.accordion.openAll();
  }
  collapseAll() {
    this.accordion.closeAll();
  }
};
_AppListComponent.\u0275fac = function AppListComponent_Factory(t) {
  return new (t || _AppListComponent)(\u0275\u0275directiveInject(ChangeDetectorRef), \u0275\u0275directiveInject(MatDialog), \u0275\u0275directiveInject(MatSnackBar), \u0275\u0275directiveInject(AppsService), \u0275\u0275directiveInject(GroupsService), \u0275\u0275directiveInject(AuthService), \u0275\u0275directiveInject(UtilityService), \u0275\u0275directiveInject(WindowService), \u0275\u0275directiveInject(DefaultLayoutService), \u0275\u0275directiveInject(DummyComponentService), \u0275\u0275directiveInject(ActivatedRoute), \u0275\u0275directiveInject(Router));
};
_AppListComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _AppListComponent, selectors: [["ng-component"]], viewQuery: function AppListComponent_Query(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275viewQuery(_c018, 5);
    \u0275\u0275viewQuery(_c19, 5);
    \u0275\u0275viewQuery(MatAccordion, 5);
  }
  if (rf & 2) {
    let _t;
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.groupSelect = _t.first);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.searchTermInput = _t.first);
    \u0275\u0275queryRefresh(_t = \u0275\u0275loadQuery()) && (ctx.accordion = _t.first);
  }
}, decls: 10, vars: 4, consts: [["groupSelect", ""], ["searchTermInput", ""], ["menu", "matMenu"], [1, "px-3"], [1, "title", "mb-3"], ["class", "d-flex-wrapper", 4, "ngIf"], ["multi", ""], [3, "expanded", 4, "ngFor", "ngForOf"], ["mat-fab", "", "class", "position-fixed b-0 r-0 mr-3 mb-3", "color", "primary", "matTooltip", "New app", "queryParamsHandling", "merge", 3, "routerLink", 4, "ngIf"], ["mode", "indeterminate", "class", "position-fixed l-0 b-0", 4, "ngIf"], [1, "d-flex-wrapper"], [1, "d-flex"], ["appearance", "outline", 1, "w-25", "mr-2", "border-bottom-1", 3, "click"], [3, "selectionChange"], [3, "value", 4, "ngFor", "ngForOf"], ["appearance", "outline", 1, "w-25", "mr-2", "border-bottom-1"], ["matInput", "", 3, "keyup"], ["matSuffix", ""], [4, "ngIf"], ["class", "mt-2", "mat-stroked-button", "", "color", "primary", 3, "click", 4, "ngIf"], [1, "spacer"], ["mat-icon-button", "", "matTooltip", "Expand All", 3, "click", "disabled"], ["mat-icon-button", "", "matTooltip", "Collapse All", 3, "click", "disabled"], [3, "value"], ["mat-stroked-button", "", "color", "primary", 1, "mt-2", 3, "click"], [3, "expanded"], [1, "card-container"], [3, "ngClass", 4, "ngFor", "ngForOf"], [3, "ngClass"], ["mat-card-avatar", "", 1, "mat-bg-primary"], [1, "app-icon", "bg-white"], [1, "card-subtitle-client-id", 2, "font-size", "13px"], [1, "position-relative"], ["mat-icon-button", "", "class", "list-content-copy icon-mini d-inherit", "matTooltip", "Copy", "matTooltipPosition", "right", 3, "click", 4, "ngIf"], ["mat-icon-button", "", 3, "matMenuTriggerFor"], ["mat-menu-item", "", "queryParamsHandling", "merge", 3, "routerLink"], ["mat-menu-item", "", 3, "click"], ["mat-menu-item", "", "target", "_blank", 3, "href", 4, "ngIf"], [1, "ww-anywhere"], ["disabled", "", 4, "ngFor", "ngForOf"], [1, "card-footer"], ["mat-button", "", "color", "primary", "queryParamsHandling", "merge", 3, "routerLink"], ["mat-icon-button", "", "matTooltip", "Copy", "matTooltipPosition", "right", 1, "list-content-copy", "icon-mini", "d-inherit", 3, "click"], ["mat-menu-item", "", "target", "_blank", 3, "href"], ["disabled", ""], ["mat-fab", "", "color", "primary", "matTooltip", "New app", "queryParamsHandling", "merge", 1, "position-fixed", "b-0", "r-0", "mr-3", "mb-3", 3, "routerLink"], ["mode", "indeterminate", 1, "position-fixed", "l-0", "b-0"]], template: function AppListComponent_Template(rf, ctx) {
  if (rf & 1) {
    \u0275\u0275elementStart(0, "div", 3)(1, "div", 4)(2, "h1");
    \u0275\u0275text(3, "Apps");
    \u0275\u0275elementEnd()();
    \u0275\u0275template(4, AppListComponent_div_4_Template, 24, 5, "div", 5);
    \u0275\u0275elementStart(5, "mat-accordion", 6);
    \u0275\u0275template(6, AppListComponent_mat_expansion_panel_6_Template, 6, 3, "mat-expansion-panel", 7);
    \u0275\u0275elementEnd()();
    \u0275\u0275template(7, AppListComponent_button_7_Template, 3, 2, "button", 8)(8, AppListComponent_mat_progress_bar_8_Template, 1, 0, "mat-progress-bar", 9);
    \u0275\u0275element(9, "router-outlet");
  }
  if (rf & 2) {
    \u0275\u0275advance(4);
    \u0275\u0275property("ngIf", ctx.isProvider);
    \u0275\u0275advance(2);
    \u0275\u0275property("ngForOf", ctx.groupedApps);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isProvider);
    \u0275\u0275advance();
    \u0275\u0275property("ngIf", ctx.isLoading);
  }
}, dependencies: [NgClass, NgForOf, NgIf, RouterOutlet, RouterLink, MatFormField, MatLabel, MatHint, MatSuffix, MatIcon, MatAccordion, MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle, MatCard, MatCardActions, MatCardAvatar, MatCardContent, MatCardHeader, MatCardSubtitle, MatCardTitle, MatOption, MatButton, MatIconButton, MatFabButton, MatMenu, MatMenuItem, MatMenuTrigger, MatChip, MatChipSet, MatProgressBar, MatSelect, MatTooltip, MatInput, TruncatePipe], styles: ["\n\n.card-item-three[_ngcontent-%COMP%] {\n  flex-basis: calc(33.33% - 8px);\n}\n.card-item-two[_ngcontent-%COMP%] {\n  flex-basis: calc(50% - 8px);\n}\n.card-container[_ngcontent-%COMP%] {\n  display: flex;\n  flex-wrap: wrap;\n  justify-content: flex-start;\n  gap: 8px;\n}\n.card-footer[_ngcontent-%COMP%] {\n  margin-top: auto;\n}\n  .border-bottom-1 .mdc-notched-outline__leading,   .border-bottom-1 .mdc-notched-outline__notch,   .border-bottom-1 .mdc-notched-outline__trailing {\n  border-bottom: 1px inset !important;\n  border: 0px;\n  border-radius: 0 !important;\n}\n  .border-none .mdc-notched-outline__leading,   .border-none .mdc-notched-outline__notch,   .border-none .mdc-notched-outline__trailing {\n  border-bottom: 0px !important;\n  border: 0px;\n  border-radius: 0 !important;\n}\n.d-flex-wrapper[_ngcontent-%COMP%] {\n  height: auto;\n  min-height: 82px;\n}\n.mat-mdc-card-avatar[_ngcontent-%COMP%] {\n  padding: 1px;\n}\n.card-subtitle-client-id[_ngcontent-%COMP%] {\n  font-style: 13px;\n}\n.card-subtitle-client-id[_ngcontent-%COMP%]    > span[_ngcontent-%COMP%] {\n  font-style: 12px;\n}\n.list-content-copy[_ngcontent-%COMP%] {\n  scale: 0.65;\n  position: absolute;\n  top: -16px;\n  left: -11px;\n}\n/*# sourceMappingURL=app-list.component.css.map */"] });
var AppListComponent = _AppListComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(AppListComponent, { className: "AppListComponent", filePath: "src\\app\\features\\app\\components\\app-list\\app-list.component.ts", lineNumber: 31 });
})();

// src/app/shared/components/json-editor/json-editor.module.ts
var _JsonEditorModule = class _JsonEditorModule {
};
_JsonEditorModule.\u0275fac = function JsonEditorModule_Factory(t) {
  return new (t || _JsonEditorModule)();
};
_JsonEditorModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _JsonEditorModule });
_JsonEditorModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [CommonModule] });
var JsonEditorModule = _JsonEditorModule;

// src/app/shared/components/json-diff-editor/json-diff-editor.module.ts
var _JsonDiffEditorModule = class _JsonDiffEditorModule {
};
_JsonDiffEditorModule.\u0275fac = function JsonDiffEditorModule_Factory(t) {
  return new (t || _JsonDiffEditorModule)();
};
_JsonDiffEditorModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _JsonDiffEditorModule });
_JsonDiffEditorModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  MatCheckboxModule
] });
var JsonDiffEditorModule = _JsonDiffEditorModule;

// src/app/features/setting-history/setting-history-routing.module.ts
var routes = [];
var _SettingHistoryRoutingModule = class _SettingHistoryRoutingModule {
};
_SettingHistoryRoutingModule.\u0275fac = function SettingHistoryRoutingModule_Factory(t) {
  return new (t || _SettingHistoryRoutingModule)();
};
_SettingHistoryRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _SettingHistoryRoutingModule });
_SettingHistoryRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes), RouterModule] });
var SettingHistoryRoutingModule = _SettingHistoryRoutingModule;

// src/app/features/setting-history/setting-history.module.ts
var _SettingHistoryModule = class _SettingHistoryModule {
};
_SettingHistoryModule.\u0275fac = function SettingHistoryModule_Factory(t) {
  return new (t || _SettingHistoryModule)();
};
_SettingHistoryModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _SettingHistoryModule });
_SettingHistoryModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  SettingHistoryRoutingModule,
  FormsModule,
  JsonEditorModule,
  JsonDiffEditorModule,
  MatCardModule,
  MatIconModule,
  MatTooltipModule,
  MatSelectModule,
  MatExpansionModule,
  MatButtonModule,
  MatDialogModule
] });
var SettingHistoryModule = _SettingHistoryModule;

// src/app/features/setting/setting-routing.module.ts
var routes2 = [];
var _SettingRoutingModule = class _SettingRoutingModule {
};
_SettingRoutingModule.\u0275fac = function SettingRoutingModule_Factory(t) {
  return new (t || _SettingRoutingModule)();
};
_SettingRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _SettingRoutingModule });
_SettingRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes2), RouterModule] });
var SettingRoutingModule = _SettingRoutingModule;

// src/app/features/setting/setting.module.ts
var _SettingModule = class _SettingModule {
};
_SettingModule.\u0275fac = function SettingModule_Factory(t) {
  return new (t || _SettingModule)();
};
_SettingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _SettingModule });
_SettingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  FormsModule,
  SettingRoutingModule,
  SettingHistoryModule,
  JsonEditorModule,
  ReactiveFormsModule,
  MatIconModule,
  MatExpansionModule,
  MatMenuModule,
  MatCardModule,
  MatFormFieldModule,
  MatOptionModule,
  MatButtonModule,
  MatTooltipModule,
  MatButtonToggleModule,
  MatInputModule,
  MatSelectModule,
  MatDialogModule,
  MatSlideToggleModule,
  MatDialogModule,
  MatAutocompleteModule
] });
var SettingModule = _SettingModule;

// src/app/features/instance/instance.module.ts
var _InstanceModule = class _InstanceModule {
};
_InstanceModule.\u0275fac = function InstanceModule_Factory(t) {
  return new (t || _InstanceModule)();
};
_InstanceModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _InstanceModule });
_InstanceModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  FormsModule,
  MatExpansionModule,
  MatCardModule,
  MatIconModule,
  MatListModule,
  MatCheckboxModule,
  MatButtonModule,
  MatSlideToggleModule,
  MatTooltipModule
] });
var InstanceModule = _InstanceModule;

// src/app/shared/components/dummy/dummy-child.component.ts
var _DummyChildComponent = class _DummyChildComponent {
  constructor(route, dummyComponentService) {
    this.route = route;
    this.dummyComponentService = dummyComponentService;
  }
  ngOnInit() {
    const path = this.route.snapshot.data["path"];
    const data = this.route.snapshot.data["data"];
    if (path) {
      this.dummyComponentService.emitEvent({
        path,
        data,
        activatedSnapshot: this.route.snapshot,
        activatedRoute: this.route
      });
    }
  }
  ngOnDestroy() {
    this.dummyComponentService.emitEvent(void 0);
  }
};
_DummyChildComponent.\u0275fac = function DummyChildComponent_Factory(t) {
  return new (t || _DummyChildComponent)(\u0275\u0275directiveInject(ActivatedRoute), \u0275\u0275directiveInject(DummyComponentService));
};
_DummyChildComponent.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({ type: _DummyChildComponent, selectors: [["ng-component"]], decls: 0, vars: 0, template: function DummyChildComponent_Template(rf, ctx) {
}, encapsulation: 2 });
var DummyChildComponent = _DummyChildComponent;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && \u0275setClassDebugInfo(DummyChildComponent, { className: "DummyChildComponent", filePath: "src\\app\\shared\\components\\dummy\\dummy-child.component.ts", lineNumber: 8 });
})();

// src/app/features/app/app-routing.module.ts
var routes3 = [
  {
    path: APP_ROUTES.base,
    component: AppListComponent,
    children: [
      {
        path: APP_ROUTES.create,
        pathMatch: "full",
        component: DummyComponent,
        data: {
          path: APP_ROUTES.create
        }
      },
      {
        path: APP_ROUTES.update,
        pathMatch: "full",
        component: DummyComponent,
        data: {
          path: APP_ROUTES.update
        }
      },
      {
        path: APP_ROUTES.view,
        component: DummyComponent,
        data: {
          path: APP_ROUTES.view,
          data: APP_ROUTES.view
        },
        children: [
          {
            path: APP_VIEW_ROUTES.viewNewIdentifierMapping,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewNewIdentifierMapping
            }
          },
          {
            path: APP_VIEW_ROUTES.viewSettings,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewSettings
            }
          },
          {
            path: APP_VIEW_ROUTES.viewSettings2,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewSettings2
            }
          },
          {
            path: APP_VIEW_ROUTES.viewCreateSetting,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewCreateSetting
            }
          },
          {
            path: APP_VIEW_ROUTES.viewSetting,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewSetting
            }
          },
          {
            path: APP_VIEW_ROUTES.viewUpdateSetting,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewUpdateSetting
            }
          },
          {
            path: APP_VIEW_ROUTES.viewCopySettingTo,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewCopySettingTo
            }
          },
          {
            path: APP_VIEW_ROUTES.viewSettingHistories,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewSettingHistories
            }
          },
          {
            path: APP_VIEW_ROUTES.viewSettingHistory,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewSettingHistory
            }
          },
          {
            path: APP_VIEW_ROUTES.viewInstances,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewInstances
            }
          },
          {
            path: APP_VIEW_ROUTES.viewInstances2,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewInstances2
            }
          },
          {
            path: APP_VIEW_ROUTES.viewInstance,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewInstance
            }
          },
          {
            path: APP_VIEW_ROUTES.viewConfiguration,
            component: DummyChildComponent,
            data: {
              path: APP_VIEW_ROUTES.viewConfiguration
            }
          },
          {
            path: "**",
            redirectTo: APP_VIEW_ROUTES.viewSettings2
          }
        ]
      }
    ]
  },
  { path: "**", redirectTo: APP_ROUTES.base }
];
var _AppRoutingModule = class _AppRoutingModule {
};
_AppRoutingModule.\u0275fac = function AppRoutingModule_Factory(t) {
  return new (t || _AppRoutingModule)();
};
_AppRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _AppRoutingModule });
_AppRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes3), RouterModule] });
var AppRoutingModule = _AppRoutingModule;

// src/app/shared/components/dummy/dummy-module.ts
var routes4 = [];
var _DummyModule = class _DummyModule {
};
_DummyModule.\u0275fac = function DummyModule_Factory(t) {
  return new (t || _DummyModule)();
};
_DummyModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _DummyModule });
_DummyModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes4), RouterModule] });
var DummyModule = _DummyModule;

// src/app/features/configuration/configuration-routing.module.ts
var routes5 = [];
var _ConfigurationRoutingModule = class _ConfigurationRoutingModule {
};
_ConfigurationRoutingModule.\u0275fac = function ConfigurationRoutingModule_Factory(t) {
  return new (t || _ConfigurationRoutingModule)();
};
_ConfigurationRoutingModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _ConfigurationRoutingModule });
_ConfigurationRoutingModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [RouterModule.forChild(routes5), RouterModule] });
var ConfigurationRoutingModule = _ConfigurationRoutingModule;

// src/app/features/configuration/configuration.module.ts
var _ConfigurationModule = class _ConfigurationModule {
};
_ConfigurationModule.\u0275fac = function ConfigurationModule_Factory(t) {
  return new (t || _ConfigurationModule)();
};
_ConfigurationModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _ConfigurationModule });
_ConfigurationModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  FormsModule,
  ConfigurationRoutingModule,
  ReactiveFormsModule,
  MatIconModule,
  MatFormFieldModule,
  MatOptionModule,
  MatButtonModule,
  MatTooltipModule,
  MatInputModule,
  MatSelectModule,
  MatSlideToggleModule,
  MatBadgeModule,
  MatExpansionModule
] });
var ConfigurationModule = _ConfigurationModule;

// src/app/features/app/app.module.ts
var _AppModule = class _AppModule {
};
_AppModule.\u0275fac = function AppModule_Factory(t) {
  return new (t || _AppModule)();
};
_AppModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({ type: _AppModule });
_AppModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({ imports: [
  CommonModule,
  AppRoutingModule,
  SharedModule,
  DummyModule,
  SettingModule,
  InstanceModule,
  ReactiveFormsModule,
  FormsModule,
  MatFormFieldModule,
  MatIconModule,
  MatExpansionModule,
  MatCardModule,
  MatOptionModule,
  MatButtonModule,
  MatMenuModule,
  MatChipsModule,
  MatProgressBarModule,
  MatDialogModule,
  MatTabsModule,
  MatSelectModule,
  MatTooltipModule,
  MatAutocompleteModule,
  MatDialogModule,
  MatInputModule,
  ConfigurationModule
] });
var AppModule = _AppModule;
export {
  AppModule
};
//# sourceMappingURL=chunk-DXQKGPI4.js.map
