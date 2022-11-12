function init() {
    $.ajax({
        url: "/UpdateEvent/GetEventById",
        method: "GET",
        success: function (data) {
            try {
                var newData = JSON.parse(data);

                ['Title', 'Duration', 'Description', 'StartTime', 'Location', 'Date', 'Type'].forEach((key) => {
                    const element = document.getElementById(key);
                    if (element.type === 'radio') {
                        const allChilds = document.querySelectorAll(`[name=${key}]`);
                        allChilds.forEach((child) => {
                            child.checked = child.value === newData[key];
                        })
                    } else if (element.type === 'date') {
                        element.value = (newData[key] ?? '').slice(0, 10);
                    } else {
                        element.value = newData[key];
                    }
                })
            } catch (error) {
                console.error(error)
            }
        },
        error: function (err) {
            console.error(err);
        }
    })
}

init();