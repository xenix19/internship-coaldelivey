<template>
<div :style="{width: block ? '100%' : 'unset'}">
    <v-btn v-if="to" :block="block" :loading="loading" class="Button"  :to="to">
         <span><slot></slot></span> 
    </v-btn>
    <v-btn v-else :block="block" :loading="loading" class="Button"  @click="$emit('click')">
         <span><slot></slot></span> 
    </v-btn>
</div>
</template>

<script>
export default {
    props: {
        loading: Boolean,
        block: Boolean,
        to: String
    }
}
</script>

<style scoped>
    .Button {
        transition: all 0.2s !important;
        background: #FFB800 !important;
        border-radius: 8px !important;
        color: white !important;
        height: 40px !important;
        min-height: 40px !important;
        text-transform: none;
        box-shadow: unset ;
    }
    .Button:hover {
        background: #e2a201;
    }
    .Button:active {
        background: #ffca45;
    }
</style>
