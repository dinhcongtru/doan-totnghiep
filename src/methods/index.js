
function dynamicUrlProduct(namePro){
    let newStr = namePro.toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/\s+/g, "-");
    return `/${newStr}-p37689115.html`
}
export{dynamicUrlProduct}