import {
  ChangeDetectionStrategy,
  Component,
  Input,
  MatCommonModule,
  NgModule,
  ViewEncapsulation$1,
  coerceBooleanProperty,
  setClassMetadata,
  ɵɵStandaloneFeature,
  ɵɵattribute,
  ɵɵclassProp,
  ɵɵdefineComponent,
  ɵɵdefineInjector,
  ɵɵdefineNgModule
} from "./chunk-SUR7UARE.js";

// node_modules/@angular/material/fesm2022/divider.mjs
var _MatDivider = class _MatDivider {
  constructor() {
    this._vertical = false;
    this._inset = false;
  }
  /** Whether the divider is vertically aligned. */
  get vertical() {
    return this._vertical;
  }
  set vertical(value) {
    this._vertical = coerceBooleanProperty(value);
  }
  /** Whether the divider is an inset divider. */
  get inset() {
    return this._inset;
  }
  set inset(value) {
    this._inset = coerceBooleanProperty(value);
  }
};
_MatDivider.\u0275fac = function MatDivider_Factory(t) {
  return new (t || _MatDivider)();
};
_MatDivider.\u0275cmp = /* @__PURE__ */ \u0275\u0275defineComponent({
  type: _MatDivider,
  selectors: [["mat-divider"]],
  hostAttrs: ["role", "separator", 1, "mat-divider"],
  hostVars: 7,
  hostBindings: function MatDivider_HostBindings(rf, ctx) {
    if (rf & 2) {
      \u0275\u0275attribute("aria-orientation", ctx.vertical ? "vertical" : "horizontal");
      \u0275\u0275classProp("mat-divider-vertical", ctx.vertical)("mat-divider-horizontal", !ctx.vertical)("mat-divider-inset", ctx.inset);
    }
  },
  inputs: {
    vertical: "vertical",
    inset: "inset"
  },
  standalone: true,
  features: [\u0275\u0275StandaloneFeature],
  decls: 0,
  vars: 0,
  template: function MatDivider_Template(rf, ctx) {
  },
  styles: [".mat-divider{display:block;margin:0;border-top-style:solid;border-top-color:var(--mat-divider-color);border-top-width:var(--mat-divider-width)}.mat-divider.mat-divider-vertical{border-top:0;border-right-style:solid;border-right-color:var(--mat-divider-color);border-right-width:var(--mat-divider-width)}.mat-divider.mat-divider-inset{margin-left:80px}[dir=rtl] .mat-divider.mat-divider-inset{margin-left:auto;margin-right:80px}"],
  encapsulation: 2,
  changeDetection: 0
});
var MatDivider = _MatDivider;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatDivider, [{
    type: Component,
    args: [{
      selector: "mat-divider",
      host: {
        "role": "separator",
        "[attr.aria-orientation]": 'vertical ? "vertical" : "horizontal"',
        "[class.mat-divider-vertical]": "vertical",
        "[class.mat-divider-horizontal]": "!vertical",
        "[class.mat-divider-inset]": "inset",
        "class": "mat-divider"
      },
      template: "",
      encapsulation: ViewEncapsulation$1.None,
      changeDetection: ChangeDetectionStrategy.OnPush,
      standalone: true,
      styles: [".mat-divider{display:block;margin:0;border-top-style:solid;border-top-color:var(--mat-divider-color);border-top-width:var(--mat-divider-width)}.mat-divider.mat-divider-vertical{border-top:0;border-right-style:solid;border-right-color:var(--mat-divider-color);border-right-width:var(--mat-divider-width)}.mat-divider.mat-divider-inset{margin-left:80px}[dir=rtl] .mat-divider.mat-divider-inset{margin-left:auto;margin-right:80px}"]
    }]
  }], null, {
    vertical: [{
      type: Input
    }],
    inset: [{
      type: Input
    }]
  });
})();
var _MatDividerModule = class _MatDividerModule {
};
_MatDividerModule.\u0275fac = function MatDividerModule_Factory(t) {
  return new (t || _MatDividerModule)();
};
_MatDividerModule.\u0275mod = /* @__PURE__ */ \u0275\u0275defineNgModule({
  type: _MatDividerModule
});
_MatDividerModule.\u0275inj = /* @__PURE__ */ \u0275\u0275defineInjector({
  imports: [MatCommonModule, MatCommonModule]
});
var MatDividerModule = _MatDividerModule;
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(MatDividerModule, [{
    type: NgModule,
    args: [{
      imports: [MatCommonModule, MatDivider],
      exports: [MatDivider, MatCommonModule]
    }]
  }], null, null);
})();

export {
  MatDivider,
  MatDividerModule
};
//# sourceMappingURL=chunk-TDUSDNS5.js.map
