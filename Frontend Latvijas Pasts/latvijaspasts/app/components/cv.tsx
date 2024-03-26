import  Card  from 'antd/es/card/Card';
import { CardTitle } from './CardTitle';
import Button from 'antd/es/button/button';

interface Props {
    personalInfo: PersonalInfo[];
    handleDelete: (id: number) => void;
    handleOpen: (info: PersonalInfo) => void;
}

export const CV = ({ personalInfo, handleDelete, handleOpen }: Props) => {
    return (
        <div className="cards">
            {personalInfo.map((info: PersonalInfo) => (
                <Card
                    key={info.id}
                    title={<CardTitle FirstName={info.firstName} LastName={info.lastName} />}
                    bordered={false}
                >
                    <p>
                     <span style={{ float: 'left' }}>{info.email}</span>
                      <span style={{ float: 'right' }}>{info.phoneNumber}</span>
                    </p>
                    <br/>
                    <div className='card__buttons'>
                        <Button
                        onClick={() => handleOpen(info)}
                        style={{flex: 1}}
                        >
                            Edit
                            </Button>
                        <Button
                        onClick={() => handleDelete(info.id)}
                        danger
                        style={{flex: 1}}
                        >
                            Delete
                            </Button>
                    </div>
                 </Card>
            ))}
        </div>
    );
};
