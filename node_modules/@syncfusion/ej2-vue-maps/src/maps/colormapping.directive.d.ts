import Vue from 'vue';
export declare class ColorMappingsDirective extends Vue {
    render(): void;
}
export declare const ColorMappingsPlugin: {
    name: string;
    install(Vue: any): void;
};
/**
 * `BubblesDirective` directive represent a bubble settings of the Vuejs maps.
 * ```vue
 * <ejs-maps>
 * <e-layers>
 * <e-layer>
 * <e-bubbleSettings>
 * <e-bubbleSetting>
 * </e-bubbleSetting>
 * </e-bubbleSettings>
 * </e-layer>
 * </e-layers>
 * </ejs-maps>
 * ```
 */
export declare class ColorMappingDirective extends Vue {
    render(): void;
}
export declare const ColorMappingPlugin: {
    name: string;
    install(Vue: any): void;
};
