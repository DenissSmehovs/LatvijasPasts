export interface CvRequest {
    firstName: string;
    lastName: string;
    phoneNumber: string;
    email: string;
    workExperiences: WorkExperience;
    educations: Education;
}

export const getAllCv = async () =>  {
    const response = await fetch("http://localhost:5108/cv");
    return response.json();
};

export const createCv = async (cvRequest: CvRequest) => {
    await fetch("http://localhost:5108/cv", {
        method: "POST",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(cvRequest)
    });
};

    export const updateCv = async (id: number, cvRequest: CvRequest) => {
        await fetch(`http://localhost:5108/cv/${id}`, {
            method: "PUT",
            headers:{
                "content-type": "application/json",
            },
            body: JSON.stringify(cvRequest),
        });
    };

    export const deleteCv = async (id: number) => {
        await fetch(`http://localhost:5108/cv/${id}`, {
            method: "DELETE",
        });
    };