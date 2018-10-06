
export class GlobalStatic {
    // private static _courseList: ICourseInterface[];

    public static get prefixUrl(): string { return 'http://localhost/WebAPI'; }

    // public static set setCourse(courses: any) { this._courseList = courses };

    // public static get getCourseList(): any { return this._courseList };
}

export const GlobalCons = Object.freeze({

    registerUrl: GlobalStatic.prefixUrl + '/api/User/Register',
    loginUrl: GlobalStatic.prefixUrl + '/token',
    homePageUrl: 'http://localhost:4200/',
    backofficePageUrl: 'http://localhost:5000/',
    getCourse: GlobalStatic.prefixUrl + '/Api/Courses',
    postContact: GlobalStatic.prefixUrl + '/api/Contactus',
    getToken: localStorage.getItem('userToken'),
    imagePath: 'assets/images/',
    storeImage: GlobalStatic.prefixUrl + '/' +'assets/images/'

});

// Defines all of the validation messages for the form.
// ToDO : These could instead be retrieved from a file or database.
export const contactMessages = {
    Name: {
        required: 'Please enter full name.',
        minlength: 'Full name must be at least four characters.',
        maxlength: 'Full name cannot exceed 50 characters.'
    },
    Email: {
        required: 'Please enter email.',
        pattern: 'Please enter valid email.'
    },
    Mobile: {
        required: 'Please enter mobile number.',
        pattern: 'Please enter 10-digit mobile number.'
    },
    Subject: {
        required: 'Please enter subject',
        minlength: 'Full name must be at least 10 characters.',
        maxlength: 'Full name cannot exceed 50 characters.'
    },
    Message: {
        required: 'Please enter message.',
        minlength: 'Full name must be at 10 characters.',
        maxlength: 'Full name cannot exceed 200 characters.'
    }
};

//TODO : Get Data from SQL for SignUP
export const signupMessages = {
  FirstName: {
      required: 'Please enter full name.'
  },
  LastName: {
    required: 'Please enter last name.'
},
UserName: {
  required: 'Please enter user name .',
  minlength: 'User name must be at least four characters.',
  maxlength: 'User name cannot exceed 10 characters.'
},

  Email: {
      required: 'Please enter email.',
      pattern: 'Please enter valid email.'
  },
  Mobile: {
      required: 'Please enter mobile number.',
      pattern: 'Please enter 10-digit mobile number.'
  },
  Password: {
      required: 'Please enter Password',
      minlength: 'Password must be at least 6 characters.'
  },
  ConfirmPassword: {
    required: 'Please enter Password',
    minlength: 'Password must be at least 6 characters.'
}
};


