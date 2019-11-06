<template>
    <div>
        <md-card>
            <md-card-header class='header'>
                <div class="md-layout">
                    <div class="md-layout-item"></div>
                    <div class="md-layout-item">Monthly Emotions View: <span class="md-accent">Themba Baloyi</span></div>
                    <div class="md-layout-item">
                        Overall monthly emotions: 
                        <md-icon class="md-accent">sentiment_satisfied</md-icon>
                    </div>
                </div>
                <br>      
                <div class='md-layout' >
                    <div class='md-layout'>
                        <div class="item-layout">
                                <md-field> 
                                    <md-select v-model="months" name="months" id="months" placeholder='Select a month'>
                                        <md-option value="january">January</md-option>
                                        <md-option value="february">February</md-option>
                                        <md-option value="march">March</md-option>
                                        <md-option value="april">April</md-option>
                                        <md-option value="may">May</md-option>
                                        <md-option value="june">June</md-option>
                                        <md-option value="july">July</md-option>
                                        <md-option value="august">August</md-option>
                                        <md-option value="september">September</md-option>
                                        <md-option value="october">October</md-option>
                                        <md-option value="november">November</md-option>
                                        <md-option value="december">December</md-option>
                                    </md-select>
                                </md-field>
                            </div>  
                    </div>
                    <div class='md-layout'>
                        <div class="item-layout">
                                <md-field> 
                                    <md-select v-model="years" name="years" id="years" placeholder='Select a year'>
                                        <md-option value="2019">2019</md-option>
                                        <md-option value="2020">2020</md-option>
                                        <md-option value="2021">2021</md-option>
                                        <md-option value="2022">2022</md-option>
                                        <md-option value="2023">2023</md-option>
                                        <md-option value="2024">2024</md-option>
                                        <md-option value="2025">2025</md-option>
                                        <md-option value="2026">2026</md-option>
                                        <md-option value="2027">2027</md-option>
                                        <md-option value="2028">2028</md-option>
                                        <md-option value="2029">2029</md-option>
                                        <md-option value="2030">2030</md-option>
                                    </md-select>
                                    <md-button class="md-primary md-raised">Apply Date</md-button>
                                </md-field>
                        </div>
                    </div>
                    <div class="md-layout-item">
                        
                    </div>
                </div>
           
            </md-card-header>

            <md-card-content>
                <md-card>
                    <md-card-content>
                        <calendar/>
                    </md-card-content>
                </md-card>
                
            </md-card-content>
            <md-card-footer>
                <span class="md-accent md-display-2">Dominance</span><br><br>
                <md-icon>sentiment_satisfied</md-icon>
                <span> - 60% Happy</span>
                <br>
                <md-icon>sentiment_satisfied</md-icon>
                <span> - 5% Sad</span>
                <br>
                <md-icon>sentiment_satisfied</md-icon>
                <span> - 4% Neutral</span>
                <br>
                <md-icon>sentiment_satisfied</md-icon>
                <span> - 6% Happy</span>
                <br>
                <md-icon>sentiment_satisfied</md-icon>
                <span> - 8% Happy</span>
                <br>
                <md-icon>sentiment_satisfied</md-icon>
                <span> - 10% Happy</span>
            
                    <md-divider class="md-inset"></md-divider>
            </md-card-footer>

        </md-card>
    </div>
</template>

<script>
import calendar from './Calendar';

export default {
    name: 'monthview',
    components: {
        calendar
    }
}
</script>

<style lang="scss" scoped>
    .item-layout{
        width: 350px;
    }

    .md-layout-item {
    height: 40px;

    &:after {
      width: 100%;
      height: 100%;
      display: block;
      background: md-get-palette-color(red, 200);
      content: " ";
    }

    .md-list {
    width: 320px;
    display: inline-block;
    vertical-align: top;
    border: 1px solid rgba(#000, .12);
  }
  }
</style>