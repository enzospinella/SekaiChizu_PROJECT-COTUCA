<template>
    <div id="contato">
        <meuMenu></meuMenu>
        <div class="containerContato">
            <div class="avaliacoes">
                <h1>Avaliar sua experiência</h1>
            </div>
            <div class="comentarios">

            </div>
        </div>
    </div>
</template>

<script>
import Menu from '../components/shared/Menu.vue';
export default {
    el: 'contato',
    data() {
        return{
        }
    },
    components: {
        'meuMenu': Menu
    }
}
</script>

<style>
    .containerContato {
        width: 100vmax;
        height: 100vmin;
        display: inline-flex;
    }
    .avaliacoes {
        display: flex;
        justify-content: center;
        flex: 50%;
    }
    .comentarios {
        flex: 50%;
    }
</style>