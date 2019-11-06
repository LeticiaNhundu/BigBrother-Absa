<template>
    <div>
        <md-card>
            <md-ripple>
                <md-card-header>
                <div class="md-title"></div>
                </md-card-header>

                <md-card-content>
                <md-table v-model="teams"  @md-selected="onSelect">
                    <md-table-toolbar>
                        <h1 class="md-title">Big Brother Teams</h1>
                        <h2 class="md-title">Weekly View</h2>
                        <h3 class="md-title" v-bind="emotions">Overall: {{emotions}}</h3>
                        <md-field class="User">
                            <md-select class="md-raise">
                                <md-option value="a" >Leticia</md-option>
                                <md-option value="b">Themba</md-option>
                                <md-option value="c">Leepo</md-option>
                            </md-select>
                        </md-field>
                        <md-field class="Month">
                            <md-select class="md-raise">
                                <md-option value="a" >January</md-option>
                                <md-option value="b">February</md-option>
                                <md-option value="c">March</md-option>
                                <md-option value="d" >April</md-option>
                                <md-option value="e">May</md-option>
                                <md-option value="f">June</md-option>
                                <md-option value="g" >July</md-option>
                                <md-option value="h">August</md-option>
                                <md-option value="i">September</md-option>
                                <md-option value="j" >October</md-option>
                                <md-option value="k">November</md-option>
                                <md-option value="l">December</md-option>
                            </md-select>
                        </md-field>
                        
                    </md-table-toolbar>
                    <md-table-row slot="md-table-row" slot-scope="{ item }" :class="getClass(item)" md-selectable="single">
                    <md-table-cell md-label="Week"  md-sort-by="id" md-numeric>{{ item.id }}</md-table-cell>
                    <md-table-cell md-label="Happy" md-sort-by="happy" md-numeric>{{ item.happy }}</md-table-cell>
                    <md-table-cell md-label="Sad" md-sort-by="sad" md-numeric>{{ item.sad }}</md-table-cell>
                    <md-table-cell md-label="Angry" md-sort-by="angry" md-numeric>{{ item.angry }}</md-table-cell>
                    <md-table-cell md-label="Neutral" md-sort-by="neutral" md-numeric>{{ item.neutral }}</md-table-cell>
                    <md-table-cell md-label="Time" md-sort-by="time" md-numeric>{{ item.time }}</md-table-cell>
                    </md-table-row>
                </md-table>
                </md-card-content>


                    
                
                
                <md-card-footer>
                <slot>Average: 80%  70%  60%  30%</slot>
                </md-card-footer>
            </md-ripple>
        </md-card>
  </div>
</template>

<script>
export default {
    name: 'team',
    data: () => ({
      showDialog: false,
      showAddDialog: false,
      selected: {},
      teamName: 'The Voice Folks',
      
      teams: [
        {
          id: 1,
          happy: '50%',
          sad: '3%',
          angry: '22%',
          neutral: '10%',
          time: '07:28'
        },
        {
          id: 2,
          happy: '20%',
          sad: '10%',
          angry: '22%',
          neutral: '10%',
          time: '10:50'
        },
        {
          id: 3,
          happy: '22%',
          sad: '3%',
          angry: '22%',
          neutral: '10%',
          time: '12:30'
        },
        {
          id: 4,
          happy: '89%',
          sad: '13%',
          angry: '22%',
          neutral: '10%',
          time: '09:46'
        }
        
      ]
    }),
    methods: {
      getClass: ({ item }) => ({
        'md-primary': item != '',
      }),
      onSelect (item) {
        this.selected = item
      }
    }
  }
  
</script>

<style lang="scss" scoped>

</style>