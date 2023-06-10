import {useState} from 'react'
import {Card, Container, Divider, Grid, GridColumn, GridRow, Header, Icon, Input} from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import './App.css'

interface ToDoModel {
    id: number,
    task: string,
    isCompleted: boolean,
    createdDate: Date
}

const App = () => {
    const [list, setList] = useState<ToDoModel[]>([]);
    const [text, setText] = useState('');

    const addToList = () => {
        if (text == "")
            return;
        setList([...list, {
            id: Date.now(),
            createdDate: new Date(),
            isCompleted: false,
            task: text
        }])

        setText('')
    }

    const deleteToDo = (id: number) => {
        setList(list.filter(x => x.id != id))
    }


    const doneToDo = (id: number) => {
        setList(list.map(function (x) {
            if (x.id == id)
                x.isCompleted = !x.isCompleted;

            return x;
        }))
    }
    const sortByCreatedDateAscending = () => {
        const sortedList = [...list].sort(
            (a, b) => a.createdDate.getTime() - b.createdDate.getTime()
        );
        setList(sortedList);
    };

    const sortByCreatedDateDescending = () => {
        const sortedList = [...list].sort(
            (a, b) => b.createdDate.getTime() - a.createdDate.getTime()
        );
        setList(sortedList);
    };
    return (
        <Container>
            <Container>

                <Header as='h1' textAlign={'center'}>TO DO LIST</Header>
                <Divider/>
                <div style={{display: 'flex', justifyContent: 'center', marginBottom: '10px'}}>
                    <button style={{background: 'white'}} onClick={sortByCreatedDateAscending}>
                        <Icon color={'orange'} size={'large'} name={'arrow down'}/>
                    </button>
                    <button style={{background: 'white'}} onClick={sortByCreatedDateDescending}>
                        <Icon color={'green'} size={'large'} name={'arrow up'}/>
                    </button>
                </div>
                <Card.Group>
                    {
                        list.map((item, index) =>
                            <Card onDoubleClick={() => doneToDo(item.id)} style={{padding: 25}} fluid
                                  color={index % 2 == 0 ? 'green' : 'orange'}>
                                <Grid>
                                    <GridRow>
                                        <GridColumn width={'15'}>
                                            <Header
                                                style={{textDecoration: item.isCompleted ? 'line-through' : undefined}}
                                                as='h3'>{item.task}</Header>
                                        </GridColumn>
                                        <GridColumn verticalAlign={'middle'} width={'1'}>
                                            <Icon onClick={() => deleteToDo(item.id)} color={'red'} size={'large'}
                                                  name={'trash'}/>
                                        </GridColumn>
                                    </GridRow>
                                </Grid>
                            </Card>
                        )
                    }
                </Card.Group>

                <Divider/>

                <Input
                    action={{
                        color: 'orange',
                        labelPosition: 'right',
                        icon: 'add',
                        content: 'Add',
                        onClick: addToList
                    }}
                    fluid
                    onChange={(text) => setText(text.target.value)}
                    value={text}
                />

                <Divider/>
            </Container>
        </Container>
    )
}

export default App