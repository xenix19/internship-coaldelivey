<template>
    <v-container justify-center align-center fluid fill-height class="wrapper">
        <div class="card">
            <h1>Авторизация</h1>
            <TextField :disabled="loading" v-model="login" class="mt-3" label="Логин" placeholder="Логин" />
            <TextField :disabled="loading" v-model="password" password class="mt-2" label="Пароль" placeholder="Пароль" />
            <Button :loading="loading" block @click="Login" class="mt-2">Войти</Button>
            <span v-if="error" class="error mt-2">{{error}}</span>
            <v-row class="mt-2" no-gutters justify="center">
                <router-link to="/sign-up" style="text-decoration: none;">
                    <span class="sign-up">У меня нет личного кабинета</span>
                </router-link>
            </v-row>
        </div>
    </v-container>
</template>

<script>
export default {
    data() {
        return {
            loading: false,
            error: undefined,
            login: "xenix",
            password: "123123"
        }
    },
    created() {
            if(this.$store.state.access_token && this.$store.state.user) this.$router.push('/')
    },
    methods: {
        async Login() {
           this.loading = true;
           this.error = undefined;
           var login = await this.$API.LOGIN(this.login, this.password);

           if(login === null) this.error = "Не удалось соединится с сервером DeliveryCoal";
           else if(!login) this.error = "Неверный логин или пароль";

           if(login) {
             this.$store.commit("UpdateToken", login.token);
             var me = await this.$API.ME();
             if(me) {
                 this.$store.commit("UpdateUser", me);
                 this.$router.push('/');
             }else  this.error = "Не удалось соединится с сервером DeliveryCoal!";
           }

           this.loading = false;
        }
    }
}
</script>

<style scoped>
.error {
    display: block;
    background: transparent !important;
    color: red;
    font-size: 12px;
    text-align: center;
}
.sign-up {
    font-weight: 500;
    font-size: 14px;
    line-height: 17px;
    color: #A7A7A7;
}
h1 {
    font-weight: 700;
    font-size: 22px;
    line-height: 27px;
    color: #000000;

}
.card {
    width: 300px;
    padding: 16px;
    background: #FFFFFF;
    border-radius: 16px;
}
.wrapper {
    background: #C3C3C3;
}
</style>