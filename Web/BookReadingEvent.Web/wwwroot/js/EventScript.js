(function () {
    const addMoreButton = document.getElementById('cr652AddMore');

    addMoreButton.addEventListener('click', () => {
        const allInvites = document.querySelectorAll('[data-invite]');
        const invitesWrapper = document.getElementById('cr652Invites')

        let hasEmptyValue = false;
        allInvites.forEach((email) => {
            var regexp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            hasEmptyValue = hasEmptyValue || !regexp.test(String(email).toLowerCase());
        })

        console.log('again')

        if (!allInvites) {
            const inputElement = document.createElement('input')
            inputElement.setAttribute('asp-for', 'InviteByEmail');
            inputElement.setAttribute('class', 'form-control');
            inputElement.setAttribute('data-index')

            invitesWrapper.append(inputElement)
        }
    })
})();