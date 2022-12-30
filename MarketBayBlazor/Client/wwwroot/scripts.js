function resetProduct(produtoID) {
    const destaque = document.getElementById(`destaque-${produtoID}`); 
    const quantidade = document.getElementById(`quantidade-produto-${produtoID}`);
    const preco = document.getElementById(`preco-produto-${produtoID}`);

    if(destaque.checked)
        destaque.click();

    quantidade.value = 0;
    preco.value = 0.0;
}

function getProductPrice(produtoID) {
    return Number(document.getElementById(`preco-produto-${produtoID}`).value)
}

function getProductQuantity(produtoID) {
    return Number(document.getElementById(`quantidade-produto-${produtoID}`).value)
}

function estaDestacado(produtoID) {
    return document.getElementById(`destaque-${produtoID}`).checked;
}

function printHello() {
    console.log('hello world');
}