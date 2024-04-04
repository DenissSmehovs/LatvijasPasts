import { useState, useEffect } from "react";
import { CvRequest } from "../services/personalinfo";
import Modal from "antd/es/modal/Modal";
import Input from "antd/es/input";
import WorkExperienceInput from "../components/WorkExperience";
import EducationInput from "../components/Education";

interface Props{
    mode: Mode;
    values: PersonalInfo,
    isModalOpen: boolean;
    handleCancel: () => void,
    handleCreate: (request: CvRequest) => void;
    handleUpdate: (id: number, request: CvRequest) => void;
}

export enum Mode {
    Create = "Create",
    Edit = "Edit",
}

export const CreateUpdateCv = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [personalInfo, setPersonalInfo] = useState<PersonalInfo>({
        firstName: "",
        lastName: "",
        phoneNumber: "",
        email: "",
        workExperiences: {
            companyName: "",
            position: "",
            yearsOfExperience: 0,
            description: "",
            id: 0,
        },
        educations: {
            institutionName: "",
            faculty: "",
            degree: "",
            status: "",
            id: 0,
        },
        id: 0,
    });

    useEffect(() => {
        setPersonalInfo(values);
    }, [values]);

    const handleOnOk = async () => {
        const cvRequest: CvRequest = {
            firstName: personalInfo.firstName,
            lastName: personalInfo.lastName,
            email: personalInfo.email,
            phoneNumber: personalInfo.phoneNumber,
            workExperiences: personalInfo.workExperiences,
            educations: personalInfo.educations,
        };
        mode === Mode.Create ? handleCreate(cvRequest) : handleUpdate(values.id, cvRequest);
    };

    return (
        <Modal
        title={mode === Mode.Create ? "Add Cv" : "UpdateCv"}
        visible={isModalOpen}
        onOk={handleOnOk}
        onCancel={handleCancel}
        cancelText={"Cancel"}
    >
        <div className="cv__modal">
            <Input
                value={personalInfo.firstName}
                onChange={(e) => setPersonalInfo({ ...personalInfo, firstName: e.target.value })}
                placeholder="FirstName"
            />
            <Input
                value={personalInfo.lastName}
                onChange={(e) => setPersonalInfo({ ...personalInfo, lastName: e.target.value })}
                placeholder="LastName"
            />
            <Input
                value={personalInfo.email}
                onChange={(e) => setPersonalInfo({ ...personalInfo, email: e.target.value })}
                placeholder="Email"
            />
            <Input
                value={personalInfo.phoneNumber}
                onChange={(e) => setPersonalInfo({ ...personalInfo, phoneNumber: e.target.value })}
                placeholder="PhoneNumber"
            />
        <WorkExperienceInput
          value={personalInfo.workExperiences}
          onChange={(newValue) => setPersonalInfo({ ...personalInfo, workExperiences: newValue })}
        />
        <EducationInput
          value={personalInfo.educations}
          onChange={(newValue) => setPersonalInfo({ ...personalInfo, educations: newValue })}
        />
        </div>
    </Modal>
    );
};