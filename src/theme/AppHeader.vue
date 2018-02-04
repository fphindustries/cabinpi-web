<template>
  <div class="column flexv primary-menu" style="width:250px; margin-top:148px;" data-section="visual-guide">
      <div class="complexButton radio" id="radio_3" name="samples1">
        <router-link class="button bg-green-1" to="/" exact=""  data-label="Master Systems Display">
        </router-link>
      </div>
      <div class="complexButton radio" id="radio_5" name="samples1">
        <router-link class="button bg-green-3" to="/forecast" exact="" data-label="Environmental">
        </router-link>
      </div>
      <div class="complexButton radio checked" id="radio_53" name="samples1">
          <div class="button bg-blue-3" id="button_52" data-label="Power"></div>
      </div>
      <div class="complexButton radio" id="radio_55" name="samples1">
          <div class="button bg-blue-1" id="button_54" data-label="Forecast"></div>
      </div>
      <div class="complexButton radio" id="radio_57" name="samples1">
          <div class="button bg-green-1" id="button_56" data-label="Optical"></div>
      </div>
      <div class="elbow bottom-left base bg-green-3 horizontal flexcv" id="button_62"></div>
  </div>
</template>

<script>
  export default {
  };
</script>
