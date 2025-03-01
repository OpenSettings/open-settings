import {
  MatSnackBar
} from "./chunk-JQUQ3G7S.js";
import {
  ɵɵdefineInjectable,
  ɵɵinject
} from "./chunk-SUR7UARE.js";

// src/app/shared/models/error-type.model.ts
var ErrorType;
(function(ErrorType2) {
  ErrorType2[ErrorType2["Custom"] = 0] = "Custom";
  ErrorType2[ErrorType2["Validation"] = 1] = "Validation";
  ErrorType2[ErrorType2["Exception"] = 2] = "Exception";
})(ErrorType || (ErrorType = {}));

// src/app/shared/services/utility.service.ts
var _UtilityService = class _UtilityService {
  constructor(snackBar) {
    this.snackBar = snackBar;
  }
  internalError(errors, duration, action) {
    if (errors.length > 1) {
      const errorMessages = errors.map((error) => `* ${error.description}`).join("\n");
      return this.snackBar.open(`Errors occurred:
${errorMessages}`, action, {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration
      });
    } else if (errors.length === 1) {
      const error = errors[0];
      if (error.type === ErrorType.Validation) {
        const validationFailures = error.validationFailures.map((v) => `PropertyName: '${v.propertyName}', Message: '${v.message}'`).join("\n");
        return this.snackBar.open(`${error.title}: ${error.description} ${validationFailures}`, action, {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration
        });
      } else {
        return this.snackBar.open(`${error.title}: ${error.description}`, action, {
          horizontalPosition: "right",
          verticalPosition: "top",
          duration
        });
      }
    }
    return null;
  }
  internalSimpleError(messages, duration, action) {
    if (messages.length > 1) {
      const errorMessages = messages.map((message) => `* ${message}`).join("\n");
      return this.snackBar.open(`Errors occurred:
${errorMessages}`, action, {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration
      });
    } else if (messages.length === 1) {
      const error = messages[0];
      return this.snackBar.open(error, action, {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration
      });
    }
    return null;
  }
  error(errors, duration) {
    return this.internalError(errors, duration, "Close");
  }
  errorWithRestart(errors, duration, dismissByAction) {
    return this.internalError(errors, duration, "Restart")?.afterDismissed().subscribe((action) => {
      if (!dismissByAction || action.dismissedByAction) {
        window.location.reload();
      }
    });
  }
  simpleError(message, duration) {
    return this.internalSimpleError([message], duration, "Close");
  }
  simpleErrorWithRestart(message, duration, dismissByAction) {
    return this.internalSimpleError([message], duration, "Restart")?.afterDismissed().subscribe((action) => {
      if (!dismissByAction || action.dismissedByAction) {
        window.location.reload();
      }
    });
  }
  copyToClipboard(text) {
    navigator.clipboard.writeText(text).then(() => {
      this.snackBar.open(`Copied to clipboard!`, "Close", {
        horizontalPosition: "right",
        verticalPosition: "top",
        duration: 1500
      });
    }).catch((err) => {
    });
  }
  download(text, className) {
    const blob = new Blob([text], { type: "application/json" });
    const downloadLink = document.createElement("a");
    downloadLink.href = window.URL.createObjectURL(blob);
    downloadLink.download = `settings.${className}.json`;
    downloadLink.click();
  }
  upload(file) {
    return new Promise((resolve, reject) => {
      if (file) {
        const reader = new FileReader();
        reader.readAsText(file, "UTF-8");
        reader.onload = () => {
          const content = reader.result;
          resolve(content);
        };
        reader.onerror = (error) => {
          reject(error);
        };
      } else {
        reject(new Error("No file provided"));
      }
    });
  }
};
_UtilityService.\u0275fac = function UtilityService_Factory(t) {
  return new (t || _UtilityService)(\u0275\u0275inject(MatSnackBar));
};
_UtilityService.\u0275prov = /* @__PURE__ */ \u0275\u0275defineInjectable({ token: _UtilityService, factory: _UtilityService.\u0275fac, providedIn: "root" });
var UtilityService = _UtilityService;

export {
  UtilityService
};
//# sourceMappingURL=chunk-4H4XXYOP.js.map
