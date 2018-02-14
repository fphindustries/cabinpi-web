<template>
  <div>
    <ul>
      <li class="text-green-1">Temperature: {{ forecast.currently.temperature }}</li>
      <li class="text-green-1">Pressure: {{ forecast.currently.pressure }}</li>
      <li class="text-green-1">Summary: {{ forecast.currently.summary }}</li>
      <li class="text-green-1">Humidity: {{ forecast.currently.humidity }}</li>
      <li class="text-green-1">Wind: {{ forecast.currently.windSpeed }}</li>
      <li class="text-green-1">Forecast: {{ forecast.daily.summary }}</li>
    </ul>
    <div v-bind:key="day.time" v-for="day in forecast.daily.data">
      <div class="block bg-green-2">Hi
        {{ day.summary }}
        </div>
    </div>
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
