var values;
var genders;
var classes;

new Vue({
    el: "#pro-all",
    data: {
        list: values,
        full_name: '',
        user_id: ''
    },
    methods: {
        getAvaterColor(i) {
            return getAvaterColor(i);
        },
        fullName(fn, ln) {
            return fn + " " + ln;
        },
        first_letter(fn, ln) {
            return fn[0].toUpperCase() + ln[0].toUpperCase();
        },
        onDelete(index) {
            $('#md-delete').modal();
            this.full_name = values[index].first_name + " " + values[index].last_name;
            this.user_id = values[index].user_id;
        }
    }
});


new Vue({
    el: "#gird",
    data: { list: values },
    methods: {
        getAvaterColor(i) {
            return getAvaterColor(i);
        }
    }
});


new Vue({
    el: "#gender",
    data: genders
});

var myObject = new Vue({
    el: '#class',
    data: {
        items: classes,
        subjectChecked: []

    }
})



function onChangeClass(event, c) {
    if (event.target.checked) {
        for (i = 0; i < c.subjects.length; i++) {
            var subject = c.subjects[i];
            $('#' + subject.subject_name + subject.subject_id).prop('checked', true);
            if (!subject.is_selected) {
                myObject.subjectChecked.push(subject.subject_id);
                subject.is_selected = true;
            }
        }

    } else {
        for (i = 0; i < c.subjects.length; i++) {
            var subject = c.subjects[i];
            $('#' + subject.subject_name + subject.subject_id).prop('checked', false);
            subject.is_selected = false;
            const index = myObject.subjectChecked.indexOf(subject.subject_id);
            if (index > -1) {
                myObject.subjectChecked.splice(index, 1);
            }
        }
    }

}


function onChangeSubject(event, c, s) {
    var _class = c;
    var id = '#' + _class.class_name + _class.class_id;
    var count = 0;
    s.is_selected = event.target.checked;
    for (i = 0; i < _class.subjects.length; i++) {
        s = _class.subjects[i];
        if (s.is_selected)
            count++;
    }

    if (count == _class.subjects.length) {
        $(id).prop('indeterminate', false);
        $(id).prop('checked', true);
    } else if (count == 0) {
        $(id).prop('checked', false);
        $(id).prop('indeterminate', false);
    } else if (count > 0) {
        $(id).prop('indeterminate', true);
    }
}

function getAvaterColor(i) {
    var arr = ["avatar-azure", "avatar-blue", "avatar-pink", "avatar-orange", "avatar-cyan",
        "avatar-green", "avatar-purple", "avatar-red", "avatar-yellow"];
    var i = random(i, arr.length);
    return arr[i];
}

function random(seed, max) {
    var x = 0;
    if (seed) {
        x = Math.sin(seed * Math.random()) * 10000
    } else {
        x = Math.sin(Math.random()) * 10000
    }
    var ran = Math.floor((x - Math.floor(x)) * max);
    return ran;
}
