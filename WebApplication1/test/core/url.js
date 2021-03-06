;(function () {
    angular
        .module('factory.url', [])
        .factory('url', [
            function () {
                let baseUrl = 'http://itls-hh.eu/';
                let baseUrlNew = 'http://svm.biz.ua/api/web/v1/';
                return {
                    user: {
                        login: baseUrlNew + 'user/login',
                        register: baseUrlNew + 'user/registration'
                    },
                    dashboard: {
                        create_angrag: baseUrlNew + 'antragsteller/create',
                        update_angrag: baseUrlNew + 'antragsteller/update',
                        get_angrag: baseUrlNew + 'antragsteller/index',
                        get_all_members: baseUrlNew + 'entry/index',
                        get_werbung: baseUrl + '',
                        get_kontaktart: baseUrl + '',
                        get_partners: baseUrl + '',
                    },
                    anstragsteller: {
                        index: baseUrlNew + 'antragsteller/index'
                    },
                    immobilie: {
                        create: baseUrlNew + 'immobilie/create',
                        update: baseUrlNew + 'immobilie/update',
                        index: baseUrlNew + 'immobilie/index',
                    },
                    kreditdaten: {
                        create: baseUrlNew + 'kredit-daten/create',
                        update: baseUrlNew + 'kredit-daten/update',
                        index: baseUrlNew + 'kredit-daten/index',
                    },
                    dokument: {
                        get_all_documents: baseUrl + 'Document/GetFilesById',
                    }
                };

            }
        ]);
})();