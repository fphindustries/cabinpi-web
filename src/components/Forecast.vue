<template>
  <div>
    <p>Forecast: {{ forecast }}</p>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  computed: {
    ...mapGetters(['forecast']),
  },
};
</script>
