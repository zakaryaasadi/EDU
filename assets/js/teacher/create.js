var values;
var genders;
var classes;


var myObject = new Vue({
    el: '#form',
    data: {
        items: classes,
        list: genders,
        fields: {
            first_name: '', last_name: '',
            user_name: '', password: '', date_of_birth: '', gender_id: genders[0].gender_id,
            joining_date: '', phone: '', address: '', subjects:[]
        },
        e: {
            first_name: '', last_name: '',
            user_name: '', password: '', date_of_birth: '',
            joining_date: '', phone: '', address: '', subjects: ''
        },
    },
    methods: {
        checkForm: function (e) {
            e.preventDefault();
            var is_exit_err = false;
            for (key in this.e) {
                this.e[key] = '';
            }
            this.fields.date_of_birth = $('#birth').val();
            this.fields.joining_date = $('#joining').val();
            if (this.fields.first_name === '') {
                this.e.first_name = this.messageErr('first name');
                is_exit_err = true;
            } 

            if (this.fields.last_name === '') {
                this.e.last_name = this.messageErr('last name');
                is_exit_err = true;
            } 

            if (this.fields.user_name === '') {
                this.e.user_name = this.messageErr('user name');
                is_exit_err = true;
            }

            if (this.fields.password === '') {
                this.e.password = this.messageErr('password');
                is_exit_err = true;
            }

            if (this.fields.date_of_birth === '') {
                this.e.date_of_birth = this.messageErr('date of birth');
                is_exit_err = true;
            } 

            if (this.fields.joining_date === '') {
                this.e.joining_date = this.messageErr('joining date');
                is_exit_err = true;
            }

            if (this.fields.phone === '') {
                this.e.phone = this.messageErr('phone');
                is_exit_err = true;
            }

            if (this.fields.address === '') {
                this.e.address = this.messageErr('address');
                is_exit_err = true;
            }

            if (!this.fields.subjects.length) {
                this.e.subjects = 'Please select some subjects';
                is_exit_err = true;
            }

            if (is_exit_err) {
                $('#post').toggleClass('vibration');
            }
            else {
                $.ajax({
                    url: 'create',
                    data: this.fields,
                    type: "POST",
                    dataType: 'json',
                    success: function (e) {

                    }
                });
            }

        },
        messageErr(fieldName) {
            return 'The field ' + fieldName + ' is required!';
        }
    }
});

function onChangeClass(event, c) {
    if (event.target.checked) {
        for (i = 0; i < c.subjects.length; i++) {
            var subject = c.subjects[i];
            $('#' + subject.subject_name + subject.subject_id).prop('checked', true);
            if (!subject.is_selected) {
                myObject.fields.subjects.push(subject.subject_id);
                subject.is_selected = true;
            }
        }

    } else {
        for (i = 0; i < c.subjects.length; i++) {
            var subject = c.subjects[i];
            $('#' + subject.subject_name + subject.subject_id).prop('checked', false);
            subject.is_selected = false;
            const index = myObject.fields.subjects.indexOf(subject.subject_id);
            if (index > -1) {
                myObject.fields.subjects.splice(index, 1);
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
