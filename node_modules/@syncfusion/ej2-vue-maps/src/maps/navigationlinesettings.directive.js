var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from 'vue';
import { EJComponentDecorator } from '@syncfusion/ej2-vue-base';
var NavigationLinesDirective = /** @class */ (function (_super) {
    __extends(NavigationLinesDirective, _super);
    function NavigationLinesDirective() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    NavigationLinesDirective.prototype.render = function () {
        return;
    };
    NavigationLinesDirective = __decorate([
        EJComponentDecorator({})
    ], NavigationLinesDirective);
    return NavigationLinesDirective;
}(Vue));
export { NavigationLinesDirective };
export var NavigationLinesPlugin = {
    name: 'e-navigationLineSettings',
    install: function (Vue) {
        Vue.component(NavigationLinesPlugin.name, NavigationLinesDirective);
    }
};
/**
 * `NavigationLinesDirective` directive represent a bubble settings of the Vuejs maps.
 * ```vue
 * <ejs-maps>
 * <e-layers>
 * <e-layer>
 * <e-navigationLineSettings>
 * <e-navigationLineSetting>
 * </e-navigationLineSetting>
 * </e-navigationLineSettings>
 * </e-layer>
 * </e-layers>
 * </ejs-maps>
 * ```
 */
var NavigationLineDirective = /** @class */ (function (_super) {
    __extends(NavigationLineDirective, _super);
    function NavigationLineDirective() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    NavigationLineDirective.prototype.render = function () {
        return;
    };
    NavigationLineDirective = __decorate([
        EJComponentDecorator({})
    ], NavigationLineDirective);
    return NavigationLineDirective;
}(Vue));
export { NavigationLineDirective };
export var NavigationLinePlugin = {
    name: 'e-navigationLineSetting',
    install: function (Vue) {
        Vue.component(NavigationLinePlugin.name, NavigationLineDirective);
    }
};
