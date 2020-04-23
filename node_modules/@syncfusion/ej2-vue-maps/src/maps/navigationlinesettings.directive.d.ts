import Vue from 'vue';
export declare class NavigationLinesDirective extends Vue {
    render(): void;
}
export declare const NavigationLinesPlugin: {
    name: string;
    install(Vue: any): void;
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
export declare class NavigationLineDirective extends Vue {
    render(): void;
}
export declare const NavigationLinePlugin: {
    name: string;
    install(Vue: any): void;
};
