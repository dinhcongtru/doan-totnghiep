<template>
    <div v-show="isAlert" class="alert" :class="{ 'isTop' : isTop , 'error' : error }">
        <i class="fa-solid fa-check"></i>
        <span class="message">{{ message }}</span>
    </div>
</template>
<script>
export default {
    name : "TheAlert",
    props:{
        message:{
            type: String,
            default:""
        },
        isTop: {
            type: Boolean,
            default: true
        },
        isAlert:{
            type: Boolean,
            default: false
        },
        error :{
            type:Boolean,
            default: false,
        }

    }
}
</script>
<style scoped>
.alert {
    position: absolute;
    right: 70px;
    padding: 20px;
    background: rgb(16, 133, 16);
    display: flex;
    align-items: center;
    border-radius: 10px;
}
.message {
    text-align: center;
    color: #fff;
    font-size: 15px;
    letter-spacing: 1.5px;
    line-height: 20px;
    margin-left: 10px;
}
.fa-solid{
    font-size: 25px;
}
.isTop {
    top: 150px;
}
.error {
    background: rgb(229 43 43);
}
</style>