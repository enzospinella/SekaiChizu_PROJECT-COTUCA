import { Maps } from '../../maps/maps';
import { Point } from '../utils/helper';
import { LayerSettings, Tile } from '../model/base';
import { BingMap } from './bing-map';
/**
 * To calculate and render the shape layer
 */
export declare class LayerPanel {
    private mapObject;
    private currentFactor;
    private groupElements;
    private layerObject;
    private currentLayer;
    private rectBounds;
    tiles: Tile[];
    private clipRectElement;
    private layerGroup;
    private urlTemplate;
    private isMapCoordinates;
    private tileSvgObject;
    private ajaxModule;
    private ajaxResponse;
    private bing;
    private animateToZoomX;
    private animateToZoomY;
    horizontalPan: boolean;
    horizontalPanXCount: number;
    constructor(map: Maps);
    measureLayerPanel(): void;
    /**
     * Tile rendering
     * @private
     */
    renderTileLayer(panel: LayerPanel, layer: LayerSettings, layerIndex: number, bing?: BingMap): void;
    protected processLayers(layer: LayerSettings, layerIndex: number): void;
    private bubbleCalculation;
    calculatePathCollection(layerIndex: number, renderData: Object[]): void;
    /**
     *  layer features as bubble, marker, datalabel, navigation line.
     */
    private layerFeatures;
    /**
     *  render datalabel
     */
    private renderLabel;
    /**
     * To render path for multipolygon
     */
    private generateMultiPolygonPath;
    /**
     * To render bubble
     */
    private renderBubble;
    /**
     * To get the shape color from color mapping module
     */
    private getShapeColorMapping;
    generatePoints(type: string, coordinates: Object[], data: Object, properties: Object): void;
    calculateFactor(layer: LayerSettings): number;
    translateLayerElements(layerElement: Element, index: number): void;
    calculateRectBounds(layerData: Object[]): void;
    calculatePolygonBox(coordinates: Object[], data: Object, properties: Object): Object;
    calculateRectBox(coordinates: Object[]): void;
    generateTiles(zoomLevel: number, tileTranslatePoint: Point, zoomType?: string, bing?: BingMap, position?: Point): void;
    arrangeTiles(type: string, x: number, y: number): void;
    /**
     * Animation for tile layers and hide the group element until the tile layer rendering
     */
    private tileAnimation;
    /**
     * Static map rendering
     * @param apikey
     * @private
     */
    renderGoogleMap(apikey: string, zoom: number): void;
    /**
     * To find the tile translate point
     * @param factorX
     * @param factorY
     * @param centerPosition
     */
    private panTileMap;
}
