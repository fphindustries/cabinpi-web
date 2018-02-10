<template>
  <div>
    <p>Forecast: {{ forecast }}</p>
  </div>
</template>

<script>
import restClient from '../services/restClient';

export default {
  components: {
  },
  data() {
    return {
      forecast: {},
    };
  },
  methods: {
    loadForecast() {
      restClient.getForecast().then((data) => {
        this.forecast = data;
      });
    },
  },
  created() {
    this.loadForecast();
  },
};
</script>
