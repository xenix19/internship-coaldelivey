import Vue from 'vue'

var objects = [
    "TextField",
    "Select",
    "Button",
];

objects.forEach(element => {
    var name = element.includes("/") ? element.split("/")[element.split("/").length - 1] : element;
    Vue.component(name, () => import(`../components/${element}.vue`))
});