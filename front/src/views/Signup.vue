<template>
    <v-container justify-center align-center fluid fill-height class="wrapper">
        <div class="card" v-if="ui == 'SIGN_UP'">
            <h1>Регистрация</h1>
            <TextField :disabled="loading" v-model="data.login" class="mt-3" label="Логин" placeholder="Логин" />
            <TextField :disabled="loading" v-model="data.password" password class="mt-2" label="Пароль" placeholder="Пароль" />
            <TextField :disabled="loading" v-model="data.email" class="mt-2" label="Почта" placeholder="Почта" />
            <TextField :disabled="loading" v-model="data.surname" class="mt-2" label="Фамилия" placeholder="Фамилия" />
            <TextField :disabled="loading" v-model="data.firstname" class="mt-2" label="Имя" placeholder="Имя" />
            <TextField :disabled="loading" v-model="data.patronomic" class="mt-2" label="Отчество" placeholder="Отчество" />

            <Button :loading="loading" block @click="Register" class="mt-4">Зарегистрировать</Button>
            <span v-if="error" class="error mt-2">{{error}}</span>
            <v-row class="mt-2" no-gutters justify="center">
                <router-link to="/sign-in" style="text-decoration: none;">
                    <span class="sign-up">У меня есть личный кабинет</span>
                </router-link>
            </v-row>
        </div>

        <div class="card" v-if="ui == 'VERIFICATION_EMAIL'">
            <h1>Подтверждение почты</h1>
            <p class="mt-2">На Вашу почту был отправлен код подтверждения</p>
            <TextField :disabled="loading" v-model="data.code" class="mt-3" label="Код подтверждения" placeholder="Код подтверждения" />
            

            <Button :loading="loading" block @click="Register" class="mt-4">Подтвердить</Button>
            <span v-if="error" class="error mt-2">{{error}}</span>
            <v-row class="mt-2" no-gutters justify="center">
                <router-link to="/sign-in" style="text-decoration: none;">
                    <span class="sign-up">У меня есть личный кабинет</span>
                </router-link>
            </v-row>
        </div>


    </v-container>
</template>

<script>
export default {
    data() {
        return {
            ui: "SIGN_UP",
            data: {
                login: "xenix1",
                email: "me@xenix.ru",
                password: "123123",
                surname: "123123",
                firstname: "123123",
                patronomic: "123123",
                code: -1,
            },
          
            loading: false,
            error: undefined,
        }
    },
    created() {
            if(this.$store.state.access_token && this.$store.state.user) this.$router.push('/')
    },
    methods: {
        async Register() {
           this.loading = true;
           this.error = undefined;

           var register = await this.$API.REGISTER(this.data);

           if(!register) {
             this.error = "Не удалось соединится с сервером DeliveryCoal";
             return this.loading = false;
           }

           if(register?.error) {
             this.error = register.error;
             return this.loading = false;
           }

           if(this.data.code == -1) {
               this.data.code = undefined;
               this.ui = 'VERIFICATION_EMAIL';
               this.loading = false;
           } else {
                if(register) {
                    this.$router.push('/sign-in');
                }else 
                    this.error = "Не удалось пройти регистрацию"
                this.loading = false;
           }
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