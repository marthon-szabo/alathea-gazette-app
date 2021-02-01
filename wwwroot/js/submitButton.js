const buttons = [...document.getElementsByTagName('button')];

buttons.forEach(button => {
    if (button.type === 'submit') {
        button.addEventListener('click', () => {
            console.log("asd");
        })
    }
})

function switchToLoadingBtn(btn) {
    const childSpan = document.createElement('span');
    childSpan.class = 'spinner-border spinner-border-sm';
    childSpan.role = 'status';
    childSpan.ariaHidden = true;

    btn.class = 'btn btn-primary';
    btn.disabled = true;
    btn.appendChild(childSpan);
}