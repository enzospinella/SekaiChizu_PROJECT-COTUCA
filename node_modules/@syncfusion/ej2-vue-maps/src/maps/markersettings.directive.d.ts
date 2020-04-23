import Vue from 'vue';
export declare class MarkersDirective extends Vue {
    render(): void;
}
export declare const MarkersPlugin: {
    name: string;
    install(Vue: any): void;
};
/**
 * `MarkerSettingsDirective` directive represent a marker settings of the Vuejs maps.
 * ```vue
 * <ejs-maps>
 * <e-layers>
 * <e-layer>
 * <e-markerSettings>
 * <e-markerSetting>
 * </e-markerSetting>
 * </e-markerSettings>
 * </e-layer>
 * </e-layers>
 * </ejs-maps>
 * ```
 */
export declare class MarkerDirective extends Vue {
    render(): void;
}
export declare const MarkerPlugin: {
    name: string;
    install(Vue: any): void;
};
