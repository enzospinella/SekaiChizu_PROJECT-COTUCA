import Vue from 'vue';
export declare class LayersDirective extends Vue {
    render(): void;
}
export declare const LayersPlugin: {
    name: string;
    install(Vue: any): void;
};
/**
 * `LayersDirective` directive represent a layers of the react maps.
 * ```vue
 * <ejs-maps>
 * <e-layers>
 * <e-layer></e-layer>
 * </e-layers>
 * </ejs-maps>
 * ```
 */
export declare class LayerDirective extends Vue {
    render(): void;
}
export declare const LayerPlugin: {
    name: string;
    install(Vue: any): void;
};
