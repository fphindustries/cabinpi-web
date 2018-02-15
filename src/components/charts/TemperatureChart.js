import { Line } from 'vue-chartjs';

export default {
  extends: Line,
  props: ['data', 'labels'],
  mounted() {
    // Overwriting base render method with actual data.
    this.renderChart({
      labels: this.labels,
      datasets: [
        {
          label: 'GitHub Commits',
          backgroundColor: '#f87979',
          data: this.data,
        },
      ],
    });
  },
};
