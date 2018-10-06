export class GlobalStatic {
    public static get prefixUrl(): string { return 'http://localhost/webapi'; }
}

export const GlobalCons = Object.freeze({

    registerUrl: GlobalStatic.prefixUrl + '/api/User/Register',
    loginUrl: GlobalStatic.prefixUrl + '/token',
    homePageUrl: 'http://localhost:4200/',
    getCourse: GlobalStatic.prefixUrl + '/Api/Courses',
    trainerUrl: GlobalStatic.prefixUrl + '/api/Trainers',
    getClaimUrl: GlobalStatic.prefixUrl + '/api/GetUserClaims',
    getToken: localStorage.getItem('userToken'),
    imagePath: 'assets/images/',
    storeImage:  GlobalStatic.prefixUrl + '/' + 'assets/images/',
    imageFileType: ['image/jpeg','image/png'],
    documentFileType: ['application/pdf','application/msword','application/vnd.openxmlformats-officedocument.wordprocessingml.document'],
    maxImageSize: 1000000 ,//1 MB in bytes
    maxDocumentSize: 1000000 //1 MB in bytes
});

