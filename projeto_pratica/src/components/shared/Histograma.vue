<script>
import { Bar, mixins } from 'vue-chartjs'
const { reactiveProp } = mixins;

export default {
  extends: Bar,
  mixins: [reactiveProp],
  props: ['data', 'options'],
  mounted () {
    this.renderChart(this.data, this.options)
  },
  watch: {
  chartData () {
    this.$data._chart.update()
  }
}
}

</script>