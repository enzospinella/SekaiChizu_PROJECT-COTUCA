<template>
    <div>
        <img src="https://www.freepnglogos.com/uploads/world-map-png/globe-world-world-map-graphic-design-png-image-with-20.png"
             alt="Mapa" 
             id="mapa"
             usemap="#mapaMundi">
        <map name="mapaMundi">
            <ponto :xI="280" :yI="90" :xF="260" :yF="70"></ponto>
        </map>     
    </div>
</template>


<script>
import Ponto from './shared/Pontos.vue'
export default {
    components: {
        'ponto': Ponto
    }
}
</script>

<style> 
div {
    height: 100%;
    width: 100%;
    background-color: blue;
}
#mapa {
    height: 100%;
    width: 100%;
    z-index: -1;
}
</style>