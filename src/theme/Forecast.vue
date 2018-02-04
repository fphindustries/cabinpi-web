<template>
  <div>
    <p>Forecast: {{ forecast }}</p>
  </div>
</template>

<script>
  import appService from '../app.service';

  export default {
    components: {
    },
    data () {
      return {
        forecast: {}
      };
    },
    methods: {
      loadForecast () {
        appService.getForecast().then(data => {
          this.forecast = data;
        });
      }
    },
    created () {
      this.loadForecast();
    }
  };
</script>
