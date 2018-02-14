<template>
  <div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  computed: {
    ...mapGetters(['sht31', 'bmp280', 'ds18b20']),
  },
};
</script>
