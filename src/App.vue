<template>
  <component :is="layout">
    <router-view :key="$route.fullPath"/>
  </component>
</template>

<script>
import { computed } from 'vue'
import { useRoute } from 'vue-router';
export default {
    setup() {
        const route = useRoute();
        return {
            layout: computed(() => (route.meta.layout || "default") + "-layout")
        };
    },
};
</script>

<style>
@import url("./assets/main.css");
</style>
