<template>
<div class="wrapper column flexv flexch" id="wpr_mainView">
        <!--Header-->
        <div class="row header flexh">
            <!--Header Column-->
            <div class="column flexv">
                <div class="button bg-green-3 step-two" data-label="LCARS"></div>
                <div class="elbow bottom-left bg-green-4 flexcv default horizontal">
                    <div class="bar">
                        <div class="block"></div>
                    </div>
                </div>
            </div>
            <div class="wrapper flexch flexv">
                <!--Header Content-->
                <div class="wrapper content flexcv">
                  <div class="row flexh">
                    <div class="column">
                      <h3 class="text-green-3">TEMPERATURE</h3>
                    </div>
                    <div class="column">
                      <h1 class="text-green-2">{{ forecast.currently.temperature }}</h1>
                    </div>
                    <div class="column">
                      <h3 class="text-green-3">FEELS LIKE</h3>
                    </div>
                    <div class="column">
                      <h1 class="text-green-2">{{ forecast.currently.apparentTemperature }}</h1>
                    </div>
                    <div class="column" style="flex:50%">
                      <h3 class="text-green-2">{{ forecast.currently.summary }}</h3>
                    </div>
                  </div>
                  <div class="row flexh">
                    <div class="column" style="flex:100%">
                      <h4 class="text-green-2">{{ forecast.daily.summary }}</h4>
                    </div>
                  </div>
                </div>
                <!--Header Bar Row-->
                <div class="row frame flexh">
                    <div class="bar bg-blue-2"></div>
                    <div class="bar bg-blue-1"></div>
                    <div class="bar bg-blue-3"></div>
                    <div class="bar bg-green-1 flexch"></div>
                    <div class="bar bg-blue-3"></div>
                    <div class="bar bg-blue-2"></div>
                    <div class="bar bg-blue-3"></div>
                </div>
            </div>
        </div>
        <!--Body-->
        <div class="wrapper main flexh flexcv">
            <!--Body Button Column-->
            <div class="wrapper column flexv">
                <div class="elbow top-left bg-green-4 step-two default horizontal">
                    <div class="bar">
                        <div class="block"></div>
                    </div>
                </div>
                <div class="button bg-blue-4"></div>
                <div class="button bg-green-4 step-two"></div>
                <div class="button bg-green-1"></div>
                <div class="button bg-green-2 step-two"></div>
                <div class="button bg-blue-4 flexcv" data-altlabel="LCARS"></div>
            </div>
            <!--Body Bar Row-->
            <div class="column flexch flexv">
                <div class="row flexh frame">
                    <div class="bar bg-green-4"></div>
                    <div class="bar bg-blue-4 small"></div>
                    <div class="bar bg-blue-1"></div>
                    <div class="bar bg-green-3 flexch"></div>
                    <div class="bar bg-blue-2"></div>
                    <div class="bar bg-green-3"></div>
                    <div class="bar bg-green-1"></div>
                </div>
                <!--Body Content-->
                <div class="wrapper content flexcv" style=" overflow:auto;"></div>
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
