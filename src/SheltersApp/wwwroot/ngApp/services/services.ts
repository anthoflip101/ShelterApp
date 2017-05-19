namespace SheltersApp.Services {
    export class AnimalService {
        public animalResource;

        public getAnimals() {
            return this.animalResource.query();
        }

        public save(animal) {
            return this.animalResource.save(animal).$promise;
        }
        public deleteAnimal(id: number) {
            return this.animalResource.delete({ id: id }).$promise;
        }
        public getAnimal(id) {
            return this.animalResource.get({ id: id });
        }
        constructor($resource: ng.resource.IResourceService) {
            this.animalResource = $resource('/api/animal/:id');
        }

    }
    angular.module('SheltersApp').service('AnimalService', AnimalService);

}
    
