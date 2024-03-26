"use client";

import Button from 'antd/es/button/button';
import {CV} from "../components/cv"
import { useEffect, useState } from 'react';
import { CvRequest, getAllCv, createCv, updateCv, deleteCv } from '../services/personalinfo';
import Title from 'antd/es/skeleton/Title';
import {CreateUpdateCv, Mode} from "../components/CreateUpdateCV";

export default function CvPage(){
    const defaultValues={
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
    } as PersonalInfo;

const [values, SetValues] = useState<PersonalInfo>(defaultValues);
const [info, setCvInfo] = useState<PersonalInfo[]>([]);
const [loading , setLoading] = useState(true);
const [isModalOpen, setIsModalOpen] = useState(false);
const [mode, setMode] = useState(Mode.Create);

useEffect(() => {
    const getCv = async () => {
        const info = await getAllCv();
        console.log("Received CVs:", info);
        setLoading(false);
        setCvInfo(info);
    };

    getCv();
}, [])
const handleCreateCv = async (request: CvRequest) => {
    await createCv(request);
    closeModal();

    const info = await getAllCv();
    setCvInfo(info);
};

const handleUpdateCv = async (id: number, request: CvRequest) => {
    await updateCv(id, request);
    closeModal();

    const info = await getAllCv();
    setCvInfo(info);
}

const handleDeleteCv = async (id: number) => {
    await deleteCv(id);
    closeModal();

    const info = await getAllCv();
    setCvInfo(info);
}

const openModal = () => {
    setIsModalOpen(true);
};

const closeModal = () => {
    SetValues(defaultValues);
    setIsModalOpen(false);
};

const openEditModal = (cv: PersonalInfo) => {
    setMode(Mode.Edit);
    SetValues(cv);
    setIsModalOpen(true);
}

    return(
        <div>
            <Button
            type="primary"
            style={{marginTop: "30px"}}
            size="large"
            onClick={openModal}
            >
                Create Cv
                </Button>

            <CreateUpdateCv
            mode={mode}
            values={values}
            isModalOpen={isModalOpen}
            handleCreate={handleCreateCv}
            handleUpdate={handleUpdateCv}
            handleCancel={closeModal}
            />

            {loading ? (<Title>Loading.....</Title>
            ) : (
            <CV
             personalInfo = {info}
             handleOpen={openEditModal}
             handleDelete={handleDeleteCv} />
             )}
        </div>

    )
}