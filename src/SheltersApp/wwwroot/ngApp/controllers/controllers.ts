namespace SheltersApp.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
        public CategoryResource;
        public categories;
        public category;

        public getCategories() {
            this.categories = this.CategoryResource.query();

        }

        public saveCategory() {
            this.CategoryResource.save(this.category).$promise.then(() => {
                this.category = null;
                this.getCategories();
            });
        }

        constructor(private $resource: ng.resource.IResourceService) {
            this.CategoryResource = $resource('/api/category/:id');
            this.getCategories();
        }

    
    }
    export class AnimalDetailsController {

        public animal;


        constructor($stateParams: ng.ui.IStateParamsService, private AnimalService: SheltersApp.Services.AnimalService) {
            this.animal = this.AnimalService.getAnimal($stateParams["id"]);

        }

    }
    angular.module('SheltersApp').controller('AnimalDetailController', AnimalDetailsController);

    export class AnimalController {
        public secrets;

        public animals;

        constructor($http: ng.IHttpService, private AnimalService: SheltersApp.Services.AnimalService) {
                this.animals = this.AnimalService.getAnimals();
        }    
        
    }
    export class AnimalEditController {
        public animalToEdit;

        public editAnimal() {
            this.AnimalService.save(this.animalToEdit).then(
                () => this.$state.go('secret')
            );
        }

        constructor(private AnimalService: SheltersApp.Services.AnimalService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.animalToEdit = AnimalService.getAnimal($stateParams['id'])
        }
    }
    angular.module('SheltersApp').controller('AnimalEditController', AnimalEditController);

    export class AnimalDeleteController {
        public animalToDelete;

        public deleteAnimal() {
            this.AnimalService.deleteAnimal(this.animalToDelete.id).then(
                () => this.$state.go('secret')
            );
        }

        constructor(private AnimalService: SheltersApp.Services.AnimalService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.animalToDelete = AnimalService.getAnimal($stateParams['id'])
        }
    }

    angular.module('SheltersApp').controller('AnimalDeleteController', AnimalDeleteController);

    export class AnimalAddController {
        public animalToCreate;

        addAnimal() {
            this.AnimalService.save(this.animalToCreate).then(
                () => this.$state.go('secret')
            );
            
        }

        constructor(private AnimalService: SheltersApp.Services.AnimalService, private $state: ng.ui.IStateService) { }
    }
    angular.module('SheltersApp').controller('AnimalAddController', AnimalAddController);

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
