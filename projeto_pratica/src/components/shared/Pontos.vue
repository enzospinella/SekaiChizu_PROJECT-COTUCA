<template>
      <area shape="circle" coords="xI,yI, xF,yF" id="ponto">
</template>

<script>
export default {
    props: ['xI', 'yI', 'xF', 'yF']
}
</script>

<style>
    #ponto {
        border-radius: 20px;
        background-color: blueviolet;
        cursor: pointer;
        z-index: 1;
    }
</style>