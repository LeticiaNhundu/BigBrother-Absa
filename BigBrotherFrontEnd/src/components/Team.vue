<template>
    <div>
        <md-card md-with-hover>
            <md-ripple>
                <md-card-header>
                <div class="md-title"></div>
                </md-card-header>

                <md-card-content>
                <md-table v-model="teams"  @md-selected="onSelect">
                    <md-table-toolbar>
                        <h1 class="md-title">Big Brother Teams</h1>
                    </md-table-toolbar>
                    <md-table-row slot="md-table-row" slot-scope="{ item }" :class="getClass(item)" md-selectable="single">
                    <md-table-cell md-label="Team ID" md-sort-by="id" md-numeric>{{ item.id }}</md-table-cell>
                    <md-table-cell md-label="Team Name" md-sort-by="name">{{ item.name }}</md-table-cell>
                    <md-table-cell md-label="Number Of Members" md-sort-by="members" md-numeric>{{ item.members }}</md-table-cell>
                    </md-table-row>
                </md-table>
                </md-card-content>


                    <md-dialog :md-active.sync="showDialog">
                            <md-dialog-title>View Team</md-dialog-title> 
                            <md-dialog-content>
                                <md-field>
                                    <md-input v-model="teamName" value="The Voice Folks" placeholder="Team Name"></md-input><br>
                                </md-field>
                                <md-table v-model="teamMates">
                                    <md-table-row slot="md-table-row" slot-scope="{ item }">
                                        <md-table-cell md-label="AB Number" md-sort-by="abNumber" md-numeric>{{ item.abNumber }}</md-table-cell>
                                        <md-table-cell md-label="Full Names" md-sort-by="names">{{ item.names }}</md-table-cell>
                                    </md-table-row>
                                </md-table>
                            </md-dialog-content>
                        <md-dialog-actions>
                            <md-button class="md-primary" @click="showDialog = false">Close</md-button>
                            <md-button class="md-primary" @click="showDialog = false">Save</md-button>
                        </md-dialog-actions>
                        </md-dialog>
                
                        <md-dialog :md-active.sync="showAddDialog">
                            <md-dialog-title>Add Team</md-dialog-title> 
                            <md-dialog-content>
                                <md-field>
                                    <md-input placeholder="Team Name"></md-input><br>
                                </md-field>
                            </md-dialog-content>
                            <md-dialog-actions>
                                <md-button class="md-primary" @click="showAddDialog = false">Save</md-button>
                                <md-button class="md-primary" @click="showAddDialog = false">Close</md-button>
                            </md-dialog-actions>
                        </md-dialog>
                
                
                <md-card-actions>
                <md-button class="md-primary md-raised" @click="showDialog = true">View Team</md-button>
                <md-button class="md-accent md-raised" @click="showAddDialog = true">Add New Team</md-button>
                </md-card-actions>
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
      teamMates: [
          {
              abNumber: 'abtb409',
              names: 'Gift Themba Baloyi'
          },
          {
              abNumber: 'abtb409',
              names: 'Gift Themba Baloyi'
          },
          {
              abNumber: 'abtb409',
              names: 'Gift Themba Baloyi'
          },
          {
              abNumber: 'abtb409',
              names: 'Gift Themba Baloyi'
          },
          {
              abNumber: 'abtb409',
              names: 'Gift Themba Baloyi'
          },
          {
              abNumber: 'abtb409',
              names: 'Gift Themba Baloyi'
          },
      ],
      teams: [
        {
          id: 1,
          name: 'The Voice Folks',
          members: '3'
        },
        {
          id: 2,
          name: 'The Absa Team',
          members: '10'
        },
        {
          id: 3,
          name: 'The Dariel Team',
          members: '3'
        },
        {
          id: 4,
          name: 'The SA Tea',
          members: '13'
        },
        {
          id: 5,
          name: 'Some other Teams',
          members: '73'
        }
      ]
    }),
    methods: {
      getClass: ({ id }) => ({
        'md-primary': id != 0,
      }),
      onSelect (item) {
        this.selected = item
      }
    }
  }
</script>

<style lang="scss" scoped>

</style>