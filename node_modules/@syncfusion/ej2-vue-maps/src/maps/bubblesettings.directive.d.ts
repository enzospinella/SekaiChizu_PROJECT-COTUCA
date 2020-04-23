import Vue from 'vue';
export declare class BubblesDirective extends Vue {
    render(): void;
}
export declare const BubblesPlugin: {
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
export declare class BubbleDirective extends Vue {
    render(): void;
}
export declare const BubblePlugin: {
    name: string;
    install(Vue: any): void;
};
