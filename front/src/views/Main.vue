<template>
    <v-container fluid class="ma-0 pa-0">
        <div class="dock">
            <div class="main" v-if="isLoggined">
                <h1>Оформить заказ</h1>
                <TextField class="mt-4" label="Адрес доставки" placeholder="ул. Пушкина 17" v-model="data.adress" />
                <v-row class="mt-4" no-gutters align="center">
                    <h2>Уголь</h2>
                    <v-icon class="ml-1" color="green" @click="AddCoal">mdi-plus</v-icon>
                </v-row>

                <div class="coal-list mt-2" v-if="data.to_delivery_coals.length > 0">
                    <div class="coal-item" v-for="(n,i) in data.to_delivery_coals" :key="n._id">
                        <span style="width: 20px;">{{i+1}}.</span>
                        <Select item_text="coal" item_value="id" :items="coals" v-model="n.coal" style="width: 100%" white placeholder="Уголь" />
                        <TextField v-model="n.mass" style="width: 60%" white placeholder="Масса (КГ)" />
                        <v-icon @click="RemoveCoal(n)" color="black">mdi-close</v-icon>
                    </div>
                </div>

                <div v-if="CalculatedPrice != 0">

                <p class="cost mt-4">Общая стоимость: {{CalculatedPrice}} ₽</p>
                <p class="delivery mt-1">стоимость доставки — 1 024 ₽ </p>

                <Button style="width: 40%" class="mt-4">Заказать</Button>
                </div>
            </div>
            <div class="main not-loggined" v-else>
                <span>Для заказа угля необходимо войти в личный кабинет</span>
                <Button to="/sign-in" block>Войти</Button>
            </div>
            <div class="navigation" v-if="isLoggined">
                <div class="navigator active">
                    <v-icon size="38">mdi-cart</v-icon>
                    <span>Заказать</span>
                </div>
                
                <div class="navigator" @click="test">
                    <v-icon size="38">mdi-history</v-icon>
                    <span>История</span>
                </div>
            </div>
        </div>
        <yandex-map ref="ymaps" class="map" :controls="map.controls" :coords="map.coords">
        </yandex-map>
    </v-container>
</template>

<script>

export default {
    data() {
        return {
            data: {
                to_delivery_coals: [],
                adress: undefined,
            },
            coals: undefined,
            suppliers: undefined,
            map: {
                controls: [],
                coords: [53.7156, 91.4292],
            },
        }
    },
    methods: {
        test() {
        console.log("@@@",this.$refs.ymaps);
        },
        AddCoal() {
            this.data.to_delivery_coals.push({
                coal: undefined,
                mass: 0
            });
        },
        RemoveCoal(n) {
            this.data.to_delivery_coals.splice(this.data.to_delivery_coals.indexOf(n), 1);
        },
    },
    async created() {
        this.coals = (await this.$API.COALS());
        this.suppliers = (await this.$API.SUPPLIERS());

        console.log(this.coals);
        console.log(this.suppliers);
    },
    computed: {
        CalculatedPrice() {
            var price = 0;
            this.data.to_delivery_coals.forEach(el => {
               var coal = this.coals.find(x => x.id == el.coal);
                
                if(coal && el.mass > 0)
                price += ((coal.coast / 1000) * el.mass);
            });
            return Math.round(price * 100) / 100 ;
        },
        isLoggined(){
            if(this.$store.state.user && this.$store.state.access_token) return true;
            return false;
        }
    },
    mounted() {
        navigator.geolocation.getCurrentPosition((location) => {
            this.map.coords = [location.coords.latitude, location.coords.longitude];
        });
    }
}
</script>

<style scoped>
.main.not-loggined {
    font-size: 14px;
    gap: 16px;
    width: 250px !important;
    align-items: center;
    display: flex;
    text-align: center;
    flex-direction: column;
}
.navigator {
    cursor: pointer;
    display: flex;
    flex-direction: column;
    text-align: center;
    justify-content: center;
    align-items: center;
}
.navigator >>> *{
    transition: all 0.2s;
    color: #9F9F9F;
}
.navigator:not(.active):hover >>> *{
    color: #292929;
}
.navigator.active >>> *{
    color: #FFB800;
}

.cost {
    margin-bottom: 0;
    font-weight: 700;
    font-size: 21px;
    line-height: 25px;
    color: #000000;
}
.delivery {
    margin-bottom: 0;
    font-weight: 300;
    font-size: 12px;
    line-height: 15px;
    color: #747474;
}
.coal-item {
    align-items: center;
    display: flex;
    width: 100%;
    gap: 12px;
}
.coal-list {
    display: flex;
    flex-direction: column;
    gap: 8px;
    width: 100%;
    padding: 8px 12px;
    background: #EEEEEE;
    border-radius: 8px;
}
h2 {
    font-weight: 600;
    font-size: 16px;
    line-height: 19px;
    color: #000000;
}
.dock h1{
    font-weight: 600;
    font-size: 24px;
    line-height: 29px;
    color: #000000;
}
.dock {
    z-index: 1;
    width: 450px;
    position: absolute;
    top: 8px;
    left: 8px;
    display: flex;
    flex-direction: column;
    gap: 16px;
}
.dock .navigation {
    padding: 8px 0 !important;
    display: flex;
    justify-content: center;
    gap: 32px;
}
.dock .main,
.dock .navigation {
    width: inherit;
    background: #FFFFFF;
    border: 1px solid #646464;
    border-radius: 16px;
    padding: 16px;
}
.map {
    width: 100vw;
    height: 100vh;
}
</style>
