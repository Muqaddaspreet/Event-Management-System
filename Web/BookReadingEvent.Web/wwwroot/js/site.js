/*(function () {
    const addMoreButton = document.getElementById('cr652AddMore');

    addMoreButton.addEventListener('click', () => {
        const allInvites = document.querySelectorAll('#cr652Invites > *');
        const invitesWrapper = document.getElementById('cr652Invites');

        console.log(allInvites)

        let hasEmptyValue = true;
        allInvites.forEach((inviteInput) => {
            var regexp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            
            hasEmptyValue = hasEmptyValue && regexp.test(inviteInput.value.toLowerCase());
        })


        if (hasEmptyValue) {
            const inputElement = document.createElement('input')
            inputElement.setAttribute('asp-for', 'InviteByEmail');
            inputElement.setAttribute('class', 'form-control');
            inputElement.setAttribute('data-index', true)

            invitesWrapper.append(inputElement)
        }
    })
})();*/