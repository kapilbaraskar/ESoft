$(".DashBirthAnnibtn").click(function (e) {
    $(".DashBirthAnnibtn.activebtn").removeClass('activebtn')
    e.delegateTarget.classList.add('activebtn');

})