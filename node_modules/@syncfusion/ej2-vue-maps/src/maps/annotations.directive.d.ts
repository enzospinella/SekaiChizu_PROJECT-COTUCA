import Vue from 'vue';
export declare class AnnotationsDirective extends Vue {
    render(): void;
}
export declare const AnnotationsPlugin: {
    name: string;
    install(Vue: any): void;
};
/**
 * `AnnotationsDirective` directive represent a annotation of the Vuejs maps.
 * ```vue
 * <ejs-maps>
 * <e-maps-annotations>
 * <e-maps-annotation></e-maps-annotation>
 * </e-maps-annotations>
 * </ejs-maps>
 * ```
 */
export declare class AnnotationDirective extends Vue {
    render(): void;
}
export declare const AnnotationPlugin: {
    name: string;
    install(Vue: any): void;
};
